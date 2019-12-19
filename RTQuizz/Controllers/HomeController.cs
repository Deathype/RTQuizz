using System;
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
            forma.idFormateur = 1;
            ViewBag.Formateur = forma;

            if (_dbQuizz.Quizz.Any(q => q.NomQuizz == nomQuizz))
            {

                Quizz quizz = _dbQuizz.Quizz.Single(n => n.NomQuizz == nomQuizz);


<<<<<<< HEAD
                if (_dbQuizz.Stagiaire.Any(s => s.IdStagiaire == nomUser) && _dbQuizz.Stagiaire.Any(s => s.prenom == prenomUser))
=======
                if (_dbQuizz.Stagiaire.Any(s => s.NomStagiaire == nomUser))
>>>>>>> b018eb3c6de272fdbc6f5ccf66991ea8323cb629
                {
                    Stagiaire stagiaire = _dbQuizz.Stagiaire.Single(n => n.NomStagiaire == nomUser);
                    
                    ViewBag.Stagiaire = stagiaire;
                    // Ajout du stagiaire au quizz
                    view = "~/Views/Quizz/AfficheQuestion.cshtml";
                }
                else
                {
                    Stagiaire stagiaire = new Stagiaire();
                    stagiaire.NomStagiaire = nomUser;
                    stagiaire.IdClass = 1;
                    _dbQuizz.Stagiaire.Add(stagiaire);
                    _dbQuizz.SaveChanges();
                    ViewBag.Stagiaire = stagiaire;
                    
                    // Creation du stagiaire et ajout au quizz
                    view = "~/Views/Quizz/AfficheQuestion.cshtml";
                }
                ViewBag.Quizz = quizz;
            }
            else
            {
                message = "Le Quizz n'existe pas, impossible d'y accéder";
                ViewBag.message = message;
                view = "index";
            }

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
