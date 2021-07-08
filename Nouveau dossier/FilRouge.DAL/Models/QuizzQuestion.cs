using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DAL.Models
{
    public class QuizzQuestion
    {
        [Key, Column(Order = 1)]
        public int QuizzId { get; set; }

        [Key, Column(Order = 2)]
        public int QuestionId { get; set; }

        public virtual QuizzClass Quizz { get; set; }
        public virtual Question Question { get; set; }
    }
}
