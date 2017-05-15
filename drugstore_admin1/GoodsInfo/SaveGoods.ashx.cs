using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using drugstore_admin1.DAL;
using System.Data.SqlClient;
using System.Text;
using drugstore_admin1.Models;
using drugstore_admin1.BLL;
using System.Collections.Generic;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SaveGoods : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
                {
                int id = context.Request.QueryString["goods_id"] == null ? 0 : Int32.Parse(context.Request.QueryString["goods_id"]);
                string temp = File.ReadAllText(context.Server.MapPath( "admin_product_save.html"));

                GoodModel good = GoodsBLL.GetAGoodDetail(id);
                temp = temp.Replace("@Goods_name", good.GoodsName);
                temp = temp.Replace("@Goods_effect", good.GoodsEffect);
                temp = temp.Replace("@Goods_price", good.GoodsPrice.ToString());
                temp = temp.Replace("@Goods_norms", good.GoodsNorms.ToString());
                temp = temp.Replace("@Goods_factory", good.GoodsFactory.ToString());
                temp = temp.Replace("@Goods_stock", good.GoodsStock.ToString());
                temp = temp.Replace("@Goods_id", id.ToString());

                List<GoodsTypeModel> goodsType = GoodsTypeBLL.GetGoodsTypeList();
                StringBuilder sb = new StringBuilder();
                string selectedHtml = "";
                foreach (GoodsTypeModel item in goodsType)
                {
                    if (good.GoodsGoodsType == item.GoodsTypeid)
                    {
                        selectedHtml = "selected = 'true'";
                    }
                    sb.AppendFormat(@"<option value='{0}' {2}>{1}</option>", item.GoodsTypeid, item.GoodsTypename, selectedHtml);
                    selectedHtml = "";
                }

                temp = temp.Replace("@admin", context.Session["admin_name"].ToString());
                temp = temp.Replace("@product_type", sb.ToString());
                context.Response.Write(temp);
            }
            else
            {
                context.Response.Redirect("~/admin_login.html");
            }
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
