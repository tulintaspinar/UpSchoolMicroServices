﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchoolECommerce.Services.Order.Infrastructure
{
    public class OrderDbContext : DbContext
    {
        public const string Default_Schema = "Ordering";
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base (options) 
        {

        }
        public DbSet<Domain.OrderAggregate.Order> Orders { get; set; }
        public DbSet<Domain.OrderAggregate.OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.OrderAggregate.Order>().ToTable("Orders",Default_Schema);
            modelBuilder.Entity<Domain.OrderAggregate.OrderItem>().ToTable("OrderItem",Default_Schema);
            modelBuilder.Entity<Domain.OrderAggregate.OrderItem>().Property(x=>x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Domain.OrderAggregate.OrderItem>().Property(x=>x.ProductName).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<Domain.OrderAggregate.Order>().OwnsOne(o=>o.Adress).WithOwner(); //order sınıfı içinde adress sınıfı da yollandı ama ilişkili değiller
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
