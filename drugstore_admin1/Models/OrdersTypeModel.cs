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
    public class OrdersTypeModel
    {
        private int ordersTypeid;
        public int OrdersTypeid
        {
            get { return ordersTypeid; }
            set { ordersTypeid = value; }
        }
        private string  ordersTypename;
        public string  OrdersTypename
        {
            get { return ordersTypename; }
            set { ordersTypename = value; }
        }
    }
}
