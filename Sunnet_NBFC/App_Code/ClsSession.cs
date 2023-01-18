using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunnet_NBFC.App_Code
{
    public static class ClsSession
    {
        private static int _CompanyID = 1;
        public static int CompanyID
        {
            get { 
                return _CompanyID; 
            }
            set
            {
                _CompanyID=value;
            }
        }

        private static int _UserID = 1;
        public static int UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

    }
}