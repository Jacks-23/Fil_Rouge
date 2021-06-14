using FilRouge.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DAL.Context
{
    internal class QuizzContext : DbContext
    {
        public QuizzContext()
            : base("QuizzContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        internal DbSet<Administrateur> Administrateurs { get; set; }
        internal DbSet<Candidat> Candidats { get; set; }
        internal DbSet<Question> Questions { get; set; }
        internal DbSet<QuizzClass> Quizzs { get; set; }
        internal DbSet<Recruteur> Recruteurs { get; set; }
    }
}
