using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClassCrawler.Data.Models
{
    public partial class ClassMariaDbContext : DbContext
    {
        public ClassMariaDbContext()
        {
        }

        public ClassMariaDbContext(DbContextOptions<ClassMariaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClassInfo> ClassInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=5306;database=ClassMariaDB;user=root;password=ccstars00", x => x.ServerVersion("10.5.9-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
