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


    }
}
