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

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAddCart : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["users_id"] != null)
            {
                int id = context.Request.QueryString["goods_id"] == null ? 0 : Int32.Parse(context.Request.QueryString["goods_id"]);

                //在主页添加时默认等于1
                int addNum = 1;
                if (context.Request.Form["goods_num"] != null)
                {
                    addNum = Int32.Parse(context.Request.Form["goods_num"]);
                }
                if (id == 0)
                {
                    if (true)
                    {

                    }
                    context.Response.Redirect("../GoodsInfo/ProcessDruginfo.ashx");

                }

                
                DataTable dt = ShopCartBLL.Cart1(id, context.Session["users_id"].ToString());




                if (dt.Rows.Count > 0)
                {
                    
                    int i = ShopCartBLL.Cart2((Convert.ToInt32(dt.Rows[0]["cart_count"]) + addNum).ToString(), id, context.Session["users_id"].ToString());
                    context.Response.Redirect("../GoodsInfo/ProcessDruginfo.ashx");
                }
                else
                {

                    

                    int i = ShopCartBLL.Cart3(id, addNum, context.Session["users_id"].ToString());
                    if (i > 0)
                    {

                        context.Response.Redirect("../GoodsInfo/ProcessDruginfo.ashx");


                    }
                    else
                    {

                        context.Response.Redirect("../GoodsInfo/ProcessDruginfo.ashx");

                    }
                }
            }
            else
            {
                context.Response.Redirect("~/drugstore_login.html");
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
