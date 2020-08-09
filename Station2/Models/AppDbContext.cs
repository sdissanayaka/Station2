using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Station2.Models;

namespace Station2.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
        //base class for the EntityFrameWorkCore context to use with identity
        //IdentityUser is a built-in class that can be used to represent a user in Identity
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ItemMaster> ItemMaster { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<CustomerPayment> CustomerPayments { get; set; }
        //public DbSet<JobCard> JobCards { get; set; }
        public DbSet<InvoiceItem> InvoiceItem { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<CashBook> CashBooks { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<InvoiceItem>()
                .HasKey(c => new { c.InvoiceId, c.ItemId }); 

            //seed categories
            modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory { CategoryId = 1, CategoryName = "Raw Materials", CategoryDescription = "Buy your raw materials" });
            modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory { CategoryId = 2, CategoryName = "Services", CategoryDescription = "Get your service" });
            //modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory { CategoryId = 3, CategoryName = "Seasonal pies" });

            modelBuilder.Entity<ItemMaster>().HasData(new ItemMaster
            {
                ItemId = 1,
                CategoryId = 1,
                ItemName = "Engine oil",
                Price = 12.95M,
                ItemDescription = "Replace your engine oil",
                UOM = "litre",
                StockQuantity = 500,
                InStock = true,

                //CategoryName = "Raw Materials",
            });

            modelBuilder.Entity<ItemMaster>().HasData(new ItemMaster
            {
                ItemId = 2,
                CategoryId = 2,
                ItemName = "Body Wash",
                Price = 120.90M,
                ItemDescription = "Cleaning the body of the car",
                //UOM = "",
                //StockQuantity = 
                InStock = true,
                //CategoryName = "Services",
            });

            modelBuilder.Entity<ItemMaster>().HasData(new ItemMaster
            {
                ItemId = 3,
                CategoryId = 1,
                ItemName = "Tyre",
                Price = 33M,
                ItemDescription = "DSI",
                UOM = "Units",
                StockQuantity = 100,
                InStock = true,

                //CategoryName = "Raw Materials",
            });

        }


    }
}
