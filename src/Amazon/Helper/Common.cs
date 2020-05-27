using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapper.Amazon.Helper
{
   public static  class Common
    {
        public static string JoinStringWithPlus(string keyword)
        {           
            return keyword.Replace(" ", "+");          

        }
    }
}
