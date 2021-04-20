using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassCrawler.Processor
{
    public class ClassCrawlerProcessor
    {
        public async Task<IEnumerable> Process(HtmlDocument document)
        {
            var nameValueDictionary = GetColumnNameValuePairsFromHtml(document);


        }

        private Dictionary<string,string> GetColumnNameValuePairsFromHtml(HtmlDocument document)
        {

        }
    }
}
