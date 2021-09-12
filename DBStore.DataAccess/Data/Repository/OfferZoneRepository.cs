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
    public class OfferZoneRepository : Repository<OfferZone>, IOfferZoneRepository
    {

        private readonly ApplicationDbContext _db;

        public OfferZoneRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

       

        public IEnumerable<SelectListItem> GetOffertListForDropDown()
        {
            return _db.OfferZone.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()

            });
        }

        public void Update(OfferZone offerZone)
        {
            var OfferDB = _db.OfferZone.FirstOrDefault(m => m.Id == offerZone.Id);
            OfferDB.Name = offerZone.Name;
            OfferDB.Description = offerZone.Description;
            _db.SaveChanges();
        }
    }
}
