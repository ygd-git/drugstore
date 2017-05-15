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
using drugstore_admin1.Models;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessDrugDetails : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id = context.Request.QueryString["goods_id"] == null ? 0 : Int32.Parse(context.Request.QueryString["goods_id"]);
            string temp=File.ReadAllText(context.Server.MapPath("drugstore_details.html"));

            GoodModel good = GoodsBLL.GetAGoodDetail(id);

            temp = temp.Replace("@goods_id", good.GoodsId.ToString());
            temp = temp.Replace("@a1", good.GoodsName);
            temp = temp.Replace("@a2", good.GoodsEffect);
            temp = temp.Replace("@a3", good.GoodsPrice.ToString());
            temp = temp.Replace("@a4", "商品规格:" + good.GoodsNorms);
            temp = temp.Replace("@a5", "生产厂家:" + good.GoodsFactory);
            temp = temp.Replace("@a6", "库存状态: " + good.GoodsStock);
            temp = temp.Replace("@a7", "../Images/product_img/" + good.GoodsPicture);
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
