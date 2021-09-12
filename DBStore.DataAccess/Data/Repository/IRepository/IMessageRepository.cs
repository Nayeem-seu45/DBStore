using System;
using System.Collections.Generic;
using System.Text;
using DBStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IMessageRepository : IRepository<Massage>
    {
        
        void Update(Massage massage);

    }
}
