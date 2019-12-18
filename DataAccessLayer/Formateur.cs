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
        [Key]
        public int idFormateur { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }

        public String ProfMatiere { get; set; }

    }
}
