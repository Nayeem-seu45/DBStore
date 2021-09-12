using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        
        void Update(Product product);

    }
}
