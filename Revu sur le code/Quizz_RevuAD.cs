using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsTD.Questionnaire
{
    public class Quizz
    {
        public int Id { get; set; }

        //AD : NbQuestions => il y a plusieurs questions
        public int NbQuestion { get; set; }

        //AD : Renommer la propriété RatioQuestionsFaciles
        public double RatioFacile { get; set; }
        
        //AD : Renommer la propriété en RatioQuestionsMoyennes
        public double RatioMoyen { get; set; }

        //AD : Ajouter une propriété RatioQuestionsDifficiles
        
        //AD : Pour ces trois propriétés : Est-ce bien le bon type ? Ce sont des questions ou des étudiants ?
        // s à la fin pour bien indiquer que l'on parle d'une liste 
        //Si je comprends bien tu remplis ces listes avec toutes les questions faciles, toutes les questions moyennes et difficiles de ta base ?  
        public List<Student> StudentFacile { get; set; }
        public List<Student> StudentMoyen { get; set; }
        public List<Student> StudentDifficile { get; set; }

        //AD : Idem, le type et le nom ne sont pas représentatifs de ce que c'est.
        public List<Student> Students { get; set; }

        //AD Méthode à décaller dans une classe spécialisée, signature de la méthode à revoir => void et prennant en paramètre un object Quizz 
        public List<Student> GenerationDeStudent(int nbquestions, double x1, double x2, List<Student> student1, List<Student> student2, List<Student> student3)
        {
            // Initialisation des paramètres :
            //AD : Pourquoi renseigner des paramètres pour les valoriser avec les propriétés de l'objet en question ? Tu peux tout simplement directement utiliser 
            // la propriété. Les paramètres d'une méthode doivent servir a influencer l'exécution de celle-ci. Dans ton cas tu t'en sert comme coquille de variable
            nbquestions = this.NbQuestion;
            x1 = this.RatioFacile;
            x2 = this.RatioMoyen;
            student1 = this.StudentFacile;
            student2 = this.StudentMoyen;
            student3 = this.StudentDifficile;

            //Si tu décalles ta méthode et que tu prends en paramètre un objet quizz, il ne faut pas stocker cette liste dans une variable mais dans la propriété 
            // Questions. Tu lui affectes une nouvelle liste et tu utilises cette propriété par la suite
            List<Student> students = new List<Student>{};

            //AD : De manière générale, si tu utilises l'anglais (Student, Quizz etc.) utilise le partout. Force toi à le faire dès maintenant car la plupart des ESN codent en anglais
            // le framework et ses méthodes étant en anglais c'est plus facile à lire du full anglais que du fran-glais.
            // Et en plus ça améliorera ton vocabulaire d'anglais, pratique pour les vacances à l'étranger ;) 
            Random aleatoire = new Random();

            //AD :Je m'interroge sur l'utilité de cette méthode : elle n'a pas d'apport réél, la méthode Random.Next(min, max) fait exactement la même chose
            // Conclusion : à supprimer et à remplacer par aleatoire.Next(min,max)
            //Dans tous les cas, il faut éviter de créer une méthode dans une méthode, ça porte plus à confusion et entâche la lisibilité du code
            int melange(int x, int y)
            {
                return aleatoire.Next(x, y);
            }

            //AD : A mettre dans la propriété RatioQuestionsDifficiles
            double x3 = 100 - (x1 + x2);

            while (student3.Count < nbquestions)
            {
                // On veut avoir le bon nombre de questiuons mais prendre aussi en compte
                // le cas où il n'y a pas de questions d'un certain niveau demandées.

                //AD: x1 à remplacer par la propriété ratioQuestionsFaciles
                // A externaliser dans une méthode CalculateQuestionsCount(int ratio, int nbQuestions) qui retourne le nombre de questions
                //Comme ça tu évites de dupliquer ton code 3 fois avec des paramètres différents

                int nbquestionsfaciles = (int)Math.Floor(x1 / 100 * nbquestions);
                if (x1 != 0 && nbquestionsfaciles == 0)
                    nbquestionsfaciles = 1;

                int nbquestionsmoyennes = (int)Math.Floor(x2 / 100 * nbquestions);
                if (x2 != 0 && nbquestionsmoyennes == 0)
                    nbquestionsmoyennes = 1;

                //AD : x2 ou x3 ? 
                int nbquestionsdifficiles = (int)Math.Floor(x2 / 100 * nbquestions);
                if (x3 != 0 && nbquestionsdifficiles == 0)
                    nbquestionsdifficiles = 1;

                //AD : Dans ce cas la, pourquoi ne pas générer directement le nombre de question moyennes, le nombre de questions difficiles et en déterminer le nombre 
                // de questions faciles à partir du nombre de questions totales : moins de traitements, moins de code et même résultat donc mieux 
                int sommequestions = nbquestionsfaciles + nbquestionsmoyennes + nbquestionsdifficiles;

                if (nbquestions - sommequestions > 0)
                    nbquestionsfaciles = nbquestionsfaciles + (nbquestions - sommequestions);

                //AD : Externaliser dans une méthode GénérateQuestions(int nbQuestions, List<Questions> Questions) comme ça tu peux l'utiliser pour les trois
                while (students.Count < nbquestionsfaciles)
                {
                    int melangeId = melange(0, student1.Count);
                    if (students.Contains(student1[melangeId]) == false)
                    {
                        students.Add(student1[melangeId]);
                        student1.RemoveAt(melangeId);

                    }

                }

                while (students.Count < nbquestions - nbquestionsdifficiles)
                {
                    int melangeId = melange(0, student2.Count);
                    if (students.Contains(student2[melangeId]) == false)
                    {
                        students.Add(student2[melangeId]);
                        student2.RemoveAt(melangeId);

                    }

                }

                while (students.Count < nbquestions)
                {
                    int melangeId = melange(0, student3.Count);
                    if (students.Contains(student3[melangeId]) == false)
                    {
                        students.Add(student3[melangeId]);
                        student3.RemoveAt(melangeId);

                    }

                }
                
            }

            //AD : De manière générale une méthode doit être courte : 15 / 20 lignes, et ne faire qu'une seule fonction
            // Une classe (ici Quizz) doit représenter un objet métier, ou un regroupement de fonctionnalités (QizzGenerator par exemple) mais pas un peu des deux.
            // 
            return students;
        }
    }
}
