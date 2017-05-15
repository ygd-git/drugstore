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
    public class NewsTypeBLL
    {
        public static string GetNameById(int newId) {
            string sqlText2 = "SELECT NewsType_name FROM NewsType WHERE NewsType_id=@NewsType_id";
            SqlParameter paras2 = new SqlParameter("@NewsType_id", newId);
            string newsTypeName = SQLHelper.ExecuteScalar(sqlText2, paras2).ToString();
            return newsTypeName;
        }

        public static List<NewsTypeModel> GetNewsList() {
            string sqlText = "SELECT * FROM NewsType where NewsType_isdelete = 0";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText);
            List<NewsTypeModel> newsTypeList = new List<NewsTypeModel>();
            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        NewsTypeModel newsType = new NewsTypeModel();
                        newsType.NewsTypeid = Convert.ToInt32(sdr["NewsType_id"]);
                        newsType.NewsTypename = sdr["NewsType_name"].ToString();
                        newsTypeList.Add(newsType);
                    }
                    sdr.Close();
                    return newsTypeList;
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

        public static int NewsType1(string news_name, string news_id)
        {
            string sqlText = "UPDATE NewsType SET NewsType_name=@NewsType_name where NewsType_id=@NewsType_id";
            SqlParameter[] paras = new SqlParameter[]{
                            new SqlParameter("@NewsType_name",news_name),
                            new SqlParameter("@NewsType_id",news_id)
                        };
            return SQLHelper.ExecuteNonQuery(sqlText, paras);
        }
        public static int NewsType2(string news_name)
        {
            string sqlText = "INSERT INTO NewsType	VALUES(@NewsType_name,'')";
            SqlParameter paras = new SqlParameter("@NewsType_name", news_name);
            return SQLHelper.ExecuteNonQuery(sqlText, paras);
        }
        public static int NewsType3(string news_id_delete)
        {
            string sqlText = "update NewsType set NewsType_isdelete=1 WHERE NewsType_id=@NewsType_id";
            SqlParameter[] paras = new SqlParameter[]{
                        new SqlParameter("@NewsType_id",news_id_delete)
                    };
            return SQLHelper.ExecuteNonQuery(sqlText, paras);
        }
    }
}
