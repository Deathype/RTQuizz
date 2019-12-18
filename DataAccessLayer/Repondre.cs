using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Repondre
    {

        [ForeignKey("IdStagiaire")]
        public Stagiaire stagiaire { get; set; }

        [Key, Column(Order = 0)]
        public int IdStagiaire { get; set; }
       [ForeignKey("IdQuestion")]
        public Question question { get; set; }
        [Key, Column(Order = 1)]
        public int IdQuestion { get; set; }
        [Key, Column(Order = 2)]
        public int IdReponse { get; set; }
        [ForeignKey("IdReponse")]
        public Reponses reponses { get; set; }
        public String RepStagiaire { get; set; }

    }
}
