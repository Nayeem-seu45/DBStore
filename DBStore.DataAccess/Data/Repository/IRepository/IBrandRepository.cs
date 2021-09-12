using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
   public interface IBrandRepository : IRepository<Brand>
    {
        IEnumerable<SelectListItem> GetBrandListForDropDown();

        void Update(Brand brand);
    }
}
