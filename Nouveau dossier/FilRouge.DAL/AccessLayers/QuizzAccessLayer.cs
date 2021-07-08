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
    public class QuizzAccessLayer
    {
        private readonly QuizzContext context;
        private readonly DbSet<QuizzClass> quizzs;

        public QuizzAccessLayer()
        {
            this.context = new QuizzContext();
            this.quizzs = this.context.Set<QuizzClass>();

        }

        public List<QuizzClass> GetAll()
        {
 
            return this.quizzs.AsQueryable().AsNoTracking()
                .ToList();
        }

        public QuizzClass Get(int id)
        {
            return this.quizzs.AsQueryable().AsNoTracking()
                .Include(q => q.QuizzQuestions.Select(qq=> qq.Question))
                .FirstOrDefault(q => q.Id == id);
        }

        public async Task<bool> AddAsync(QuizzClass quizz)
        {
            this.quizzs.Add(quizz);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> UpdateAsync(QuizzClass quizz)
        {
            var quizzToEdit = this.quizzs.FirstOrDefault(p => p.Id == quizz.Id);

            if (quizzToEdit == null)
                return false;


            quizzToEdit.NbDeQuestions = quizz.NbDeQuestions;
            quizzToEdit.DateDeCreation = quizz.DateDeCreation;
            quizzToEdit.Note = quizz.Note;
            quizzToEdit.Niveau = quizz.Niveau;
            quizzToEdit.QuizzQuestions = quizz.QuizzQuestions;
            
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var quizzToRemove = this.quizzs.AsQueryable().FirstOrDefault(q => q.Id == id);
            this.quizzs.Remove(quizzToRemove);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

    }
}
