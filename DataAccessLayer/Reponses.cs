using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    class Reponses
    {
        public int id { get; set; }
        public String nom { get; set; }
        public Boolean bonneReponse { get; set; }
        public Question question { get; set; }
    }
}
