using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunnet_NBFC.Models
{

    public class clsLead
    {
        public int OptType { get; set; }
        public int LeadId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string CustName { get; set; } = "";

        [Required(ErrorMessage = "Contact No is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Contact Number.")]
        public string CustContNo { get; set; } = "";
        public string CustContNo2 { get; set; } = "";
        public string CustMail { get; set; } = "";
        public string CustAdress { get; set; } = "";
        public string Country { get; set; } = "";
        public string Pincode { get; set; }
        public Gender CustGender { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public int ServiceId { get; set; } = 0;
        public string Website { get; set; } = "";
        public string IndustryType { get; set; } = "";
        public string Remarks { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public string LeadStatus { get; set; } = "";
        public string ServiceName { get; set; } = "";
        public string GenderName { get; set; } = "";


    }
    public class ViewCatgModel
    {
        public clsLead ClsProp { get; set; }
        public List<clsLead> ViewLead { get; set; }
    }
    public enum Gender
    {
        Select,
        Male,
        Female
    }



    public class clsUser
    {
        public int OptType { get; set; }
        public int UserId { get; set; }
        public int LoginId { get; set; }

        [Required(ErrorMessage = "User Name is Requried")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User Name is Requried")]
        public string Password { get; set; }
        public Int64 ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string Userpic { get; set; }
        public string UserPicExt { get; set; }
        public string UserPicName { get; set; }
        public int IsActive { get; set; }
        public string SessionKey { get; set; }
    }
    public class ImageModel
    {
        List<string> _images = new List<string>();

        public ImageModel()
        {
            _images = new List<string>();
        }

        public List<string> Images
        {
            get { return _images; }
            set { _images = value; }
        }
    }

    public class clsTicket
    {
        public int OptType { get; set; }
        public int TicketId { get; set; }
        public string TicketNo { get; set; }

        [Required(ErrorMessage = "Description is Requried")]
        public string Description { get; set; }
        public string SoftwareName { get; set; }
        [Required(ErrorMessage = "Application Name is Requried")]
        public int Prodid { get; set; }
        public string TicketType { get; set; }
        public int TicketTypeId { get; set; }
        public string ClientName { get; set; } = "";
        [Required(ErrorMessage = "Email is Requried")]
        public string ClientEmail { get; set; } = "";
        public Int64 ClientContactNo { get; set; } = 0;
        public string TicketStatus { get; set; } = "";
        public string TicketResolution { get; set; } = "";
        public string TicketDoc { get; set; } = "";
        public string ClientRemarks { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string OutputResult { get; set; } = "";

    }

    public class clsMailTemplate
    {
        public string FilePath { get; set; } = "";
        public string ToMail { get; set; } = "";
        public string Body { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Attachment { get; set; } = "";
    }
    public class clsWhatsup
    {
        public string Message { get; set; } = "";
        public string URL { get; set; } = "";
        public string FileName { get; set; } = "";
    }

    public class clsClient
    {
        public int OptType { get; set; }
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Client Name is Requried")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "PhoneNo is Requried")]
        public string PhoneNo { get; set; }
        public string WhatsUpNo { get; set; }
        [Required(ErrorMessage = "Address is Requried")]
        public string Address { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "City is Requried")]
        public string State { get; set; }
        public string PinCode { get; set; }
        public string GSTNo { get; set; }
        public string Email { get; set; }
    }

    public class clsStatusMaster : IDisposable
    {
        public string ReqType { get; set; }
        public int StatusID { get; set; }
        public int CompanyID { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Status Description is required.")]
        public string StatusDesc { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~clsStatusMaster()
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

    public class clsCustomerMaster : IDisposable
    {
        public string ReqType { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string MaterialStatus { get; set; }
        public string PresentAddress { get; set; }
        public string PresentPinCode { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentPincode { get; set; }
        public string CibilScore { get; set; }
        public int PresentStateId { get; set; }
        public int PresentCityId { get; set; }
        public int PermanentStateId { get; set; }
        public int PermanentCityId { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string FatherMobileNo { get; set; }
        public string MotherMobileNo { get; set; }
        public string SpouseMobileNo { get; set; }
        public string AadharNo { get; set; }
        public string PanNo { get; set; }
        public int OccupationID { get; set; }
        public int QualificationId { get; set; }
        public string CustRelation { get; set; }
        public int CompanyId { get; set; }
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~clsCustomerMaster()
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
    public class clsCompanyMaster : IDisposable
    {

        public string ReqType { get; set; }
        public int CompanyId { get; set; }
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string PANNo { get; set; }
        public string GSTNo { get; set; }
        public string CompanyType { get; set; }
        public string CompanyDesc { get; set; }
        public string CompanyOthDesc { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string LOGO { get; set; }

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

        ~clsCompanyMaster()
        {
            Dispose(false);
        }

    }

    public class clsError : IDisposable
    {
        public string ReqType { get; set; }
        public int Id { get; set; }
        public string Mode { get; set; }
        public string PageName { get; set; }
        public string Link { get; set; }
        public string FunctionName { get; set; }
        public string ErrorDescrption { get; set; }
        public string UserId { get; set; }
        public DateTime ErrorDate { get; set; }
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

        ~clsError()
        {
            Dispose(false);
        }
    }

    public class clsDSAMaster : IDisposable
    {
        public string ReqType { get; set; }
        public int DSAId { get; set; }
        public string DSACode { get; set; }
        [Required(ErrorMessage = "DSA Name is required.")]
        public string DSAName { get; set; }
        public string DSAAddress { get; set; }
        public int DSACityId { get; set; }
        public int DSAStateId { get; set; }
        [Required(ErrorMessage = "DSA Contact No is required.")]
        public string DSAContactNo { get; set; }
        [Required(ErrorMessage = "DSA PinCode is required.")]
        public Int64 DSAPincode { get; set; }
        public string DSAWhatsUpNo { get; set; }
        public string DSAEmail { get; set; }
        public string DSAGSTNo { get; set; }
        public decimal DSACommision { get; set; }
        public string DSARemarks { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string DSAccountNo { get; set; }
        public string DSABankName { get; set; }
        public string DSABranch { get; set; }
        public string DSAIFSCCode { get; set; }
        public int ISDELETE { get; set; }
        public int COMPANYID { get; set; }
        public string CityName { get; set; }
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

        ~clsDSAMaster()
        {
            Dispose(false);
        }
    }

    public class clsQuestion : IDisposable
    {
        public string ReqType { get; set; }
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Main Product is required.")]
        public int MainProdId { get; set; }
        [Required(ErrorMessage = "Product is required.")]
        public int ProdId { get; set; }
        [Required(ErrorMessage = "Question Answer Type is required.")]
        public string QuestionAnsType { get; set; }

        [Required(ErrorMessage = "Question is required.")]
        public string Question { get; set; }
        public string MainProduct { get; set; }
        public string Product { get; set; }
        public int CreatedBy { get; set; }
        public int IsDelete { get; set; }
        public int CompanyId { get; set; }

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

        ~clsQuestion()
        {
            Dispose(false);
        }
    }

    public class clsLogin : IDisposable
    {
        public string ReqType { get; set; }
      
        public int UserID { get; set; }
        [Remote("IsAlreadyExistsUser", "Login", HttpMethod = "POST", ErrorMessage = "User ID Not Exists.")]
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Type { get; set; }
        public int RefID { get; set; }
        public bool IsActive { get; set; }
        public string SessionID { get; set; }
        public string DeviceID { get; set; }
        public string DeviceType { get; set; }
        public bool IsLogged { get; set; }
        public int Compid { get; set; }
        public string DeviceToken { get; set; }
        public int ChangePasswordYN { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~clsLogin()
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
    public class clsLeadGenerationMaster : IDisposable
    {
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public int LeadId { get; set; }
        public string LeadNo { get; set; }
        public string MainProductId { get; set; }
        public string ProductId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CustType { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string Gender { get; set; }
        public string DateofBirth { get; set; }
        public string MartialStatus { get; set; }
        public string PresentAddress { get; set; }
        public string PresentPincode { get; set; }
        public string Hdn_type { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentPincode { get; set; }
        public string CibilScore { get; set; }
        public string PresentStateId { get; set; }
        public string PresentCityId { get; set; }
        public string PermanentStateId { get; set; }
        public string PermanentCityId { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string FatherMobileNo { get; set; }
        public string MotherMobileNo { get; set; }
        public string SpouseMobileNo { get; set; }
        public string IsLoanDisbursed { get; set; }
        public string AadharNo { get; set; }
        public string AAdharverfiy { get; set; }
        public string PanNo { get; set; }
        public string PanVerify { get; set; }
        public string OccupationID { get; set; }
        public string QualificationId { get; set; }
        public string CustRelation { get; set; }
        
        public string CreateDate { get; set; }
        public int CompanyId { get; set; }
        public string ReqType { get; set; }


        public string CO_FirstName { get; set; }
        public string CO_MiddleName { get; set; }
        public string CO_LastName { get; set; }
        public string CO_Adress { get; set; }
        public string CO_DOB { get; set; }
        public string CO_Occupation { get; set; }
        public string CO_Marital_Status { get; set; }
        public string CO_Gender { get; set; }

        public string CO_PresentAddress { get; set; }
        public string CO_PresentPinCode { get; set; }
        public string CO_PresentStateId { get; set; }
        public string CO_PresentCityId { get; set; }


        public string CO_PermanentAddress { get; set; }
        public string CO_PermanentPincode { get; set; }
        public string CO_PermanentStateId { get; set; }
        public string CO_PermanentCityId { get; set; }




        public string CO_Mobile_No { get; set; }
        public string CO_Email_Id { get; set; }
        public string CO_PAN { get; set; }
        public string CO_Adhaar { get; set; }
        public string CO_CIBIL { get; set; }


        public string G_FirstName { get; set; }
        public string G_MiddleName { get; set; }
        public string G_LastName { get; set; }
        public string G_Adress { get; set; }
        public string G_DOB { get; set; }
        public string G_Occupation { get; set; }
        public string G_Marital_Status { get; set; }
        public string G_Gender { get; set; }

        public string G_PresentAddress { get; set; }
        public string G_PresentPinCode { get; set; }
        public int G_PresentStateId { get; set; }
        public int G_PresentCityId { get; set; }


        public string G_PermanentAddress { get; set; }
        public string G_PermanentPincode { get; set; }
        public int G_PermanentStateId { get; set; }
        public int G_PermanentCityId { get; set; }




        public string G_Mobile_No { get; set; }
        public string G_Email_Id { get; set; }
        public string G_PAN { get; set; }
        public string G_Adhaar { get; set; }
        public string G_CIBIL { get; set; }

        public string ReuestedLoanAmount { get; set; }
        public string EstValueViechle { get; set; }
        public string ReuestedLoanTenure { get; set; }
        public string EstMonthIncome { get; set; }
        public string EstMonthExpense { get; set; }
        public string CurMonthObligation { get; set; }
        public string FORecomedAmt { get; set; }
        public string NoofDependent { get; set; }
        public string ViechleNo { get; set; }
        public string ViechleRegYear { get; set; }
        public string MFGYear { get; set; }

        public string ViechleModel { get; set; }
        public string ViechleColor { get; set; }
        public string ViechleCompany { get; set; }

        public string ViechleOwner { get; set; }
        public string RefernceName { get; set; }
        public string RefenceMobileNo { get; set; }

        public string RefenceRelation { get; set; }
        public string LoanPurpose { get; set; }
        public string ColletralSecurityType { get; set; }

        public string GeoTagging { get; set; }
        public string FORemarks { get; set; }
        public int BranchID { get; set; }
        public int Empid { get; set; }

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
       
    }


    public class Gurantor {

        public string G_FirstName { get; set; }
        public string G_MiddleName { get; set; }
        public string G_LastName { get; set; }
        public string G_Adress { get; set; }
        public string G_DOB { get; set; }
        public string G_Occupation { get; set; }
        public string G_Marital_Status { get; set; }
        public string G_Gender { get; set; }

        public string G_PresentAddress { get; set; }
        public string G_PresentPinCode { get; set; }
        public int G_PresentStateId { get; set; }
        public int G_PresentCityId { get; set; }


        public string G_PermanentAddress { get; set; }
        public string G_PermanentPincode { get; set; }
        public int G_P_State { get; set; }
        public int G_P_City { get; set; }




        public string G_Mobile_No { get; set; }
        public string G_EmailId { get; set; }
        public string G_PanNo { get; set; }
        public string G_AadharNo { get; set; }
        public string G_CibilScore { get; set; }

        public int G_CompanyId { get; set; }
        public int G_BranchID { get; set; }
        public string G_LeadNo { get; set; }
    }

}