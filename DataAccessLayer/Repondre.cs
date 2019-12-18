using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Repondre
    {

        
        public Stagiaire stagiaire { get; set; }
        [Key]
        public int IdStagiare { get; set; }
        public Question question { get; set; }
        [Key]
        public int IdQuestion { get; set; }
        [Key]
        public int IdReponse { get; set; }

        public Reponses reponses { get; set; }
        public Stagiaire repStagiaire { get; set; }

    }
}
