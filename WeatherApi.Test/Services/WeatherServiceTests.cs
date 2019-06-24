using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WeatherApi.Contract;
using WeatherApi.Interface;
using WeatherApi.Services;

namespace WeatherApi.Test.Services
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class WeatherServiceTests
    {
        private WeatherService weatherService;
        private Mock<IWebApiClient> webApiClientMock;

        [SetUp]
        public void SetUp()
        {
            
            webApiClientMock = new Mock<IWebApiClient>();
            webApiClientMock.Setup(x => x.GetAsync(It.IsAny<Uri>())).ReturnsAsync(GetResponse);
            weatherService = new WeatherService(webApiClientMock.Object);
        }

        [Test]
        public async Task SearchWeather_Returns_WeatherResponse()
        {
            // Arrange
            var location = "London,UK";
   
            //Act
            var actualWeatherResponse = await weatherService.SearchWeather(location);
            
            //Assert
            Assert.IsInstanceOf<WeatherResponse>(actualWeatherResponse);
        }
        
        private HttpResponseMessage GetResponse()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(GetJson(), Encoding.UTF8, "application/json")
            };
        }
        private string GetJson()
        {
            var path = System.AppContext.BaseDirectory;
            var streamReader = new StreamReader(@path + "weather.json", Encoding.UTF8);
            return streamReader.ReadToEnd();
        }
    }
}
