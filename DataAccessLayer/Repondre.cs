using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Repondre
    {


        public Stagiaire Stagiaire { get; set; }
         public Question Question { get; set; }
         public Reponses Reponses { get; set; }
        public string RepStagiaire { get; set; }

        public int StagiaireId { get; set; }
        public int QuestionId { get; set; }
        public int ReponsesId { get; set; }

    }
}
