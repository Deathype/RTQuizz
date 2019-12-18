using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;

namespace UnitTestDAL
{
    [TestClass]
    public class DBContextTest
    {
        [TestMethod]
        public void TestOpen()
        {
            DbRtQuizz dbRtQuizz = new DbRtQuizz();
            dbRtQuizz.Database.CanConnect();

        }
    }
}
