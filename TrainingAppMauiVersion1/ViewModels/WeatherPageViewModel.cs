using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAppMauiVersion1.Models;

namespace TrainingAppMauiVersion1.ViewModels
{
    internal class WeatherPageViewModel
    {
        public OpenWeather TheWeather { get; set; }

        public WeatherPageViewModel()
        {
            var task = Task.Run(() => GetWeatherAsync("Nyköping"));
            task.Wait();
            TheWeather = task.Result;
        }
        private static async Task<OpenWeather> GetWeatherAsync(string city)
        {

            string apiKey = "aaa3c5f1fb092617638c1dcf8266f07b";

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
            OpenWeather weatherData = null;
            var client = new HttpClient();
            HttpResponseMessage response1 = await client.GetAsync(url);
            if (response1.IsSuccessStatusCode)
            {
                string apiResponse = await response1.Content.ReadAsStringAsync();
                weatherData = JsonSerializer.Deserialize<OpenWeather>(apiResponse);

            }
            return weatherData;
        }
    }
}
