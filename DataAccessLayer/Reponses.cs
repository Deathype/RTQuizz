using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Reponses
    {
      
        public int Id { get; set; }
        public String NomReponse { get; set; }
        public Boolean BonneReponse { get; set; }
        public Question Question { get; set; }
   
    }
}
