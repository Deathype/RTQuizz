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

        public DbSet<QuizzQuestion> QuizzQuestion { get; set; }
        public DbSet<QuizzStagiaire> QuizzStagiaire { get; set; }
        //  public DbSet<Composer> Composer { get; set; }

        //public DbSet<Participe> Participe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizzQuestion>().HasKey(sc => new { sc.QuizzId, sc.QuestionId });
            modelBuilder.Entity<QuizzStagiaire>().HasKey(sc => new { sc.QuizzId, sc.StagiaireId });
            modelBuilder.Entity<Repondre>().HasKey(sc => new { sc.StagiaireId, sc.ReponsesId, sc.QuestionId });


            //modelBuilder.Entity<Repondre>()
            //    .HasKey(r => new { r.StagiaireId, r.QuestionId, r.Id });

            // modelBuilder.Entity<Composer>()
            //     .HasKey(r => new { r.QuestionId, r.QuizzId});
            // modelBuilder.Entity<Participe>()
            //    .HasKey(r => new { r.StagiaireId, r.QuizzId });

            //modelBuilder.Entity<Participe>()
            //    .HasOne<Stagiaire>(sc => sc.Stagiaire)
            //     .WithMany(s => s.ListParticipe)
            //     .HasForeignKey(p => p.StagiaireId);

            // modelBuilder.Entity<Participe>()
            //  .HasOne<Quizz>(sc => sc.Quizz)
            //   .WithMany(s => s.ListParticipe)
            //   .HasForeignKey(p => p.QuizzId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=QuizDB2;Trusted_Connection=True;");
        }
    }
}
