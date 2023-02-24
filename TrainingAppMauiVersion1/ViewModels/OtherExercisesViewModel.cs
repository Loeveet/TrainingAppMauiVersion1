using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAppMauiVersion1.Models;
using TrainingAppMauiVersion1.Views;

namespace TrainingAppMauiVersion1.ViewModels
{
    internal class OtherExercisesViewModel
    {
        public List<CalorieBurningExercise> OtherExercises { get; set; }


        public OtherExercisesViewModel()
        {
            var task = Task.Run(() => GetCalorieBurningExercisesAsync("skii"));
            task.Wait();
            OtherExercises = task.Result;
        }

        public static async Task<List<CalorieBurningExercise>> GetCalorieBurningExercisesAsync(string activity)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "E2O3R8zknVI8Lo/k0kdq7A==JBFTCWQdZStbgUQq");

            List<CalorieBurningExercise> cbe = null;

            HttpResponseMessage response = await client.GetAsync("v1/caloriesburned?activity=" + activity);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                cbe = JsonSerializer.Deserialize<List<CalorieBurningExercise>>(responseString);
            }

            return cbe;
        }
    }
}
