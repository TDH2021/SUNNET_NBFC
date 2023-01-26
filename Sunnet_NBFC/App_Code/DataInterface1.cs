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
using Sunnet_NBFC.App_Code;

public class DataInterface1 : IDisposable
{

    public static DataTable GetCity(clsCity cls)
    {
        DataTable dt = new DataTable();
        using (DBOperation db = new DBOperation())
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReqType", cls.ReqType);
                sqlCommand.Parameters.AddWithValue("@CityId", cls.Cityid);
                sqlCommand.Parameters.AddWithValue("@StateId", cls.Stateid);
                sqlCommand.Parameters.AddWithValue("@CityName", cls.CityName);
                dt = db.FillTableProc(sqlCommand, "USP_City");
            }


        }
        return dt;
    }

    public static DataTable GetState()
    {
        DataTable dt = new DataTable();
        try
        {

            using (DBOperation db = new DBOperation())
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {

                    dt = db.FillTableProc(sqlCommand, "USP_STATE");
                }


            }

        }
        catch (Exception e)
        {

        }
        return dt;
    }

    public static DataTable GetProduct(clsProduct cls)
    {

        DataTable dt = new DataTable();
        using (DBOperation db = new DBOperation())
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReqType", cls.ReqType);
                sqlCommand.Parameters.AddWithValue("@MainProdId", cls.MainProdId);
                sqlCommand.Parameters.AddWithValue("@ProdId", cls.ProdId);
                sqlCommand.Parameters.AddWithValue("@ProductName", cls.ProductName);
                sqlCommand.Parameters.AddWithValue("@CustTypeRequried", cls.CustTypeRequried);
                sqlCommand.Parameters.AddWithValue("@CompanyId", cls.CompanyId);
                dt = db.FillTableProc(sqlCommand, "USP_Product");
            }
        }
        return dt;
    }

    public static DataTable GetMainProductddl(string ReqType)
    {

        DataTable dt = new DataTable();
        using (DBOperation db = new DBOperation())
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReqType", ReqType);
                dt = db.FillTableProc(sqlCommand, "USP_MainProduct");
            }
        }
        return dt;
    }
    public static DataTable GetMiseddl(string MiscType)
    {
        DataTable dt = new DataTable();
        using (DBOperation db = new DBOperation())
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReqType", "View");
                sqlCommand.Parameters.AddWithValue("@MiscType", MiscType);
                sqlCommand.Parameters.AddWithValue("@CompanyId", 1);
                sqlCommand.Parameters.AddWithValue("@isDelete", 0);
                dt = db.FillTableProc(sqlCommand, "USP_MiscMaster");
            }
        }
        return dt;
    }

    public static DataTable dbBranchddl()
    {
        DataTable dt = new DataTable();
        using (DBOperation db = new DBOperation())
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReqType", SqlDbType.VarChar).Value = "View";
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = ClsSession.CompanyID;
                cmd.Parameters.Add("@IsDelete", SqlDbType.VarChar).Value = 0;
                dt = db.FillTableProc(cmd, "USP_Branch");
            }
        }
        return dt;
    }


    public static clsEmployeeDetails GetEmployeedtlbyid(int EmpID)
    {
        clsEmployeeDetails lst = new clsEmployeeDetails();


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
            cmd.Parameters.Add("@Companyid", SqlDbType.Int).Value = ClsSession.CompanyID;
            cmd.Parameters.Add("@IsDelete", SqlDbType.Int).Value = 0;
            dt = db.FillTableProc(cmd, "USP_EmployeeDetails");
            //    }
            //}

            if (dt != null && dt.Rows.Count > 0)
                lst = GetItem<clsEmployeeDetails>(dt.Rows[0]);

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
    public static ClsReturnData GetEmployeeDetails(clsEmployeeDetails cls)
    {
        ClsReturnData clsRtn = new ClsReturnData();
        clsRtn.MsgType = (int)MessageType.Fail;
        DataTable dt = new DataTable();
        try
        {
            DBOperation db = new DBOperation();
            SqlCommand sqlCommand = new SqlCommand();

            //using (DBOperation db = new DBOperation())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ReqType", cls.ReqType);
            sqlCommand.Parameters.AddWithValue("@EmpDtlID", cls.EmpDtlID);
            sqlCommand.Parameters.AddWithValue("@EmpID", cls.EmpID);
            sqlCommand.Parameters.AddWithValue("@DesignationID", cls.DesignationID);
            sqlCommand.Parameters.AddWithValue("@DepartmentId", cls.DepartmentId);
            sqlCommand.Parameters.AddWithValue("@DOJ", cls.DOJ);
            sqlCommand.Parameters.AddWithValue("@LastESICNo", cls.LastESICNo);
            sqlCommand.Parameters.AddWithValue("@LastPFNo", cls.LastPFNo);
            sqlCommand.Parameters.AddWithValue("@LastAcadmicDegree", cls.LastAcadmicDegree);
            sqlCommand.Parameters.AddWithValue("@LastProfDegree", cls.LastProfDegree);
            sqlCommand.Parameters.AddWithValue("@LastCompany", cls.LastCompany);
            sqlCommand.Parameters.AddWithValue("@LastExperienceDtls", cls.LastExperienceDtls);
            sqlCommand.Parameters.AddWithValue("@Salary", cls.Salary);
            sqlCommand.Parameters.AddWithValue("@IsLeave", cls.IsLeave);
            sqlCommand.Parameters.AddWithValue("@DOL", cls.DOL);
            sqlCommand.Parameters.AddWithValue("@LoginType", cls.LoginType);
            sqlCommand.Parameters.AddWithValue("@Companyid", cls.Companyid);
            sqlCommand.Parameters.AddWithValue("@IsActive", cls.IsActive);
            sqlCommand.Parameters.AddWithValue("@IsDelete", cls.IsDelete);
            sqlCommand.Parameters.AddWithValue("@Longtitute", cls.Longtitute);
            sqlCommand.Parameters.AddWithValue("@Langtiute", cls.Langtiute);
            dt = db.FillTableProc(sqlCommand, "USP_EmployeeDetails");

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

    public static DataTable GetMenuMaster(clsMenuMaster cls)
    {

        DataTable dt = new DataTable();
        using (DBOperation db = new DBOperation())
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReqType", cls.ReqType);
                sqlCommand.Parameters.AddWithValue("@MenuId", cls.MenuId);
                sqlCommand.Parameters.AddWithValue("@MenuName", cls.MenuName);
                sqlCommand.Parameters.AddWithValue("@MenuUrl", cls.MenuUrl);
                sqlCommand.Parameters.AddWithValue("@MenuActive", cls.MenuActive);
                dt = db.FillTableProc(sqlCommand, "USP_Menu");
            }
        }
        return dt;
    }

    public static DataTable GetSubMenu(clsSubMenu cls)
    {

        DataTable dt = new DataTable();
        using (DBOperation db = new DBOperation())
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReqType", cls.ReqType);
                sqlCommand.Parameters.AddWithValue("@SubMenuId", cls.SubMenuId);
                sqlCommand.Parameters.AddWithValue("@MenuId", cls.MenuId);
                sqlCommand.Parameters.AddWithValue("@Title", cls.Title);
                sqlCommand.Parameters.AddWithValue("@Controller", cls.Controller);
                sqlCommand.Parameters.AddWithValue("@Action", cls.Action);
                sqlCommand.Parameters.AddWithValue("@IsActive", cls.IsActive);
                dt = db.FillTableProc(sqlCommand, "USP_SubMenu");
            }
        }
        return dt;
    }


    public static DataTable dbEmployee(clsEmployee cls)
    {
        DataTable dt = new DataTable();
        using (DBOperation db = new DBOperation())
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReqType", cls.ReqType);
                sqlCommand.Parameters.Add("@EmpID", SqlDbType.Int).Value = cls.EmpID;
                sqlCommand.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = cls.EmpName;
                sqlCommand.Parameters.Add("@FatherName", SqlDbType.VarChar).Value = cls.FatherName;
                sqlCommand.Parameters.Add("@MotherName", SqlDbType.VarChar).Value = cls.MotherName;
                sqlCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = cls.Address;
                sqlCommand.Parameters.Add("@StateID", SqlDbType.Int).Value = cls.StateID;
                sqlCommand.Parameters.Add("@CityID", SqlDbType.Int).Value = cls.CityID;
                sqlCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = cls.ZipCode;
                sqlCommand.Parameters.Add("@ContactNo1", SqlDbType.VarChar).Value = cls.ContactNo1;
                sqlCommand.Parameters.Add("@ContactNo2", SqlDbType.VarChar).Value = cls.ContactNo2;
                sqlCommand.Parameters.Add("@WhatsAppNo", SqlDbType.VarChar).Value = cls.WhatsAppNo;
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = cls.Email;
                sqlCommand.Parameters.Add("@DOB", SqlDbType.Date).Value = cls.DOB == null ? (object)DBNull.Value : cls.DOB;
                sqlCommand.Parameters.Add("@PAN", SqlDbType.VarChar).Value = cls.PAN;
                sqlCommand.Parameters.Add("@AadhaarNo", SqlDbType.VarChar).Value = cls.AadhaarNo;
                sqlCommand.Parameters.Add("@MaritalStatus", SqlDbType.VarChar).Value = cls.MaritalStatus;
                sqlCommand.Parameters.Add("@ImageName", SqlDbType.VarChar).Value = cls.ImageName;
                sqlCommand.Parameters.Add("@IsDelete", SqlDbType.Int).Value = cls.IsDelete;
                sqlCommand.Parameters.Add("@CompId", SqlDbType.Int).Value = ClsSession.CompanyID;
                sqlCommand.Parameters.Add("@Longtitute", SqlDbType.VarChar).Value = cls.Longtitute;
                sqlCommand.Parameters.Add("@Langtiute", SqlDbType.VarChar).Value = cls.Langtiute;
                sqlCommand.Parameters.Add("@EmployeeAttnStatus", SqlDbType.Int).Value = cls.EmployeeAttnStatus;
                sqlCommand.Parameters.Add("@AttnDate", SqlDbType.DateTime).Value = cls.AttnDate == null ? (object)DBNull.Value : cls.AttnDate;
                sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = ClsSession.UserID;
                sqlCommand.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = ClsSession.UserID;
                sqlCommand.Parameters.Add("@BranchId", SqlDbType.Int).Value = cls.BranchId;
                sqlCommand.Parameters.Add("@RoleId", SqlDbType.Int).Value = cls.RoleId;
                dt = db.FillTableProc(sqlCommand, "USP_Employee");
            }
        }
        return dt;
    }

    public static DataTable dbEmployeeDetails(clsEmployeeDetails cls)
    {
        DataTable dt = new DataTable();
        using (DBOperation db = new DBOperation())
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ReqType", cls.ReqType);
                sqlCommand.Parameters.AddWithValue("@EmpDtlID", cls.EmpDtlID);
                sqlCommand.Parameters.AddWithValue("@EmpID", cls.EmpID);
                sqlCommand.Parameters.AddWithValue("@DesignationID", cls.DesignationID);
                sqlCommand.Parameters.AddWithValue("@DepartmentId", cls.DepartmentId);
                sqlCommand.Parameters.AddWithValue("@DOJ", cls.DOJ);
                sqlCommand.Parameters.AddWithValue("@LastESICNo", cls.LastESICNo);
                sqlCommand.Parameters.AddWithValue("@LastPFNo", cls.LastPFNo);
                sqlCommand.Parameters.AddWithValue("@LastAcadmicDegree", cls.LastAcadmicDegree);
                sqlCommand.Parameters.AddWithValue("@LastProfDegree", cls.LastProfDegree);
                sqlCommand.Parameters.AddWithValue("@LastCompany", cls.LastCompany);
                sqlCommand.Parameters.AddWithValue("@LastExperienceDtls", cls.LastExperienceDtls);
                sqlCommand.Parameters.AddWithValue("@Salary", cls.Salary);
                sqlCommand.Parameters.AddWithValue("@IsLeave", cls.IsLeave);
                sqlCommand.Parameters.AddWithValue("@DOL", cls.DOL);
                sqlCommand.Parameters.AddWithValue("@LoginType", cls.LoginType);
                sqlCommand.Parameters.AddWithValue("@Companyid", cls.Companyid);
                sqlCommand.Parameters.AddWithValue("@IsActive", cls.IsActive);
                sqlCommand.Parameters.AddWithValue("@IsDelete", cls.IsDelete);
                sqlCommand.Parameters.AddWithValue("@Longtitute", cls.Longtitute);
                sqlCommand.Parameters.AddWithValue("@Langtiute", cls.Langtiute);
                dt = db.FillTableProc(sqlCommand, "USP_EmployeeDetails");

            }
        }
        return dt;
    }


    //=======commom fun
    public static T GetItem<T>(DataRow dr)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in dr.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    if (obj == null)
                    {
                        pro.SetValue("", dr[column.ColumnName] == DBNull.Value ? null : dr[column.ColumnName], null);
                    }
                    else
                    {
                        pro.SetValue(obj, dr[column.ColumnName] == DBNull.Value ? null : dr[column.ColumnName], null);
                    }
                else
                    continue;
            }
        }
        return obj;
    }

    //======================================= start
    // Flag: Has Dispose already been called?
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

    ~DataInterface1()
    {
        Dispose(false);
    }
    //======================================= end
}