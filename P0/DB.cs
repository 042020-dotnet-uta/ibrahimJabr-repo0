using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace P0
{
    class DB: DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source= StoreDataBase.db");
        }
    }
}
