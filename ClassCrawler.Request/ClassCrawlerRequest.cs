using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClassCrawler.Data.Repository;

namespace ClassCrawler.Request
{
    public class ClassCrawlerRequest<TEntity> where TEntity : class
    {
        //private readonly Regex _regex;
        private readonly GenericRepository<TEntity> _genericRepository;
        public string Url { get; set; }
        public string Regex { get; set; }
        public long Timeout { get; set; }

        public ClassCrawlerRequest()
        {
            _genericRepository = new GenericRepository<TEntity>();
        }

        public List<TEntity> GetUniversity()
        {
            return _genericRepository.GetAll().ToList();
        }


       
    }
}
