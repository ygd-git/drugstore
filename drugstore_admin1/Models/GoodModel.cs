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
    public class GoodModel
    {
        public GoodModel() { 
        }
        public GoodModel(string goodsName, string goodsEffect, double goodsPrice, string goodsNorms, string goodsFactory, int goodsStock, DateTime goodsShelfTime, string goodsPicture,  int goodsGoodsType) {
            GoodsName = goodsName;
            GoodsEffect = goodsEffect;
            GoodsPrice = goodsPrice;
            GoodsNorms = goodsNorms;
            GoodsFactory = goodsFactory;
            GoodsStock = goodsStock;
            
            GoodsShelfTime = goodsShelfTime;
            GoodsPicture = goodsPicture;
            
            GoodsGoodsType = goodsGoodsType;
        }

        private int goodsId;
        public int GoodsId 
        {
            get { return goodsId; }
            set { goodsId = value; }
        }

        private string goodsName;
        public string GoodsName 
        {
            get { return goodsName; }
            set { goodsName = value; }
        }

        private string goodsEffect;
        public string GoodsEffect
        {
            get { return goodsEffect; }
            set { goodsEffect = value; }
        }

        private double goodsPrice;
        public double GoodsPrice
        {
            get { return goodsPrice; }
            set { goodsPrice = value; }
        }

        private string goodsNorms;
        public string GoodsNorms
        {
            get { return goodsNorms; }
            set { goodsNorms = value; }
        }

        private string goodsFactory;
        public string GoodsFactory
        {
            get { return goodsFactory; }
            set { goodsFactory = value; }
        }

        private int goodsStock;
        public int GoodsStock
        {
            get { return goodsStock; }
            set { goodsStock = value; }
        }

        private int goodsSalesVolume;
        public int GoodsSalesVolume
        {
            get { return goodsSalesVolume; }
            set { goodsSalesVolume = value; }
        }

        private DateTime goodsShelfTime;
        public DateTime GoodsShelfTime
        {
            get { return goodsShelfTime; }
            set { goodsShelfTime = value; }
        }

        private string  goodsPicture;
        public string GoodsPicture
        {
            get { return goodsPicture; }
            set { goodsPicture = value; }
        }

        private string goodsIsDelete;
        public string GoodsIsDelete
        {
            get { return goodsIsDelete; }
            set { goodsIsDelete = value; }
        }

        private int goodsGoodsType;
        public int GoodsGoodsType
        {
            get { return goodsGoodsType; }
            set { goodsGoodsType = value; }
        }
    }
}
