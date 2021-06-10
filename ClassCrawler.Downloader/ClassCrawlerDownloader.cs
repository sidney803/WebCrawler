using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.IO;

namespace ClassCrawler.Downloader
{
    public class ClassCrawlerDownloader
    {
        private string _url;
        private string _university;
        private readonly  Regex _regex;
        public ClassCrawlerDownloader(string url, string regex, string university)
        {
            _url = url;
            if (!string.IsNullOrWhiteSpace(regex))
                _regex = new Regex(regex);

            _university = university;
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
            catch (Exception e)
            {
                return Enumerable.Empty<string>();
            }
        }
        public async Task<HtmlDocument> DownloadHtmlDoc(string url)
        {
            var htmlDocument = new HtmlDocument();
            //using (WebClient client = new WebClient())
            if (_university == "usc")  //實踐大學
            {
                using (IWebDriver driver = new PhantomJSDriver())
                {
                    /*  //只能下載靜態html網頁; JS轉譯的content擷取不到
                    string htmlCode = await client.DownloadStringTaskAsync(url);
                    htmlDocument.LoadHtml(htmlCode);
                    */
                    //使用PhantomJSDriver來存取JS轉譯後之content
                    driver.Navigate().GoToUrl(url);
                    htmlDocument.LoadHtml(driver.PageSource);
                }
            }
            return htmlDocument;
        }


    }
}
