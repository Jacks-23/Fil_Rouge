using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DAL.Models
{
   
    public class QuizzClass
    {
        public int Id { get; set; }
        public int NbDeQuestions { get; set; }
        public DateTime DateDeCreation { get; set; }
        public int Note { get; set; }
        public string Niveau { get; set; }
        public virtual ICollection<QuizzQuestion> QuizzQuestions { get; set; }


    }
}
