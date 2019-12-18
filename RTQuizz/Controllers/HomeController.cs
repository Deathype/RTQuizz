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
        public async Task<ActionResult> RunQuizz(String nomUser, String nomQuizz)
        {
            String message = "";
            String view;

            Formateur forma = new Formateur();
            forma.idFormateur = 1;
            ViewBag.Formateur = forma;

            if (_dbQuizz.Quizz.Any(q => q.NomQuizz == nomQuizz))
            {

                Quizz quizz = _dbQuizz.Quizz.Find(nomQuizz);
                

                if (_dbQuizz.Stagiaire.Any(s => s.NomStagiaire == nomUser))
                {
                    Stagiaire stagiaire = _dbQuizz.Stagiaire.Find(nomUser);
                    
                    ViewBag.Stagiaire = stagiaire;
                    ViewBag.Quizz = quizz;
                    //await QuizzHub.Instance.ConnecterUserQuizz(nomUser, "ril18", nomQuizz);
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
