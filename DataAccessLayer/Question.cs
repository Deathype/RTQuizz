using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
     public  class Question
    {
        [Key]
        public int id { get; set; }
        public String Theme { get; set; }
        public String Nom { get; set; }
    }
}
