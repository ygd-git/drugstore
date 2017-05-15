using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using drugstore_admin1.DAL;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using drugstore_admin1.BLL;
using System.Web.UI.MobileControls;
using drugstore_admin1.Models;
using System.Collections.Generic;
using Commom;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessDruginfo : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string effectId = context.Request.QueryString["effect"];

            int pageSize = 8;
            int pageIndex;
            if (!int.TryParse(context.Request.QueryString["pageIndex"],out pageIndex))
            {
                pageIndex = 1;
            }
            int pageCount = GoodsBLL.GetGoodsPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<GoodModel> GoodsList = GoodsBLL.GetGoodsList(pageIndex, pageSize);

            //string sqlText = GoodsBLL.getPaginationSql(0, pageSize, "goods", "*", "Goods_is_delete = 0", "goods_id");

           
            
            string temp = File.ReadAllText(context.Server.MapPath("drugstore_all.html"));
            StringBuilder sb = new StringBuilder();


            if (GoodsList == null)
            {
                temp = temp.Replace("@content", "该类型的商品还未上架,敬请期待.");
            }
            else
            {
                foreach (GoodModel item in GoodsList)
                {
                    sb.AppendFormat(@"<div class='col-lg-3' ><div class='thumbnail'><img src='{4}' style='height: 300px' alt='...'><div class='caption'><h3>{0}</h3><p>{1}元</p><p>总销量:{2}</p><p><a href='ProcessDrugDetails.ashx?goods_id={3}' class='btn btn-primary' role='button'>查看详情</a> <a href='../ShopCartInfo/ProcessAddCart.ashx?goods_id={3}' class='btn btn-default' role='button'>加入购物车</a></p></div></div></div>", item.GoodsName, item.GoodsPrice, item.GoodsSalesVolume, item.GoodsId, "../Images/product_img/" + item.GoodsPicture);
                }

            }

            temp = temp.Replace("@page", PageBarHelper.GetPageBar(pageIndex, pageCount));
            temp = temp.Replace("@content", sb.ToString());
            if (context.Session["users_id"] != null)
            {
                temp = temp.Replace("@user_name", context.Session["user_name"].ToString());
            }
            else
            {
                temp = temp.Replace("@user_name", "游客");
            }
            
            context.Response.Write(temp);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
