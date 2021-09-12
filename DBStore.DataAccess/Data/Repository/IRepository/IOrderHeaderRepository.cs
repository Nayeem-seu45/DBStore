using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
    }
}
