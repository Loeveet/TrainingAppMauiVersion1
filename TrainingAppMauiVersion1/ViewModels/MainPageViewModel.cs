﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAppMauiVersion1.Models;

namespace TrainingAppMauiVersion1.ViewModels
{
    internal class MainPageViewModel
    {
        public MainPageViewModel()
        {

        }
        public static async Task<List<Person>> GetUsersFromMongoDB()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myCollection = database.GetCollection<Person>("MyUsers");

            var users = await GetAllUsers(myCollection);
            return users;

        }

        private static async Task<List<Person>> GetAllUsers(IMongoCollection<Person> myCollection)
        {
            var allUsers = await myCollection.AsQueryable().ToListAsync();
            return allUsers;
        }
    }
}
