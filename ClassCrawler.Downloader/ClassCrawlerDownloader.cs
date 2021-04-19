using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassCrawler.Downloader
{
    public class ClassCrawlerDownloader
    {
        private string _url;
        private readonly  Regex _regex;
        public ClassCrawlerDownloader(string url, string regex)
        {
            _url = url;
            if (!string.IsNullOrWhiteSpace(regex))
                _regex = new Regex(regex);
        }

        public async Task<IEnumerable<string>> GetLinks(int level = 0)
        {
            if (level < 0)
                throw new ArgumentOutOfRangeException(nameof(level));

            var rootUrls = await GetPageLinks(false);

            if (level == 0)
                return rootUrls;

            //var links = await GetAllPagesLinks(rootUrls);
            //--level;
            //var tasks = await Task.WhenAll(links.Select(link => GetLinks(link, level)));
            return null;
        }

        private async Task<IEnumerable<string>> GetPageLinks(bool needMatch = true)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                var htmlDocument = await web.LoadFromWebAsync(_url);

                var linkList = htmlDocument.DocumentNode
                        .Descendants("a")
                        .Select(a => a.GetAttributeValue("href", null))
                        .Where(u => !string.IsNullOrEmpty(u))
                        .Distinct();

                //去除不是http連結的element
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
