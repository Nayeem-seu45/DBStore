using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        void Update(OrderDetails orderDetails);
    }
}
