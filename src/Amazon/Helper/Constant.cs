using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapper.Amazon.Helper
{
    public static class Constant
    {
        // Amazon search URL format
        public const string AMAZON_URL = @"https://www.amazon.com/s?k={0}&page={1}";
        public const string AMAZON_HOST = @"https://www.amazon.com";




        /// <summary>
        ///use this online tool to convert Xpath to CSS SELECTOR
        ///https://cssify.appspot.com/
        /// </summary>


        // public const string SEARCH_MAIN_DIV_XPATH = @"/html/body/div[1]/div[1]/div[1]/div[2]/div/span[4]/div[2]";

        public const string SEARCH_MAIN_DIV_CSS_SELECTOR = @"html>body>div:nth-of-type(1)>div:nth-of-type(1)>div:nth-of-type(1)>div:nth-of-type(2)>div>span:nth-of-type(4)>div:nth-of-type(2)";
        public const string PAGINATION_CSS_SELECTOR = @"html>body>div:nth-of-type(1)>div:nth-of-type(1)>div:nth-of-type(1)>div:nth-of-type(2)>div>span:nth-of-type(4)>div:nth-of-type(2)>div:nth-of-type(21)>span>div>div>ul";

        #region Data displayed in Four Row in a single column
        //public const string DESCRIPTION_LINK_FOUR_ROW_XPATH = @"/div/span/div/div/div[2]/h2/a";
        //public const string TITLE_FOUR_ROW_XPATH = @"/div/span/div/div/div[2]/h2/a/span";
        //public const string RATING_FOUR_ROW_XPATH = @"/div/span/div/div/div[3]/div/span[1]/span/a/i[1]/span";


        public const string DESCRIPTION_LINK_FOUR_ROW_CSS_SELECTOR = @"div>span>div>div>div:nth-of-type(2)>h2>a";
        public const string TITLE_FOUR_ROW_CSS_SELECTOR = @"div>span>div>div>div:nth-of-type(2)>h2>a>span";
        public const string RATING_FOUR_ROW_CSS_SELECTOR = @"div>span>div>div>div:nth-of-type(3)>div>span:nth-of-type(1)>span>a>i:nth-of-type(1)>span";
        #endregion

        #region Data displayed in single row in a single column
        //public const string DESCRIPTION_LINK_SINGLE_ROW_XPATH = @"/div/span/div/div/div[2]/div[2]/div/div[1]/div/div/div[1]/h2/a";
        //public const string TITLE_SINGLE_ROW_XPATH = @"/div/span/div/div/div[2]/div[2]/div/div[1]/div/div/div[1]/h2/a/span";
        //public const string RATING_SINGLE_ROW_XPATH = @"/div/span/div/div/div[2]/div[2]/div/div[1]/div/div/div[2]/div/span[1]/span/a/i[1]/span";


        public const string DESCRIPTION_LINK_SINGLE_ROW_CSS_SELECTOR = @"div>span>div>div>div:nth-of-type(2)>div:nth-of-type(2)>div>div:nth-of-type(1)>div>div>div:nth-of-type(1)>h2>a";
        public const string TITLE_SINGLE_ROW_CSS_SELECTOR = @"div>span>div>div>div:nth-of-type(2)>div:nth-of-type(2)>div>div:nth-of-type(1)>div>div>div:nth-of-type(1)>h2>a>span";
        public const string RATING_SINGLE_ROW_CSS_SELECTOR = @"div>span>div>div>div:nth-of-type(2)>div:nth-of-type(2)>div>div:nth-of-type(1)>div>div>div:nth-of-type(2)>div>span:nth-of-type(1)>span>a>i:nth-of-type(1)>span";
        #endregion

    }
}
