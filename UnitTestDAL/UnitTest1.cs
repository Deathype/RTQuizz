using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using System.Linq;

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



        }
    }
}
