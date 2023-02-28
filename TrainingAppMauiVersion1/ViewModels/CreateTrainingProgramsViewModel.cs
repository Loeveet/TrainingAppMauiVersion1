using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion1.ViewModels
{
    internal partial class CreateTrainingProgramsViewModel : ObservableObject
    {
        [ObservableProperty]
        string input;

        public CreateTrainingProgramsViewModel()
        {
            
        }

        public static async Task<List<Models.Exercise>> GetExercisesAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "Z1AsZOLR7z7cW8II5n1oaw==4xgbZdGvTQe5wyub");
            List<Models.Exercise> exercises = null;

            HttpResponseMessage response = await client.GetAsync("v1/exercises?muscle=biceps");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                exercises = JsonSerializer.Deserialize<List<Models.Exercise>>(responseString);
            }
            return exercises;
        }
    }
}
