using System;
using System.Threading.Tasks;
using ClassCrawler.Downloader;
using ClassCrawler.Processor;
using ClassCrawler.Data.Repository;

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
            string Url = "https://eec.usc.edu.tw/";  //實踐大學推廣教育部
            string Regex = @"/Front/Classdetail.+";
            //bool DownloadFromMemory = true;  //false: downlad from disk

            //取得網頁有課程資料的links
            var myClassCrawlerDownloader = new ClassCrawlerDownloader(Url, Regex);
            var UrlLinks = await myClassCrawlerDownloader.GetLinks();
            var processor = new ClassCrawlerProcessor();

            //讀取每個網頁的欄位資料: 課名, 價格, 圖片等
            foreach(var url in UrlLinks)
            {
                var document = await myClassCrawlerDownloader.DownloadHtmlDoc(url);
                var entity = processor.Process(document, Url);   //開課時段晚點處理
                await new GenericRepository().CreateAsync(entity);
            }

            Console.WriteLine(UrlLinks);
        }
    }
}
