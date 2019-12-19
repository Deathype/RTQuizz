using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Participe
    {
        [Key, Column(Order = 0)]
        public int IdStagiaire { get; set; }

        [Key, Column(Order = 1)]
        public int  IdQuizz { get; set; }

    }
}
