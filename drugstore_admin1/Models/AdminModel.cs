using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace drugstore_admin1.Models
{
    public class AdminModel
    {
        private int adminId;
        public int AdminId 
        {
            get { return adminId;}
            set { adminId = value; }
        }

        private string adminName;
        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }

        private string adminPwd;
        public string AdminPwd
        {
            get { return adminPwd; }
            set { adminPwd = value; }
        }

        private DateTime adminLastting;
        public DateTime AdminLastting
        {
            get { return adminLastting; }
            set { adminLastting = value; }
        }

        private int adminQuanxian;
        public int AdminQuanxian
        {
            get { return adminQuanxian; }
            set { adminQuanxian = value; }
        }


        private string adminPhone;
        public string AdminPhone {
            get { return adminPhone; } 
            set{  adminPhone=value;}
        }
    }
}
