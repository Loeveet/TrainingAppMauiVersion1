using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion1.Models
{
    internal class CalorieBurningExercise
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("calories_per_hour")]
        public int CaloriesPerHour { get; set; }

        [JsonPropertyName("duration_minutes")]
        public int DurationInMinutes { get; set; }

        [JsonPropertyName("total_calories")]
        public int TotalCalories { get; set; }

        public static async Task<List<CalorieBurningExercise>> GetCalorieBurningExercises(string uri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "E2O3R8zknVI8Lo/k0kdq7A==JBFTCWQdZStbgUQq");

            List<CalorieBurningExercise> cbe = null;

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                cbe = JsonSerializer.Deserialize<List<CalorieBurningExercise>>(responseString);
            }

            return cbe;
        }
    }
}
