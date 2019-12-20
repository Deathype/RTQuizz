using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    [Table("Formateur")]
   public class Formateur
    {
        
        public int Id { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }

        public String ProfMatiere { get; set; }

        public Formateur()
        {

        }

        public Formateur(string nom, string prenom, string profMatiere)
        {
            Nom = nom;
            Prenom = prenom;
            ProfMatiere = profMatiere;
        }
    }
}
