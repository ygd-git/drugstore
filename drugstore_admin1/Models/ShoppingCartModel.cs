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
    public class ShoppingCartModel
    {
        private int cartId;
        public int CartId 
        { 
            get; 
            set; 
        }

        private int cartGoodsId;
        public int CartGoodsId
        {
            get;
            set;
        }

        private int cartCount;
        public int CartCount
        {
            get;
            set;
        }

        private double cartPrice;
        public double CartPrice
        {
            get;
            set;
        }

        private int cartUsersId;
        public int CartUsersId
        {
            get;
            set;
        }
    }
}
