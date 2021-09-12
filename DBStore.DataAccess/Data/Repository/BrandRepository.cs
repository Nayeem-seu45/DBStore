using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.DataAceess.Data.Repository;
using DBStore.Models;


namespace DBStore.DataAccess.Data.Repository
{
   public class BrandRepository : Repository<Brand> ,IBrandRepository
    {
        private readonly ApplicationDbContext _db;

        public BrandRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetBrandListForDropDown()
        {
            return _db.Brand.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()

            });

            
        }

        public void Update(Brand brand)
        {
            var objFromDb = _db.Brand.FirstOrDefault(s => s.Id == brand.Id);
            objFromDb.Name = brand.Name;
            objFromDb.DisplayOrder = brand.DisplayOrder;

            if (brand.BrandIcon != null)
            {
                objFromDb.BrandIcon = objFromDb.BrandIcon;

            }
            _db.SaveChanges();
        }
    }
}
