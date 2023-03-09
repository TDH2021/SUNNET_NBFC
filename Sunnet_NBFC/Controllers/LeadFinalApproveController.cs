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
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Sunnet_NBFC.Controllers
{
    public class LeadFinalApproveController : Controller
    {

        public ActionResult GetLeadFinalApprove(clsLeadFinalApproveMain M)
        {
            try
            {
                DataTable dtLeadDetail = new DataTable();
                DataTable dtLeadDoc = new DataTable();
                if (M.LeadId > 0)
                {
                    M.ReqType = "Get";
                    M.StageId = 3;
                    dtLeadDetail = DataInterface2.GetLeadDetail(M);
                    dtLeadDoc = DataInterface1.dbLeadFinalApprove(M);
                }
                if (dtLeadDetail != null && dtLeadDetail.Rows.Count > 0)
                    M = DataInterface.GetItem<clsLeadFinalApproveMain>(dtLeadDetail.Rows[0]);

                if (dtLeadDoc != null && dtLeadDoc.Rows.Count > 0)
                    M.clsLeadFinalApprove = DataInterface.ConvertDataTable<clsLeadFinalApprove>(dtLeadDoc);

                M.Status = M.Status ?? "P";
                return View(M);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult LeadFinalApproveSave(clsLeadFinalApproveMain M)
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


                if (M.FinalApproveId <= 0)
                {
                    M.ReqType = "Insert";
                }
                else
                {
                    M.ReqType = "Update";
                }

                dt = DataInterface1.dbLeadFinalApprove(M);

                //ClsCommon.GETClassFromDt(dt, ref clsRtn);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (Convert.ToInt64("0" + Convert.ToString(dt.Rows[0]["ReturnID"])) > 0)
                    {
                        IsSave = true;
                    }
                }


                if (IsSave)
                {
                    M.ReqType = "UpdateStatus";
                    dt = DataInterface1.UpdateLeadStatusFa(M);
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
                    clse.FunctionName = "LeadFinalApproveSave";
                    clse.Link = "Lead/LeadFinalApprove";
                    clse.PageName = "Lead Final Approve Controller";
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
                DataTable dtLeadDetail2 = new DataTable();
                DataTable dtLeadDoc2 = new DataTable();
                if (M.LeadId > 0)
                {
                    M.ReqType = "Get";
                    M.StageId = 3;
                    dtLeadDetail2 = DataInterface2.GetLeadDetail(M);
                    dtLeadDoc2 = DataInterface1.dbLeadFinalApprove(M);
                }
                if (dtLeadDetail2 != null && dtLeadDetail2.Rows.Count > 0)
                    M = DataInterface.GetItem<clsLeadFinalApproveMain>(dtLeadDetail2.Rows[0]);

                if (dtLeadDoc2 != null && dtLeadDoc2.Rows.Count > 0)
                    M.clsLeadFinalApprove = DataInterface.ConvertDataTable<clsLeadFinalApprove>(dtLeadDoc2);

                M.Status = M.Status ?? "P";

                ViewBag.Error = !string.IsNullOrEmpty(clsRtn.Message) ? clsRtn.Message : "Error: Data Not Saved/Updated";
                return View(M);
            }
        }

        [HttpPost]
        public ActionResult LeadDocumentCollectionMulti(clsLeadmaind M, FormCollection frm)
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

                clsLeadDocument DocumentModel = new clsLeadDocument();
                int Total = Convert.ToInt32(frm["hdnCount"]);
                string DocID = "";
                string DcId = "";
                string CustomerType = "";
                string LeadCustId = "";
                string IsReceived = "";
                string Remarks = "";

                for (int i = 1; i <= Total; i++)
                {
                    DocID = "";
                    DcId = "";
                    CustomerType = "";
                    LeadCustId = "";
                    IsReceived = "";
                    Remarks = "";
                    DocID = frm[i + "_DocID"];
                    DcId = frm[i + "_DcId"];
                    CustomerType = frm[i + "_CustomerType"];
                    LeadCustId = frm[i + "_LeadCustId"];
                    IsReceived = frm[i + "_IsReceived"];
                    Remarks = frm[i + "_Remarks"];

                    string[] arr = IsReceived.Split(',');

                    DocumentModel = new clsLeadDocument();

                    DocumentModel.DcId = Convert.ToInt32(DcId);
                    DocumentModel.LeadId = M.LeadId;
                    DocumentModel.DocID = Convert.ToInt32(DocID);
                    DocumentModel.CustomerType = CustomerType;
                    DocumentModel.IsReceived = Convert.ToBoolean(arr[0]);
                    DocumentModel.Remarks = Remarks;
                    DocumentModel.LeadCustId = Convert.ToInt32(LeadCustId);

                    if (DocumentModel.DcId <= 0)
                    {
                        DocumentModel.ReqType = "Insert";
                    }
                    else
                    {
                        DocumentModel.ReqType = "Update";
                    }

                    dt = DataInterface1.dbLeadDocument(DocumentModel);

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
                    dt = DataInterface1.UpdateLeadStatus(M);
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
                DataTable dtLeadDoc2 = new DataTable();
                if (M.LeadId > 0)
                {
                    M.ReqType = "Get";
                    M.StageId = 2;
                    dtLeadDoc2 = DataInterface1.dbLeadDocument(M);
                }

                if (dtLeadDoc2 != null && dtLeadDoc2.Rows.Count > 0)
                    M.clsLeadDocument = DataInterface.ConvertDataTable<clsLeadDocument>(dtLeadDoc2);

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