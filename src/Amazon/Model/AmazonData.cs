using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapper.Amazon.Model
{
   public class AmazonData
    {
        public int DataIndex { get; set; }
        public int SearchResultPosition { get; set; }
        public string Title { get; set; }
        public string DescriptionURL { get; set; }

    }
}
