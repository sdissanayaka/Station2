﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ItemMaster> ItemMaster { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory { CategoryId = 1, CategoryName = "Raw Materials", CategoryDescription = "Buy your raw materials" });
            modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory { CategoryId = 2, CategoryName = "Services", CategoryDescription = "Get your service" });
            //modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory { CategoryId = 3, CategoryName = "Seasonal pies" });

            modelBuilder.Entity<ItemMaster>().HasData(new ItemMaster
            {
                ItemId = 1,
                ItemName = "Engine oil",
                Price = 12.95M,
                ItemDescription = "Replace your engine oil",
                CategoryId = 1,
                InStock = true,
                IsItemOfTheWeek = true,
                //CategoryName = "Raw Materials",
            });

        }

    }
}