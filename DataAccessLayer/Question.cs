﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
     public  class Question
    {
        [Key]
        public int IdQuestion { get; set; }
        public String Theme { get; set; }
        public String NomQuestion { get; set; }

    }
}
