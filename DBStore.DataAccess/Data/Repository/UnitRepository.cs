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
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {

        private readonly ApplicationDbContext _db;

        public UnitRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetUnitListForDropDown()
        {
            return _db.Unit.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()

            });


        }

        public void Update(Unit unit)
        {
            var UnitDB = _db.Unit.FirstOrDefault(m => m.Id == unit.Id);
            UnitDB.Name = unit.Name;
            UnitDB.ShortName = unit.ShortName;
            _db.SaveChanges();
        }
    }
}
