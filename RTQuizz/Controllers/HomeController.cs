﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RTQuizz.Hubs;
using RTQuizz.Models;

namespace RTQuizz.Controllers
{
    public class HomeController : Controller
    {
        private DbRTContext _dbQuizz;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DbRTContext dbQuizz)
        {
            _logger = logger;
            this._dbQuizz = dbQuizz;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RunQuizz(String nomUser, String nomQuizz)
        {
            String message = "";
            String view;

            Formateur forma = new Formateur();
            forma.Id = 1;
            ViewBag.Formateur = forma;

            Quizz quizz = _dbQuizz.Quizz.SingleOrDefault(n => n.NomQuizz == nomQuizz);

            if (quizz == null)
            {
                message = "Le Quizz n'existe pas, impossible d'y accéder";
                ViewBag.message = message;
                return View("index");
            }

            Stagiaire stagiaire = _dbQuizz.Stagiaire.SingleOrDefault(n => n.NomStagiaire == nomUser && n.Classe.Id == 1);
            
            if (stagiaire != null)
            {
                
                // Ajout du stagiaire au quizz
                view = "~/Views/Quizz/AfficheQuestion.cshtml";
            }
            else
            {
                stagiaire = new Stagiaire();
                stagiaire.NomStagiaire = nomUser;
                stagiaire.Classe.Id = 1;
                _dbQuizz.Stagiaire.Add(stagiaire);
                _dbQuizz.SaveChanges();

                // Creation du stagiaire et ajout au quizz
                view = "~/Views/Quizz/AfficheQuestion.cshtml";
            }
            quizz.QuizzStagiaire.Add(new QuizzStagiaire(quizz, stagiaire));
            
            ViewBag.Stagiaire = stagiaire;
            ViewBag.Quizz = quizz;
            ViewBag.Question = quizz.Questions.First();
            ViewBag.Reponses = quizz.Questions.First().ListReponses;
            return View(view);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
