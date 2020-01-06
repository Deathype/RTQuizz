using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Reponses
    {
        public int Id { get; set; }
        public string NomReponse { get; set; }
        public bool BonneReponse { get; set; }
        public Question Question { get; set; }

        public Reponses()
        {

        }

        public Reponses(string nomReponse, bool bonneReponse, Question question)
        {
            NomReponse = nomReponse;
            BonneReponse = bonneReponse;
            Question = question;
        }
    }
}
