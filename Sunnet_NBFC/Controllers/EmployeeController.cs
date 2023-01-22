﻿using System;
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
                {
                    clsEmployee cls = new clsEmployee();
                    cls.ReqType = "View";
                    cls.EmpID = Convert.ToInt32("0" + Id.ToString());
                    dt = DataInterface1.dbEmployee(cls);
                }
                if (dt != null && dt.Rows.Count > 0)
                    M = DataInterface1.GetItem<clsEmployee>(dt.Rows[0]);
                return View(M);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Employee(clsEmployee M, HttpPostedFileBase postedFile)
        {
            ClsReturnData clsRtn = new ClsReturnData();
            clsRtn.MsgType = (int)MessageType.Fail;
            string up = "";
            try
            {
                TempData.Clear();
                DataTable dt = new DataTable();


                if (!ModelState.IsValid)
                {
                    ViewBag.Error = "Invalid Model";
                    return View(M);
                }

                if (postedFile != null && postedFile.ToString() != "")
                {
                    up = UploadEmpPhoto(postedFile);
                }


                if (M.EmpID <= 0)
                {
                    M.ReqType = "Insert";
                }
                else
                {
                    M.ReqType = "Update";
                }

                if (up != "")
                {
                    M.ImageName = up;
                }

                //clsRetData = DataInterface2.SaveEmployee(M);
                dt = DataInterface1.dbEmployee(M);

                if (dt != null && dt.Rows.Count > 0)
                {
                    clsRtn.ID = Convert.ToInt64("0" + Convert.ToString(dt.Rows[0]["ReturnID"]));
                    clsRtn.Message = Convert.ToString(dt.Rows[0]["ReturnMessage"]);
                    clsRtn.MessageDesc = clsRtn.Message;
                    if (clsRtn.ID > 0)
                        clsRtn.MsgType = (int)MessageType.Success;
                    else
                        clsRtn.MsgType = (int)MessageType.Fail;
                }
            }
            catch (Exception e1)
            {
                using (clsError clse = new clsError())
                {
                    clse.ReqType = "Insert";
                    clse.Mode = "WEB";
                    clse.ErrorDescrption = e1.Message;
                    clse.FunctionName = "Employee";
                    clse.Link = "Employee/Employee";
                    clse.PageName = "Employee Controller";
                    clse.UserId = "1";
                    DataInterface.PostError(clse);
                }
            }
            if (clsRtn.ID > 0)
            {

                TempData["Success"] = !string.IsNullOrEmpty(clsRtn.Message) ? clsRtn.Message : "Saved/Updated";
                return RedirectToAction("EmployeeView", "Employee");
            }
            else
            {
                ViewBag.Error = !string.IsNullOrEmpty(clsRtn.Message) ? clsRtn.Message : "Error: Data Not Saved/Updated";
                return View(M);
            }
        }

        [HttpGet]
        public ActionResult EmployeeView()
        {
            List<clsEmployee> lst = new List<clsEmployee>();
            try
            {

                //if (TempData["Error"] != null)
                //    ViewBag.Error = TempData["Error"];
                //if (TempData["Success"] != null)
                //    ViewBag.Success = TempData["Success"];
                TempData.Clear();

                DataTable dt = new DataTable();

                //lst = DataInterface2.GetEmployeeNew();

                clsEmployee cls = new clsEmployee();
                cls.ReqType = "view";
                dt = DataInterface1.dbEmployee(cls);
                lst = DataInterface.ConvertDataTable<clsEmployee>(dt);

            }
            catch (Exception e1)
            {
                using (clsError clse = new clsError())
                {
                    clse.ReqType = "Insert";
                    clse.Mode = "WEB";
                    clse.ErrorDescrption = e1.Message;
                    clse.FunctionName = "EmployeeView";
                    clse.Link = "Employee/Employee";
                    clse.PageName = "Employee Controller";
                    clse.UserId = "1";
                    DataInterface.PostError(clse);
                }
            }
            finally
            {

            }
            return View(lst);
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

        public ActionResult EmployeeDetail(int? Id)
        {
            try
            {
                clsEmployeeDetails M = new clsEmployeeDetails();
                DataTable dt = new DataTable();
                if (Id != null && Id > 0)
                {
                    clsEmployeeDetails cls = new clsEmployeeDetails();
                    cls.ReqType = "View";
                    cls.EmpID = Convert.ToInt32("0" + Id.ToString());
                    dt = DataInterface1.dbEmployeeDetails(cls);
                }
                if (dt != null && dt.Rows.Count > 0)
                    M = DataInterface1.GetItem<clsEmployeeDetails>(dt.Rows[0]);

                ViewBag.ddlDep = ClsCommon.ToSelectList(DataInterface1.GetMiseddl("Department"), "MiscId", "MiscName");
                ViewBag.ddlDesig = ClsCommon.ToSelectList(DataInterface1.GetMiseddl("Designation"), "MiscId", "MiscName");
                ViewBag.ddlmari = ClsCommon.ToSelectList(DataInterface1.GetMiseddl("Martial Status"), "MiscId", "MiscName");

                return View(M);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult EmployeeDetail(clsEmployeeDetails M)
        {
            ClsReturnData clsRtn = new ClsReturnData();
            clsRtn.MsgType = (int)MessageType.Fail;
            try
            {
                TempData.Clear();
                DataTable dt = new DataTable();
                if (!ModelState.IsValid)
                {
                    ViewBag.Error = "Invalid Model";
                    return View(M);
                }

                M.ReqType = "Insert";
                dt = DataInterface1.dbEmployeeDetails(M);
                if (dt != null && dt.Rows.Count > 0)
                {
                    clsRtn.ID = Convert.ToInt64("0" + Convert.ToString(dt.Rows[0]["ReturnID"]));
                    clsRtn.Message = Convert.ToString(dt.Rows[0]["ReturnMessage"]);
                    clsRtn.MessageDesc = clsRtn.Message;
                    if (clsRtn.ID > 0)
                        clsRtn.MsgType = (int)MessageType.Success;
                    else
                        clsRtn.MsgType = (int)MessageType.Fail;
                }
            }
            catch (Exception e1)
            {
                using (clsError clse = new clsError())
                {
                    clse.ReqType = "Insert";
                    clse.Mode = "WEB";
                    clse.ErrorDescrption = e1.Message;
                    clse.FunctionName = "Employee";
                    clse.Link = "Employee/Employee";
                    clse.PageName = "Employee Controller";
                    clse.UserId = "1";
                    DataInterface.PostError(clse);
                }
            }
            if (clsRtn.ID > 0)
            {
                TempData["Success"] = !string.IsNullOrEmpty(clsRtn.Message) ? clsRtn.Message : "Saved/Updated";
                return RedirectToAction("EmployeeView", "Employee");
            }
            else
            {
                ViewBag.Error = !string.IsNullOrEmpty(clsRtn.Message) ? clsRtn.Message : "Error: Data Not Saved/Updated";
                return View(M);
            }
        }

        public string UploadEmpPhoto(HttpPostedFileBase file)
        {
            string upfile = "";
            try
            {
                if (file.ContentLength > 0)
                {
                    //string _FileName = Path.GetFileName(p.ImageName.FileName);
                    Guid id = Guid.NewGuid();
                    string FileExtension = Path.GetExtension(file.FileName);
                    string _FileName = "Emp" + id.ToString() + FileExtension;
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles/EmployeePhoto"), _FileName);
                    file.SaveAs(_path);
                    upfile = _FileName;
                    //clsEmployee clsphoto = new clsEmployee();
                    //clsphoto.ReqType = "UpdatePhoto";
                    //clsphoto.EmpID = EmpId;
                    //clsphoto.CompId = ClsSession.CompanyID;
                    //clsphoto.ImageName = _FileName;
                    //DataTable dt = DataInterface1.dbEmployee(clsphoto);
                }
                //ViewBag.Message = "File Uploaded Successfully!!";

                return upfile;
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return upfile;
            }
        }
    }
}