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
        public string NomStagiaire { get; set; }
        public Classe Classe { get; set; }
        public IList<QuizzStagiaire> QuizzStagiaire { get; set; }

        public Stagiaire()
        {

        }

        public Stagiaire(string nomStagiaire, Classe classe)
        {
            NomStagiaire = nomStagiaire;
            Classe = classe;
        }
    }
}
