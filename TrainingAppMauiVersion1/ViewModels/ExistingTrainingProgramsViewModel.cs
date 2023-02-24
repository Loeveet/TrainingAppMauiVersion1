using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion1.Models;

namespace TrainingAppMauiVersion1.ViewModels
{
    internal class ExistingTrainingProgramsViewModel
    {
        public List<TrainingProgram> TrainingPrograms { get; set; }

        public static async Task<List<TrainingProgram>> GetTrainingProgramFromMongoDB()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myCollection = database.GetCollection<TrainingProgram>("MyUsers");

            var users = await GetAllTrainingPrograms(myCollection);
            return users;

        }

        private static async Task<List<TrainingProgram>> GetAllTrainingPrograms(IMongoCollection<TrainingProgram> myCollection)
        {
            var allTrainingPrograms = await myCollection.AsQueryable().ToListAsync();
            return allTrainingPrograms;
        }

    }
}
