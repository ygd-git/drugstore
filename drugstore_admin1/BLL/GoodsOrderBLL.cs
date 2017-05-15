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
    public class GoodsOrderBLL
    {
        public static List<GoodsorderModel> GetGoodsOrderListById(int id) {
            string sqlText = "select * from goodsorder where gdod_order_id = @gdod_order_id";
            SqlParameter[] paras = new SqlParameter[]{
                        new SqlParameter("@gdod_order_id",id)
                    };
            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText,paras);
            List<GoodsorderModel> goodsorderList = new List<GoodsorderModel>();

            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        GoodsorderModel goodsOrder = new GoodsorderModel(Convert.ToInt32( sdr["Gdod_id"]), Convert.ToInt32(sdr["Gdod_goods_id"]), Convert.ToInt32(sdr["Gdod_order_count"]), Convert.ToInt32(sdr["Gdod_order_id"]));

                        goodsorderList.Add(goodsOrder);
                    }
                    sdr.Close();
                    return goodsorderList;
                }
                else
                    return null;
            }
            else
                return null;
        }
    }
}
