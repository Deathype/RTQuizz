using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccessLayer
{
    public class DbRTContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<Formateur> Formateurs { get; set; }
        public DbSet<Question> Question { get; set; }

      public DbSet<Quizz> Quizz{ get; set; }

           public DbSet<Repondre> Repondre { get; set; }

         public DbSet<Reponses> Reponses { get; set; }

         public DbSet<Stagiaire> Stagiaire { get; set; }

           public DbSet<Classe> Classe { get; set; }
           

       // public DbSet<Composer> Composer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repondre>()
                .HasKey(r => new { r.IdStagiaire, r.IdQuestion, r.IdReponse });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=QuizDB;Trusted_Connection=True;");
        }
    }
}
