using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ClassCrawler.Data.Models
{
    public partial class ClassDbContext: DbContext
    {
        public ClassDbContext()
        {
        }
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        { }
        public virtual DbSet<ClassInfo> ClassInfo { get; set; }  
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=ClassDb;Trusted_Connection=True;");
            }
        }
        
    }
}
