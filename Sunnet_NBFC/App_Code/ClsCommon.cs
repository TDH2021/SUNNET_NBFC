using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunnet_NBFC.App_Code
{
    public class ClsCommon
    {
        public static SelectList ToSelectList(DataTable table, string valueField, string textField)
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

        public static void GETClassFromDt(DataTable dt,ref ClsReturnData clsRtn)
        {
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

        public static SelectList AnswerDDL()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem()
                {
                    Text = "Satisfactory",
                    Value = "Satisfactory"
            });

            list.Add(new SelectListItem()
            {
                Text = "Not Satisfactory",
                Value = "Not Satisfactory",
                Selected = true
            }) ;

            return new SelectList(list, "Value", "Text");
        }

        public static SelectList StatusDDL(string StatusType)
        {
            DataTable Dt = DataInterface2.GetStatusForDDL(StatusType);
            //return new SelectList(Dt.AsEnumerable(), "Status", "StatusDesc");
            return ToSelectList(Dt, "Status", "StatusDesc");
        }
        public static bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".bmp":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".png":
                    return true;
                default:
                    return false;
            }
        }


    }
}