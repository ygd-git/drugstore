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
    public class NewsTypeModel
    {
        private int nwsTypeid;
        public int NewsTypeid
        {
            get { return nwsTypeid; }
            set { nwsTypeid = value; }
        }

        private string nwsTypename;
        public string NewsTypename
        {
            get { return nwsTypename; }
            set { nwsTypename = value; }
        }

        private int nwsTypeisdelete;
        public int NewsTypeisdelete
        {
            get { return nwsTypeisdelete; }
            set { nwsTypeisdelete = value; }
        }
    }
}
