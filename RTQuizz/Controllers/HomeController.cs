using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RTQuizz.Models;

namespace RTQuizz.Controllers
{
    public class HomeController : Controller
    {
        private DbRtQuizz _dbQuizz;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DbRtQuizz dbQuizz)
        {
            _logger = logger;
            this._dbQuizz = dbQuizz;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RunQuizz(String prenomUser, String nomUser, String nomQuizz)
        {
            String message = "";
            String view;

            Formateur forma = new Formateur();
            forma.idFormateur = 1;
            ViewBag.Formateur = forma;

            if (_dbQuizz.Quizz.Any(q => q.nomQuizz == nomQuizz))
            {

                Quizz quizz = _dbQuizz.Quizz.Find(nomQuizz);
                ViewBag.Quizz = quizz;

                if (_dbQuizz.Stagiaires.Any(s => s.nom == nomUser) && _dbQuizz.Stagiaires.Any(s => s.prenom == prenomUser))
                {
                    // Ajout du stagiaire au quizz
                    view = "~/Views/Quizz/AfficheQuestion.cshtml";
                }
                else
                {
                    // Creation du stagiaire et ajout au quizz
                    view = "~/Views/Quizz/AfficheQuestion.cshtml";
                }
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
