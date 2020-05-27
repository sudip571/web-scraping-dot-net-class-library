using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapper.Amazon.Helper;
using WebScrapper.Amazon.Model;

namespace WebScrapper.Amazon.Service
{
   public class ExtractData
    {
        public  async Task<List<AmazonData>> GetAmazonData(string keywords, int dataCount)
        {
            int pageNo = 1;
            int resultPosition = 1;
            int pageCount = 0;
            var modelList = new List<AmazonData>();
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            
            try
            {
                do
                {                    
                    var amazonURL = string.Format(Constant.AMAZON_URL, Common.JoinStringWithPlus(keywords), pageNo);
                    var document = await context.OpenAsync(amazonURL);
                    var searchDivElement = document.QuerySelector(Constant.SEARCH_MAIN_DIV_CSS_SELECTOR);
                     pageCount = ProcessData.GetPageNo(searchDivElement);
                    //get only searched result not Amazon's Choice,Editor's recommendations and so on
                    var searchResultElement = searchDivElement.Children.Where( x => x.LocalName == "div" && x.GetAttribute("data-component-type") == "s-search-result").ToList();
                    foreach (var item in searchResultElement)
                    {
                       // var model = new AmazonData();
                        bool displayInRow = true;
                        var dataIndex = item.GetAttribute("data-index");
                        var divNo = int.Parse(dataIndex) + 1;
                        //find out if result is displayed in single row or in 4 columns
                        var displayInSingleRow = item.QuerySelector("div.a-section.a-spacing-medium").QuerySelector("div.sg-row");
                        if (displayInSingleRow == null)
                            displayInRow = false;
                        var title = ProcessData.GetTitle(divNo, displayInRow, item);
                        var descriptionURL= ProcessData.GetDescription(divNo, displayInRow, item);
                        var model = new AmazonData()
                        {
                            SearchResultPosition = resultPosition,
                            Title = title,
                            DescriptionURL = descriptionURL
                        };
                        modelList.Add(model);
                        resultPosition++;
                        if (modelList.Count == dataCount)
                            goto exit;
                    }
                    pageNo++;

                } while (pageNo <= pageCount);
                exit:
                return modelList;
            }
            catch (Exception ex)
            {

                throw;
            }
            


        }

        #region Experiment and reference  code
        //public async Task<ActionResult> Test2()
        //{
        //    var service1 = new ExtractData();
        //    var result = await service1.GetAmazonData("printer", 2);
        //    var io = 2;
        //    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        //    // Load default configuration
        //    var config = Configuration.Default.WithDefaultLoader();
        //    // var config = Configuration.Default.WithDefaultLoader().WithJs();
        //    // Create a new browsing context
        //    var context = BrowsingContext.New(config);
        //    // This is where the HTTP request happens, returns <IDocument> that // we can query later
        //    var document = await context.OpenAsync("https://www.amazon.com/s?k=shoe+adidas&qid=1590488458&ref=sr_pg_1");
        //    //var document = await context.OpenAsync("https://shop.coles.com.au/a/national/everything/search/milk?pageNumber=1");
        //    var searchDiv = document.QuerySelector(".s-main-slot.s-result-list.s-search-results.sg-row");
        //    var searchDivXpath = document.QuerySelector("html>body>div:nth-of-type(1)>div:nth-of-type(1)>div:nth-of-type(1)>div:nth-of-type(2)>div>span:nth-of-type(4)>div:nth-of-type(2)");
        //    var test22 = searchDivXpath.Children.FirstOrDefault();
        //    var test = searchDivXpath.Children.Where(x => x.GetAttribute("data-component-type") == "s-search-result");
        //    var test1 = searchDivXpath.QuerySelectorAll("div[data-component-type='s-search-result']");
        //    var test2 = searchDivXpath.QuerySelectorAll("*").Where(x => x.LocalName == "div" && x.GetAttribute("data-component-type") == "s-search-result");
        //    var title = document.QuerySelector("div:nth-of-type(3)>div>span>div>div>div:nth-of-type(2)>h2>a>span").TextContent;
        //    var lastPage = searchDivXpath.QuerySelector("ul.a-pagination");
        //    var llast = lastPage.QuerySelector("li:nth-last-child(2)");
        //    var lllast = lastPage.Children[lastPage.ChildElementCount - 2];
        //    var i = 0;
        //    var yy = test.FirstOrDefault().GetAttribute("data-index");
        //    var yyyy = test.FirstOrDefault().QuerySelector("div.a-section.a-spacing-medium").QuerySelector("div.a-section.a-spacing-none.a-spacing-top-small");
        //    var yyyyt = test.FirstOrDefault().QuerySelector("div.a-section.a-spacing-medium").QuerySelector("div.sg-row");
        //    return View();
        //}
        #endregion
    }
}
