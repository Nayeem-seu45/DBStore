using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;
using DBStore.Models.CMS;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IReviewsRepository : IRepository<Reviews>
    {
        void Update(Reviews reviews);
    }
}
