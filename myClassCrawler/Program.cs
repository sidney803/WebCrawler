using System;
using System.Threading.Tasks;
using ClassCrawler.Downloader;
using ClassCrawler.Processor;
using ClassCrawler.Data.Repository;
using ClassCrawler.Data.Models;
using ClassCrawler.Request;

namespace myClassCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var classRequestUnits = new ClassCrawlerRequest<University>();
            var universities = classRequestUnits.GetUniversity();
            foreach (var u in universities)
            {
                string Regex = @"/Front/Classdetail.+";
                //bool DownloadFromMemory = true;  //false: download from disk

                //取得網頁有課程資料的links
                var myClassCrawlerDownloader = new ClassCrawlerDownloader(u.RootUrl, Regex, u.ShortName);
                var UrlLinks = await myClassCrawlerDownloader.GetLinks();
                var processor = new ClassCrawlerProcessor();

                //讀取每個網頁的欄位資料: 課名, 價格, 圖片等
                foreach (var url in UrlLinks)
                {
                    var document = await myClassCrawlerDownloader.DownloadHtmlDoc(url);
                    var entity = processor.Process(document, u.RootUrl);   //開課時段晚點處理
                    await new GenericRepository<UscClass>().CreateAsync(entity);
                }

                Console.WriteLine(UrlLinks);
            }
        }
    }
}
