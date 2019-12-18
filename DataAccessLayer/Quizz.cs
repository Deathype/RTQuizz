using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
   public class Quizz
    {
        [Key]
        public int idQuizz { get; set; }
        public String NomQuizz { get; set; }
        public String ThemeQuizz { get; set; }
     [ForeignKey("IdFormateur")]
        public Formateur formateur { get; set; }
    
    }
}
