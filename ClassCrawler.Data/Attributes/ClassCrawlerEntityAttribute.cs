using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCrawler.Data.Attributes
{
    public class ClassCrawlerEntityAttribute: Attribute
    {
        public string XPath { get; set; }
    }
}
