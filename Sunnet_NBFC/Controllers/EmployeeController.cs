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

namespace Sunnet_NBFC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Employee(int? Id)
        {
            try
            {
                clsEmployee M = new clsEmployee();
                DataTable dt = new DataTable();

                if (Id != null && Id > 0)
                    M = DataInterface2.GetEmployee(Convert.ToInt32("0" + Id.ToString()));
                return View(M);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Employee(clsEmployee M)
        {
            TempData.Clear();

            ClsReturnData clsRetData = new ClsReturnData();

            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Invalid Model";
                return View(M);
            }

            if (M.EmpID <= 0)
            {
                M.ReqType = "Insert";
            }
            else
            {
                M.ReqType = "Update";
            }
            clsRetData = DataInterface2.SaveEmployee(M);


            if (clsRetData.ID > 0)
            {
                TempData["Success"] = !string.IsNullOrEmpty(clsRetData.Message) ? clsRetData.Message : "Saved/Updated";
                return RedirectToAction("EmployeeView", "Employee");
            }
            else
            {
                ViewBag.Error = !string.IsNullOrEmpty(clsRetData.Message) ? clsRetData.Message : "Error: Data Not Saved/Updated";
                return View(M);
            }
        }

        [HttpGet]
        public ActionResult EmployeeView()
        {
            try
            {

                if (TempData["Error"] != null)
                    ViewBag.Error = TempData["Error"];
                if (TempData["Success"] != null)
                    ViewBag.Success = TempData["Success"];
                TempData.Clear();

                DataTable dt = new DataTable();
                List<clsEmployee> lst = new List<clsEmployee>();
                lst = DataInterface2.ViewEmployee();
                //ViewBag.LeadDetails = lst;
                return View(lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }


        public ActionResult DeleteEmployee(int Id)
        {
            try
            {

                if (Id <= 0)
                {
                    TempData["Error"] = "Employee not exists";
                    return RedirectToAction("EmployeeView");
                }

                TempData.Clear();

                ClsReturnData clsRetData = new ClsReturnData();

                clsRetData = DataInterface2.DeleteEmployee(Convert.ToInt32(Id));

                if (clsRetData.ID > 0)
                {
                    TempData["Success"] = !string.IsNullOrEmpty(clsRetData.Message) ? clsRetData.Message : "Deleted";
                }
                else
                {
                    TempData["Error"] = !string.IsNullOrEmpty(clsRetData.Message) ? clsRetData.Message : "Error: Data Not Deleted";
                }

                return RedirectToAction("EmployeeView", "Employee");

            }
            catch (Exception ex)
            {
                throw ex;
                //return RedirectToAction("Index");
            }

        }



    }
}