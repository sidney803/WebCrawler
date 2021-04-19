using System;
using System.Threading.Tasks;
using ClassCrawler.Downloader;

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
            bool DownloadFromMemory = true;  //false: downlad from disk

            var myClassCrawlerDownloader = new ClassCrawlerDownloader(Url, Regex);
            var UrlLinks = await myClassCrawlerDownloader.GetLinks();

            Console.WriteLine(UrlLinks);
        }
    }
}
