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
using drugstore_admin1.DAL;
using System.Data.SqlClient;
using System.Web.UI.MobileControls;
using System.Collections.Generic;

namespace drugstore_admin1.BLL
{
    public class NewsBLL
    {
        public static int AddNews(NewsModel news) {
            string sqlText = "INSERT INTO News VALUES(@News_title,@News_content,@News_time,'',0,@News_newstype,@News_source)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@News_title",news.NewsTitle),
                    new SqlParameter("@News_content",news.NewsContent),
                    new SqlParameter("@News_time",DateTime.Now),
                    new SqlParameter("@News_newstype",news.NewsType),
                    new SqlParameter("@News_source",news.NewsSource)
            };
            return SQLHelper.ExecuteNonQuery(sqlText, paras);
        }
        public static int UpdateNews(NewsModel news) {
            string sqlText = "UPDATE News SET News_title = @News_title,News_newstype=@News_newstype, News_content=@News_content WHERE News_id = @News_id";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@News_title",news.NewsTitle),
                new SqlParameter("@News_content",news.NewsContent),                    
                new SqlParameter("@News_newstype",news.NewsType),
                new SqlParameter("@News_id",news.NewsId)
            };
            int i = SQLHelper.ExecuteNonQuery(sqlText, paras);
            return i;
        }
        public static int DeleteNews(int news_id)
        {
            string sqlText = "UPDATE News SET News_isdelete = 1 WHERE News_id = @News_id";
            SqlParameter para = new SqlParameter("@News_id", news_id);
            int i = SQLHelper.ExecuteNonQuery(sqlText, para);
            return i;
        }
        public static int UpdateNewsView(int news_id)
        {
            string sqlText = "UPDATE News SET News_view_count = ((SELECT top 1 News_view_count FROM News WHERE News_id = @News_id)+1)WHERE News_id = @News_id";
            SqlParameter para = new SqlParameter("@News_id", news_id);
            int i = SQLHelper.ExecuteNonQuery(sqlText, para);
            return i;
        }

        public static List<NewsModel> GetNewsList() {
            string sqlText = "SELECT * FROM News WHERE News_isdelete=0";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText);
            List<NewsModel> newsList = new List<NewsModel>();
            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        NewsModel news = new NewsModel(Convert.ToInt32(sdr["News_id"]), sdr["News_title"].ToString(), sdr["News_content"].ToString(), Convert.ToDateTime(sdr["News_time"]), Convert.ToInt32(sdr["News_view_count"]), sdr["News_isdelete"].ToString(), Convert.ToInt32(sdr["News_newstype"]), sdr["News_source"].ToString());

                        newsList.Add(news);
                    }
                    sdr.Close();
                    return newsList;
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

        public static List<NewsModel> GetHotNewsList()
        {
            string sqlText = "select  * from News WHERE News_isdelete = 0 ORDER BY News_view_count DESC";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText);
            List<NewsModel> newsList = new List<NewsModel>();
            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        NewsModel news = new NewsModel(Convert.ToInt32(sdr["News_id"]), sdr["News_title"].ToString(), sdr["News_content"].ToString(), Convert.ToDateTime(sdr["News_time"]), Convert.ToInt32(sdr["News_view_count"]), sdr["News_isdelete"].ToString(), Convert.ToInt32(sdr["News_newstype"]), sdr["News_source"].ToString());

                        newsList.Add(news);
                    }
                    sdr.Close();
                    return newsList;
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
        public static List<NewsModel> GetNewsListByType(int newsType)
        {
            string sql4 = "select  * from News WHERE News_isdelete = 0 and  News_newstype = @News_newstype ORDER BY News_view_count DESC";
            SqlParameter para4 = new SqlParameter("@News_newstype", newsType);
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql4, para4);
            List<NewsModel> newsList = new List<NewsModel>();
            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        NewsModel news = new NewsModel(Convert.ToInt32(sdr["News_id"]), sdr["News_title"].ToString(), sdr["News_content"].ToString(), Convert.ToDateTime(sdr["News_time"]), Convert.ToInt32(sdr["News_view_count"]), sdr["News_isdelete"].ToString(), Convert.ToInt32(sdr["News_newstype"]), sdr["News_source"].ToString());

                        newsList.Add(news);
                    }
                    sdr.Close();
                    return newsList;
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

        public static NewsModel GetANews(string newsId)
        {
            string sqlText = "SELECT TOP(1) * FROM News WHERE News_id=@News_id";
            SqlParameter paras = new SqlParameter("@News_id", newsId);
            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText, paras);
            NewsModel news = new NewsModel();
            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        news = new NewsModel(Convert.ToInt32(sdr["News_id"]), sdr["News_title"].ToString(), sdr["News_content"].ToString(), Convert.ToDateTime(sdr["News_time"]), Convert.ToInt32(sdr["News_view_count"]), sdr["News_isdelete"].ToString(), Convert.ToInt32(sdr["News_newstype"]), sdr["News_source"].ToString());

                       
                    }
                    sdr.Close();
                    return news;
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
