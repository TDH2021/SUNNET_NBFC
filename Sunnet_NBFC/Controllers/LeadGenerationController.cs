using Newtonsoft.Json;
using Sunnet_NBFC.App_Code;
using Sunnet_NBFC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                    clsStatus.CompanyId = 1;
                }


                ViewBag.StateList = ClsCommon.ToSelectList(DataInterface1.GetState(), "ID", "StateName");


                using (clsLeadGenerationMaster clsStatus = new clsLeadGenerationMaster())
                {
                }


                ViewBag.MainProductList = ClsCommon.ToSelectList(DataInterface1.GetMainProductddl("View"), "MainProdId", "ProductName");
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
                master.CompanyId = 1;
                master.BranchID = 1;
                string message = "";
                using (DataTable dt = DataInterface.GetLeadGeneration(master))
                {
                   
                        foreach (DataRow row in dt.Rows)
                        {
                                
                                message = row["ReturnMessage"].ToString();
                                master.LeadNo = row["ReturnID"].ToString();


                    }
                    if (message == "Lead saved succussfully") {

                        
                        DataTable dt1 = DataInterface.GetLeadGenerationCustomer(master);
                        dt1 = DataInterface.GetLeadGenerationCO_ApplicantCustomer(master);

                        for (int i = 0; i < Gurantor_Details.Count; i++) {
                            Gurantor_Details[i].G_CompanyId = 1;
                            Gurantor_Details[i].G_BranchID = 1;
                            Gurantor_Details[i].G_LeadNo = master.LeadNo;
                            dt1 = DataInterface.GetLeadGenerationGurantorCustomer(Gurantor_Details[i]);
                        }
                    }

                    JSONresult = JsonConvert.SerializeObject(dt);
                }
                return Json(JSONresult, JsonRequestBehavior.AllowGet);

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
                    clsE.UserId = "1";
                    DataInterface.PostError(clsE);
                }

                return Json(JSONresult, JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}