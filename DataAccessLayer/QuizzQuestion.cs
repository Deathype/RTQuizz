using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class QuizzQuestion
    {
        public int QuizzId { get; set; }
        public Quizz Quizz { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public QuizzQuestion(Quizz Quizz, Question question)
        {
            this.Quizz = Quizz;
            this.Question = Question;
        }

        public QuizzQuestion() { }
    }
}
