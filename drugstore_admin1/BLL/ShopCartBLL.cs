using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using drugstore_admin1.DAL;
using System.Data.SqlClient;

namespace drugstore_admin1.BLL
{
    public class ShopCartBLL
    {
        public static string GetRandomOrderNumber() {
            int numberLength = 11;
            Random r = new Random();
            string rst = "";
            for (int i = 1; i < 11; i++)
            {
                rst += r.Next(1, 9);
            }
            return rst;
        }

        public static DataTable Cart1(int id,string users_id) {
            string sqlText = "select * from Shoppingcart where Cart_goods_id=@cart_goods_id and Cart_users_id=@users_id";
            SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@cart_goods_id",id),
                    new SqlParameter("@users_id",users_id)
                };
            return SQLHelper.ExecuteDataTable(sqlText, paras);
        }

        public static int Cart2(string count,int id, string users_id)
        {

            string addsql = "update Shoppingcart set Cart_count=@count where Cart_goods_id=@goods_id and Cart_users_id=@users_id";
            SqlParameter[] addspa = new SqlParameter[]
                        {
                            new SqlParameter("@count",count),
                            new SqlParameter("@goods_id",id),
                            new SqlParameter("@users_id",users_id)
                        };
            return SQLHelper.ExecuteNonQuery(addsql, addspa);
        }

        public static int Cart3(int id, int addNum, string users_id)
        {
            string sql = "insert into Shoppingcart values(@goods_id,@count,@users_id)";
            SqlParameter[] spa = new SqlParameter[]
                    {
                        new SqlParameter("@goods_id",id),
                        new SqlParameter ("@count",addNum),
                        new SqlParameter("@users_id",users_id)
                    };

            return SQLHelper.ExecuteNonQuery(sql, spa);
        }

        public static int Cart4(string orderNumber, string address, string phone, string users_id)
        {
            string sqlText3 = "INSERT INTO Orders VALUES(@number,@address,@phone,@user_id,@datetime,0)";
            
            SqlParameter[] paras3 = new SqlParameter[]{
                new SqlParameter("@number",orderNumber),
                new SqlParameter("@address",address),
                new SqlParameter("@phone",phone),
                new SqlParameter("@user_id",users_id),
                new SqlParameter("@datetime",DateTime.Now)
            };
            return SQLHelper.ExecuteNonQuery(sqlText3, paras3);
        }
        /// <summary>
        /// 获得结算的商品id 和 用户ID
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public static DataTable Cart5(int cartId)
        {
            string sqlText2 = "SELECT * FROM Shoppingcart WHERE Cart_id = @Cart_id";
            SqlParameter para2 = new SqlParameter("@Cart_id", cartId);
            return SQLHelper.ExecuteDataTable(sqlText2, para2);
        }
        /// <summary>
        /// 删除购物车中要结算的商品
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public static int Cart6( int cartId) {
            string sqlText = "DELETE FROM Shoppingcart WHERE Cart_id = @Cart_id";
            SqlParameter para = new SqlParameter("@Cart_id", cartId);
            return SQLHelper.ExecuteNonQuery(sqlText, para);
        }
        public static DataTable Cart7(string orderNumber)
        {
            string sqlText4 = "SELECT * FROM Orders WHERE Order_number = @Order_number";
            SqlParameter para4 = new SqlParameter("@Order_number", orderNumber);
            return SQLHelper.ExecuteDataTable(sqlText4, para4);
        }
        public static int Cart8(int Cart_goods_id, int count, int orderId)
        {
            string sqlText5 = "INSERT INTO Goodsorder VALUES(@goods_id,@order_count,@order_id)";
            SqlParameter[] paras5 = new SqlParameter[]{
                new SqlParameter("@goods_id",Cart_goods_id),
                new SqlParameter("@order_count",count),
                new SqlParameter("order_id",orderId)
            };
            return SQLHelper.ExecuteNonQuery(sqlText5, paras5);
        }
        /// <summary>
        /// 计算销量
        /// </summary>
        /// <returns></returns>
        public static int Cart9(int Cart_goods_id, int count)
        {
            string sqlText7 = "UPDATE Goods SET Goods_sales_volume= ((SELECT TOP 1 Goods_sales_volume WHERE Goods_id = @goods_id)+@Goods_sales_volume)WHERE goods_id = @goods_id";
            SqlParameter[] paras7 = new SqlParameter[]{
                            new SqlParameter("@goods_id",Cart_goods_id),
                            new SqlParameter("@Goods_sales_volume",count)
                        };
            return SQLHelper.ExecuteNonQuery(sqlText7, paras7);
        }
        public static int Cart10(int orderId)
        {
            string sqlText6 = "DELETE FROM Orders WHERE Order_id = @Order_id ";
            SqlParameter para6 = new SqlParameter("@Order_id", orderId);
            return SQLHelper.ExecuteNonQuery(sqlText6, para6);
        }

        public static int Cart11(int cartId)
        {
            string sqlText = "DELETE FROM Shoppingcart WHERE Cart_id = @Cart_id";
            SqlParameter para = new SqlParameter("@Cart_id", cartId);
            return SQLHelper.ExecuteNonQuery(sqlText, para);
        
        }

        public static DataTable Cart12(string users_id)
        {
            string sqlText = "SELECT * from	Shoppingcart WHERE Cart_users_id = @Cart_users_id";
            SqlParameter para = new SqlParameter("@Cart_users_id", users_id);
            return SQLHelper.ExecuteDataTable(sqlText, para);
        }

        public static DataTable Cart13(string cart_goods_id)
        {
            string sqlText2 = "SELECT * from Goods WHERE Goods_id = @Goods_id and Goods_is_delete = 0";
            SqlParameter para2 = new SqlParameter("@Goods_id", cart_goods_id);
            return SQLHelper.ExecuteDataTable(sqlText2, para2);
        }
        
    }
}
