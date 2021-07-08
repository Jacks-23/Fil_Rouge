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

        public Question Get(int id)
        {
            return this.questions.AsQueryable().AsNoTracking()
                .FirstOrDefault(q => q.Id == id);
        }

        public async Task<bool> AddAsync(Question question)
        {
            this.questions.Add(question);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }

        public async Task<bool> UpdateAssync(Question question)
        {
            var questionToEdit = this.questions.FirstOrDefault(q => q.Id == question.Id);

            if (questionToEdit == null)
                return false;
            questionToEdit.Quizzs = question.Quizzs;
            questionToEdit.Reponse = question.Reponse;
            questionToEdit.Difficulte = question.Difficulte;

            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var questionToremove = this.questions.AsQueryable().FirstOrDefault(q => q.Id == id);
            this.questions.Remove(questionToremove);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }

        public bool Exists(List<int> ids) => ids.All(q =>
        this.questions.Select(idq => idq.Id).Contains(q));
    }
}
