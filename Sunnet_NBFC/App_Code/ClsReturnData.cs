using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunnet_NBFC.App_Code
{
    public class ClsReturnData
    {
        public int MsgType { get; set; }
        public long ID { get; set; }
        public string Message { get; set; }
        public string MessageDesc { get; set; }
    }

    public enum MessageType
    {
        Unknown,
        Success,
        Fail,
        Error
        
    }
}

