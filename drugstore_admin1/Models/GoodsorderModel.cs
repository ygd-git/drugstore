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
    public class GoodsorderModel
    {
        public GoodsorderModel() { 
        
        }
        public GoodsorderModel(int gdod_id, int gdod_goods_id, int gdod_order_count, int gdod_order_id)
        { 
            Gdod_id = gdod_id;
            Gdod_goods_id = gdod_goods_id;
            Gdod_order_count = gdod_order_count;
            Gdod_order_id = gdod_order_id;
        }
        private int gdod_id;
        public int Gdod_id
        {
            get { return gdod_id; }
            set { gdod_id = value; }
        }
        private int gdod_goods_id;
        public int Gdod_goods_id
        {
            get { return gdod_goods_id; }
            set { gdod_goods_id = value; }
        }
        private int gdod_order_count;
        public int Gdod_order_count
        {
            get { return gdod_order_count; }
            set { gdod_order_count = value; }
        }
        private int gdod_order_id;
        public int Gdod_order_id
        {
            get { return gdod_order_id; }
            set { gdod_order_id = value; }
        }
    }
}
