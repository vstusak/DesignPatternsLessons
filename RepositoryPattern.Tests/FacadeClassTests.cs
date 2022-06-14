using FacadePattern;
using FacadePattern.Entities;
using Moq;
using NUnit.Framework;

namespace RepositoryPattern.Tests
{
    [TestFixture]
    public class FacadeClassTests : TestsBase
    {

        private Mock<ITemperatureConventorService> mockTemperatureConventorService;
        private Mock<ILocationLookUpService> mockLocationLookUpService;
        private Mock<IWeatherService> mockWeatherService;

        [SetUp]
        public void SetUp()
        {
            mockTemperatureConventorService = MockRepo.Create<ITemperatureConventorService>();
            mockLocationLookUpService = MockRepo.Create<ILocationLookUpService>();
            mockWeatherService = MockRepo.Create<IWeatherService>();
        }

        private FacadeClass CreateFacadeClass()
        {
            return new FacadeClass(
                mockTemperatureConventorService.Object,
                mockLocationLookUpService.Object,
                mockWeatherService.Object);
        }

        [Test]
        public void GetWeather_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var city = "Brno";
            var state = "Czech Republic";
            var f = 45;
            var c = 5;
            var unit = CreateFacadeClass();
            string zip = "62100";

            mockLocationLookUpService.Setup(mlmus => mlmus.GetCity(It.IsAny<string>())).Returns(new City{Name = city});
            mockLocationLookUpService.Setup(mlmus => mlmus.GetState(It.IsAny<string>())).Returns(new State { Name = state });
            mockWeatherService.Setup(mws => mws.GetFahrenheit(It.IsAny<City>(), It.IsAny<State>())).Returns(f);
            mockTemperatureConventorService.Setup(mtcs => mtcs.ToCelsia(It.IsAny<int>())).Returns(c);
            // Act
            var result = unit.GetWeather(
                zip);

            // Assert
            Assert.AreEqual(city, result.City.Name);
            Assert.AreEqual(state, result.State.Name);
            Assert.AreEqual(f, result.TempF);
            Assert.AreEqual(c, result.TempC);
        }
    }
}
