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
    }
}
