using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WeatherApi.Contract;
using WeatherApi.Controllers;
using WeatherApi.Interface;
using WeatherApi.Model;

namespace WeatherApi.Test.Controllers
{

    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class WeatherControllerTests
    {
        private WeatherController _weatherController;
        private Mock<IWeatherService> _weatherServiceMock;
        private Mock<IWeatherResultViewModelBuilder> _weatherResultViewModelBuilderMock;

        [SetUp]
        public void SetUp()
        {
            _weatherServiceMock = new Mock<IWeatherService>();
            _weatherResultViewModelBuilderMock = new Mock<IWeatherResultViewModelBuilder>();
            _weatherServiceMock.Setup(x => x.SearchWeather(It.IsAny<string>())).ReturnsAsync(new WeatherResponse());
            _weatherResultViewModelBuilderMock.Setup(x => x.Build(It.IsAny<WeatherResponse>()))
                .Returns(GetWeatherViewModel());
            _weatherController = new WeatherController(_weatherServiceMock.Object, _weatherResultViewModelBuilderMock.Object);
        }

        [Test]
        public async Task Get_Returns_Instance_Of_IActionResult()
        {
            // Act
            var result = await _weatherController.Get("London,uk");

            // Assert
            Assert.IsInstanceOf<ActionResult<WeatherViewModel>>(result);
        }

        [Test]
        public async Task Get_Calls_SearchWeather()
        {
            // Act
            await _weatherController.Get("London,uk");

            // Assert
            _weatherServiceMock.Verify(x=>x.SearchWeather(It.IsAny<string>()),Times.Once);
        }

        [Test]
        public async Task Get_Calls_Build()
        {
            // Act
            await _weatherController.Get("London,uk");

            // Assert
            _weatherResultViewModelBuilderMock.Verify(x => x.Build(It.IsAny<WeatherResponse>()), Times.Once);
        }

        [Ignore("set up later")]
        [Test]
        public void Get_Calls_SearchWeather_Throws_Exception()
        {
            //Arrange 
            _weatherServiceMock.Setup(x => x.SearchWeather(It.IsAny<string>())).Throws(new Exception());

            // Assert
            Assert.ThrowsAsync<Exception>(async() => await _weatherController.Get("London,uk"));
        }

        private WeatherViewModel GetWeatherViewModel()
        {
            return new WeatherViewModel();
        }
    }
}
