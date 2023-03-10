using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sunnet_NBFC.App_Code;


namespace Sunnet_NBFC.Models
{
    public class clsTDH2
    {
    }
    public class clsBranch : IDisposable
    {
        public string ReqType { get; set; }

        public int BranchId { get; set; }

        [Required(ErrorMessage = "Branch Code is required.")]
        [DisplayName("Branch Code")]

        public string BranchCode { get; set; }

        [Required(ErrorMessage = "Branch Name is required.")]
        [DisplayName("Branch Name")]
        public string BranchName { get; set; }

        public int CompanyID { get; set; }

        [DisplayName("Branch Address")]
        public string BranchAddres { get; set; }

        [DisplayName("Contact No")]
        [Required(ErrorMessage = "Contact No is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Contact Number.")]
        public string BranchContactNo { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string BranchManger { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public int CreatedBy { get; set; }
        public int IsDelete { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        ~clsBranch()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose any disposable fields here-
                GC.SuppressFinalize(this);
            }
            ReleaseNativeResource();
        }

        private void ReleaseNativeResource()
        {

        }

    }


    public class clsMisc : IDisposable
    {
        public string ReqType { get; set; }

        public int MiscId { get; set; }
        public int CompanyId { get; set; }


        [Required(ErrorMessage = "Misc Name is required.")]
        [DisplayName("Misc Name")]
        public string MiscName { get; set; }


        [Required(ErrorMessage = "Misc Type is required.")]
        [DisplayName("Misc Type")]
        public string MiscType { get; set; }
        public string tmpMiscType { get; set; }

        public int IsDelete { get; set; }

        //public DateTime? CreateDate { get; set; }
        //public int? CreateBy { get; set; }
        //public DateTime? UpdateDate { get; set; }
        //public int? UpdateBy { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        ~clsMisc()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose any disposable fields here-
                GC.SuppressFinalize(this);
            }
            ReleaseNativeResource();
        }

        private void ReleaseNativeResource()
        {

        }

    }




    public class clsDocument : IDisposable
    {
        public string ReqType { get; set; }

        public int DocID { get; set; }

        [Required(ErrorMessage = "Document Name is required.")]
        [DisplayName("Document Name")]
        public string DocumentName { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [DisplayName("Product Name")]
        public int ProdID { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }


        [DisplayName("Is Requried")]
        public bool IsRequried { get; set; }
        public int IsDelete { get; set; }
        public int CompanyID { get; set; }

        //public DateTime UpdateDate { get; set; }
        //public int UpdatedBy { get; set; }
        //public int CreatedBy { get; set; }
        //public DateTime CreateDate { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        ~clsDocument()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose any disposable fields here-
                GC.SuppressFinalize(this);
            }
            ReleaseNativeResource();
        }

        private void ReleaseNativeResource()
        {

        }

    }

    public class clsEmployee
    {
        public string ReqType { get; set; }
        public int EmpID { get; set; }

        [DisplayName("Employee Code")]
        public string EmpCode { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        [DisplayName("Employee Name")]
        public string EmpName { get; set; }

        [DisplayName("Father Name")]
        public string FatherName { get; set; }

        [DisplayName("Mother Name")]
        public string MotherName { get; set; }

        public string Address { get; set; }

        [DisplayName("State")]
        public int? StateID { get; set; }

        [DisplayName("City")]
        public int? CityID { get; set; }


        [DisplayName("Pin Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "{0} is Required")]
        [DisplayName("Mobile No")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid {0}")]
        public string ContactNo1 { get; set; }

        [DisplayName("Mobile No2")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid {0}")]
        public string ContactNo2 { get; set; }

        [DisplayName("WhatsAppNo")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid {0}")]
        public string WhatsAppNo { get; set; }

        [DisplayName("Email")]
        //[DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail address")]
        [StringLength(50, ErrorMessage = "{0} max limit only 50 char")]
        public string Email { get; set; }

        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
        [DisplayName("PAN")]
        public string PAN { get; set; }
        [DisplayName("Aadhaar No")]
        public string AadhaarNo { get; set; }
        [DisplayName("Marital Status")]
        public string MaritalStatus { get; set; }

        [DisplayName("Photo")]
        public HttpPostedFile Imagefile { get; set; }
        public string ImageName { get; set; }
        public int IsDelete { get; set; }
        public int CompId { get; set; }
        public string Longtitute { get; set; }
        public string Langtiute { get; set; }
        public int? EmployeeAttnStatus { get; set; }
        public DateTime? AttnDate { get; set; }

        [Required(ErrorMessage = "Branch is required.")]
        [DisplayName("Branch")]
        public int BranchId { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [DisplayName("Role")]
        public int RoleId { get; set; }


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

        ~clsEmployee()
        {
            Dispose(false);
        }

    }


    public class clsStateDDL
    {
        public static SelectList GetStateDDL()
        {
            return ClsCommon.ToSelectList(DataInterface1.GetState(), "ID", "StateName");
        }
    }

    public class clsCityDDL
    {
        public static SelectList GetCityDDL()
        {
            clsCity cls = new clsCity();
            cls.ReqType = "View";
            return ClsCommon.ToSelectList(DataInterface1.GetCity(cls), "CityId", "CityName");
        }
    }

    public class clsLeadDetail
    {
        public string ReqType { get; set; }
        public int LeadDtlId { get; set; }
        public int LeadId { get; set; }

        [Required(ErrorMessage = "Stage is required.")]
        [DisplayName("StageId")]
        public int StageId { get; set; }

        [DisplayName("StageName")]
        public string StageName { get; set; }

        public int IsActive { get; set; }
        public int IsCurrent { get; set; }

        [DisplayName("ShortStage_Name")]
        public string ShortStage_Name { get; set; }


        public int Dependancy { get; set; }
        public int Sequence { get; set; }
        public int CompanyId { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }
        [DisplayName("Remarks")]
        public string Remarks { get; set; }

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

        ~clsLeadDetail()
        {
            Dispose(false);
        }

    }


    public class clsLeadMain : clsLeadDetail
    {
        //public string ReqType { get; set; }
        //public int LeadId { get; set; }
        public string LeadNo { get; set; }
        public List<clsLeadCalling> clsLeadCalling { get; set; }


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

        ~clsLeadMain()
        {
            Dispose(false);
        }

    }

    public class clsLeadCalling
    {
        public string ReqType { get; set; }
        public int TcId { get; set; }
        public int LeadId { get; set; }

        [DisplayName("QuestionId")]
        public int QuestionId { get; set; }

        [DisplayName("Question")]
        public string Question { get; set; }
        public string QuestionAnsType { get; set; }
        [Required(ErrorMessage = "Answer is required.")]

        [DisplayName("Answer")]
        public string Answer { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }
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

        ~clsLeadCalling()
        {
            Dispose(false);
        }

    }

    public class clsLeadDocument : clsLeadDetail
    {
        //public string ReqType { get; set; }
        public int DcId { get; set; }
        //public int LeadId { get; set; }

        [Required(ErrorMessage = "Document is required.")]
        [DisplayName("Document")]
        public int DocID { get; set; }

        [DisplayName("CustomerType")]
        public string CustomerType { get; set; }

        [DisplayName("Is Received")]
        public bool IsReceived { get; set; }

        [DisplayName("Remarks")]
        //public string Remarks { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsRequried { get; set; }

        //[DisplayName("Document Name")]
        public string DocumentName { get; set; }
        public int LeadCustId { get; set; }
        public string CustName { get; set; }
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

        ~clsLeadDocument()
        {
            Dispose(false);
        }

    }







}