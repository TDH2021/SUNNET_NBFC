﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sunnet_NBFC.Models;
using Sunnet_NBFC.App_Code;
using System.Web.Script.Serialization;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Sunnet_NBFC.Controllers
{
    public class LoginController : Controller
    {
        public string JSONresult { get; private set; }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ChecKLogin()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            clsLogin cls = jss.Deserialize<clsLogin>(Request.Form["AllDataArray"]);

            try
            {

                using (DataTable dt = DataInterface.DBLogin(cls))
                {
                    JSONresult = JsonConvert.SerializeObject(dt);
                }
                return Json(JSONresult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e1)
            {

                using (clsError clsE = new clsError())
                {
                    clsE.ReqType = "CheckLogin";
                    clsE.Mode = "WEB";
                    clsE.ErrorDescrption = e1.Message;
                    clsE.FunctionName = "CheckLogin";
                    clsE.Link = "Login/CheckLogin";
                    clsE.PageName = "Login Controller";
                    clsE.UserId = "0";
                    DataInterface.PostError(clsE);
                }
                return Json(JSONresult, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult UpdateLogin()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            using (clsLogin cls = jss.Deserialize<clsLogin>(Request.Form["LoginDetails"]))
            {
                cls.SessionID = Session.SessionID;
                cls.IsLogged = true;
                string hostName = Dns.GetHostName();
                cls.DeviceID = "";// Dns.GetHostEntry(hostName).AddressList[3].ToString();
                cls.DeviceType = "Web";
                try
                {

                    using (DataTable dt = DataInterface.DBLogin(cls))
                    {
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["Message"].ToString().ToUpper() == "RECORD UPDATE")
                                {
                                    Session["UserID"] = cls.UserID;
                                    Session["UserType"] = cls.Type;
                                   Session["SessionId"] = cls.SessionID;
                                    if (cls.Type == "E")
                                    {
                                        clsEmployee cls1 = new clsEmployee();
                                        cls1.EmpID = cls.RefID;
                                        cls1.ReqType = "View";
                                        using (DataTable dt1 = DataInterface1.dbEmployee(cls1))
                                        {
                                            if (dt1 != null)
                                            {
                                                if (dt1.Rows.Count > 0)
                                                {
                                                    Session["EmpId"] = dt1.Rows[0]["EmpId"].ToString();
                                                    Session["EmpCode"] = dt1.Rows[0]["EmpCode"].ToString();
                                                    Session["EmpName"] = dt1.Rows[0]["EmpName"].ToString();
                                                    Session["CompanyId"] = dt1.Rows[0]["CompId"].ToString();
                                                    Session["BranchId"] = dt1.Rows[0]["Branchid"].ToString();
                                                }
                                            }


                                        }

                                    }
                                }
                            }
                          
                        }
                    }

                    var data = new
                    {
                        Msg = "Success"
                    };
                    JSONresult = JsonConvert.SerializeObject(data);
                    var jsonresult = Json(JSONresult, JsonRequestBehavior.AllowGet);
                    return Json(jsonresult);
                }
                catch (Exception e1)
                {

                    using (clsError clsE = new clsError())
                    {
                        clsE.ReqType = "CheckLogin";
                        clsE.Mode = "WEB";
                        clsE.ErrorDescrption = e1.Message;
                        clsE.FunctionName = "CheckLogin";
                        clsE.Link = "Login/CheckLogin";
                        clsE.PageName = "Login Controller";
                        clsE.UserId = "0";
                        DataInterface.PostError(clsE);
                    }

                    var data = new
                    {
                        Msg = "Error"
                    };
                    JSONresult = JsonConvert.SerializeObject(data);
                    var jsonresult = Json(JSONresult, JsonRequestBehavior.AllowGet);
                    return Json(jsonresult);
                }
                

            }


        }

    }
}
