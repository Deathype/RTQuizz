using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
     public  class Question
    {
        
        public int Id { get; set; }
        public String Theme { get; set; }
        public String NomQuestion { get; set; }
        public IList<QuizzQuestion> QuizzQuestion { get; set; }
    }
    //public List<Reponses> ListReponses { get; set; }


    }

