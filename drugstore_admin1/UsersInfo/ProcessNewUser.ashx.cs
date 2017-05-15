using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using drugstore_admin1.DAL;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessNewUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string account = context.Request["account"];
            string name = context.Request["name"];
            string password = context.Request["password"];
            string password_confirm = context.Request["password_confirm"];
            string time = DateTime.Now.ToString();
            if (password == password_confirm)
            {
                
                int i = UserBLL.User6(account, name, password, time);
                if (i > 0)
                {
                    context.Response.Write("注册成功!");
                }
                else
                {
                    context.Response.Write("注册失败!");
                }
                context.Response.Write("<a href='../drugstore_login.html'>回到用户登录页面</a>");
            }
            else
            {
                
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
