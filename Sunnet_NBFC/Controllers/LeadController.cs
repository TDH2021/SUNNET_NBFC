using Sunnet_NBFC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sunnet_NBFC.Controllers
{
    public class LeadController : Controller
    {

        public ActionResult LeadView()
        {


            if (Session["UserID"] != null)
            {
                if (String.IsNullOrEmpty(Session["UserID"].ToString()) == true)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {


                    List<clsLeadGenerationMaster> lst = new List<clsLeadGenerationMaster>();
                    try
                    {
                        using (clsLeadGenerationMaster cls = new clsLeadGenerationMaster())
                        {
                            cls.ReqType = "GetLeadAllData";
                            cls.CompanyId = 1;
                            cls.LeadNo = "";
                            cls.LeadId = 0;
                            cls.Empid = int.Parse(Session["EmpId"].ToString());
                            using (DataTable dt = DataInterface.GetLeadGenerationData(cls))
                            {
                                if (dt != null)
                                {
                                    ViewBag.lst = DataInterface.ConvertDataTable<clsLeadGenerationMaster>(dt);


                                }
                            }
                        }

                    }
                    catch (Exception e1)
                    {
                        using (clsError clsE = new clsError())
                        {
                            clsE.ReqType = "Insert";
                            clsE.Mode = "WEB";
                            clsE.ErrorDescrption = e1.Message;
                            clsE.FunctionName = "Status View";
                            clsE.Link = "Status/ViewStatus";
                            clsE.PageName = "Status Controller";
                            clsE.UserId = "1";
                            DataInterface.PostError(clsE);
                        }
                    }

                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }


        public ActionResult LeadDetails(string LeadNo, string LeadId)
        {
            clsLeadGenerationMaster model = new clsLeadGenerationMaster();

            try
            {
                using (clsLeadGenerationMaster cls = new clsLeadGenerationMaster())
                {
                    cls.ReqType = "ViewLead";
                    cls.CompanyId = 1;
                    cls.LeadNo = LeadNo;
                    cls.LeadId = Convert.ToInt32(LeadId);
                    using (DataSet ds = DataInterface.GetLeadGenerationDataSingle(cls))
                    {
                        if (ds != null)
                        {
                            DataTable dt = ds.Tables[0];
                            if (dt != null)
                            {

                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {


                                    model.LeadNo = Convert.ToString(ds.Tables[0].Rows[i]["LeadNo"]);
                                    model.ReuestedLoanAmount = Convert.ToString(ds.Tables[0].Rows[i]["ReqLoanAmt"]);
                                    model.ReuestedLoanTenure = Convert.ToString(ds.Tables[0].Rows[i]["ReqLoanTenure"]);
                                    model.MainProductId = Convert.ToString(ds.Tables[0].Rows[i]["MainProdId"]);
                                    model.ProductId = Convert.ToString(ds.Tables[0].Rows[i]["ProdId"]);
                                }

                               




                            }



                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {

                                if (Convert.ToString(ds.Tables[1].Rows[i]["CustType"]) == "C")
                                {
                                    model.FirstName = Convert.ToString(ds.Tables[1].Rows[i]["FirstName"]);
                                    model.MiddleName = Convert.ToString(ds.Tables[1].Rows[i]["MiddleName"]);
                                    model.LastName = Convert.ToString(ds.Tables[1].Rows[i]["LastName"]);
                                    model.FatherName = Convert.ToString(ds.Tables[1].Rows[i]["FatherName"]);
                                    model.MotherName = Convert.ToString(ds.Tables[1].Rows[i]["MotherName"]);
                                    model.SpouseName = Convert.ToString(ds.Tables[1].Rows[i]["SpouseName"]);
                                    model.Gender = Convert.ToString(ds.Tables[1].Rows[i]["Gender"]);
                                    model.DateofBirth = Convert.ToString(ds.Tables[1].Rows[i]["DateofBirth"]);
                                    model.MartialStatus = Convert.ToString(ds.Tables[1].Rows[i]["MartialStatus"]);
                                    model.PresentAddress = Convert.ToString(ds.Tables[1].Rows[i]["PresentAddress"]);
                                    model.PresentPincode = Convert.ToString(ds.Tables[1].Rows[i]["PresentPincode"]);
                                    model.PresentStateId = Convert.ToString(ds.Tables[1].Rows[i]["PresentStateId"]);
                                    model.PresentCityId = Convert.ToString(ds.Tables[1].Rows[i]["PresentCityId"]);
                                    model.PermanentAddress = Convert.ToString(ds.Tables[1].Rows[i]["PermanentAddress"]);
                                    model.PermanentPincode = Convert.ToString(ds.Tables[1].Rows[i]["PermanentPincode"]);
                                    model.PermanentStateId = Convert.ToString(ds.Tables[1].Rows[i]["PermanentStateId"]);
                                    model.PermanentCityId = Convert.ToString(ds.Tables[1].Rows[i]["PermanentCityId"]);
                                    model.CibilScore = Convert.ToString(ds.Tables[1].Rows[i]["CibilScore"]);
                                    model.MobileNo1 = Convert.ToString(ds.Tables[1].Rows[i]["MobileNo1"]);
                                    model.FatherMobileNo = Convert.ToString(ds.Tables[1].Rows[i]["FatherMobileNo"]);
                                    model.MotherMobileNo = Convert.ToString(ds.Tables[1].Rows[i]["MotherMobileNo"]);
                                    model.SpouseMobileNo = Convert.ToString(ds.Tables[1].Rows[i]["SpouseMobileNo"]);
                                    model.AadharNo = Convert.ToString(ds.Tables[1].Rows[i]["AadharNo"]);
                                    model.PanNo = Convert.ToString(ds.Tables[1].Rows[i]["PanNo"]);
                                }
                                else if (Convert.ToString(ds.Tables[1].Rows[i]["CustType"]) == "G")
                                {
                                   

                                }
                                else if (Convert.ToString(ds.Tables[1].Rows[i]["CustType"]) == "CO_Applicant")
                                {
                                    model.CO_FirstName = Convert.ToString(ds.Tables[1].Rows[i]["FirstName"]);
                                    model.CO_MiddleName = Convert.ToString(ds.Tables[1].Rows[i]["MiddleName"]);
                                    model.CO_LastName = Convert.ToString(ds.Tables[1].Rows[i]["LastName"]);
                                    model.CO_Gender = Convert.ToString(ds.Tables[1].Rows[i]["Gender"]);
                                    model.CO_DOB = Convert.ToString(ds.Tables[1].Rows[i]["DateofBirth"]);
                                    model.CO_Marital_Status = Convert.ToString(ds.Tables[1].Rows[i]["MartialStatus"]);
                                    model.CO_PresentAddress = Convert.ToString(ds.Tables[1].Rows[i]["PresentAddress"]);
                                    model.CO_PresentPinCode = Convert.ToString(ds.Tables[1].Rows[i]["PresentPincode"]);
                                    model.CO_PresentStateId = Convert.ToString(ds.Tables[1].Rows[i]["PresentStateId"]);
                                    model.CO_PresentCityId = Convert.ToString(ds.Tables[1].Rows[i]["PresentCityId"]);
                                    model.CO_PermanentAddress = Convert.ToString(ds.Tables[1].Rows[i]["PermanentAddress"]);
                                    model.CO_PermanentPincode = Convert.ToString(ds.Tables[1].Rows[i]["PermanentPincode"]);
                                    model.CO_PermanentStateId = Convert.ToString(ds.Tables[1].Rows[i]["PermanentStateId"]);
                                    model.CO_PermanentCityId = Convert.ToString(ds.Tables[1].Rows[i]["PermanentCityId"]);
                                    model.CO_Mobile_No = Convert.ToString(ds.Tables[1].Rows[i]["MobileNo1"]);
                                    model.CO_Adhaar = Convert.ToString(ds.Tables[1].Rows[i]["AadharNo"]);
                                    model.CO_PAN = Convert.ToString(ds.Tables[1].Rows[i]["PanNo"]);
                                    model.CO_CIBIL = Convert.ToString(ds.Tables[1].Rows[i]["CibilScore"]);

                                }



                            }

                        }
                    }
                }

            }
            catch (Exception e1)
            {
                using (clsError clsE = new clsError())
                {
                    clsE.ReqType = "Insert";
                    clsE.Mode = "WEB";
                    clsE.ErrorDescrption = e1.Message;
                    clsE.FunctionName = "Status View";
                    clsE.Link = "Status/ViewStatus";
                    clsE.PageName = "Status Controller";
                    clsE.UserId = "1";
                    DataInterface.PostError(clsE);
                }
            }










            return PartialView("_LeadDetailsView", model);
        }
    }
}