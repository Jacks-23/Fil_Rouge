using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DAL.Models
{
    public class Candidat
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Niveau { get; set; }
        
        public string NomComplet()
        {
            return $"Le candidat se nomme {this.Prenom} {this.Nom} !";

        }
    }
}
