﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EFCore.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-3U6P1HI;Initial Catalog=Northwind;User ID=sa;Password=Pooya_359428");
        }

        public DbSet<Product> Products { get; set; }
    }
}