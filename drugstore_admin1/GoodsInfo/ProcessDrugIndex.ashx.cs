using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using drugstore_admin1.DAL;
using System.Collections.Generic;
using drugstore_admin1.Models;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessDrugIndex : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string temp = File.ReadAllText(context.Server.MapPath("drugstore_index.html"));
            
            
            
            List<GoodModel> list1 = GoodsBLL.GetTop5SaleGoods();
            List<GoodModel> list2 = GoodsBLL.GetTop5NewGoods();
            
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();
            List<GoodsTypeModel> goodsTypeList = GoodsTypeBLL.GetGoodsTypeList();
            int count = 1;
            foreach (GoodModel item in list1)
            {
                sb1.AppendFormat(@"<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", count, item.GoodsName ,item.GoodsEffect);
                count++;
            }
            count = 1;
            foreach (GoodModel item in list2)
            {
                sb2.AppendFormat(@"<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", count, item.GoodsName, item.GoodsEffect);
                count++;
            }
            foreach (GoodsTypeModel item in goodsTypeList)
            {
                sb3.AppendFormat("<a href='drugstore_search.ashx?effect={0}' class='list-group-item'>{1}</a>", item.GoodsTypeid, item.GoodsTypename);
            }
            temp = temp.Replace("@content1", sb1.ToString());
            temp = temp.Replace("@content2", sb2.ToString());
            temp = temp.Replace("@goods_type", sb3.ToString());
            if (context.Session["users_id"] != null)
            {
                temp = temp.Replace("@user_name", context.Session["user_name"].ToString());
            }
            else
            {
                temp = temp.Replace("@user_name", "游客");
            }
            
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
