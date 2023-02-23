using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion1.Models
{
    internal class Trivia
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("question")]
        public string Question { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        public static readonly string[] categories = new[]
        {
            "artliterature",
            "language",
            "sciencenature",
            "general",
            "fooddrink",
            "peopleplaces",
            "geography",
            "historyholidays",
            "entertainment",
            "toysgames",
            "music",
            "mathematics",
            "religionmythology",
            "sportsleisure"
        };

        public static async Task<List<Trivia>> GetTrivia(string uri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "Z1AsZOLR7z7cW8II5n1oaw==4xgbZdGvTQe5wyub");

            List<Trivia> trivia = null;

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                trivia = JsonSerializer.Deserialize<List<Trivia>>(responseString);

            }
            return trivia;
        }
    }
}
