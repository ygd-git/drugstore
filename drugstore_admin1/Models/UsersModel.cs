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
    public class UsersModel
    {
        private int  usersId;
        public int UsersId
        {
            get { return usersId; }
            set { usersId = value; }
        }
        private string  usersName;
        public string  UsersName
        {
            get { return usersName; }
            set { usersName = value; }
        }
        private string usersPsw;
        public string UsersPsw
        {
            get { return usersPsw; }
            set { usersPsw = value; }
        }
        private DateTime usersLoginTime;
        public DateTime UsersLoginTime
        {
            get { return usersLoginTime; }
            set { usersLoginTime = value; }
        }
        private string usersAvailable;
        public string UsersAvailable
        {
            get { return usersAvailable; }
            set { usersAvailable = value; }
        }
        private string usersAccount;
        public string UsersAccount
        {
            get { return usersAccount; }
            set { usersAccount = value; }
        }


    }
}
