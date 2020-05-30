﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Station2.Models;

namespace Station2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200516102627_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Station2.Models.ItemCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("ItemCategories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Raw Materials"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Services"
                        });
                });

            modelBuilder.Entity("Station2.Models.ItemMaster", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryNameCategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsItemOfTheWeek")
                        .HasColumnType("bit");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryNameCategoryId");

                    b.ToTable("ItemMaster");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            CategoryId = 1,
                            InStock = true,
                            IsItemOfTheWeek = true,
                            ItemDescription = "Our famous apple pies!",
                            ItemName = "Engine oil",
                            Price = 12.95m
                        });
                });

            modelBuilder.Entity("Station2.Models.ItemMaster", b =>
                {
                    b.HasOne("Station2.Models.ItemCategory", "CategoryName")
                        .WithMany("Items")
                        .HasForeignKey("CategoryNameCategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}