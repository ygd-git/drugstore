using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using drugstore_admin1.DAL;
using System.Text;
using drugstore_admin1.BLL;

namespace drugstore_admin1.ShopCartInfo
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessShoppingIndex : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["users_id"] != null)
            {
                string temp = File.ReadAllText(context.Server.MapPath("drugstore_shopping_cart.html"));
                
                DataTable dt = ShopCartBLL.Cart12(context.Session["users_id"].ToString());
                StringBuilder sb = new StringBuilder();
                foreach (DataRow item in dt.Rows)
                {
                    //goods_id  item["cart_goods_id"]
                    
                    DataTable dt2 = ShopCartBLL.Cart13(item["cart_goods_id"].ToString());
                    sb.AppendFormat("<tr><td><label><input type='checkbox' class='product' name='{0}'>{1}</label></td><td>{2}...</td><td class='price'>{3}元</td><td style='width:200px'><div class='input-group' ><span class='input-group-addon reduceNum' >-</span><input type='text' name='num{0}' value='{4}' class='form-control' ><span class='input-group-addon addNum'>+</span><span>件</span></div></td><td class='money'>¥</td><td><a class='btn btn-danger' href='ProcessShopCartDelete.ashx?cart_id={0}'>删除</a></td></tr>", item["cart_id"], dt2.Rows[0]["Goods_name"], dt2.Rows[0]["Goods_effect"], dt2.Rows[0]["Goods_price"],item["cart_count"]);
                }
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
            else
            {
                context.Response.Write("登陆后再来使用购物车吧!<a href='../drugstore_login.html'>登录页面</a>");
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
