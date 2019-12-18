using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Stagiaire
    {

        [Key]
        public int IdStagiaire { get; set; }
        public String NomStagiaire { get; set; }

        [ForeignKey("IdClass")]
        public Classe Classe { get; set; }

        
        public int IdClass { get; set; }
    }
}
