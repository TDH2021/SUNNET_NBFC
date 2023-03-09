using Newtonsoft.Json;
using Sunnet_NBFC.App_Code;
using Sunnet_NBFC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sunnet_NBFC.Controllers
{
    public class LeadGenerationController : Controller
    {
        // GET: LeadGeneration
        public ActionResult LeadGeneration()
        {

            try
            {

                using (clsLeadGenerationMaster clsStatus = new clsLeadGenerationMaster())
                {
                    clsStatus.CompanyId = ClsSession.CompanyID ;
                }


                ViewBag.StateList = ClsCommon.ToSelectList(DataInterface1.GetState(), "ID", "StateName");


                using (clsLeadGenerationMaster clsStatus = new clsLeadGenerationMaster())
                {
                }


                ViewBag.MainProductList = ClsCommon.ToSelectList(DataInterface1.GetMainProductddl("View"), "MainProdId", "ProductName");
                ViewBag.MaterialStatusList = ClsCommon.ToSelectList(DataInterface1.GetMiseddl("Martial Status"), "MiscName", "MiscName");
                ViewBag.ProductId = "";

                List<clsLeadGenerationMaster> LeadGenerationdataModels = new List<clsLeadGenerationMaster>();


                ViewBag.LeadGenerationdataModels = LeadGenerationdataModels;
            }
            catch (Exception e1)
            {

            }
            return View();
        }

        public string JSONresult { get; private set; }


        [HttpPost]
        public JsonResult AddRequestLeadGeneration(clsLeadGenerationMaster cls)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            clsLeadGenerationMaster master = jss.Deserialize<clsLeadGenerationMaster>(Request.Form["AllDataArray"]);
            List<Gurantor> Gurantor_Details = jss.Deserialize<List<Gurantor>>(Request.Form["Gurantor_Details"]);
            

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    try
                    {
                        master.CompanyId = ClsSession.CompanyID;
                        master.BranchID = ClsSession.BranchId;
                        string message = "";
                        using (DataTable dt = DataInterface.GetLeadGeneration(master))
                        {

                            foreach (DataRow row in dt.Rows)
                            {

                                message = row["ReturnMessage"].ToString();
                                master.LeadId = int.Parse(row["ReturnID"].ToString());
                                master.LeadNo = row["LeadNo"].ToString();

                            }
                            if (message == "Lead saved succussfully")
                            {


                                DataTable dt1 = DataInterface.GetLeadGenerationCustomer(master);
                                HttpPostedFileBase file = null;
                                if (Request.Files[0] != null)
                                {
                                    file = Request.Files["ApplicantImg"];
                                    //Extract Image File Name.
                                    string fileName = System.IO.Path.GetFileName(file.FileName);

                                    fileName = master.LeadNo + "_Applicant_" + fileName;

                                    //Set the Image File Path.
                                    string filePath = Server.MapPath("~/Img/ApplicantImgs");

                                    //Save the Image File in Folder.
                                    file.SaveAs(filePath + "\\" + fileName);

                                }
                                if (master.Hdn_type.ToUpper() == "B" || master.Hdn_type.ToUpper() == "C")
                                {
                                    dt1 = DataInterface.GetLeadGenerationCO_ApplicantCustomer(master);
                                    if (Request.Files[1] != null)
                                    {
                                        file = Request.Files["COApplicantImg"];
                                        //Extract Image File Name.
                                        string fileName = System.IO.Path.GetFileName(file.FileName);

                                        fileName = master.LeadNo + "_CO_Applicant_" + fileName;

                                        //Set the Image File Path.
                                        string filePath = Server.MapPath("~/Img/COApplicantImgs");

                                        //Save the Image File in Folder.
                                        file.SaveAs(filePath + "\\" + fileName);

                                    }
                                }


                                for (int i = 0; i < Gurantor_Details.Count; i++)
                                {
                                    Gurantor_Details[i].G_CompanyId = ClsSession.CompanyID;
                                    Gurantor_Details[i].G_BranchID = ClsSession.BranchId;
                                    Gurantor_Details[i].G_LeadId = master.LeadId;
                                    if (master.Hdn_type.ToString().ToUpper() == "B" || master.Hdn_type.ToUpper() == "G")
                                    {
                                        dt1 = DataInterface.GetLeadGenerationGurantorCustomer(Gurantor_Details[i]);
                                    }

                                }
                            }

                            JSONresult = JsonConvert.SerializeObject(dt);
                        }
                        scope.Complete();
                        return Json(JSONresult, JsonRequestBehavior.AllowGet);

                    }
                    catch (Exception e1)
                    {
                        scope.Dispose();
                        using (clsError clsE = new clsError())
                        {
                            clsE.ReqType = "Insert";
                            clsE.Mode = "WEB";
                            clsE.ErrorDescrption = e1.Message;
                            clsE.FunctionName = "AddRequestLead";
                            clsE.Link = "Status/AddRequestLead";
                            clsE.PageName = "Status Controller";
                            clsE.UserId = ClsSession.EmpId.ToString();
                            DataInterface.PostError(clsE);
                        }

                        return Json(JSONresult, JsonRequestBehavior.AllowGet);
                    }
                } 
            }
            catch (Exception e1)
            {
                DataTable dt = new DataTable();
                using (clsError clsE = new clsError())
                {
                    clsE.ReqType = "Insert";
                    clsE.Mode = "WEB";
                    clsE.ErrorDescrption = e1.Message;
                    clsE.FunctionName = "AddRequestStatus";
                    clsE.Link = "Status/AddStatus";
                    clsE.PageName = "Status Controller";
                    clsE.UserId = ClsSession.EmpId.ToString();
                    DataInterface.PostError(clsE);
                }

               
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}