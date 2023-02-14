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
    public class BranchController : Controller
    {


        // GET: Branch
        public ActionResult Branch(int? Id)
        {
            try
            {
                clsBranch M = new clsBranch();
                DataTable dt = new DataTable();

                if (Id != null && Id > 0)
                    M = DataInterface2.GetBranch(Convert.ToInt32("0" + Id.ToString()));
                
                return View(M);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Branch(clsBranch M)
        {
            TempData.Clear();

            ClsReturnData clsRetData = new ClsReturnData();

            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Invalid Model";
                return View(M);
            }

            if (M.BranchId <= 0)
            {
                M.ReqType = "Insert";
                M.CreatedBy = ClsSession.EmpId;
            }
            else
            {
                M.ReqType = "Update";
            }

            clsRetData = DataInterface2.SaveBranch(M);


            if (clsRetData.ID > 0)
            {
                TempData["Success"] = !string.IsNullOrEmpty(clsRetData.Message) ? clsRetData.Message : "Saved/Updated";
                return RedirectToAction("BranchView", "Branch");
            }
            else
            {
                ViewBag.Error = !string.IsNullOrEmpty(clsRetData.Message) ? clsRetData.Message : "Error: Data Not Saved/Updated";
                return View(M);
            }
        }

        [HttpGet]
        public ActionResult BranchView()
        {
            try
            {
                if (TempData["Error"] != null)
                    ViewBag.Error = TempData["Error"];
                if (TempData["Success"] != null)
                    ViewBag.Success = TempData["Success"];
                TempData.Clear();

                DataTable dt = new DataTable();
                List<clsBranch> lst = new List<clsBranch>();
                lst = DataInterface2.ViewBranch();
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


        public ActionResult DeleteBranch(int Id)
        {
            try
            {

                if (Id <= 0)
                {
                    TempData["Error"] = "Branch not exists";
                    return RedirectToAction("BranchView");
                }

                TempData.Clear();

                using (ClsReturnData clsRetData = DataInterface2.DeleteBranch(Convert.ToInt32(Id)))
                {

                    if (clsRetData.ID > 0)
                    {
                        TempData["Success"] = !string.IsNullOrEmpty(clsRetData.Message) ? clsRetData.Message : "Deleted";
                    }
                    else
                    {
                        TempData["Error"] = !string.IsNullOrEmpty(clsRetData.Message) ? clsRetData.Message : "Error: Data Not Deleted";
                    }

                }


                return RedirectToAction("BranchView", "Branch");

            }
            catch (Exception ex)
            {
                throw ex;
                //return RedirectToAction("Index");
            }

        }



    }
}