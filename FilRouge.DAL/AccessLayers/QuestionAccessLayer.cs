using FilRouge.DAL.Context;
using FilRouge.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DAL.AccessLayers
{
    public class QuestionAccessLayer
    {
        private readonly QuizzContext context;
        private readonly DbSet<Question> questions;

        public QuestionAccessLayer()
        {
            this.context = new QuizzContext();
            this.questions = this.context.Set<Question>();
        }

        public List<Question> GetAll()
        {
            return this.questions.AsQueryable().AsNoTracking().ToList();
        }
    }
}
