using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ClassCrawler.Data.Attributes;

namespace ClassCrawler.Data.Models
{
    [ClassCrawlerEntityAttribute(XPath = "//*[@id='leftArea']")]
    public class ClassInfo
    {
        [Key]
        [ClassCrawlerFieldAttributes(XpathExpression = "課程代號", SelectorType = SelectorType.FixedValue)]
        public string ClassId { get; set; }

        [ClassCrawlerFieldAttributes(XpathExpression = "//*[@id='leftArea']/p/b/a")]
        public string ClassName { get; set; }

        [ClassCrawlerFieldAttributes(XpathExpression = "//*[@id='leftArea']/img")]
        public string ClassImg { get; set; }

        //[ClassCrawlerFieldAttributes(XpathExpression = "//*[@id='leftArea']/p/text()[3]")]
        [ClassCrawlerFieldAttributes(XpathExpression = "開課狀況", SelectorType = SelectorType.FixedValue)]
        public string ClassStatus { get; set; }

        //[ClassCrawlerFieldAttributes(XpathExpression ="//*[@id='leftArea']/p/text()[5]")]
        [ClassCrawlerFieldAttributes(XpathExpression = "開課日期", SelectorType = SelectorType.FixedValue)]
        public string ClassDate { get; set; }

        //[ClassCrawlerFieldAttributes(XpathExpression ="//*[@id='leftArea']/p/text()[6]")]
        [ClassCrawlerFieldAttributes(XpathExpression = "開課時段", SelectorType = SelectorType.FixedValue)]
        public string ClassTime { get; set; }
        //[ClassCrawlerFieldAttributes(XpathExpression = "//*[@id='leftArea']/p/text()[7]")]
        [ClassCrawlerFieldAttributes(XpathExpression = "//*[@id='leftArea']/p/span[@class='label label-danger']", SelectorType = SelectorType.XPath)]
        public string ClassPrice { get; set; }
    }
}
