using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IWarrantyTypeRepository : IRepository<WarrantyType>
    {
        IEnumerable<SelectListItem> GetWarrantyTypeListForDropDown();
        void Update(WarrantyType warrantyType);

    }
}
