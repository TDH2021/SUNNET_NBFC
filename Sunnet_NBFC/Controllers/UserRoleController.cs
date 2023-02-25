using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sunnet_NBFC.Models;
using System.Data;
using Sunnet_NBFC.App_Code;
namespace Sunnet_NBFC.Controllers
{
    public class UserRoleController : Controller
    {
        // GET: UserRole
        public ActionResult RoleMaster(clsRoleMaster M)
        {
            try
            {
               
                using (clsSubMenu cls = new clsSubMenu())
                {
                    cls.ReqType = "View";
                    cls.IsActive = 1;
                    using (DataTable dtddl = DataInterface1.GetSubMenu(cls))
                    {
                        M.clsSubMenulst = DataInterface.ConvertDataTable<clsRoleMaster>(dtddl);   
                    }
                    M.ReqType = "Insert";
                    M.CompanyId = ClsSession.CompanyID;
                    M.IsDelete = 0;
                }
              
            }
            catch(Exception ex)
            {

            }
            return View(M);


        }
        [HttpPost]
        
        public ActionResult RoleMaster(clsRoleMaster cls,FormCollection frm, string htmlTableValue)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Error = "Invalid Model";
            //    return View(cls);
            //}
            //int Total = Convert.ToInt32(frm["hdnCount1"]);
            //for (int i = 1; i <= Total; i++)
            //{ 
            //}
                return View();
        }
    }
}