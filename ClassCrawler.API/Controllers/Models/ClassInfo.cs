using ClassCrawler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassCrawler.API.Controllers.Models
{
    public class ClassInfo
    {
        public University University {get;set;}
        public List<UscClass> UscClass { get; set; }  //實踐大學
    }
}
