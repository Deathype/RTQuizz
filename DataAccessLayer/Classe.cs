using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Classe
    {
       
        public int Id { get; set; }
        public String NomClasse { get; set; }
        public int NombreEleve { get; set; }

        public Classe()
        {

        }

        public Classe(string nomClasse, int nombreEleve)
        {
            NomClasse = nomClasse;
            NombreEleve = nombreEleve;

        }
    }
}
