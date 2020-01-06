using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Question
    {
        public int Id { get; set; }
        public string NomQuestion { get; set; }
        public IList<Reponses> ListReponses { get; set; }

        public Quizz Quizz { get; set; }

        public int NumQuestion { get; set; }

        public Question()
        {

        }

        public Question(Quizz quizz,string nomQuestion, int numQuestion)
        {
            Quizz = quizz;
            NomQuestion = nomQuestion;
            NumQuestion = numQuestion;
        }
    }
}

