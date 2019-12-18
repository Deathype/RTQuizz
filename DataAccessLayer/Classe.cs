using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Classe
    {
        [Key]
        public int IdClasse { get; set; }
        public String nomClasse { get; set; }

        public int nombreEleve { get; set; }
    }
}
