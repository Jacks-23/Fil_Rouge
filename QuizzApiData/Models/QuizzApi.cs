using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace QuizzApiData.Models
{
    [DataContract]
    public class QuizzApi
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int NbDeQuestions { get; set; }

        [DataMember]
        public DateTime Depart { get; set; }

        [DataMember]
        public DateTime Fin { get; set; }

        [DataMember]
        public int Note { get; set; }

        [DataMember]
        public string Niveau { get; set; }

        [DataMember]
        public virtual IList<Question> Questions { get; set; }


    }

    [DataContract]
    public class Administrateur
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public string Prenom { get; set; }
        
        [DataMember]
        public string MotDePasse { get; set; }
    }

    [DataContract]
    public class Candidat
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public string Prenom { get; set; }

        [DataMember]
        public string Niveau { get; set; }
    }

    [DataContract]
    public class Question
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Reponse { get; set; }

        [DataMember]
        public string Difficulte{ get; set; }

    }

    [DataContract]
    public class Recruteur
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public string Prenom { get; set; }

        [DataMember]
        public string MotDePasse { get; set; }
    }



}