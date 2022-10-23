using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Vejrudsigten.Services
{
    public static class WeatherForecast
    {
        private static IWeatherService weatherService;
        public static void SetWeatherService(IWeatherService value)
        {
            weatherService = value;
        }

        private static bool SameTemperature(double tempYesterday, double tempToday)
        {
            return (((tempToday - tempYesterday) >= -2) || ((tempToday - tempYesterday) <= 2));
        }
        public static async Task<string> GetForecastAsync(string key)
        {
            var todayInfo = await weatherService.GetTodaysWeather(key, "Kolding");
            var yesterdayInfo = await weatherService.GetYesterdaysWeather(key, "Kolding");
            
            switch (yesterdayInfo.Conditions)
            {
                case "Klart vejr":
                    if (todayInfo.Conditions == "Klart vejr" && SameTemperature(yesterdayInfo.Temperature, todayInfo.Temperature))
                        return "Det gode vejr fortsætter også i dag";
                    else if (todayInfo.Conditions == "Regn" && ((todayInfo.Temperature - yesterdayInfo.Temperature) > 2))
                        return "Solen erstattes i dag af regn og varmere vejr";
                    else if (todayInfo.Conditions == "Regn" && ((todayInfo.Temperature - yesterdayInfo.Temperature) < -2))
                        return "Farvel sol og varme - I dag bliver med kulde og regn";
                    else if (todayInfo.Conditions == "Sne" && SameTemperature(yesterdayInfo.Temperature, todayInfo.Temperature))
                        return "I dag skal fortovet ryddes og dækkene skiftes, nu kommer sneen";
                    else if (todayInfo.Conditions == "Skyet" && SameTemperature(yesterdayInfo.Temperature, todayInfo.Temperature))
                        return "Ikke mere sol for nu, men temperaturen holder ved";
                    break;
                case "Regn":
                    if (todayInfo.Conditions == "Regn" && SameTemperature(yesterdayInfo.Temperature, todayInfo.Temperature))
                        return "Klassisk efterår, regnen forsætter";
                    else if (todayInfo.Conditions == "Sne" && ((todayInfo.Temperature - yesterdayInfo.Temperature) < -2))
                        return "Efteråret lakker mod enden. Nu kommer vinteren";
                    else if (todayInfo.Conditions == "Klart vejr" && ((todayInfo.Temperature - yesterdayInfo.Temperature) > 2))
                        return "Sol og varme i vente i løbet af dagen";
                    break;
                case "Sne":
                    if (todayInfo.Conditions == "Sne" && ((todayInfo.Temperature - yesterdayInfo.Temperature) < -2))
                        return "Børnene kan nå en kælketur endnu - Sneen fortsætter og temperaturen daler";
                    if (todayInfo.Conditions == "Regn" && SameTemperature(yesterdayInfo.Temperature, todayInfo.Temperature))
                        return "Regn, tøsne og glatte veje";
                    else if (todayInfo.Conditions == "Klart vejr" && ((todayInfo.Temperature - yesterdayInfo.Temperature) > 2))
                        return "Sidste chance for leg i sneen. I dag kommer der sol og varme";
                    break;
                case "Skyet":
                    if (todayInfo.Conditions == "Skyet" && SameTemperature(yesterdayInfo.Temperature, todayInfo.Temperature))
                       return "Det tørre vejr fortsætter, men stadig ingen sol";
                    break;
                default:
                    break;
            }

            return "Vejrtekst ikke defineret";
        }
    }
}
