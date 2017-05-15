using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using drugstore_admin1.DAL;
using System.IO;

namespace drugstore_admin1.OrderInfo
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessOrderIndex : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string temp = File.ReadAllText(context.Server.MapPath("drugstore_order.html"));
            if (context.Session["users_id"] != null)
            {


                string sqlText = "SELECT * FROM Orders WHERE Order_users_id = @Order_users_id  ORDER BY Order_time DESC";
                SqlParameter para = new SqlParameter("@Order_users_id", Int32.Parse(context.Session["users_id"].ToString()));
                DataTable dt = SQLHelper.ExecuteDataTable(sqlText,para);
                StringBuilder sb = new StringBuilder();
                foreach (DataRow item in dt.Rows)
                {
                    sb.AppendFormat("<div class='panel panel-default'><div class='panel-heading'><b>{0}</b>订单号: <span>{1}</span> {2}<span class='pull-right'>是否发货:{5}</span><span class='pull-right'>手机:{3}</span><span class='pull-right'>&nbsp;</span><span class='pull-right'>{4}</span> </div><table class='table table-bordered'><thead><tr><td>#</td><td>药品名</td><td>治疗症状</td><td>数量</td></tr></thead><tbody>", item["order_time"], item["order_number"], "", item["order_phone"], item["order_adress"],item["order_issend"]);
                    string sqlText1 = "select * from goodsorder where gdod_order_id = @gdod_order_id";
                    SqlParameter[] paras1 = new SqlParameter[]{
                        new SqlParameter("@gdod_order_id",item["order_id"])
                    };
                    DataTable dt1 = SQLHelper.ExecuteDataTable(sqlText1, paras1);
                    foreach (DataRow item1 in dt1.Rows)
                    {
                        string sqlText2 = "select top 1 * from goods where goods_id = @goods_id";
                        SqlParameter[] paras = new SqlParameter[]{
                            new SqlParameter("@goods_id",item1["gdod_goods_id"])
                        };
                        DataTable dt2 = SQLHelper.ExecuteDataTable(sqlText2, paras);
                        //dt2.Rows[0].item[""]
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", dt2.Rows[0]["goods_id"], dt2.Rows[0]["goods_name"], dt2.Rows[0]["goods_effect"], item1["gdod_order_count"]);
                    }
                    sb.AppendFormat("</tbody></table></div> ");
                }

                temp = temp.Replace("@content", sb.ToString());
                temp = temp.Replace("@user_name", context.Session["user_name"].ToString());
                
                    
                
                context.Response.Write(temp);
            }
            else
            {
                temp = temp.Replace("@user_name", "游客");
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
