using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commom
{
    public class PageBarHelper
    {
        public static string GetPageBar(int pageIndex, int pageCount)
        {

            if (pageCount == 1)
            {
                return string.Empty;
            }
            int start = pageIndex - 5;
            if (start < 1)
            {
                start = 1;
            }
            int end = start + 9;
            if (end > pageCount)
            {
                end = pageCount;
                start = end - 9 < 1 ? 1 : end - 9;
            }
            StringBuilder sb = new StringBuilder();
            if (pageIndex > 1)
            {
                sb.AppendFormat("<li><a href='ProcessDrugInfo.ashx?pageIndex={0}'>上一页</a></li>", pageIndex - 1);
            }
            for (int i = 1; i <= pageCount; i++)
            {
                if (i == pageIndex)
                {
                    sb.AppendFormat("<li class='active'><a href='ProcessDrugInfo.ashx?pageIndex={0}'>{0}</a></li>", i);

                }
                else
                {
                    sb.AppendFormat("<li><a href='ProcessDrugInfo.ashx?pageIndex={0}'>{0}</a></li>", i);
                }
            }
            if (pageIndex < pageCount)
            {
                sb.AppendFormat("<li><a href='ProcessDrugInfo.ashx?pageIndex={0}'>下一页</a></li>", pageIndex + 1);
            }
            return sb.ToString();
        }
    }
}
