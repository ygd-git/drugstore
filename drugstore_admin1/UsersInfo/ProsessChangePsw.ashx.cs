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
    public class ProsessChangePsw : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string temp = File.ReadAllText(context.Server.MapPath("drugstore_password.html"));

            DataTable dt = UserBLL.User8(context.Session["users_id"].ToString());
            temp=temp.Replace("@name",dt.Rows[0][2].ToString());

            context.Response.Write(temp);
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
