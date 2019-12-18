using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Reponses
    {
        [Key]
        public int IdReponse { get; set; }
        public String NomReponse { get; set; }
        public Boolean BonneReponse { get; set; }

        [ForeignKey("IdQuestion")]
        public Question question { get; set; }

        
        public int IdQuestion { get; set; }
    }
}
