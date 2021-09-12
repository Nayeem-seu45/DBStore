using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IPaymentMathodRepository : IRepository<PaymentMathod>
    {
        IEnumerable<SelectListItem> GetPaymentMathodListForDropDown();
        void Update(PaymentMathod paymentMathod);

    }
}
