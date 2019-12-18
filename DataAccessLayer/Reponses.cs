using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Reponses
    {
        [Key]
        public int id { get; set; }
        public String nom { get; set; }
        public Boolean bonneReponse { get; set; }
        public Question question { get; set; }
    }
}
