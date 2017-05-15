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
using drugstore_admin1.BLL;

namespace drugstore_admin1.ShopCartInfo
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessSettlemet : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            
            //建订单表 空(时间)
            bool flag = true;
            int orderId = 0;
            
            string orderNumber = ShopCartBLL.GetRandomOrderNumber();
            
            int i3 = ShopCartBLL.Cart4(orderNumber, context.Request.Form["address"].ToString(), context.Request.Form["phone"].ToString(), context.Session["users_id"].ToString());
            
            for (int i = 0; i < context.Request.Form.Count; i++)
            {
                if (context.Request.Form[i] == "on")
                {
                    int cartId = Int32.Parse(context.Request.Form.GetKey(i));
                    int count =Int32.Parse( context.Request.Form["num" + context.Request.Form.GetKey(i)]);

                    
                    
            		
                    DataTable dt2 = ShopCartBLL.Cart5(cartId);
                    
                    int i2 = ShopCartBLL.Cart6(cartId);
                    if (i2>0)
	                {
                        flag = false;
                        
                        //dt2.Rows[0]["Cart_goods_id"]    dt2.Rows[0]["Cart_users_id"]
                        //根据唯一的订单号获取添加的cart_id
                        
                        DataTable dt4 = ShopCartBLL.Cart7(orderNumber);
                        //dt4.Rows[0]["cart_id"]
                        orderId = Int32.Parse(dt4.Rows[0]["order_id"].ToString());
                        
                        int i5 = ShopCartBLL.Cart8(Int32.Parse(dt2.Rows[0]["Cart_goods_id"].ToString()), count, orderId);

                        //计算销量
                        
                        int i7 = ShopCartBLL.Cart9(Int32.Parse(dt2.Rows[0]["Cart_goods_id"].ToString()), count);
	                }

                }
            }
            if (flag)
            {
                //falg为true时 说明没有订单商品属于该订单  需要删除时间为1900-01-01 00:00:00.000的订单
                
                int i6 = ShopCartBLL.Cart10(orderId);
                context.Response.Write("结算失败,请重试<a href='ProcessShoppingIndex.ashx'>购物车</a>");
            }
            else
            {
                
                context.Response.Write("收货地址:"+context.Request.Form["address"] + "    联系电话:"+context.Request.Form["phone"]+"   ");
                context.Response.Write("购买成功!<a href='../OrderInfo/ProcessOrderIndex.ashx'>前往查看订单</a>");

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
