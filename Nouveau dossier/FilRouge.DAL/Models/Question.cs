using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DAL.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Reponse { get; set; }
        public string Difficulte { get; set; }
        public virtual ICollection<QuizzQuestion> Quizzs { get; set; }
    }
}
