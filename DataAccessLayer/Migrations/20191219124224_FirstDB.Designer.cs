﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(DbRTContext))]
    [Migration("20191219124224_FirstDB")]
    partial class FirstDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomClasse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreEleve")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Classe");
                });

            modelBuilder.Entity("DataAccessLayer.Formateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfMatiere")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Formateur");
                });

            modelBuilder.Entity("DataAccessLayer.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomQuestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuizzId")
                        .HasColumnType("int");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuizzId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("DataAccessLayer.Quizz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FormateurId")
                        .HasColumnType("int");

                    b.Property<string>("NomQuizz")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StagiaireId")
                        .HasColumnType("int");

                    b.Property<string>("ThemeQuizz")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormateurId");

                    b.HasIndex("StagiaireId");

                    b.ToTable("Quizz");
                });

            modelBuilder.Entity("DataAccessLayer.QuizzQuestion", b =>
                {
                    b.Property<int>("QuizzId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("QuizzId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuizzQuestion");
                });

            modelBuilder.Entity("DataAccessLayer.Reponses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BonneReponse")
                        .HasColumnType("bit");

                    b.Property<string>("NomReponse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Reponses");
                });

            modelBuilder.Entity("DataAccessLayer.Stagiaire", b =>
                {
                    b.Property<int>("StagiaireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClasseId")
                        .HasColumnType("int");

                    b.Property<string>("NomStagiaire")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StagiaireId");

                    b.HasIndex("ClasseId");

                    b.ToTable("Stagiaire");
                });

            modelBuilder.Entity("DataAccessLayer.Question", b =>
                {
                    b.HasOne("DataAccessLayer.Quizz", null)
                        .WithMany("ListQuestion")
                        .HasForeignKey("QuizzId");
                });

            modelBuilder.Entity("DataAccessLayer.Quizz", b =>
                {
                    b.HasOne("DataAccessLayer.Formateur", "Formateur")
                        .WithMany()
                        .HasForeignKey("FormateurId");

                    b.HasOne("DataAccessLayer.Stagiaire", null)
                        .WithMany("ListQuizz")
                        .HasForeignKey("StagiaireId");
                });

            modelBuilder.Entity("DataAccessLayer.QuizzQuestion", b =>
                {
                    b.HasOne("DataAccessLayer.Question", "Question")
                        .WithMany("QuizzQuestion")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Quizz", "Quizz")
                        .WithMany("QuizzQuestion")
                        .HasForeignKey("QuizzId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Reponses", b =>
                {
                    b.HasOne("DataAccessLayer.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("DataAccessLayer.Stagiaire", b =>
                {
                    b.HasOne("DataAccessLayer.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("ClasseId");
                });
#pragma warning restore 612, 618
        }
    }
}
