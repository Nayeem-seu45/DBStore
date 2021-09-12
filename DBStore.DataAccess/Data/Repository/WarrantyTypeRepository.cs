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
    public class WarrantyTypeRepository : Repository<WarrantyType>, IWarrantyTypeRepository
    {

        private readonly ApplicationDbContext _db;

        public WarrantyTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetWarrantyTypeListForDropDown()
        {
            return _db.WarrantyType.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()

            });


        }

      

        public void Update(WarrantyType warrantyType)
        {
            var WarrantyTypeDB = _db.WarrantyType.FirstOrDefault(m => m.Id == warrantyType.Id);
            WarrantyTypeDB.Name = warrantyType.Name;
            WarrantyTypeDB.Description = warrantyType.Description;
            _db.SaveChanges();
        }
    }
}
