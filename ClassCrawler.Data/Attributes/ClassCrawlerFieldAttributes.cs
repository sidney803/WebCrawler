using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCrawler.Data.Attributes
{
    public class ClassCrawlerFieldAttributes: Attribute
    {
        public string XpathExpression { get; set; }
        public SelectorType SelectorType { get; set; }
    }
}
