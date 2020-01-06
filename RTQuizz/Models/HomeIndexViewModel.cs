using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTQuizz.Models
{
    public class HomeIndexViewModel
    {
        public string Message { get; set; }

        public IList<Quizz> QuizzList { get; set; }
    }
}
