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
    }
}
