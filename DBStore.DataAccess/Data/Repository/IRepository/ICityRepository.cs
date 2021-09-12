using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<SelectListItem> GetCityListForDropDown();
        void Update(City city);

    }
}
