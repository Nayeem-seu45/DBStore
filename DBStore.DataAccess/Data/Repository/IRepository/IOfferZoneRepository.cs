using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IOfferZoneRepository : IRepository<OfferZone>
    {
        IEnumerable<SelectListItem> GetOffertListForDropDown();
        void Update(OfferZone offerZone);
    }
}
