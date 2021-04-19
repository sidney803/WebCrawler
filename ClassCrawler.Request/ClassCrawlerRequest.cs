using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassCrawler.Request
{
    class ClassCrawlerRequest
    {
        //private readonly Regex _regex;
        public string Url { get; set; }
        public string Regex { get; set; }
        public long Timeout { get; set; }

        public ClassCrawlerRequest()
        {
        }

       
    }
}
