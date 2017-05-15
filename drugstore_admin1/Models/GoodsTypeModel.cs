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
    public class GoodsTypeModel
    {
        private int goodsTypeid;
        public int  GoodsTypeid
        {
            get { return goodsTypeid; }
            set { goodsTypeid = value; }
        }
        private string  goodsTypename;
        public string  GoodsTypename
        {
            get { return goodsTypename; }
            set { goodsTypename = value; }
        }
        private int goodsTypeisdelete;
        public int GoodsType_is_delete
        {
            get { return goodsTypeisdelete; }
            set { goodsTypeisdelete = value; }
        }
    }
}
