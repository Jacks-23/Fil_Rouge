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
    }
}
