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
    public class AdministrateurAccessLayer
    {
        private readonly QuizzContext context;
        private readonly DbSet<Administrateur> administrateurs;

        public AdministrateurAccessLayer()
        {
            this.context = new QuizzContext();
            this.administrateurs = this.context.Set<Administrateur>();
        }

        public List<Administrateur> GetAll()
        {
            return this.administrateurs.AsQueryable().AsNoTracking().ToList();
        }

        public Administrateur Get(int id)
        {
            return this.administrateurs.AsQueryable().AsNoTracking()
                .FirstOrDefault(a => a.Id == id);

        }

        public async Task<bool> AddAsync(Administrateur administrateur)
        {
            this.administrateurs.Add(administrateur);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }
        
        public async Task<bool> UpdateAsync(Administrateur administrateur)
        {
            var administrateurToEdit = this.administrateurs.FirstOrDefault(a => a.Id == administrateur.Id);

            if (administrateurToEdit == null)
                return false;
            administrateurToEdit.Identifiant = administrateur.Identifiant;
            administrateurToEdit.MotDePasse = administrateur.MotDePasse;
            administrateurToEdit.Nom = administrateur.Nom;
            administrateurToEdit.Prenom = administrateur.Prenom;

            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;

        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            var administrateurToRemove = this.administrateurs.AsQueryable().FirstOrDefault(a => a.Id == id);
            this.administrateurs.Remove(administrateurToRemove);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }
    }
}
