using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapper.Amazon.Service
{
   public static  class ProcessData
    {
        public static int  GetPageNo(IElement element)
        {
            var pagingElement = element.QuerySelector("ul.a-pagination");
            var lastPageNo = pagingElement.QuerySelector("li:nth-last-child(2)").TextContent;
            //var lastPageNo = pagingElement.Children[lastPage.ChildElementCount - 2];
            var pageNo = int.Parse(lastPageNo);
            return pageNo;

        }
        public static string GetTitle(int divNo, bool displayInSingleRow, IElement element)
        {
            var path = "div:nth-of-type(" + divNo + ")" + ">";
            if (displayInSingleRow)
                path = path + Helper.Constant.TITLE_SINGLE_ROW_CSS_SELECTOR;
            else
                path = path + Helper.Constant.TITLE_FOUR_ROW_CSS_SELECTOR;
            var title= element.QuerySelector(path).TextContent;
            return title;
        }
        public static string GetDescription(int divNo, bool displayInSingleRow, IElement element)
        {
            var path = "div:nth-of-type(" + divNo + ")" + ">";
            if (displayInSingleRow)
                path = path + Helper.Constant.DESCRIPTION_LINK_SINGLE_ROW_CSS_SELECTOR;
            else
                path = path + Helper.Constant.DESCRIPTION_LINK_FOUR_ROW_CSS_SELECTOR;
            var description = element.QuerySelector(path).GetAttribute("href");
            return Helper.Constant.AMAZON_HOST + description;
        }
        
    }
}
