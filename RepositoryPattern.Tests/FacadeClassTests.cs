using FacadePattern;
using Moq;
using NUnit.Framework;
using System;

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
            var unit = CreateFacadeClass();
            string zip = null;

            // Act
            var result = unit.GetWeather(
                zip);

            // Assert
            Assert.Fail();
        }
    }
}
