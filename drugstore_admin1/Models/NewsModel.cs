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

namespace drugstore_admin1.Models
{
    public class NewsModel
    {
        public NewsModel() { 
            
        }
        public NewsModel(int newsId, string newsTitle, string newsContent, DateTime newsTime, int newsViewCount, string newsIsDelete, int newsType, string newsSource) {
            NewsId = newsId;
            NewsTitle = newsTitle;
            NewsContent = newsContent;
            NewsTime = newsTime;
            NewsViewCount = newsViewCount;
            NewsIsDelete = newsIsDelete;
            NewsType = newsType;
            NewsSource = newsSource;
        }
        private int newsId;
        public int NewsId
        {
            get { return newsId; }
            set { newsId = value; }
        }
        private string  newsTitle;
        public string NewsTitle
        {
            get { return newsTitle; }
            set { newsTitle = value; }
        }
        private string newsContent;
        public string NewsContent
        {
            get { return newsContent; }
            set { newsContent = value; }
        }
        private DateTime  newsTime;
        public DateTime NewsTime
        {
            get { return newsTime; }
            set { newsTime = value; }
        }
        private int newsViewCount;
        public int NewsViewCount
        {
            get { return newsViewCount; }
            set { newsViewCount = value; }
        }
        private string  newsIsDelete;
        public string  NewsIsDelete
        {
            get { return newsIsDelete; }
            set { newsIsDelete = value; }
        }
        private int newsType;
        public int NewsType
        {
            get { return newsType; }
            set { newsType = value; }
        }
        private string  newsSource;
        public string  NewsSource
        {
            get { return newsSource; }
            set { newsSource = value; }
        }
    }
}
