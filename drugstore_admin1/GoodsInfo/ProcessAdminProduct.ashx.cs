using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using drugstore_admin1.DAL;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using drugstore_admin1.Models;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminProduct : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
            {
                
                List<GoodModel> goodsList = new List<GoodModel>();
                if (context.Request.Form["name"] != null)
	            {


                    goodsList = GoodsBLL.GetGoodsListBySearch(context.Request.Form["name"].ToString());
                }
                else
                {
                    goodsList = GoodsBLL.GetGoodsList2();
                }
                
                //读取模板
                string temp = File.ReadAllText(context.Server.MapPath("admin_product.html"));
                //删除文本
                //string deleteText = "'确认要删除{1}的商品?'";
                StringBuilder sb = new StringBuilder();
                foreach (GoodModel item in goodsList)
                {
                    sb.AppendFormat(@"<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><a href='DeleteGoods.ashx?goods_id={0}' class='btn btn-danger'>删除</a><a href='SaveGoods.ashx?goods_id={0}' class='btn btn-primary'>修改</a></td></tr>", item.GoodsId, item.GoodsName, item.GoodsPrice + "元", item.GoodsStock + "件");
                }
                temp = temp.Replace("@content", sb.ToString());
                temp = temp.Replace("@admin", context.Session["admin_name"].ToString());
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
