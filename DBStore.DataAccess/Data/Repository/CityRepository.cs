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
    public class CityRepository : Repository<City>, ICityRepository
    {

        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCityListForDropDown()
        {
            return _db.City.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()

            });


        }

        public void Update(City city)
        {
            var cityDB = _db.City.FirstOrDefault(m => m.Id == city.Id);
            cityDB.Name = city.Name;
            cityDB.Amount = city.Amount;
            cityDB.DisplayOrder = city.DisplayOrder;
            _db.SaveChanges();
        }
    }
}
