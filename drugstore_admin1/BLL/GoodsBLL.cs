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
using System.Web.UI.MobileControls;
using drugstore_admin1.Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace drugstore_admin1.BLL
{
    public class GoodsBLL
    {
        /// <summary>
        /// 获得全部商品页分页的页数
        /// </summary>
        /// <param name="pageSize">每页显示的商品数</param>
        /// <returns>页数</returns>
        public static int GetGoodsPageCount(int pageSize) {
            string sqlText = "SELECT COUNT(*) FROM Goods WHERE Goods_is_delete = 0";
            int pageCount = Int32.Parse(SQLHelper.ExecuteScalar(sqlText).ToString());
            int rst = Convert.ToInt32(Math.Ceiling((double)pageCount / pageSize));
            return rst;
        }
        /// <summary>
        /// 获得分页后该页显示的商品列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns>商品列</returns>
        public static List<GoodModel> GetGoodsList(int pageIndex, int pageSize) {

            int start = (pageIndex - 1) * pageSize + 1;
            //int end = pageIndex * pageSize;
            string sqlText = getPaginationSql(start, pageSize, "goods", "*", "Goods_is_delete = 0", "goods_id");
            
            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText);
            List<GoodModel> goodsList = new List<GoodModel>();
            if (sdr!=null)
	        {
        		 if (sdr.HasRows)
	            {
                     while (sdr.Read())
	                {
            	         GoodModel goodModel = new GoodModel();
                         goodModel.GoodsId =Convert.ToInt32(sdr["Goods_id"]);
                         goodModel.GoodsName = sdr["Goods_name"].ToString();
                         goodModel.GoodsPrice = Convert.ToInt32(sdr["Goods_price"]);
                         goodModel.GoodsSalesVolume = Convert.ToInt32(sdr["Goods_sales_volume"]);
                         goodModel.GoodsPicture = sdr["Goods_picture"].ToString();
                         goodsList.Add(goodModel);  
	                }
                     sdr.Close();
        		     return goodsList;
	            }else
	            {
                    return null;                   
	            }
	        }else
	        {
                return null;
	        }
        }
        /// <summary>
        /// 分页sql语句
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="tableName"></param>
        /// <param name="fields"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public static String getPaginationSql(int start, int limit, String tableName, String fields, String filter, String orderBy)
        {
            String sql = "SELECT TOP " + limit + " * FROM "
            + "( "
            + "SELECT ROW_NUMBER() OVER (ORDER BY " + orderBy + ") AS RowNumber," + fields + " FROM " + tableName +
                    ((filter != null) ? " where " + filter : "")
            + ") A "
            + " WHERE RowNumber >= " + start;
            return sql;
        }
        /// <summary>
        /// 删除一个商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteGoodsById(int id) {
            string sqlText = "update goods set goods_is_delete=1 where goods_id = @id";
            return SQLHelper.ExecuteNonQuery(sqlText, new SqlParameter("@id", id));
        }
        /// <summary>
        /// 根据商品类型  get商品列表
        /// </summary>
        /// <param name="effectId"></param>
        /// <returns></returns>
        public static List<GoodModel> GetGoodsListByEffectId(string effectId) {
            string sqlText = "SELECT * FROM Goods WHERE Goods_is_delete = 0 and Goods_GoodsType = @Goods_GoodsType";

            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText, new SqlParameter("@Goods_GoodsType", effectId));
            List<GoodModel> goodsList = new List<GoodModel>();
            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        GoodModel goodModel = new GoodModel();
                        goodModel.GoodsId = Convert.ToInt32(sdr["Goods_id"]);
                        goodModel.GoodsName = sdr["Goods_name"].ToString();
                        goodModel.GoodsPrice = Convert.ToInt32(sdr["Goods_price"]);
                        goodModel.GoodsSalesVolume = Convert.ToInt32(sdr["Goods_sales_volume"]);
                        goodModel.GoodsPicture = sdr["Goods_picture"].ToString();
                        goodsList.Add(goodModel);
                    }
                    sdr.Close();
                    return goodsList;
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

        /// <summary>
        /// 根据搜索值  get商品列表
        /// </summary>
        /// <param name="goodsName"></param>
        /// <returns></returns>
        public static List<GoodModel> GetGoodsListBySearch(string goodsName) {
            string sqlText = "SELECT * FROM Goods WHERE Goods_name LIKE @Goods_name and Goods_is_delete = 0";
            SqlParameter para = new SqlParameter("@Goods_name", "%" + goodsName + "%");

            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText, para);
            List<GoodModel> goodsList = new List<GoodModel>();
            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        GoodModel goodModel = new GoodModel();
                        goodModel.GoodsId = Convert.ToInt32(sdr["Goods_id"]);
                        goodModel.GoodsName = sdr["Goods_name"].ToString();
                        goodModel.GoodsPrice = Convert.ToInt32(sdr["Goods_price"]);
                        goodModel.GoodsSalesVolume = Convert.ToInt32(sdr["Goods_sales_volume"]);
                        goodModel.GoodsStock = Convert.ToInt32(sdr["Goods_stock"]);
                        goodModel.GoodsPicture = sdr["Goods_picture"].ToString();
                        goodsList.Add(goodModel);
                    }
                    sdr.Close();
                    return goodsList;
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
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="good"></param>
        /// <returns></returns>
        public static int AddGood(GoodModel good) {
            string sqlText = "INSERT into   Goods  VALUES(@Goods_name,@Goods_effect,@Goods_price,@Goods_norms,@Goods_factory,@Goods_stock,'',@Goods_shelf_time,@Goods_picture,@Goods_is_delete,@Goods_GoodsType)";
            SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@Goods_name",good.GoodsName),
                    new SqlParameter("@Goods_effect",good.GoodsEffect),
                    new SqlParameter("@Goods_price",good.GoodsPrice),
                    new SqlParameter("@Goods_factory",good.GoodsFactory),
                    new SqlParameter("@Goods_stock",good.GoodsStock),
                    new SqlParameter("@Goods_norms",good.GoodsNorms),
                    new SqlParameter("@Goods_picture",good.GoodsPicture),
                    new SqlParameter("@Goods_shelf_time",good.GoodsShelfTime),
                    new SqlParameter("@Goods_is_delete",""),
                    new SqlParameter("@Goods_GoodsType",good.GoodsGoodsType)
                };
            return SQLHelper.ExecuteNonQuery(sqlText, paras);
        }
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="good"></param>
        /// <returns></returns>
        public static int UpdateGood(GoodModel good)
        {
            string sqlText = "UPDATE Goods SET Goods_name= @Goods_name,Goods_effect=@Goods_effect,  Goods_price=@Goods_price, Goods_norms=@Goods_norms, Goods_factory=@Goods_factory, Goods_picture=@Goods_picture, Goods_stock=@Goods_stock,Goods_GoodsType=@Goods_GoodsType WHERE Goods_id=@Goods_id";
            SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@Goods_id",good.GoodsId),
                    new SqlParameter("@Goods_name",good.GoodsName),
                    new SqlParameter("@Goods_effect",good.GoodsEffect),
                    new SqlParameter("@Goods_price",good.GoodsPrice),
                    new SqlParameter("@Goods_factory",good.GoodsFactory),
                    new SqlParameter("@Goods_stock",good.GoodsStock),
                    new SqlParameter("@Goods_norms",good.GoodsNorms),
                    new SqlParameter("@Goods_picture",good.GoodsPicture),                    
                    new SqlParameter("@Goods_GoodsType",good.GoodsGoodsType)
                };
            return SQLHelper.ExecuteNonQuery(sqlText, paras);
        }

        /// <summary>
        /// get商品列表
        /// </summary>
        /// <returns></returns>
        public static List<GoodModel> GetGoodsList2() {
            string sqlText = "select * from Goods where goods_is_delete = 0";

            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText);
            List<GoodModel> goodsList = new List<GoodModel>();
            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        GoodModel goodModel = new GoodModel();
                        goodModel.GoodsId = Convert.ToInt32(sdr["Goods_id"]);
                        goodModel.GoodsName = sdr["Goods_name"].ToString();
                        goodModel.GoodsPrice = Convert.ToInt32(sdr["Goods_price"]);
                        goodModel.GoodsSalesVolume = Convert.ToInt32(sdr["Goods_sales_volume"]);
                        goodModel.GoodsStock = Convert.ToInt32(sdr["Goods_stock"]);
                        goodModel.GoodsPicture = sdr["Goods_picture"].ToString();
                        goodsList.Add(goodModel);
                    }
                    sdr.Close();
                    return goodsList;
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
        /// <summary>
        /// get商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GoodModel GetAGoodDetail(int id) {
            string sqlText = "select * from Goods where Goods_id=@goods_id";
            SqlParameter[] spa = new SqlParameter[]
            {
                new SqlParameter("@goods_id",id)
            };
            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText,spa);
            GoodModel goodModel = new GoodModel();
            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        
                        goodModel.GoodsId = Convert.ToInt32(sdr["Goods_id"]);
                        goodModel.GoodsName = sdr["Goods_name"].ToString();
                        goodModel.GoodsEffect = sdr["Goods_effect"].ToString();
                        goodModel.GoodsPrice = Convert.ToInt32(sdr["Goods_price"]);
                        goodModel.GoodsNorms = sdr["Goods_norms"].ToString();
                        goodModel.GoodsFactory = sdr["Goods_factory"].ToString();

                        goodModel.GoodsSalesVolume = Convert.ToInt32(sdr["Goods_sales_volume"]);
                        goodModel.GoodsStock = Convert.ToInt32(sdr["Goods_stock"]);
                        goodModel.GoodsPicture = sdr["Goods_picture"].ToString();

                        goodModel.GoodsGoodsType = Convert.ToInt32(sdr["Goods_GoodsType"]);
                    }
                    sdr.Close();
                    return goodModel;
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

        /// <summary>
        ///  get销量最高的6个商品列表
        /// </summary>
        /// <returns></returns>
        public static List<GoodModel> GetTop5SaleGoods() {
            string sqlText = "select top 5 * from Goods WHERE Goods_is_delete = 0 order by Goods_sales_volume DESC";

            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText);
            List<GoodModel> goodsList = new List<GoodModel>();

            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        GoodModel goodModel = new GoodModel();
                        goodModel.GoodsId = Convert.ToInt32(sdr["Goods_id"]);
                        goodModel.GoodsName = sdr["Goods_name"].ToString();
                        goodModel.GoodsEffect = sdr["Goods_effect"].ToString();
                        goodModel.GoodsPrice = Convert.ToInt32(sdr["Goods_price"]);
                        goodModel.GoodsSalesVolume = Convert.ToInt32(sdr["Goods_sales_volume"]);
                        goodModel.GoodsStock = Convert.ToInt32(sdr["Goods_stock"]);
                        goodModel.GoodsPicture = sdr["Goods_picture"].ToString();
                        goodsList.Add(goodModel);
                    }
                    sdr.Close();
                    return goodsList;
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
        /// <summary>
        ///  get最新的5个商品列表
        /// </summary>
        /// <returns></returns>
        public static List<GoodModel> GetTop5NewGoods()
        {
            string sqlText = "select top 5 * from Goods WHERE Goods_is_delete = 0  order by Goods_shelf_time desc ";

            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText);
            List<GoodModel> goodsList = new List<GoodModel>();

            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        GoodModel goodModel = new GoodModel();
                        goodModel.GoodsId = Convert.ToInt32(sdr["Goods_id"]);
                        goodModel.GoodsName = sdr["Goods_name"].ToString();
                        goodModel.GoodsEffect = sdr["Goods_effect"].ToString();
                        goodModel.GoodsPrice = Convert.ToInt32(sdr["Goods_price"]);
                        goodModel.GoodsSalesVolume = Convert.ToInt32(sdr["Goods_sales_volume"]);
                        goodModel.GoodsStock = Convert.ToInt32(sdr["Goods_stock"]);
                        goodModel.GoodsPicture = sdr["Goods_picture"].ToString();
                        goodsList.Add(goodModel);
                    }
                    sdr.Close();
                    return goodsList;
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
    }
}
