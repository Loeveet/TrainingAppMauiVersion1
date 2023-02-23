using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion1.Models
{
    internal class Person
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Email { get; set; }
        public List<TrainingProgram> Programs { get; set; }

        public static async Task<List<Person>> GetUsers()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myCollection = database.GetCollection<Person>("MyUsers");

            var users = await GetAllUsers(myCollection);
            return users;
            //var allUsers = await myCollection.AsQueryable().ToListAsync();
            //return allUsers;

        }

        private static async Task<List<Person>> GetAllUsers(IMongoCollection<Person> myCollection)
        {
            var allUsers = await myCollection.AsQueryable().ToListAsync();
            return allUsers;
        }
    }
}
