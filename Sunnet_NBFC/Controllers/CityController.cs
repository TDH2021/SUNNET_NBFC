using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Sunnet_NBFC.Models;
using Sunnet_NBFC.App_Code;
using Newtonsoft.Json;

namespace Sunnet_NBFC.Controllers
{
    public class CityController : Controller
    {


        //[HttpGet]

        public ActionResult AddCity()
        {

            ViewBag.Service = ClsCommon.ToSelectList(DataInterface1.GetState(), "ID", "StateName");
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult PostCity(clsCity cls)
        {
            if (ModelState.IsValid)
            {
                DataInterface dB = new DataInterface();
                cls.ReqType = "Insert";
                using (DataTable dt = DataInterface1.GetCity(cls))
                {

                    ViewBag.Message = dt.Rows[0]["ReturnMessage"].ToString();
                }

            }
            cls = null;
            ViewBag.Service = ClsCommon.ToSelectList(DataInterface1.GetState(), "ID", "StateName");

            return View("AddCity");
        }

        [ValidateAntiForgeryToken]
        public ActionResult UpdateCity(clsCity cls)
        {
            if (ModelState.IsValid)
            {
                DataInterface dB = new DataInterface();
                cls.ReqType = "Update";
                using (DataTable dt = DataInterface1.GetCity(cls))
                {

                    ViewBag.Message = dt.Rows[0]["ReturnMessage"].ToString();
                    if (dt.Rows[0]["ReturnMessage"].ToString().ToLower() == "record updated successfully")
                    {
                        ModelState.Clear();
                        return RedirectToAction("CityView", "City");
                    }

                }

            }
            cls = null;
            ////clsCity cls = new clsCity();
            //cls.ReqType = "View";
            //DataTable dtdtl = new DataTable();
            //List<clsCity> Lead = new List<clsCity>();
            //dtdtl = DataInterface1.GetCity(cls);
            //Lead = DataInterface.ConvertDataTable<clsCity>(dtdtl);
            //ViewBag.CityDetails = Lead;
            //return View("CityView");
            ViewBag.Service = ClsCommon.ToSelectList(DataInterface1.GetState(), "ID", "StateName");
            return View("EditCity");
        }
        public ActionResult CityView()
        {

            try
            {
                clsCity cls = new clsCity();
                cls.ReqType = "view";
                DataTable dt = new DataTable();
                List<clsCity> Lead = new List<clsCity>();
                dt = DataInterface1.GetCity(cls);
                Lead = DataInterface.ConvertDataTable<clsCity>(dt);
                ViewBag.CityDetails = Lead;


            }
            catch (Exception e1)
            {
                using (clsError cls = new clsError())
                {
                    cls.ReqType = "Insert";
                    cls.Mode = "WEB";
                    cls.ErrorDescrption = e1.Message;
                    cls.FunctionName = "City View";
                    cls.Link = "City/CityView";
                    cls.PageName = "City Controller";
                    cls.UserId = "1";
                    DataInterface.PostError(cls);
                }
            }
            return View();
        }

        public ActionResult EditCity(int cityid)
        {
            DataTable dt = new DataTable();
            clsCity clsdt = new clsCity();
            try
            {

                using (clsCity cls = new clsCity())
                {
                    cls.ReqType = "view";
                    cls.Cityid = cityid;

                    dt = DataInterface1.GetCity(cls);
                }


                if (dt.Rows.Count == 1)
                {
                    clsdt.Cityid = int.Parse(dt.Rows[0]["CityId"].ToString());
                    clsdt.Stateid = int.Parse(dt.Rows[0]["Stateid"].ToString());
                    clsdt.CityName = dt.Rows[0]["CityName"].ToString();


                }
                ViewBag.Service = ClsCommon.ToSelectList(DataInterface1.GetState(), "ID", "StateName");
                return View(clsdt);
            }
            catch (Exception e1)
            {
                return null;
            }

        }

        public JsonResult GetCity(string StateId)
        {
            JsonResult result = new JsonResult();

            try
            {

                using (clsCity cls = new clsCity())
                {
                    cls.ReqType = "View";
                    cls.Stateid = int.Parse(StateId);
                    using (DataTable dt = DataInterface1.GetCity(cls))
                    {
                        result = this.Json(JsonConvert.SerializeObject(dt), JsonRequestBehavior.AllowGet);

                    }


                }

            }
            catch (Exception e1)
            {
                using (clsError cls = new clsError())
                {
                    cls.ReqType = "Insert";
                    cls.Mode = "WEB";
                    cls.ErrorDescrption = e1.Message + "-" + e1.InnerException.Message;
                    cls.FunctionName = "City View";
                    cls.Link = "Company/CompanyView";
                    cls.PageName = "Company Controller";
                    cls.UserId = "1";
                    DataInterface.PostError(cls);
                }
            }

            return result;

        }
    }
}