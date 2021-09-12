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
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {

        private readonly ApplicationDbContext _db;

        public QuestionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
                

        }

        public void Update( Question question)
        {
            var QuestionDB = _db.Questions.FirstOrDefault(m => m.Id == question.Id);
          
            _db.SaveChanges();
        }

    }
}
