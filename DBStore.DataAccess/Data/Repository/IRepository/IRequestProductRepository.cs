using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IRequestProductRepository : IRepository<RequestProduct>
    {
        
        void Update(RequestProduct requestProduct);

    }
}
