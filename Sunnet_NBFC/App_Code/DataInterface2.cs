using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Globalization;
using Newtonsoft.Json;
using System.Threading;
using Sunnet_NBFC.Models;
using System.Reflection;
using System.Web.Mvc;
using Sunnet_NBFC;
using Sunnet_NBFC.App_Code;

public class DataInterface2 : DataInterface, IDisposable
{
    public SqlConnection _cnSQL = null;
    public ConnectionStatus _StateValue = ConnectionStatus.Unknown;
    public string _StateDescription = string.Empty;
    //private static errormessage="Error Occurred";

    /// <summary>
    /// Enumeration representing the state of the SQL connection.
    /// </summary>
    public enum ConnectionStatus
    {
        Open = 0,
        Closed = 1,
        Failed = 2,
        Unknown = 99

    }
    /// <summary>
    /// State of the SQL connection.
    /// </summary>
    public ConnectionStatus StateValue
    {
        get
        {
            return _StateValue;
        }
    }
    /// <summary>
    /// A description of the state of the connection or command.
    /// </summary>
    public string StateDescription
    {
        get
        {
            return _StateDescription;
        }
    }
    public void Dispose()
    {
        try
        {
            if (_cnSQL != null)
            {
                try { _cnSQL.Close(); }
                catch { }
                try { _cnSQL.Dispose(); }
                catch { }
                _cnSQL = null;
            }
        }
        catch { }
        _StateValue = ConnectionStatus.Closed;
        _StateDescription = "Disconnected OK";
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

    //--------------------------Branch Master-----------------------

    #region Save Branch
    public static ClsReturnData SaveBranch(clsBranch cls)
    {
        ClsReturnData clsRtn = new ClsReturnData();
        clsRtn.MsgType = (int)MessageType.Fail;
        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = cls.ReqType;
            cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = cls.BranchId;
            cmd.Parameters.Add("@BranchName", SqlDbType.VarChar).Value = cls.BranchName;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
            cmd.Parameters.Add("@BranchAddres", SqlDbType.VarChar).Value = cls.BranchAddres;
            cmd.Parameters.Add("@BranchContactNo", SqlDbType.VarChar).Value = cls.BranchContactNo;
            cmd.Parameters.Add("@IsDelete", SqlDbType.VarChar).Value = cls.IsDelete;
            dt = db.FillTableProc(cmd, "USP_Branch");

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
            //    }
            //}

        }
        catch (Exception ex)
        {
            clsRtn.MsgType = (int)MessageType.Error;
            clsRtn.ID = 0;
            clsRtn.Message = ex.Message;
            clsRtn.MessageDesc = ex.Message;
        }
        finally
        {
            dt.Dispose();
        }

        return clsRtn;
    }

    #endregion

    #region GET Branch
    public static clsBranch GetBranch(int BranchId)
    {
        clsBranch lst = new clsBranch();


        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "View";
            cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
            cmd.Parameters.Add("@IsDelete", SqlDbType.VarChar).Value = 0;
            dt = db.FillTableProc(cmd, "USP_Branch");
            //    }
            //}

            if (dt != null && dt.Rows.Count > 0)
                lst = GetItem<clsBranch>(dt.Rows[0]);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dt.Dispose();
        }

        return lst;

    }

    #endregion

    #region View Branch
    public static List<clsBranch> ViewBranch()
    {
        //DBHelper dBHlper = new DBHelper();
        List<clsBranch> lst = new List<clsBranch>();
        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "View";
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
            cmd.Parameters.Add("@IsDelete", SqlDbType.VarChar).Value = 0;
            dt = db.FillTableProc(cmd, "USP_Branch");

            //    }
            //}

            lst = DataInterface.ConvertDataTable<clsBranch>(dt);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dt.Dispose();
        }

        return lst;
    }
    #endregion

    #region Delete Branch
    public static ClsReturnData DeleteBranch(int Id)
    {
        ClsReturnData clsRtn = new ClsReturnData();
        clsRtn.MsgType = (int)MessageType.Fail;
        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "Delete";
            cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
            dt = db.FillTableProc(cmd, "USP_Branch");

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
            //    }
            //}

        }
        catch (Exception ex)
        {
            clsRtn.MsgType = (int)MessageType.Error;
            clsRtn.ID = 0;
            clsRtn.Message = ex.Message;
            clsRtn.MessageDesc = ex.Message;
        }
        finally
        {
            dt.Dispose();
        }

        return clsRtn;
    }
    #endregion

    //--------------------------Branch Master-----------------------


    //--------------------------Misc Master-----------------------

    #region Save Misc
    public static ClsReturnData SaveMisc(clsMisc cls)
    {
        ClsReturnData clsRtn = new ClsReturnData();
        clsRtn.MsgType = (int)MessageType.Fail;
        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = cls.ReqType;
            cmd.Parameters.Add("@MiscId", SqlDbType.Int).Value = cls.MiscId;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
            cmd.Parameters.Add("@MiscName", SqlDbType.VarChar).Value = cls.MiscName;
            cmd.Parameters.Add("@MiscType", SqlDbType.VarChar).Value = cls.MiscType;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Int).Value = cls.IsDelete;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = ClsSession.UserID;// cls.CreatedBy ?? 0;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = ClsSession.UserID;// cls.UpdatedBy ?? 0;
            dt = db.FillTableProc(cmd, "USP_MiscMaster");

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
            //    }
            //}

        }
        catch (Exception ex)
        {
            clsRtn.MsgType = (int)MessageType.Error;
            clsRtn.ID = 0;
            clsRtn.Message = ex.Message;
            clsRtn.MessageDesc = ex.Message;
        }
        finally
        {
            dt.Dispose();
        }

        return clsRtn;
    }

    #endregion

    #region GET Misc
    public static clsMisc GetMisc(int MiscId)
    {
        clsMisc lst = new clsMisc();


        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "View";
            cmd.Parameters.Add("@MiscId", SqlDbType.Int).Value = MiscId;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Int).Value = 0;
            dt = db.FillTableProc(cmd, "USP_MiscMaster");
            //    }
            //}

            if (dt != null && dt.Rows.Count > 0)
                lst = GetItem<clsMisc>(dt.Rows[0]);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dt.Dispose();
        }

        return lst;

    }

    #endregion

    #region View Misc
    public static List<clsMisc> ViewMisc()
    {
        //DBHelper dBHlper = new DBHelper();
        List<clsMisc> lst = new List<clsMisc>();
        DataTable dt = new DataTable();
        try
        {
            //DBOperation db = new DBOperation();
            //SqlCommand cmd = new SqlCommand();

            using (DBOperation db = new DBOperation())
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "View";
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
                    cmd.Parameters.Add("@IsDelete", SqlDbType.Int).Value = 0;
                    dt = db.FillTableProc(cmd, "USP_MiscMaster");

                }
            }

            lst = DataInterface.ConvertDataTable<clsMisc>(dt);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dt.Dispose();
        }

        return lst;
    }
    #endregion

    #region Delete Misc
    public static ClsReturnData DeleteMisc(int Id)
    {
        ClsReturnData clsRtn = new ClsReturnData();
        clsRtn.MsgType = (int)MessageType.Fail;
        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "Delete";
            cmd.Parameters.Add("@MiscId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
            dt = db.FillTableProc(cmd, "USP_MiscMaster");

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
            //    }
            //}

        }
        catch (Exception ex)
        {
            clsRtn.MsgType = (int)MessageType.Error;
            clsRtn.ID = 0;
            clsRtn.Message = ex.Message;
            clsRtn.MessageDesc = ex.Message;
        }
        finally
        {
            dt.Dispose();
        }

        return clsRtn;
    }
    #endregion

    //--------------------------Misc Master-----------------------


    //--------------------------Document Master-----------------------

    #region Save Document
    public static ClsReturnData SaveDocument(clsDocument cls)
    {
        ClsReturnData clsRtn = new ClsReturnData();
        clsRtn.MsgType = (int)MessageType.Fail;
        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = cls.ReqType;
            cmd.Parameters.Add("@DocId", SqlDbType.Int).Value = cls.DocID;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
            cmd.Parameters.Add("@DocumentName", SqlDbType.VarChar).Value = cls.DocumentName;
            cmd.Parameters.Add("@ProdId", SqlDbType.Int).Value = cls.ProdID;
            cmd.Parameters.Add("@IsRequried", SqlDbType.Int).Value = (cls.IsRequried ? 1 : 0);
            cmd.Parameters.Add("@IsDelete", SqlDbType.Int).Value = cls.IsDelete;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = ClsSession.UserID;// cls.CreatedBy ?? 0;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = ClsSession.UserID;// cls.UpdatedBy ?? 0;
            dt = db.FillTableProc(cmd, "USP_Document");

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
            //    }
            //}

        }
        catch (Exception ex)
        {
            clsRtn.MsgType = (int)MessageType.Error;
            clsRtn.ID = 0;
            clsRtn.Message = ex.Message;
            clsRtn.MessageDesc = ex.Message;
        }
        finally
        {
            dt.Dispose();
        }

        return clsRtn;
    }

    #endregion

    #region GET Document
    public static clsDocument GetDocument(int DocumentId)
    {
        clsDocument lst = new clsDocument();


        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "View";
            cmd.Parameters.Add("@DocId", SqlDbType.Int).Value = DocumentId;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Int).Value = 0;
            dt = db.FillTableProc(cmd, "USP_Document");
            //    }
            //}

            if (dt != null && dt.Rows.Count > 0)
                lst = GetItem<clsDocument>(dt.Rows[0]);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dt.Dispose();
        }

        return lst;

    }

    #endregion

    #region View Document
    public static List<clsDocument> ViewDocument()
    {
        //DBHelper dBHlper = new DBHelper();
        List<clsDocument> lst = new List<clsDocument>();
        DataTable dt = new DataTable();
        try
        {
            //DBOperation db = new DBOperation();
            //SqlCommand cmd = new SqlCommand();

            using (DBOperation db = new DBOperation())
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "View";
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
                    cmd.Parameters.Add("@IsDelete", SqlDbType.Int).Value = 0;
                    dt = db.FillTableProc(cmd, "USP_Document");

                }
            }

            lst = DataInterface.ConvertDataTable<clsDocument>(dt);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dt.Dispose();
        }

        return lst;
    }
    #endregion

    #region Delete clsDocument
    public static ClsReturnData DeleteDocument(int Id)
    {
        ClsReturnData clsRtn = new ClsReturnData();
        clsRtn.MsgType = (int)MessageType.Fail;
        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "Delete";
            cmd.Parameters.Add("@DocId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
            dt = db.FillTableProc(cmd, "USP_Document");

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
            //    }
            //}

        }
        catch (Exception ex)
        {
            clsRtn.MsgType = (int)MessageType.Error;
            clsRtn.ID = 0;
            clsRtn.Message = ex.Message;
            clsRtn.MessageDesc = ex.Message;
        }
        finally
        {
            dt.Dispose();
        }

        return clsRtn;
    }
    #endregion

    //--------------------------Document Master-----------------------

    //public static DataTable GetProduct()
    //{

    //    DataTable dt = new DataTable();
    //    using (DBOperation db = new DBOperation())
    //    {
    //        using (SqlCommand sqlCommand = new SqlCommand())
    //        {
    //            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
    //            sqlCommand.Parameters.AddWithValue("@ReqType", "View");
    //            sqlCommand.Parameters.AddWithValue("@CompanyId", ClsSession.CompanyID);
    //            dt = db.FillTableProc(sqlCommand, "USP_Product");
    //        }


    //    }
    //    return dt;
    //}


    //--------------------------Document Master-----------------------


    //--------------------------Employee Master-----------------------
    // by chetan as himnshu change
  



    #region Save Employee
    public static ClsReturnData SaveEmployee(clsEmployee cls)
    {
        ClsReturnData clsRtn = new ClsReturnData();
        clsRtn.MsgType = (int)MessageType.Fail;
        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = cls.ReqType;
            cmd.Parameters.Add("@EmpID", SqlDbType.Int).Value = cls.EmpID;
            //cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar).Value = cls.EmpCode;
            cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = cls.EmpName;
            cmd.Parameters.Add("@FatherName", SqlDbType.VarChar).Value = cls.FatherName;
            cmd.Parameters.Add("@MotherName", SqlDbType.VarChar).Value = cls.MotherName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = cls.Address;
            cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = cls.StateID;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = cls.CityID;
            cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = cls.ZipCode;
            cmd.Parameters.Add("@ContactNo1", SqlDbType.VarChar).Value = cls.ContactNo1;
            cmd.Parameters.Add("@ContactNo2", SqlDbType.VarChar).Value = cls.ContactNo2;
            cmd.Parameters.Add("@WhatsAppNo", SqlDbType.VarChar).Value = cls.WhatsAppNo;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = cls.Email;
            cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = cls.DOB == null ? (object)DBNull.Value : cls.DOB;
            cmd.Parameters.Add("@PAN", SqlDbType.VarChar).Value = cls.PAN;
            cmd.Parameters.Add("@AadhaarNo", SqlDbType.VarChar).Value = cls.AadhaarNo;
            cmd.Parameters.Add("@MaritalStatus", SqlDbType.VarChar).Value = cls.MaritalStatus;
            cmd.Parameters.Add("@ImageName", SqlDbType.VarChar).Value = cls.ImageName;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Int).Value = cls.IsDelete;
            cmd.Parameters.Add("@CompId", SqlDbType.Int).Value = ClsSession.CompanyID;
            cmd.Parameters.Add("@Longtitute", SqlDbType.VarChar).Value = cls.Longtitute;
            cmd.Parameters.Add("@Langtiute", SqlDbType.VarChar).Value = cls.Langtiute;
            cmd.Parameters.Add("@EmployeeAttnStatus", SqlDbType.Int).Value = cls.EmployeeAttnStatus;
            cmd.Parameters.Add("@AttnDate", SqlDbType.DateTime).Value = cls.AttnDate == null ? (object)DBNull.Value : cls.AttnDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = ClsSession.UserID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = ClsSession.UserID;
            dt = db.FillTableProc(cmd, "USP_Employee");

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
            //    }
            //}

        }
        catch (Exception ex)
        {
            clsRtn.MsgType = (int)MessageType.Error;
            clsRtn.ID = 0;
            clsRtn.Message = ex.Message;
            clsRtn.MessageDesc = ex.Message;
        }
        finally
        {
            dt.Dispose();
        }

        return clsRtn;
    }

    #endregion

    #region GET Employee
    public static DataTable GetEmployee(int EmpID)
    {
        clsEmployee lst = new clsEmployee();


        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "View";
            cmd.Parameters.Add("@EmpID", SqlDbType.Int).Value = EmpID;
            cmd.Parameters.Add("@CompId", SqlDbType.Int).Value = ClsSession.CompanyID;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Int).Value = 0;
            dt = db.FillTableProc(cmd, "USP_Employee");
            //    }
            //}

            if (dt != null && dt.Rows.Count > 0)
                lst = GetItem<clsEmployee>(dt.Rows[0]);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dt.Dispose();
        }

        return dt;

    }

    #endregion

    #region View Employee
    public static List<clsEmployee> ViewEmployee()
    {
        //DBHelper dBHlper = new DBHelper();
        List<clsEmployee> lst = new List<clsEmployee>();
        DataTable dt = new DataTable();
        try
        {
            //DBOperation db = new DBOperation();
            //SqlCommand cmd = new SqlCommand();

            using (DBOperation db = new DBOperation())
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "View";
                    cmd.Parameters.Add("@CompId", SqlDbType.Int).Value = ClsSession.CompanyID;
                    cmd.Parameters.Add("@IsDelete", SqlDbType.Int).Value = 0;
                    dt = db.FillTableProc(cmd, "USP_Employee");

                }
            }

            lst = DataInterface.ConvertDataTable<clsEmployee>(dt);
            //lst = DataInterface.ConvertDataTable<clsCustomerMaster>(dt);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dt.Dispose();
        }

        return lst;
    }
    #endregion

    #region Delete clsEmployee
    public static ClsReturnData DeleteEmployee(int Id)
    {
        ClsReturnData clsRtn = new ClsReturnData();
        clsRtn.MsgType = (int)MessageType.Fail;
        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand cmd = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "Delete";
            cmd.Parameters.Add("@EmpID", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@CompId", SqlDbType.Int).Value = ClsSession.CompanyID;
            dt = db.FillTableProc(cmd, "USP_Employee");

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
            //    }
            //}

        }
        catch (Exception ex)
        {
            clsRtn.MsgType = (int)MessageType.Error;
            clsRtn.ID = 0;
            clsRtn.Message = ex.Message;
            clsRtn.MessageDesc = ex.Message;
        }
        finally
        {
            dt.Dispose();
        }

        return clsRtn;
    }
    #endregion

    //--------------------------Employee Master-----------------------




}
