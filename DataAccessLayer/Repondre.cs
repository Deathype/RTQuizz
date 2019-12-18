using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Repondre
    {

        
        public Stagiaire stagiaire { get; set; }

        [Key, Column(Order = 0)]
        public int IdStagiare { get; set; }
       
        public Question question { get; set; }
        [Key, Column(Order = 1)]
        public int IdQuestion { get; set; }
        [Key, Column(Order = 2)]
        public int IdReponse { get; set; }

        public Reponses reponses { get; set; }
        public Stagiaire repStagiaire { get; set; }

    }
}
