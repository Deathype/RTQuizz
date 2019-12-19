using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class QuizzStagiaire
    {
        public int QuizzId { get; set; }
        public Quizz Quizz { get; set; }

        public int StagiaireId { get; set; }
        public Stagiaire Stagiaire { get; set; }


    }
}
