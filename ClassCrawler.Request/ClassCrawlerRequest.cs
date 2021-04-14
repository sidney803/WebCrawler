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
        private readonly Regex _regex;
        public string Url { get; set; }
        public string Regex { get; set; }
        public long Timeout { get; set; }

        public ClassCrawlerRequest()
        {
            if (!string.IsNullOrWhiteSpace(Regex))
                _regex = new Regex(Regex);
        }

        public async Task<IEnumerable<string>> GetLinks(string url, int level = 0)
        {
            if (level < 0)
                throw new ArgumentOutOfRangeException(nameof(level));

            var rootUrls = await GetPageLinks(url, false);

            if (level == 0)
                return rootUrls;

            //var links = await GetAllPagesLinks(rootUrls);

            //--level;

            //var tasks = await Task.WhenAll(links.Select(link => GetLinks(link, level)));
            return null; 
        }

        public async Task<IEnumerable<string>> GetPageLinks(string url, bool needMatch = true)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                var htmlDocument = await web.LoadFromWebAsync(url);

                var linkList = htmlDocument.DocumentNode
                        .Descendants("a")
                        .Select(a => a.GetAttributeValue("href", null))
                        .Where(u => !string.IsNullOrEmpty(u))
                        .Distinct();

                if (_regex != null)
                    linkList = linkList.Where(x => _regex.IsMatch(x));

                return linkList;
            }
            catch (Exception exception)
            {
                return Enumerable.Empty<string>();
            }
        }
    }
}
