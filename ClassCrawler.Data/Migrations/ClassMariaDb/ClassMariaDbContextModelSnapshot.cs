﻿// <auto-generated />
using ClassCrawler.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassCrawler.Data.Migrations.ClassMariaDb
{
    [DbContext(typeof(ClassMariaDbContext))]
    partial class ClassMariaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ClassCrawler.Data.Models.ClassInfo", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClassDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClassImg")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClassName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("ClassPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ClassStatus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClassTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ClassId");

                    b.ToTable("ClassInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
