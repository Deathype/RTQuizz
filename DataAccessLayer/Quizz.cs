using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    class Quizz
    {
        public int idQuizz { get; set; }
        public String nomQuizz { get; set; }
        public String themeQuizz { get; set; }
        public Formateur formateur { get; set; }
        public List<Question> listQuestions { get; set; }
    }
}
