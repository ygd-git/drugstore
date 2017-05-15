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

namespace drugstore_admin1.DAL
{
    public class constHelper
    {
        /// <summary>
        /// 放置后台页面模板的目录
        /// </summary>
        /// <returns></returns>
        public static string GetAdminViewUrl() {
            string rst = ConfigurationManager.AppSettings["adminViewPath"];
            return rst;
        }
    }
}
