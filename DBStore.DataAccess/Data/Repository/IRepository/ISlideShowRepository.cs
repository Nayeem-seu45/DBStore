using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;
using DBStore.Models.CMS;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface ISlideShowRepository : IRepository<SlideShow>
    {
        void Update(SlideShow slideShow);
    }
}
