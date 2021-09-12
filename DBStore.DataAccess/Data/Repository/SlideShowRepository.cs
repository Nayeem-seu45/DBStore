using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.DataAceess.Data.Repository;
using DBStore.Models;
using DBStore.Models.CMS;

namespace DBStore.DataAccess.Data.Repository
{
    public class SlideShowRepository : Repository<SlideShow>, ISlideShowRepository
    {

        private readonly ApplicationDbContext _db;

        public SlideShowRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
                

        }

        public void Update( SlideShow slideShow)
        {
            var slideShowDB = _db.SlideShow.FirstOrDefault(m => m.Id == slideShow.Id);
            slideShowDB.PrimaryText = slideShowDB.PrimaryText;
            slideShowDB.RawHtmlCode = slideShowDB.RawHtmlCode;
            slideShowDB.OtherText = slideShowDB.OtherText;
        
            
            if(slideShow.ImgUrl != null)
            {
                slideShowDB.ImgUrl = slideShowDB.ImgUrl;

            }
            _db.SaveChanges();
        }

    }
}
