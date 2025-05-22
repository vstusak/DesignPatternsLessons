using Moq;
using NUnit.Framework;

namespace BuilderPattern;

[TestFixture]
public class DirectorTests
{
    private ReportDirector reportDirector;
    private Mock<IMyDateTimeAdapter> _myDateTimeAdapterMock;

    [SetUp]
    public void Setup()
    {
        _myDateTimeAdapterMock = new Mock<IMyDateTimeAdapter>(MockBehavior.Strict);
        reportDirector = new ReportDirector(new ReportBuilder(new BookRepository(), _myDateTimeAdapterMock.Object));
    }

    [Test]
    public void GetSimpleReportTest()
    {
        var result = reportDirector.CreateReportBasedOnParameters("s");
        var expected = "Baskervil Dog (Arthur C. Doyle) - 100\nClean Code (Robert C. Martin) - 324\nCatch me if you can (Frenk Abagnale) - 650\nR.U.R. (Karel Capek) - 50\n1984 (Jorge Orwell) - 350\n1984 (Jorge Orwell) - 350\n1985 () - 350";
        result.Is(expected);
    }

    [Test]
    public void GetFullReportTest()
    {
        var expectedDateTime = new DateTime(2011, 11, 11);
        _myDateTimeAdapterMock.Setup(dtp => dtp.GetDateTime()).Returns(expectedDateTime);

        var result = reportDirector.CreateReportBasedOnParameters("f");
        var expected = $"Hello this is content of our library\r\n------------------------------\r\nBaskervil Dog (Arthur C. Doyle) - 100\nClean Code (Robert C. Martin) - 324\nCatch me if you can (Frenk Abagnale) - 650\nR.U.R. (Karel Capek) - 50\n1984 (Jorge Orwell) - 350\n1984 (Jorge Orwell) - 350\n1985 () - 350\nCollected at {expectedDateTime}\r\n";
        Assert.That(result, Is.EqualTo(expected));
    }

}