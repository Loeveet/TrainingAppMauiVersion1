using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion1.Models
{
    internal static class SiteVariables
    {
        public static string SearchOtherExercises { get; set; }
        public static Person LoggedInPerson { get; set; } // kanske inte behöver
        public static string LoggedInPersonString { get; set; } // kanske räcker med denna
    }
}
