using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.DataAceess.Data.Repository;
using DBStore.Models;

namespace DBStore.DataAccess.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
           


        }

       
        public void Update(Product product)
         {
            int i = 0;
            var productDB = _db.Product.FirstOrDefault(m => m.Id == product.Id);
            productDB.Name = product.Name;
            productDB.CategoryId = product.CategoryId;
            productDB.Description = product.Description;
            productDB.Price = product.Price;
            productDB.DisPrice = product.DisPrice;
            productDB.Feature = product.Feature;
            productDB.InStock = product.InStock;
            productDB.BrandId = product.BrandId;
            productDB.KeyFeature = product.KeyFeature;
            productDB.UpdateDate = DateTime.Now;
            
            if(product.Image != null)
            {
                if (i == 0)
                {
                    productDB.Image = product.Image;
                }
                if (i == 1)
                {
                   productDB.Image1 = product.Image1;
                }
                if (i == 2)
                {
                    productDB.Image2 = product.Image2;
                }
                if (i == 3)
                {
                    productDB.Image3 = product.Image3;
                }
              

            }
            _db.SaveChanges();
        }

    }
}
