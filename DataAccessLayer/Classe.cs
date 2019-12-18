using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Classe
    {
        [Key]
        public int IdClass { get; set; }
        public String NomClasse { get; set; }

        public int NombreEleve { get; set; }
    }
}
