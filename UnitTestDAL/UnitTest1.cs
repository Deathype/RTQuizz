using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UnitTestDAL
{
    [TestClass]
    public class DBContextTest
    {
        [TestMethod]
        public void TestOpen()
        {
            DbRTContext dbRtQuizz = new DbRTContext();
            dbRtQuizz.Database.CanConnect();

        }
        [TestMethod]
        public void TestTables()
        {
            DbRTContext dbRTContext = new DbRTContext();
           
            Assert.IsTrue(dbRTContext.Quizz.ToList().Count>= 0);
            Assert.IsTrue(dbRTContext.Formateurs.ToList().Count >= 0); 
            Assert.IsTrue(dbRTContext.Question.ToList().Count >= 0);
          
            Assert.IsTrue(dbRTContext.Repondre.ToList().Count >= 0);
            Assert.IsTrue(dbRTContext.Reponses.ToList().Count >= 0);
            Assert.IsTrue(dbRTContext.Stagiaire.ToList().Count >= 0);
            Assert.IsTrue(dbRTContext.Classe.ToList().Count >= 0);
            Assert.IsTrue(dbRTContext.QuizzStagiaire.ToList().Count >= 0);
            
           



        }
        [TestMethod]
        public void TestParticipe()
        {
            DbRTContext dbRtQuizz = new DbRTContext();
            var p = dbRtQuizz.Quizz.Include(q => q.QuizzStagiaire).ThenInclude(p=>p.Stagiaire).ToList()[0].QuizzStagiaire.ToList();

           // var p1 = dbRtQuizz.Quizz.Include(q => q.ListParticipe).ThenInclude(p => p.Stagiaire);

           // var p = p1.ToList()[0].ListParticipe.ToList();
            Assert.IsTrue(p.Count>=0);
           // var ListStagiaire = from quizz in dbRtQuizz.Quizz 
           //                     join participe in dbRtQuizz.Participe on quizz.Id equals participe.QuizzId
           //                     where quizz.Id == 1
           //                     select participe.Stagiaire;

           // Assert.IsTrue(ListStagiaire.Count() >= 0);
           //// p[0].Stagiaire.

        }
    }
}
