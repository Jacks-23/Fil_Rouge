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
    public class RecruteurAccessLayer
    {
        private readonly QuizzContext context;
        private readonly DbSet<Recruteur> recruteurs;

        public RecruteurAccessLayer()
        {
            this.context = new QuizzContext();
            this.recruteurs = this.context.Set<Recruteur>();
        }

        public List<Recruteur> GetAll()
        {
            return this.recruteurs.AsQueryable().AsNoTracking().ToList();
        }

        public Recruteur Get(int id)
        {
            return this.recruteurs.AsQueryable().AsNoTracking()
                .FirstOrDefault(r => r.Id == id);
        }

        public async Task<bool> AddAsync(Recruteur recruteur)
        {
            this.recruteurs.Add(recruteur);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Recruteur recruteur)
        {
            var recruteurToEdit = this.recruteurs.FirstOrDefault(r => r.Id == recruteur.Id);

            if (recruteurToEdit == null)
                return false;
            recruteurToEdit.Identifiant = recruteur.Identifiant;
            recruteurToEdit.MotDePasse = recruteur.MotDePasse;
            recruteurToEdit.Nom = recruteur.Nom;
            recruteurToEdit.Prenom = recruteur.Prenom;

            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var recruteurToRemove = this.recruteurs.AsQueryable().FirstOrDefault(r => r.Id == id);
            this.recruteurs.Remove(recruteurToRemove);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;

        }

    }
}
