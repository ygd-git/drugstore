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
using drugstore_admin1.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using drugstore_admin1.DAL;

namespace drugstore_admin1.BLL
{
    public class OrderBLL
    {
        public static int SendOrder(string number) {
            string sqlText = "UPDATE Orders SET Order_issend = 1 WHERE Order_number = @Order_number";
            SqlParameter para = new SqlParameter("@Order_number", number);
            int i = SQLHelper.ExecuteNonQuery(sqlText, para);
            return i;
        }

        public static List<OrdersModel> GetOrderByIsend() {
            string sqlText = "select * from orders ORDER BY Order_issend";

            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText);
            List<OrdersModel> orderList = new List<OrdersModel>();

            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        OrdersModel order = new OrdersModel(Convert.ToInt32( sdr["Order_id"]), sdr["Order_number"].ToString(), sdr["Order_adress"].ToString(), sdr["Order_phone"].ToString(),Convert.ToInt32( sdr["Order_users_id"]),Convert.ToDateTime( sdr["Order_time"]), sdr["Order_issend"].ToString());

                        orderList.Add(order);
                    }
                    sdr.Close();
                    return orderList;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public static List<OrdersModel> GetOrderByName(string name)
        {
            string sqlText = "SELECT * FROM Orders WHERE Order_number LIKE @name";
            SqlParameter para = new SqlParameter("@name", "%" + name + "%");

            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText,para);
            List<OrdersModel> orderList = new List<OrdersModel>();

            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        OrdersModel order = new OrdersModel(Convert.ToInt32(sdr["Order_id"]), sdr["Order_number"].ToString(), sdr["Order_adress"].ToString(), sdr["Order_phone"].ToString(), Convert.ToInt32(sdr["Order_users_id"]), Convert.ToDateTime(sdr["Order_time"]), sdr["Order_issend"].ToString());

                        orderList.Add(order);
                    }
                    sdr.Close();
                    return orderList;
                }
                else
                    return null;
            }
            else
                return null;
        }
    }
}
