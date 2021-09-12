using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IColorRepository : IRepository<Color>
    {
        IEnumerable<SelectListItem> GetColorListForDropDown();
        void Update(Color color);

    }
}
