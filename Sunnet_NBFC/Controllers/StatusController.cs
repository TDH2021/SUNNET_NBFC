﻿using Newtonsoft.Json;
using Sunnet_NBFC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sunnet_NBFC.Controllers
{
    public class StatusController : Controller
    {


        public ActionResult AddStatus()
        {
            using (clsStatusMaster clsStatus = new clsStatusMaster())
            {
                clsStatus.CompanyID = 1;
            }
            return View();
        }

        public string JSONresult { get; private set; }


        [HttpPost]
        public JsonResult AddRequestStatus(clsStatusMaster cls)
        {


            JavaScriptSerializer jss = new JavaScriptSerializer();
            clsStatusMaster master = jss.Deserialize<clsStatusMaster>(Request.Form["AllDataArray"]);


            try
            {
                using (DataTable dt = DataInterface.GetStatus(master))
                {
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
        }

        public ActionResult StatusView()
        {

            List<clsStatusMaster> lst = new List<clsStatusMaster>();
            try
            {
               using(clsStatusMaster cls=new clsStatusMaster())
                {
                    cls.ReqType = "View";
                    using (DataTable dt = DataInterface.GetStatus(cls))
                    {
                        if (dt != null)
                        {
                            ViewBag.lst = DataInterface.ConvertDataTable<clsStatusMaster>(dt);


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
            return View();
        }



        [HttpGet]
        public ActionResult Statusdelete(string Id)
        {

            try
            {
                using (clsStatusMaster cls = new clsStatusMaster())
                {
                    cls.StatusID = int.Parse(Id);
                    cls.ReqType = "Delete";
                    using (DataTable dt = DataInterface.GetStatus(cls))
                    {
                        JSONresult = JsonConvert.SerializeObject(dt);
                    }
                }
                return RedirectToAction("StatusView");

            }
            catch (Exception e1)
            {
                using (clsError clsE = new clsError())
                {
                    clsE.ReqType = "Insert";
                    clsE.Mode = "WEB";
                    clsE.ErrorDescrption = e1.Message;
                    clsE.FunctionName = "Delete Status";
                    clsE.Link = "Status/DeleteStatus";
                    clsE.PageName = "Status Controller";
                    clsE.UserId = "1";
                    DataInterface.PostError(clsE);
                }
                return Json(JSONresult, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult EditStatus(string Id, string Status, string Desc)
        {

            try
            {
                using (clsStatusMaster sm = new clsStatusMaster())
                {
                    sm.StatusID = int.Parse(Id);
                    sm.Status = Status;
                    sm.StatusDesc = Desc;
                    return View(sm);
                }
            }
            catch (Exception e1)
            {
                using (clsError clsE = new clsError())
                {
                    clsE.ReqType = "I";
                    clsE.Mode = "WEB";
                    clsE.ErrorDescrption = e1.Message;
                    clsE.FunctionName = "ViewRequestStatus";
                    clsE.Link = "Status/EditStatus";
                    clsE.PageName = "Status Controller";
                    clsE.UserId = "1";
                    DataInterface.PostError(clsE);
                }
            }

            return RedirectToAction("StatusView");

        }

        [HttpPost]
        public JsonResult UpdateRequestStatus(clsStatusMaster cls)
        {
            ///model

            JavaScriptSerializer jss = new JavaScriptSerializer();
            clsStatusMaster master = jss.Deserialize<clsStatusMaster>(Request.Form["AllDataArray"]);


            try
            {
                cls.ReqType = "Update";
                using (DataTable dt = DataInterface.GetStatus(cls))
                {

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
                    clsE.FunctionName = "UpdateRequestStatus";
                    clsE.Link = "Status/UpdateStatus";
                    clsE.PageName = "Status Controller";
                    clsE.UserId = "1";
                    DataInterface.PostError(clsE);
                }
                return Json(JSONresult, JsonRequestBehavior.AllowGet);
            }

        }


    }
}