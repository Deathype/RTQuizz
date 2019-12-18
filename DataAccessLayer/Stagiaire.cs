using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Stagiaire
    {

        [Key]
        public int idStagiaire { get; set; }
        public String nom { get; set; }

        public String prenom { get; set; }

        public Classe idClasse { get; set; }
    }
}
