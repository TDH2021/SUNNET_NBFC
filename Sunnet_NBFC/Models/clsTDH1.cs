using Sunnet_NBFC.App_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunnet_NBFC.Models
{

    public class clsCity : IDisposable
    {
        public string ReqType { get; set; }
        public int Cityid { get; set; }

        [Required(ErrorMessage = "City Name Description is required.")]
        public string CityName { get; set; }


        [Required(ErrorMessage = "City Name Description is required.")]
        public int Stateid { get; set; }

        public string StateName { get; set; }
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~clsCity()
        {
            Dispose(false);
        }

    }

    public class clsProduct : IDisposable
    {

        public string ReqType { get; set; }
        public int ProdId { get; set; }

        [Required(ErrorMessage = "Main Product is required.")]
        [DisplayName("Main Product")]
        public int MainProdId { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public int IsDelete { get; set; }
        public string CustTypeRequried { get; set; }
        public DateTime CreateDate { get; set; }
        public int CompanyId { get; set; }

        [DisplayName("Main Product")]
        public string MainProduct { get; set; }
        public string CustTypeName { get; set; }

        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~clsProduct()
        {
            Dispose(false);
        }


        public static SelectList GetProductDDL()
        {
            clsProduct cls = new clsProduct();
            cls.ReqType = "View";
            return ClsCommon.ToSelectList(DataInterface1.GetProduct(cls), "ProdId", "ProductName");
        }

    }




    public class clsEmployeeDetails
    {
        public string ReqType { get; set; }
        public int EmpDtlID { get; set; }

        [Required(ErrorMessage = "Employee is required.")]
        [DisplayName("Employee")]
        public int EmpID { get; set; }
        [Required(ErrorMessage = "Desgination is required.")]
        [DisplayName("Designation")]
        public int DesignationID { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [DisplayName("Date Of Joining")]
        public string DOJ { get; set; }

        [DisplayName("Last ESIC No.")]
        public string LastESICNo { get; set; }

        [DisplayName("Last PF No.")]
        public string LastPFNo { get; set; }

        [DisplayName("Last Acadmic Degree")]
        [Required(ErrorMessage = "Last Acadmic Degree is required.")]
        public string LastAcadmicDegree { get; set; }

        [DisplayName("Last Professional Degree")]
        public string LastProfDegree { get; set; }

        [DisplayName("Last Company")]
        public string LastCompany { get; set; }

        [DisplayName("Last Experience Detail")]
        public string LastExperienceDtls { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public double Salary { get; set; }
        public bool IsLeave { get; set; }

        [DisplayName("Date Of Leave")]
        public string DOL { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [DisplayName("Login Type")]
        public string LoginType { get; set; }
        public int Companyid { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
        public string Longtitute { get; set; }
        public string Langtiute { get; set; }

        [DisplayName("Employee Code")]
        public string EmpCode { get; set; }

        [DisplayName("Employee Name")]
        public string EmpName { get; set; }

        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~clsEmployeeDetails()
        {
            Dispose(false);
        }


    }


    public class clsMenuMaster : IDisposable
    {
        public string ReqType { get; set; }
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Menu Name is required.")]
        [DisplayName("Menu Name")]
        public string MenuName { get; set; }

        [Required(ErrorMessage = "Menu Url is required.")]
        [DisplayName("Menu Url")]
        public string MenuUrl { get; set; }
        public int MenuActive { get; set; }
        public string ActiveStr { get; set; }
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~clsMenuMaster()
        {
            Dispose(false);
        }
    }

    public class clsSubMenu : IDisposable
    {
        public string ReqType { get; set; }
        public int SubMenuId { get; set; }

        [Required(ErrorMessage = "Menu Name is required.")]
        [DisplayName("Menu Name")]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Title Name is required.")]
        [DisplayName("Title Name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Controller is required.")]
        [DisplayName("Controller Name")]
        public string Controller { get; set; }
        public string Action { get; set; }
        public int IsActive { get; set; }
        public string MenuName { get; set; }
        public string ActiveStr { get; set; }
        public bool IsSelected { get; set; }
       
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~clsSubMenu()
        {
            Dispose(false);
        }
    }

    public class clsStageRole
    {
        public string ReqType { get; set; }
        public int StageRoleId { get; set; }

        [Required(ErrorMessage = "Employee is required.")]
        [DisplayName("Employee")]
        public int StageRoleEmpId { get; set; }

        [DisplayName("Employee Code")]
        public string StageRoleEmpCode { get; set; }

        [DisplayName("Employee Name")]
        public string StageRoleEmpName { get; set; }

        [DisplayName("Role Name")]
        [Required(ErrorMessage = "Role Name is required.")]
        public string StageRoleName { get; set; }

        [DisplayName("CreatedBy")]
        public int CreatedBy { get; set; }

        public int CompanyID { get; set; }
        public int IsDelete { get; set; }

        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~clsStageRole()
        {
            Dispose(false);
        }
    }
    public class clsLeadmaind : clsLeadDocument
    {
        //public string ReqType { get; set; }
        //public int LeadId { get; set; }
        public string LeadNo { get; set; }
        public List<clsLeadDocument> clsLeadDocument { get; set; }


        bool disposed = false;

        ~clsLeadmaind()
        {
            Dispose(false);
        }

    }

    public class clsLeadDocSign : clsLeadDetail
    {
        public string ReqType { get; set; }
        public int DocSignId { get; set; }
        public int LeadId { get; set; }

        //[Required(ErrorMessage = "Employee is required.")]
        [DisplayName("Documents")]
        public string Documents { get; set; }

        [DisplayName("Sanction Letter")]
        public string SanctionLetter { get; set; }

        [DisplayName("Loan Agreement Kit")]
        public string LoanAgrmentKit { get; set; }

        [DisplayName("PDC")]
        //[Required(ErrorMessage = "Role Name is required.")]
        public string PDC { get; set; }

        [DisplayName("NACH")]
        public string NACH { get; set; }

        [DisplayName("Disbursment Kit")]
        public string DisbursmentKit { get; set; }

        [DisplayName("Insurance With HP")]
        public string InsuranceWithHP { get; set; }

        [DisplayName("NOC")]
        public string NOC { get; set; }

        [DisplayName("RTO Slip")]
        public string RTOSlip { get; set; }

        [DisplayName("Orignal Property Paper")]
        public string OrignalPropertyPaper { get; set; }

        [DisplayName("Registerd Mortage Deed")]
        public string RegisterdMortageDeed { get; set; }

        [DisplayName("Equitable Mortage Deed")]
        public string EquitableMortageDeed { get; set; }

        [DisplayName("Affidavit")]
        public string Affidavit { get; set; }

        [DisplayName("Remark")]
        public string Remarks { get; set; }

        [DisplayName("CreatedBy")]
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public int CompanyID { get; set; }
        public int IsDelete { get; set; }

        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~clsLeadDocSign()
        {
            Dispose(false);
        }
    }

    public class clsLeadFinalApprove : clsLeadDetail
    {
        //public string ReqType { get; set; }
        public int FinalApproveId { get; set; }
        //public int LeadId { get; set; }

        //[Required(ErrorMessage = "Employee is required.")]
        [DisplayName("Particulers")]
        public string Particulers { get; set; }

        [DisplayName("Procces fees")]
        public decimal Proccesfees { get; set; }

        [DisplayName("Advance EMI")]
        public decimal AdvanceEMI { get; set; }

        [DisplayName("GST")]
        public decimal GST { get; set; }

        [DisplayName("NetDisbAmt")]
        public decimal NetDisbAmt { get; set; }

        [DisplayName("TrnchsNo")]
        public decimal TrnchsNo { get; set; }

        [DisplayName("CersaiCharges")]
        public decimal CersaiCharges { get; set; }

        [DisplayName("StamppingCharges")]
        public decimal StamppingCharges { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

        [DisplayName("CreatedBy")]
        public int CreatedBy { get; set; }
        public class clsLeadFinalApprove : clsLeadDetail
        {
            public string ReqType { get; set; }
            public int FinalApproveId { get; set; }
            public int LeadId { get; set; }

            //[Required(ErrorMessage = "Employee is required.")]
            [DisplayName("Particulers")]
            public string Particulers { get; set; }

            [DisplayName("Procces fees")]
            public decimal Proccesfees { get; set; }

            [DisplayName("Advance EMI")]
            public decimal AdvanceEMI { get; set; }

            [DisplayName("GST")]
            public decimal GST { get; set; }

            [DisplayName("NetDisbAmt")]
            public decimal NetDisbAmt { get; set; }

            [DisplayName("TrnchsNo")]
            public decimal TrnchsNo { get; set; }

            [DisplayName("CersaiCharges")]
            public decimal CersaiCharges { get; set; }

            [DisplayName("StamppingCharges")]
            public decimal StamppingCharges { get; set; }

            [DisplayName("Remarks")]
            public string Remarks { get; set; }

            [DisplayName("CreatedBy")]
            public int CreatedBy { get; set; }

            [DisplayName("UpdatedBy")]
            public int UpdatedBy { get; set; }

            [DisplayName("IsDelete")]
            public int IsDelete { get; set; }

            [DisplayName("CompanyId")]
            public int CompanyId { get; set; }

            [DisplayName("BorrowerKyc")]
            public string BorrowerKyc { get; set; }

            [DisplayName("GuarantorKyc")]
            public string GuarantorKyc { get; set; }

            [DisplayName("PDC")]
            public string PDC { get; set; }

            [DisplayName("BorrowerPhoto")]
            public string BorrowerPhoto { get; set; }

            [DisplayName("CoBorrowerPhoto")]
            public string CoBorrowerPhoto { get; set; }

            [DisplayName("GuarantorPhoto")]
            public string GuarantorPhoto { get; set; }

            [DisplayName("SanctionLetter")]
            public string SanctionLetter { get; set; }

            [DisplayName("LoanAgreementkit")]
            public string LoanAgreementkit { get; set; }

            [DisplayName("DisbursementRequestLetter")]
            public string DisbursementRequestLetter { get; set; }

            [DisplayName("NocPreviousFinanced")]
            public string NocPreviousFinanced { get; set; }

            [DisplayName("Rtoslip")]
            public string Rtoslip { get; set; }

            bool disposed = false;

            // Public implementation of Dispose pattern callable by consumers.
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            // Protected implementation of Dispose pattern.
            protected virtual void Dispose(bool disposing)
            {
                if (disposed)
                    return;

                if (disposing)
                {
                    // Free any other managed objects here.
                    //
                }

                // Free any unmanaged objects here.
                //
                disposed = true;
            }

            ~clsLeadFinalApprove()
            {
                Dispose(false);
            }
        }

        public class clsLeadFinalApproveMain : clsLeadFinalApprove
        {
            public string LeadNo { get; set; }
            public List<clsLeadFinalApprove> clsLeadFinalApprove { get; set; }


            bool disposed = false;

            ~clsLeadFinalApproveMain()
            {
                Dispose(false);
            }


        }
        [DisplayName("UpdatedBy")]
        public int UpdatedBy { get; set; }

        [DisplayName("IsDelete")]
        public int IsDelete { get; set; }

        [DisplayName("CompanyId")]
        public int CompanyId { get; set; }

        [DisplayName("BorrowerKyc")]
        public string BorrowerKyc { get; set; }

        [DisplayName("GuarantorKyc")]
        public string GuarantorKyc { get; set; }

        [DisplayName("PDC")]
        public string PDC { get; set; }

        [DisplayName("BorrowerPhoto")]
        public string BorrowerPhoto { get; set; }

        [DisplayName("CoBorrowerPhoto")]
        public string CoBorrowerPhoto { get; set; }

        [DisplayName("GuarantorPhoto")]
        public string GuarantorPhoto { get; set; }

        [DisplayName("SanctionLetter")]
        public string SanctionLetter { get; set; }

        [DisplayName("LoanAgreementkit")]
        public string LoanAgreementkit { get; set; }

        [DisplayName("DisbursementRequestLetter")]
        public string DisbursementRequestLetter { get; set; }

        [DisplayName("NocPreviousFinanced")]
        public string NocPreviousFinanced { get; set; }

        [DisplayName("Rtoslip")]
        public string Rtoslip { get; set; }

        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~clsLeadFinalApprove()
        {
            Dispose(false);
        }
    }

    public class clsLeadFinalApproveMain : clsLeadFinalApprove
    {
        public string LeadNo { get; set; }
        public List<clsLeadFinalApprove> clsLeadFinalApprove { get; set; }


        bool disposed = false;

        ~clsLeadFinalApproveMain()
        {
            Dispose(false);
        }


    }

    public class clsLeadDocSignMain : clsLeadDocSign
    {
        public string LeadNo { get; set; }
        public List<clsLeadDocSign> clsLeadDocSign { get; set; }


        bool disposed = false;

        ~clsLeadDocSignMain()
        {
            Dispose(false);
        }


    }

    public class clsMiscDDL
    {
        public static SelectList GetMiscDDL(string mtype)
        {
            return ClsCommon.ToSelectList(DataInterface1.GetMiseddl(mtype), "MiscId", "MiscName");
        }
    }
    public class clsBranchDDL
    {
        public static SelectList GetBranchDDL()
        {
            return ClsCommon.ToSelectList(DataInterface1.dbBranchddl(), "BranchId", "BranchName");
        }
    }

    public class clsEmoloyeeDDL
    {
        public static SelectList GetEmoloyeeDDL()
        {
            clsEmployee cls = new clsEmployee();
            cls.ReqType = "view";
            cls.CompId = ClsSession.CompanyID;
            cls.IsDelete = 0;
            return ClsCommon.ToSelectList(DataInterface1.dbEmployee(cls), "EmpID", "ddlname");

        }
    }

    public class clsRoleDDL
    {
        public static SelectList GetRoleDDL()
        {
            return ClsCommon.ToSelectList(DataInterface1.dbStageMasterddl(), "ShortStage_Name", "Stage_Name");

        }
    }
    
    //========================
}