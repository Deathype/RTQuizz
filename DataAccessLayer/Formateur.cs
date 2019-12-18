using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
   public class Formateur
    {
        [Key]
        public int idFormateur { get; set; }

        public String nom { get; set; }

        public String npPrenom { get; set; }

        public int profMatiere { get; set; }

    }
}
