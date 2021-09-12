using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;
using DBStore.Models.CMS;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DBStore.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<SlideShow> SlideShow { get; set; }
        public DbSet<HomeBanner> HomeBanner { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<WarrantyType> WarrantyType { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<PaymentMathod> PaymentMathod { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<RequestProduct> RequestProduct { get; set; }
        public DbSet<Payment> Payment { get; set; }

        public DbSet<Reviews> Reviews { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Massage> Massage { get; set; }

        public DbSet<OfferZone> OfferZone  { get; set; }

        //public DbSet<ProductTag> ProductTag { get; set; }


    }
}
