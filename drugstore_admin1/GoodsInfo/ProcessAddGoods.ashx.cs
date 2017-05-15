using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using drugstore_admin1.DAL;
using drugstore_admin1.Models;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAddGoods : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
            {
                string name = context.Request.Form["name"];
                string effect = context.Request.Form["effect"];
                string price = context.Request.Form["price"];
                string factory = context.Request.Form["factory"];
                string stock = context.Request.Form["stock"];
                string norms = context.Request.Form["norms"];
                string type = context.Request.Form["type"];
                HttpPostedFile imgFile = context.Request.Files[0];
                //Image img = new Bitmap(imgFile.InputStream);
                string newFileName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + System.IO.Path.GetExtension(imgFile.FileName).ToLower();
                imgFile.SaveAs(context.Server.MapPath("~/Images/product_img/" + newFileName));



                GoodModel good = new GoodModel(name, effect, Convert.ToDouble(price), norms, factory, Convert.ToInt32(stock), DateTime.Now, newFileName, Convert.ToInt32(type));
                int i = GoodsBLL.AddGood(good);
                if (i>0)
                {
                    context.Response.Write("新增成功!");
                }
                else
                {
                    context.Response.Write("新增失败!");
                }
                context.Response.Write("<a href='ProcessAdminProduct.ashx'>回到商品首页</a>");
                //context.Response.Write(name + "/" + effect + "/" + price + "/" + factory + "/" + stock + "/" + norms + "/");
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
