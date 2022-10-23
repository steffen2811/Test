using Moq;
using System;
using System.Collections.Generic;
using Vejrudsigten.Services;
using Xunit;

namespace Vejrudsigten_test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(20, "Klart vejr", 22, "Klart vejr", "Det gode vejr fortsætter også i dag")]
        [InlineData(20, "Klart vejr", 22.0001, "Regn", "Solen erstattes i dag af regn og varmere vejr")]
        [InlineData(20, "Klart vejr", 17.9999, "Regn", "Farvel sol og varme - I dag bliver med kulde og regn")]
        [InlineData(1, "Klart vejr", -1, "Sne", "I dag skal fortovet ryddes og dækkene skiftes, nu kommer sneen")]
        [InlineData(5, "Klart vejr", 7, "Skyet", "Ikke mere sol for nu, men temperaturen holder ved")]
        [InlineData(6, "Regn", 4, "Regn", "Klassisk efterår, regnen forsætter")]
        [InlineData(2, "Regn", -12, "Sne", "Efteråret lakker mod enden. Nu kommer vinteren")]
        [InlineData(12, "Regn", 22, "Klart vejr", "Sol og varme i vente i løbet af dagen")]
        [InlineData(-1, "Sne", -3.0001, "Sne", "Børnene kan nå en kælketur endnu - Sneen fortsætter og temperaturen daler")]
        [InlineData(-1, "Sne", 0, "Regn", "Regn, tøsne og glatte veje")]
        [InlineData(0, "Sne", 3, "Klart vejr", "Sidste chance for leg i sneen. I dag kommer der sol og varme")]
        [InlineData(0, "Skyet", 2, "Skyet", "Det tørre vejr fortsætter, men stadig ingen sol")]
        public void PositiveBlackBoxTests(double tempYesterday, string condYesterday, double tempToday, string condToday, string expected )
        {
            var WeatherServiceStub = new Mock<IWeatherService>();
            
            WeatherInfo weatherInfoYesterday = new WeatherInfo();
            weatherInfoYesterday.Temperature = tempYesterday;
            weatherInfoYesterday.Conditions = condYesterday;

            WeatherInfo weatherInfoToday = new WeatherInfo();
            weatherInfoToday.Temperature = tempToday;
            weatherInfoToday.Conditions = condToday;

            WeatherServiceStub.Setup(x => x.GetYesterdaysWeather(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(weatherInfoYesterday));
            WeatherServiceStub.Setup(x => x.GetTodaysWeather(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(weatherInfoToday));

            WeatherForecast.SetWeatherService(WeatherServiceStub.Object);
            var result = WeatherForecast.GetForecastAsync("some_key");

            Assert.Equal(expected, result.Result);

        }
    }
}