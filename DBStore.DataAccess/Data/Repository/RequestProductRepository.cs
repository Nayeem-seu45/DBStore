using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.DataAceess.Data.Repository;
using DBStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBStore.DataAccess.Data.Repository
{
    public class RequestProductRepository : Repository<RequestProduct>, IRequestProductRepository
    {

        private readonly ApplicationDbContext _db;

        public RequestProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

     

        public void Update(RequestProduct requestProduct)
        {
            var RequestProductDB = _db.RequestProduct.FirstOrDefault(m => m.Id == requestProduct.Id);
            RequestProductDB.ProductName = requestProduct.ProductName;
            RequestProductDB.Description = requestProduct.Description;


            _db.SaveChanges();
        }
    }
}
