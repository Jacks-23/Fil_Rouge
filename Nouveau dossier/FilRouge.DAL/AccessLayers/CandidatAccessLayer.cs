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
    public class CandidatAccessLayer
    {
        private readonly QuizzContext context;
        private readonly DbSet<Candidat> candidats;

        public CandidatAccessLayer()
        {
            this.context = new QuizzContext();
            this.candidats = this.context.Set<Candidat>();
        }

        public List<Candidat> GetAll()
        {
            return this.candidats.AsQueryable().AsNoTracking().ToList();
        }

        public Candidat Get(int id)
        {
            return this.candidats.AsQueryable().AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public async Task<bool> AddAsync(Candidat candidat)
        {
            this.candidats.Add(candidat);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Candidat candidat)
        {
            var candidatToEdit = this.candidats.FirstOrDefault(c => c.Id == candidat.Id);

            if (candidatToEdit == null)
                return false;
            candidatToEdit.Niveau = candidat.Niveau;
            candidatToEdit.Nom = candidat.Nom;
            candidatToEdit.Prenom = candidat.Prenom;

            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var candidatToRemove = this.candidats.AsQueryable().FirstOrDefault(c => c.Id == id);
            this.candidats.Remove(candidatToRemove);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }

       
    }
}
