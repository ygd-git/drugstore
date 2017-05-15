using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using drugstore_admin1.DAL;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminSettingsForm : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
            {
                string product_id = context.Request.Form["product_id"];
                string product_name = context.Request.Form["product_name"];
                string product_action = context.Request.Form["product_action"];
                string goods_id_delete = context.Request.QueryString["goods_id_delete"];

                string news_id = context.Request.Form["news_id"];
                string news_name = context.Request.Form["news_name"];
                string news_action = context.Request.Form["news_action"];
                string news_id_delete = context.Request.QueryString["news_id_delete"];
                
                if (product_action == "0")
                {
                    if (product_name!=null)
                    {

                        int i = GoodsTypeBLL.GoodsType1(product_name);
                        if (i > 0)
                        {
                            context.Response.Write(product_name + "添加成功<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                            //return;
                        }
                        else
                        {
                            context.Response.Write(product_name + "添加失败<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                            //return;
                        }

                    }
                    else
                    {
                        context.Response.Write("添加时请填写类型名<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                        //return;
                    }
                }
                else if (product_action=="1")
                {
                    if (product_id!=null&&product_name!=null)
                    {
                        
                        int i = GoodsTypeBLL.GoodsType2(product_name, product_id);
                        if (i > 0)
                        {
                            context.Response.Write(product_name + "修改成功<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                            //return;
                        }
                        else
                        {
                            context.Response.Write(product_name + "修改失败<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                            //return;
                        }
                    }
                }
                else if (goods_id_delete!=null)
                {
                    
                    int i = GoodsTypeBLL.GoodsType3(goods_id_delete);
                    if (i > 0)
                    {
                        context.Response.Write(product_name + "删除成功<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                        //return;
                    }
                    else
                    {
                        context.Response.Write(product_name + "删除失败<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                        //return;
                    }
                }
                else if (news_action == "0")
                {
                    if (news_name != null)
                    {
                        
                        int i = NewsTypeBLL.NewsType2(news_name);
                        if (i > 0)
                        {
                            context.Response.Write(news_name + "添加成功<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                            //return;
                        }
                        else
                        {
                            context.Response.Write(news_name + "添加失败<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                            //return;
                        }

                    }
                    else
                    {
                        context.Response.Write("添加时请填写类型名<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                        //return;
                    }
                }
                else if (news_action == "1")
                {
                    if (news_id != null && news_name != null)
                    {
                        
                        int i = NewsTypeBLL.NewsType1(news_name, news_id);
                        if (i > 0)
                        {
                            context.Response.Write(news_name + "修改成功<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                            //return;
                        }
                        else
                        {
                            context.Response.Write(news_name + "修改失败<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                            //return;
                        }
                    }
                }
                else if (news_id_delete != null)
                {
                    
                    int i = NewsTypeBLL.NewsType3(news_id_delete);
                    if (i > 0)
                    {
                        context.Response.Write(news_name + "删除成功<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                        //return;
                    }
                    else
                    {
                        context.Response.Write(news_name + "删除失败<a href='ProcessAdminSettings.ashx'>返回设置页面</a>");
                        //return;
                    }
                }

                context.Response.Write(product_id + "ProcessAdminSettingsForm" + product_name);
            }
            else
            {
                context.Response.Redirect("~/admin_login.html");
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
