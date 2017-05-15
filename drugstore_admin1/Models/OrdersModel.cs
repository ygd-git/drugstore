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
    public class OrdersModel
    {
        public OrdersModel(int orderid, string ordernumber, string orderadress, string orderphone, int orderusersid, DateTime ordertime, string orderIssend)
        {
            Orderid = orderid;
            Ordernumber = ordernumber;
            Orderadress = orderadress;
            Orderphone = orderphone;
            Orderusersid = orderusersid;
            Ordertime = ordertime;
            OrderIssend = orderIssend;
        }
        private int orderid;
        public int Orderid
        {
            get { return orderid; }
            set { orderid = value; }
        }

        private string  ordernumber;
        public string  Ordernumber
        {
            get { return ordernumber; }
            set { ordernumber = value; }
        }

        private string orderadress;
        public string Orderadress
        {
            get { return orderadress; }
            set { orderadress = value; }
        }

        private string orderphone;
        public string Orderphone
        {
            get { return orderphone; }
            set { orderphone = value; }
        }

        private int orderusersid;
        public int Orderusersid
        {
            get { return orderusersid; }
            set { orderusersid = value; }
        }

        private DateTime  ordertime;
        public DateTime  Ordertime
        {
            get { return ordertime; }
            set { ordertime = value; }
        }

        private string orderIssend;
        public string OrderIssend
        {
            get { return orderIssend; }
            set { orderIssend = value; }
        }
        
    }
}
