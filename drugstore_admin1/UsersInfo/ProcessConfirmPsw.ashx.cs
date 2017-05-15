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
    public class ProcessConfirm : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string id=context.Session["users_id"].ToString();
            string oldPsw = context.Request["old_password"];
            string newPsw = context.Request["password"];
            string confirmPsw = context.Request["password_confirm"];
            
            

            DataTable dt = UserBLL.User4(id);

            if (dt.Rows[0][2].ToString() == oldPsw)
            {
                if (newPsw == confirmPsw)
                {
                    
                    int i = UserBLL.User5(newPsw, id);
                    if (i > 0)
                    {
                        context.Response.Redirect("~/drugstore_login.html");
                    }
                }
                else
                {
                    context.Response.Write("");
                }
            }
            else
            {
                context.Response.Write("");
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
