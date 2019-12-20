using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Stagiaire
    {
        public int StagiaireId { get; set; }
        public String NomStagiaire { get; set; }
        public Classe Classe { get; set; }
     //   public List<Quizz> ListQuizz { get; set; }
        public IList<QuizzStagiaire> QuizzStagiaire { get; set; }

        public Stagiaire()
        {

        }

        public Stagiaire(String nomStagiaire, Classe classe)
        {
            NomStagiaire = nomStagiaire;
            Classe = classe;
        }
    }
}
