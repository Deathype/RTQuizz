﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Quizz
    {
        public int Id { get; set; }
        public string NomQuizz { get; set; }
        public string ThemeQuizz { get; set; }
        public Formateur Formateur { get; set; }
        public IList<Question> Questions { get; set; }
        public IList<QuizzStagiaire> QuizzStagiaire { get; set; }
        //   public List<Stagiaire> ListeStagiaire { get; set; }
        // public List<Question> ListQuestion { get; set; }

        public Quizz()
        {

        }

        public Quizz(string nomQuizz, string themeQuizz, Formateur formateur)
        {
            NomQuizz = nomQuizz;
            ThemeQuizz = themeQuizz;
            Formateur = formateur;
        }
    }
}

