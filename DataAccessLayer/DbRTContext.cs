﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccessLayer
{
    public class DbRTContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Formateur> Formateurs { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Quizz> Quizz { get; set; }
        public DbSet<Repondre> Repondre { get; set; }
        public DbSet<Reponses> Reponses { get; set; }
        public DbSet<Stagiaire> Stagiaire { get; set; }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<QuizzQuestion> QuizzQuestion { get; set; }
        public DbSet<QuizzStagiaire> QuizzStagiaire { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizzQuestion>().HasKey(sc => new { sc.QuizzId, sc.QuestionId });
            modelBuilder.Entity<QuizzStagiaire>().HasKey(sc => new { sc.QuizzId, sc.StagiaireId });
            modelBuilder.Entity<Repondre>().HasKey(sc => new { sc.StagiaireId, sc.ReponsesId, sc.QuestionId });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=QuizDB2;Trusted_Connection=True;");
        }

        public Formateur AddFormateur(string nom, string prenom, string profMatiere)
        {
            var formateur = new Formateur(nom, prenom, profMatiere);
            Formateurs.Add(formateur);
            return formateur;
        }

        public Classe AddClasse(string nomClasse, int nombreEleve)
        {
            var classe = new Classe(nomClasse, nombreEleve);
            Classe.Add(classe);
            return classe;
        }

        public Stagiaire AddStagiaire(String nomStagiaire, Classe classe)
        {
            var stagiaire = new Stagiaire(nomStagiaire, classe);
            Stagiaire.Add(stagiaire);
            return stagiaire;
        }

        public Quizz AddQuizz(string nomQuizz, string themeQuizz, Formateur formateur)
        {
            var quizz = new Quizz(nomQuizz, themeQuizz, formateur);
            Quizz.Add(quizz);
            return quizz;
        }

        public QuizzStagiaire AddQuizzStagiaire(Quizz quizz, Stagiaire stagiaire)
        {
            var quizzStagiaire = new QuizzStagiaire(quizz, stagiaire);
            QuizzStagiaire.Add(quizzStagiaire);
            return quizzStagiaire;
        }

        public Question AddQuestion(string nomQuestion)
        {
            var question = new Question(nomQuestion);
            Question.Add(question);
            return question;
        }

        public QuizzQuestion AddQuizzQuestion(Quizz quizz, Question question)
        {
            var quizzQuestion = new QuizzQuestion(quizz, question);
            QuizzQuestion.Add(quizzQuestion);
            return quizzQuestion;
        }

        public Reponses AddReponses(string nomReponse, bool bonneReponse, Question question)
        {
            var reponses = new Reponses(nomReponse, bonneReponse, question);
            Reponses.Add(reponses);
            return reponses;
        }

        public Repondre AddRepondre(Stagiaire stagiaire, Question question, Reponses reponses, string repStagiaire)
        {
            var repondre = new Repondre(stagiaire, question, reponses, repStagiaire);
            Repondre.Add(repondre);
            return repondre;
        }

        public void DeleteAllData<T>(DbSet<T> dbset) where T : class
        {
            foreach (var entity in dbset)
                dbset.Remove(entity);
        }

        public void DeleteAllData()
        {
            DeleteAllData<Repondre>(Repondre);
            DeleteAllData<Reponses>(Reponses);
            DeleteAllData<QuizzQuestion>(QuizzQuestion);
            DeleteAllData<Question>(Question);
            DeleteAllData<QuizzStagiaire>(QuizzStagiaire);
            DeleteAllData<Quizz>(Quizz);
            DeleteAllData<Stagiaire>(Stagiaire);
            DeleteAllData<Classe>(Classe);
            DeleteAllData<Formateur>(Formateurs);
            SaveChanges();
        }

        public void InitData()
        {
            //DeleteAllData();

            if (Formateurs.Any())
                return;

            // Création du formateur
            var formateur = AddFormateur("Planas", "Jean-Pierre", "C#");

            // Création de la classe
            var classe = AddClasse("Ril18", 5);

            // Création des stagiaires :
            var stagiaireMarouen = AddStagiaire("Marouen", classe);
            var stagiaireGuillaume = AddStagiaire("Guillaume", classe);
            var stagiaireCamille = AddStagiaire("Camille", classe);
            var stagiaireClement = AddStagiaire("Clément", classe);
            var stagiaireRenaud = AddStagiaire("Renaud", classe);
            var stagiaireTiffaine = AddStagiaire("Tiffaine", classe);
            var stagiaireNicolas = AddStagiaire("Nicolas", classe);

            // Création du quizz
            var quizz1 = AddQuizz("Découvrir C#", "C#", formateur);
            var quizzLinq = AddQuizz("Linq", "C#", formateur);

            SaveChanges();
            // Association QuizzStagiaire
            AddQuizzStagiaire(quizz1, stagiaireMarouen);
            AddQuizzStagiaire(quizz1, stagiaireGuillaume);
            AddQuizzStagiaire(quizz1, stagiaireCamille);
            AddQuizzStagiaire(quizz1, stagiaireClement);
            AddQuizzStagiaire(quizz1, stagiaireRenaud);
            AddQuizzStagiaire(quizz1, stagiaireTiffaine);
            AddQuizzStagiaire(quizz1, stagiaireNicolas);

            AddQuizzStagiaire(quizzLinq, stagiaireMarouen);
            AddQuizzStagiaire(quizzLinq, stagiaireGuillaume);
            AddQuizzStagiaire(quizzLinq, stagiaireCamille);
            AddQuizzStagiaire(quizzLinq, stagiaireClement);
            AddQuizzStagiaire(quizzLinq, stagiaireRenaud);
            AddQuizzStagiaire(quizzLinq, stagiaireTiffaine);
            AddQuizzStagiaire(quizzLinq, stagiaireNicolas);

            SaveChanges();

            // Ajout de questions
            var q1 = AddQuestion("Quelle est l'outil responsable de mapping objet en C#");

            var qLinq1 = AddQuestion("Linq q1");
            var qLinq2 = AddQuestion("Linq q2");
            var qLinq3 = AddQuestion("Linq q3");
            var qLinq4 = AddQuestion("Linq q4");
            var qLinq5 = AddQuestion("Linq q5");
            var qLinq6 = AddQuestion("Linq q6");
            var qLinq7 = AddQuestion("Linq q7");
            var qLinq8 = AddQuestion("Linq q8");
            var qLinq9 = AddQuestion("Linq q9");
            var qLinq10 = AddQuestion("Linq q10");

            SaveChanges();
            // Association Quizz et questions
            AddQuizzQuestion(quizz1, q1);
            AddQuizzQuestion(quizzLinq, qLinq1);
            AddQuizzQuestion(quizzLinq, qLinq2);
            AddQuizzQuestion(quizzLinq, qLinq3);
            AddQuizzQuestion(quizzLinq, qLinq4);
            AddQuizzQuestion(quizzLinq, qLinq5);
            AddQuizzQuestion(quizzLinq, qLinq6);
            AddQuizzQuestion(quizzLinq, qLinq7);
            AddQuizzQuestion(quizzLinq, qLinq8);
            AddQuizzQuestion(quizzLinq, qLinq9);
            AddQuizzQuestion(quizzLinq, qLinq10);

            SaveChanges();
            // Ajout de réponses
            var repQ1 = AddReponses("Entity framework", true, q1);

            AddReponses("A", true, qLinq1);
            AddReponses("B", false, qLinq1);
            AddReponses("C", false, qLinq1);
            AddReponses("D", false, qLinq1);
            AddReponses("E", false, qLinq1);

            AddReponses("A", false, qLinq2);
            AddReponses("B", false, qLinq2);
            AddReponses("C", false, qLinq2);
            AddReponses("D", true, qLinq2);

            AddReponses("A", false, qLinq3);
            AddReponses("B", false, qLinq3);
            AddReponses("C", false, qLinq3);
            AddReponses("D", true, qLinq3);
            AddReponses("E", false, qLinq3);
            AddReponses("F", false, qLinq3);

            AddReponses("A", false, qLinq4);
            AddReponses("B", false, qLinq4);
            AddReponses("C", true, qLinq4);
            AddReponses("D", false, qLinq4);

            AddReponses("A", false, qLinq5);
            AddReponses("B", false, qLinq5);
            AddReponses("C", false, qLinq5);
            AddReponses("D", true, qLinq5);

            AddReponses("Affichage des données - Appel de GetValues - Jean - Pierre", true, qLinq6);

            AddReponses("Appel de GetValues - Affichage des données - Jean - Pierre", true, qLinq7);

            AddReponses("A", true, qLinq8);
            AddReponses("B", false, qLinq8);
            AddReponses("C", false, qLinq8);
            AddReponses("D", false, qLinq8);

            AddReponses("A", true, qLinq9);
            AddReponses("B", false, qLinq9);
            AddReponses("C", false, qLinq9);
            AddReponses("D", false, qLinq9);

            AddReponses("A", false, qLinq10);
            AddReponses("B", true, qLinq10);
            AddReponses("C", false, qLinq10);
            AddReponses("D", false, qLinq10);

            SaveChanges();
            // Ajout de réponses d'une stagiaire
            AddRepondre(stagiaireMarouen, q1, repQ1, repQ1.NomReponse);

            SaveChanges();
        }
    }
}
