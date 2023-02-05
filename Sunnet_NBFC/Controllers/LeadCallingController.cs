using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sunnet_NBFC.Models;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using Sunnet_NBFC.App_Code;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Sunnet_NBFC.Controllers
{
    public class LeadCallingController : Controller
    {
        //// GET: LeadCalling
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: LeadCalling
        public ActionResult LeadCalling(clsLeadMain M)
        {
            try
            {
                //clsLeadMain M = new clsLeadMain();
                DataTable dtLeadDetail = new DataTable();
                DataTable dtLeadCalling = new DataTable();
                if (M.LeadId > 0)
                {
                    M.ReqType = "Get";
                    M.StageId = 2;
                    dtLeadDetail = DataInterface2.GetLeadDetail(M);
                    dtLeadCalling = DataInterface2.GetLeadCalling(M);
                }
                if (dtLeadDetail != null && dtLeadDetail.Rows.Count > 0)
                    M = DataInterface.GetItem<clsLeadMain>(dtLeadDetail.Rows[0]);

                if (dtLeadCalling != null && dtLeadCalling.Rows.Count > 0)
                    M.clsLeadCalling = DataInterface.ConvertDataTable<clsLeadCalling>(dtLeadCalling);

                //M = DataInterface1.GetItem<clsLeadCalling>(dt.Rows[0]); //for single row

                ViewBag.AnswerListDDL= ClsCommon.AnswerDDL();
                ViewBag.StatusListDDL = ClsCommon.StatusDDL("PrimyTel");
                M.Status = M.Status ?? "P";
                return View(M);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult LeadCalling(clsLeadMain M, FormCollection frm)
        {
            ClsReturnData clsRtn = new ClsReturnData();
            clsRtn.MsgType = (int)MessageType.Fail;
            bool IsSave = false;

            try
            {
                TempData.Clear();
                DataTable dt = new DataTable();


                if (!ModelState.IsValid)
                {
                    ViewBag.Error = "Invalid Model";
                    return View(M);
                }

                var QnsAnsKeyValue = frm.AllKeys
                 .Where(k => k.StartsWith("A_"))
                 .ToDictionary(k => k, k => frm[k]);


                clsLeadCalling CallingModel = new clsLeadCalling();

                foreach (var item in QnsAnsKeyValue)
                {
                    string Key = item.Key;
                    string Value = item.Value;
                    string[] valueArray = Key.Split('_');
                    CallingModel = new clsLeadCalling();

                    CallingModel.TcId = Convert.ToInt32(valueArray[1]);
                    CallingModel.LeadId = M.LeadId;
                    CallingModel.QuestionId = Convert.ToInt32(valueArray[2]);
                    CallingModel.Answer = Value;


                     if (CallingModel.TcId <= 0)
                    {
                        CallingModel.ReqType = "Insert";
                    }
                    else
                    {
                        CallingModel.ReqType = "Update";
                    }

                    dt = DataInterface2.SaveLeadCalling(CallingModel);

                    //ClsCommon.GETClassFromDt(dt, ref clsRtn);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt64("0" + Convert.ToString(dt.Rows[0]["ReturnID"])) > 0)
                        {
                            IsSave = true;
                        }
                    }
                }


                if (IsSave)
                {
                    M.ReqType = "UpdateStatus";
                    dt=DataInterface2.UpdateLeadStatus(M);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        clsRtn.ID = Convert.ToInt64("0" + Convert.ToString(dt.Rows[0]["ReturnID"]));
                        clsRtn.Message = Convert.ToString(dt.Rows[0]["ReturnMessage"]);
                        clsRtn.MessageDesc = clsRtn.Message;
                        if (clsRtn.ID > 0)
                        {
                            clsRtn.MsgType = (int)MessageType.Success;
                        }
                        else
                        {
                            clsRtn.MsgType = (int)MessageType.Fail;
                        }
                    }
                }


            }
            catch (Exception e1)
            {
                using (clsError clse = new clsError())
                {
                    clse.ReqType = "InsertUpdate";
                    clse.Mode = "WEB";
                    clse.ErrorDescrption = e1.Message;
                    clse.FunctionName = "LeadCalling";
                    clse.Link = "Lead/LeadCalling";
                    clse.PageName = "Lead Calling Controller";
                    clse.UserId = ClsSession.UserID.ToString();
                    DataInterface.PostError(clse);
                }
            }
            if (IsSave)
            {

                TempData["Success"] = !string.IsNullOrEmpty(clsRtn.Message) ? clsRtn.Message : "Saved/Updated";
                return RedirectToAction("LeadView", "Lead");
            }
            else
            {
                DataTable dtLeadCalling = new DataTable();
                if (M.LeadId > 0)
                {
                    M.ReqType = "Get";
                    M.StageId = 2;
                    dtLeadCalling = DataInterface2.GetLeadCalling(M);
                }
                
                if (dtLeadCalling != null && dtLeadCalling.Rows.Count > 0)
                    M.clsLeadCalling = DataInterface.ConvertDataTable<clsLeadCalling>(dtLeadCalling);

                //M = DataInterface1.GetItem<clsLeadCalling>(dt.Rows[0]); //for single row

                ViewBag.AnswerListDDL = ClsCommon.AnswerDDL();
                ViewBag.StatusListDDL = ClsCommon.StatusDDL("PrimyTel");
                M.Status = M.Status ?? "P";

                ViewBag.Error = !string.IsNullOrEmpty(clsRtn.Message) ? clsRtn.Message : "Error: Data Not Saved/Updated";
                return View(M);
            }
        }

    }
}