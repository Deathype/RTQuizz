using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;


namespace RTQuizz.Hubs.Tests
{
    [TestClass()]
    public class QuizzHubTests
    {
        [TestMethod()]
        public void EnvoieresultatQuestionClasseTest()
        {

            Repondre testrep = new Repondre();
         testrep.Reponses.Question.NomQuestion="Esquec'estlol?";
             testrep.Stagiaire.NomStagiaire="le bleu";
             testrep.Stagiaire.Classe.NomClasse="ril18";
           testrep.Reponses.NomReponse="eededf";
            testrep.Reponses.BonneReponse=true;
                       
     //   string recup =  QuizzHub.Instance.EnvoieresultatQuestionClasse(testrep);




            Assert.Fail();
        }
    }
}