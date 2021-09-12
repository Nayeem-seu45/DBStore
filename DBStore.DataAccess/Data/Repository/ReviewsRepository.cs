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
    public class ReviewsRepository : Repository<Reviews>, IReviewsRepository
    {

        private readonly ApplicationDbContext _db;

        public ReviewsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
                

        }

        public void Update( Reviews reviews)
        {
            var ReviewsDB = _db.Reviews.FirstOrDefault(m => m.Id == reviews.Id);
            
          
            if(reviews.ProductImage != null)
            {
                ReviewsDB.ProductImage = ReviewsDB.ProductImage;

            }
            _db.SaveChanges();
        }

    }
}
