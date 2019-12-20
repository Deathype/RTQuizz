using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using RTQuizz.Hubs;

namespace RTQuizz.Controllers
{
    public class QuizzController : Controller
    {
        private readonly ILogger<QuizzController> _logger;
        private DbRTContext _dbQuizz;
        private QuizzHub _QuizzHub;

        public QuizzController(ILogger<QuizzController> logger, DbRTContext dbQuizz, QuizzHub quizzHub)
        {
            _logger = logger;
            this._dbQuizz = dbQuizz;
            this._QuizzHub = quizzHub;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidReponse(int stagiaireId, int quizzId, int questionId, int reponseId)
        {
            //ReponseClasse RepClasseTemp = new ReponseClasse();
            //RepClasseTemp.Question = Rep.Reponses.Question.NomQuestion;
            //RepClasseTemp.Nom = Rep.Stagiaire.NomStagiaire;
            //RepClasseTemp.Classe = Rep.Stagiaire.Classe.NomClasse;
            //RepClasseTemp.Reponse = Rep.Reponses.NomReponse;
            //RepClasseTemp.Juste = Rep.Reponses.BonneReponse;

            //pour test signalr
            Repondre testrep = new Repondre();
                              


            testrep.Stagiaire = _dbQuizz.Stagiaire.Single(a => a.StagiaireId == stagiaireId);
            testrep.Question = _dbQuizz.Question.Single(a => a.Id == questionId);
            testrep.Reponses = _dbQuizz.Reponses.Single(r => r.Id == reponseId);
            // testrep.RepStagiaire

            _QuizzHub.AjoutResultat(testrep);

            ViewBag.Classe = testrep.Stagiaire.Classe.NomClasse;
            ViewBag.Question = testrep.Question.NomQuestion;

            return View("~/Views/Quizz/ResultQuestion.cshtml");
        }


    }
}