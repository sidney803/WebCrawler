using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassCrawler.Data.Models
{
    public class University
    {
        public uint Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(50)]
        public string ShortName { get; set; }
        [StringLength(50)]
        public string ClassName { get; set; }
        [StringLength(100)]
        public string RootUrl { get; set; }
    }
}
