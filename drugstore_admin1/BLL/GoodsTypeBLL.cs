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
using System.Web.UI.MobileControls;
using drugstore_admin1.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using drugstore_admin1.DAL;

namespace drugstore_admin1.BLL
{
    public class GoodsTypeBLL
    {
        public static List<GoodsTypeModel> GetGoodsTypeList() {
            string sqlText = "SELECT * from GoodsType where GoodsType_is_delete = 0";

            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText);
            List<GoodsTypeModel> goodsTypeList = new List<GoodsTypeModel>();
            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        GoodsTypeModel goodsType = new GoodsTypeModel();
                        goodsType.GoodsTypeid = Convert.ToInt32(sdr["GoodsType_id"]);
                        goodsType.GoodsTypename = sdr["GoodsType_name"].ToString();
                        goodsTypeList.Add(goodsType);
                    }
                    sdr.Close();
                    return goodsTypeList;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }


        public static int GoodsType1(string product_name)
        {
            string sqlText = "INSERT INTO GoodsType	VALUES(@GoodsType_name,'')";
            SqlParameter paras = new SqlParameter("@GoodsType_name", product_name);
            return SQLHelper.ExecuteNonQuery(sqlText, paras);
        }
        public static int GoodsType2(string product_name, string product_id)
        {
            string sqlText = "UPDATE GoodsType SET GoodsType_name=@GoodsType_name where GoodsType_id=@GoodsType_id";
            SqlParameter[] paras = new SqlParameter[]{
                            new SqlParameter("@GoodsType_name",product_name),
                            new SqlParameter("@GoodsType_id",product_id)
                        };
            return SQLHelper.ExecuteNonQuery(sqlText, paras);
        }
        public static int GoodsType3(string goods_id_delete)
        {
            string sqlText = "update GoodsType set GoodsType_is_delete=1 WHERE GoodsType_id=@GoodsType_id";
            SqlParameter[] paras = new SqlParameter[]{
                        new SqlParameter("@GoodsType_id",goods_id_delete)
                    };
            return SQLHelper.ExecuteNonQuery(sqlText, paras);
        }
       
    }
}
