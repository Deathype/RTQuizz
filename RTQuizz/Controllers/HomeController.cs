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
using Microsoft.EntityFrameworkCore;

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
            List<Quizz> listQuizz = _dbQuizz.Quizz.ToList();

            ViewBag.listQuizz = listQuizz;
            return View();
        }

        [HttpPost]
        public ActionResult RunQuizz(String nomUser, String nomQuizz)
        {
            String message = "";
            String view;

            //Formateur forma = _dbQuizz.Formateurs.First();
            Classe classe = _dbQuizz.Classe.First();

            //ViewBag.Formateur = forma;

            // Récupération du Quizz dans la base
            Quizz quizz = _dbQuizz.Quizz.Include(q => q.Questions).ThenInclude(q => q.ListReponses).SingleOrDefault(n => n.NomQuizz == nomQuizz);

            if (quizz == null)
            {
                ViewBag.listQuizz = _dbQuizz.Quizz.ToList();
                message = "Le Quizz n'existe pas, impossible d'y accéder";
                ViewBag.message = message;
                return View("index");
            }
            // Questions
            if (quizz.Questions.Count() == 0)
            {
                ViewBag.listQuizz = _dbQuizz.Quizz.ToList();
                message = "Le Quizz ne comporte aucunes questions, impossible de jouer ☺";
                ViewBag.message = message;
                return View("index");
            }
            // Recupération du stagiaire dans la base
            Stagiaire stagiaire = _dbQuizz.Stagiaire.SingleOrDefault(n => n.NomStagiaire == nomUser && n.Classe == classe);
            
            if (stagiaire != null)
            {
                
                // Ajout du stagiaire au quizz
                view = "~/Views/Quizz/AfficheQuestion.cshtml";
            }
            else
            {
                stagiaire = new Stagiaire();
                stagiaire.NomStagiaire = nomUser;
                stagiaire.Classe = classe;
                _dbQuizz.Stagiaire.Add(stagiaire);
                _dbQuizz.SaveChanges();

                // Creation du stagiaire et ajout au quizz
                view = "~/Views/Quizz/AfficheQuestion.cshtml";
            }
            if(!_dbQuizz.QuizzStagiaire.Any(qs => qs.Stagiaire == stagiaire && qs.Quizz == quizz)){
                _dbQuizz.QuizzStagiaire.Add(new QuizzStagiaire(quizz, stagiaire));
            }
            
            
            // Stagiaire
            ViewBag.Stagiaire = stagiaire;
            // Quizz
            ViewBag.Quizz = quizz;

          
            ViewBag.Question = quizz.Questions.First();
            
            // Reponses 
            var reponses = quizz.Questions.First().ListReponses;
            if (reponses == null)
            {
                ViewBag.listQuizz = _dbQuizz.Quizz.ToList();
                return View("Index");
            }
            ViewBag.Reponses = reponses;

            ViewBag.listQuizz = _dbQuizz.Quizz.ToList();
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
