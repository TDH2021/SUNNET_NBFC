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
        // GET: Lead
        [HttpGet]
        public ActionResult LeadPage()
        {
            DataInterface db = new DataInterface();
            ViewBag.Service = ToSelectList(db.GetService(), "ServiceID", "ServiceName");
            db = null;
            return View();
        }
        [HttpPost]
      
        [ValidateAntiForgeryToken]
        public ActionResult LeadPage(clsLead cls)
        {
            if (ModelState.IsValid)
            {
                DataInterface dB = new DataInterface();
                cls.OptType = 1;
                cls.LeadId = 0;
                if (DataInterface.PostLead(cls) > 0)
                {
                    ModelState.Clear();
                    ViewBag.Message = "Lead Save successfully";
                }
            }
            DataInterface db = new DataInterface();
            ViewBag.Service = ToSelectList(db.GetService(), "ServiceID", "ServiceName");
            db = null;
            return View();
        }
        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        [HttpGet]
        public ActionResult LeadView()
        {
            DataTable dt = new DataTable();
            List<clsLead> Lead = new List<clsLead>();
            dt = GetLead();
            Lead = DataInterface.ConvertDataTable<clsLead>(dt);
            ViewBag.LeadDetails = Lead;
           
            return View();
        }
        public DataTable GetLead()
        {
            clsLead cls = new clsLead();
            cls.OptType = 4;
            
            DataInterface db = new DataInterface();
            DataTable dt = new DataTable();
            dt = db.GetLead(cls);
            db = null;
            cls = null;
            return dt;
        }
        [HttpGet]
        public ActionResult LeadDisplay(int id)
        {
            clsLead cls = new clsLead();
            cls.OptType = 4;
            cls.LeadId = id;
            List<clsLead> Lead = new List<clsLead>();
            DataInterface db = new DataInterface();
            DataTable dt = new DataTable();
            dt = db.GetLead(cls);
            cls = null;
            clsLead clsleaddtl = new clsLead();

            if (dt.Rows.Count == 1)
            {
                clsleaddtl.LeadId = int.Parse(dt.Rows[0]["Leadid"].ToString());
                clsleaddtl.CustName = dt.Rows[0]["CustName"].ToString();
                clsleaddtl.CustAdress = dt.Rows[0]["CustAdress"].ToString();
                clsleaddtl.CustContNo = dt.Rows[0]["CustContNo"].ToString();
                clsleaddtl.CustMail = dt.Rows[0]["CustMail"].ToString();
                clsleaddtl.GenderName = dt.Rows[0]["Gender"].ToString();
                clsleaddtl.ServiceName = dt.Rows[0]["ServiceName"].ToString();
                clsleaddtl.Remarks = dt.Rows[0]["Remarks"].ToString();

            }
            return View(clsleaddtl);
            
        }

        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = this.GetLead();
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=LeadView.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            DataTable dt = new DataTable();
            List<clsLead> Lead = new List<clsLead>();
            dt = GetLead();
            Lead = DataInterface.ConvertDataTable<clsLead>(dt);
            ViewBag.LeadDetails = Lead;
            dt.Dispose();

            return View("LeadView");

        }
       
    }
}