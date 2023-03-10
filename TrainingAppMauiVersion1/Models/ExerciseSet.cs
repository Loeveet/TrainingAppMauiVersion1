using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion1.Models
{
    internal class ExerciseSet
    {
        public Exercise Exercise { get; set; }
        public double ChoosenWeight { get; set; } = 0;
        public int Repetitions { get; set; } = 0;
        public double Duration { get; set; }
        public double CaloriesBurned { get; set; } // Räkna ut hur långt ett set blir. använd sedan formeln.

        //The MET value of Weight lifting = 4.8.
        //We multiply the MET value with the person\'s body weight in kilogram.
        //Then we multiply this with 0.0175 and the duration in minutes.
        //30 minutes of Weight lifting burns 206 kcal.
        //TimeSpan ts = TimeSpan.FromSeconds(Repetitions * 5);
        //Duration = ts.TotalMinutes
        //4,8 * Person.Weight * 0,0175 * Duration.
    }
}
