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
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {

        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
                

        }

        public void Update( OrderDetails orderDetails)
        {
            var orderDetailsFromDb = _db.OrderHeader.FirstOrDefault(m => m.Id == orderDetails.Id);
            _db.OrderHeader.Update(orderDetailsFromDb);

            _db.SaveChanges();
        }

    }
}
