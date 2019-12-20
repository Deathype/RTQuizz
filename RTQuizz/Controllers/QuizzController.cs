using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using RTQuizz.Hubs;

namespace RTQuizz.Controllers
{
    public class QuizzController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidReponse()
        {


            //pour test signalr
            Repondre testrep = new Repondre();
            testrep.Reponses.Question.NomQuestion = "Esquec'estlol?";
            testrep.Stagiaire.NomStagiaire = "le bleu";
            testrep.Stagiaire.Classe.NomClasse = "ril18";
            testrep.Reponses.NomReponse = "eededf";
            testrep.Reponses.BonneReponse = true;


            QuizzHub.Instance.AjoutResultat(testrep);

            ViewBag.Classe = testrep.Stagiaire.Classe.NomClasse;
            ViewBag.Question= testrep.Question.NomQuestion;

            return View("~/Views/Quizz/ResultQuestion.cshtml");
        }


    }
}