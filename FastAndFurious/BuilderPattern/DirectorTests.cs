using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BuilderPattern
{
    [TestFixture]
    public class DirectorTests
    {
        private ReportDirector reportDirector;

        [SetUp]
        public void Setup()
        {
            reportDirector = new ReportDirector(new ReportFactory(new BookRepository()));
        }

        [Test]
        public void GetSimpleReportTest()
        {
            var result = reportDirector.CreateReportBasedOnParameters("s");
            var expected = "Baskervil Dog (Arthur C. Doyle) - 100\nClean Code (Robert C. Martin) - 324\nCatch me if you can (Frenk Abagnale) - 650\nR.U.R. (Karel Capek) - 50\n1984 (Jorge Orwell) - 350\n1984 (Jorge Orwell) - 350\n1985 () - 350";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetFullReportTest()
        {
            var result = reportDirector.CreateReportBasedOnParameters("f");
            var expected = "Hello this is content of our library\r\n------------------------------\r\nBaskervil Dog (Arthur C. Doyle) - 100\nClean Code (Robert C. Martin) - 324\nCatch me if you can (Frenk Abagnale) - 650\nR.U.R. (Karel Capek) - 50\n1984 (Jorge Orwell) - 350\n1984 (Jorge Orwell) - 350\n1985 () - 350\nCollected at 4/3/2025 1:53:56 PM\r\n";
            Assert.That(result, Is.EqualTo(expected));
        }

        // TODO Split full report test (date time)
        // TODO Create an extensin "Is" that does assert
    }
}
