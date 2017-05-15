using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using drugstore_admin1.DAL;
using System.Text;
using System.Data.SqlClient;
using drugstore_admin1.BLL;
using drugstore_admin1.Models;
using System.Collections.Generic;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminOrder : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
            {
                string temp = File.ReadAllText(context.Server.MapPath("drugstore_admin_order.html"));
                if (context.Request.Form["goods_number"] != null)
                {
                    int i = OrderBLL.SendOrder(context.Request.Form["goods_number"].ToString());

                }

                List<OrdersModel> orderList = new List<OrdersModel>();
                if (context.Request.Form["name"] == null)
                {
                    orderList = OrderBLL.GetOrderByIsend();
                }
                else
                {
                    orderList = OrderBLL.GetOrderByName(context.Request.Form["name"].ToString());
                }
                
                StringBuilder sb = new StringBuilder();
                if (orderList != null)
                {
                    foreach (OrdersModel item in orderList)
                    {
                        sb.AppendFormat("<div class='panel panel-default'><div class='panel-heading'><b>{0}</b>订单号: <span>{1}</span> <span class='pull-right'>是否发货:{5}</span><span class='pull-right'>买家ID:{2}</span><span class='pull-right'>&nbsp;</span><span class='pull-right'>手机:{3}</span><span class='pull-right'>&nbsp;</span><span class='pull-right'>{4}</span> </div><table class='table table-bordered'><thead><tr><td>#</td><td>药品名</td><td>治疗症状</td><td>数量</td></tr></thead><tbody>", item.Ordertime, item.Ordernumber, item.Orderusersid.ToString(), item.Orderphone, item.Orderadress, item.OrderIssend);
                        List<GoodsorderModel> dt1 = GoodsOrderBLL.GetGoodsOrderListById(item.Orderid);
                        foreach (GoodsorderModel item1 in dt1)
                        {

                            GoodModel goods = GoodsBLL.GetAGoodDetail(item1.Gdod_goods_id);
                            //dt2.Rows[0].item[""]
                            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", goods.GoodsId, goods.GoodsName, goods.GoodsEffect, item1.Gdod_order_count);
                        }
                        sb.AppendFormat("</tbody></table></div> ");
                    }
                }
                



                temp = temp.Replace("@admin", context.Session["admin_name"].ToString());
                temp = temp.Replace("@content", sb.ToString());
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
