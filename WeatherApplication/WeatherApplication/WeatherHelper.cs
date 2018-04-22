using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WeatherApplication
{
    internal static class WeatherHelper
    {
        private static string AppId = "5a9f5e7ae554f4156e5442293048f920";
        private static WeatherResult response;

        internal static async Task<bool> init(string cityName)
        {
            var httpClient = new HttpClient();
            var requestUri = $"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={AppId}";
            var json = await httpClient.GetStringAsync(requestUri);

            response = JsonConvert.DeserializeObject<WeatherResult>(json);

            return true; // async void methods are not okay
        }

        internal static BitmapImage GetImage()
        {
            var icon = $"https://openweathermap.org/img/w/{response.list[0].weather[0].icon}.png";
            var source = new BitmapImage(new Uri(icon));

            return source;
        }

        internal static double GetTemperature()
        {
            return ConvertKelvinToCelciusDegrees(response.list[0].main.temp);
        }

        internal static double GetHumidity()
        {
            return response.list[0].main.humidity;
        }

        internal static double GetPressure()
        {
            return response.list[0].main.pressure;
        }

        internal static double GetWindSpeed()
        {
            return response.list[0].wind.speed;
        }

        internal static string GetCountry()
        {
            return response.city.country;
        }

        internal static string GetDescription()
        {
            return response.list[0].weather[0].description;
        }

        internal static string GetTime()
        {
            return response.list[0].dt_txt;
        }

        private static double ConvertKelvinToCelciusDegrees(double kelvin)
        {
            return kelvin - 273.15;
        }
    }
}