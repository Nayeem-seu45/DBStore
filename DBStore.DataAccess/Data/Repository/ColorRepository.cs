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
    public class ColorRepository : Repository<Color>, IColorRepository
    {

        private readonly ApplicationDbContext _db;

        public ColorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetColorListForDropDown()
        {
            return _db.Color.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()

            });


        }

        public void Update(Color color)
        {
            var ColorDB = _db.Color.FirstOrDefault(m => m.Id == color.Id);
            ColorDB.Name = color.Name;
          
            _db.SaveChanges();
        }
    }
}
