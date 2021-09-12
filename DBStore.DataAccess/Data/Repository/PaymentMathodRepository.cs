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
    public class PaymentMathodRepository : Repository<PaymentMathod>, IPaymentMathodRepository
    {

        private readonly ApplicationDbContext _db;

        public PaymentMathodRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetPaymentMathodListForDropDown()
        {
            return _db.PaymentMathod.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()

            });


        }

        public void Update(PaymentMathod PaymentMathod)
        {
            var PaymentMathodDB = _db.PaymentMathod.FirstOrDefault(m => m.Id == PaymentMathod.Id);
            PaymentMathodDB.Name = PaymentMathod.Name;
            PaymentMathodDB.Description = PaymentMathod.Description;
            _db.SaveChanges();
        }
    }
}
