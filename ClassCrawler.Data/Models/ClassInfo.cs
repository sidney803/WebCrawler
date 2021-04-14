using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ClassCrawler.Data.Models
{
    public class ClassInfo
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassIntro { get; set; }
        public string ClassTime { get; set; }
        public string ClassAddr { get; set; }
        public decimal ClassPrice { get; set; }
    }
}
