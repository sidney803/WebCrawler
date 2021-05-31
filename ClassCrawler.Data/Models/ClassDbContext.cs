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
        public virtual DbSet<UscClass> ClassInfo { get; set; } 
        public virtual DbSet<University> University { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=ClassDB;Trusted_Connection=True;");
            }
        }
        
    }
}
