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
    public class MessageRepository : Repository<Massage>, IMessageRepository
    {

        private readonly ApplicationDbContext _db;

        public MessageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

     

        public void Update(Massage massage)
        {
            var MassageDB = _db.Massage.FirstOrDefault(m => m.Id == massage.Id);
            

            _db.SaveChanges();
        }
    }
}
