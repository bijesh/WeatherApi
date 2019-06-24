using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using WeatherApi.Contract;
using WeatherApi.Model;
using WeatherApi.ViewModelBuilder;

namespace WeatherApi.Test.ViewModelBuilder
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class WeatherResultViewModelBuilderTests
    {
        
        private WeatherResultViewModelBuilder _weatherResultViewModelBuilder;

        [SetUp]
        public void SetUp()
        {
            _weatherResultViewModelBuilder = new WeatherResultViewModelBuilder();
        }

        [Test]
        public void Build_Returns_BreakdownPatchResult()
        {
            // Arrange
            var expectedResult = GetWeatherViewModel();
            var weatherResponse = GetWeatherResponse();

            // Act
            var actualResult = _weatherResultViewModelBuilder.Build(weatherResponse);

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        private WeatherViewModel GetWeatherViewModel()
        {
            return new WeatherViewModel()
            {
                Sunrise = 7,
                Sunset = 16,
                Humidity = 10,
                Pressure = 10,
                Temperature = 30.10,
                LocationName = "London",
                Maximum = 40.10,
                Minimum = 25.10

            };
        }

        private WeatherResponse GetWeatherResponse()
        {
            return  new WeatherResponse()
            {
                main = new Main()
                {
                    Temp = 30.10,
                    Humidity = 10,
                    Pressure = 10,
                    TempMax = 40.10,
                    TempMin = 25.10,

                },
                Name = "London",
                sys = new Sys()
                {
                    Sunset = 16,
                    Sunrise = 7
                }
            };
        }
    }
}
