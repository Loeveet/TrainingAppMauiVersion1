using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAppMauiVersion1.Models;

namespace TrainingAppMauiVersion1.ViewModels
{
    internal partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string userName;
        [ObservableProperty]
        string password;

        [ObservableProperty]
        OpenWeather oWeather = new OpenWeather();
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
        [RelayCommand]
        public async void GetAWeather()
        {
            var weather = await GetWeatherAsync("Nyköping");
            OWeather = weather;
        }

        [RelayCommand]
        public static async Task<OpenWeather> GetWeatherAsync(string city)
        {

            string apiKey = "aaa3c5f1fb092617638c1dcf8266f07b";

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
            OpenWeather weatherData = null;
            var client = new HttpClient();
            HttpResponseMessage response1 = await client.GetAsync(url);
            if (response1.IsSuccessStatusCode)
            {
                string apiResponse = await response1.Content.ReadAsStringAsync();
                weatherData = JsonSerializer.Deserialize<OpenWeather>(apiResponse);

            }
            return weatherData;
        }
        //public static async void OnClickedLoggedIn()
        //{
        //    var users = await MainPageViewModel.GetUsersFromMongoDB();

        //    foreach (var user in users)
        //    {
        //        if (UserName == user.UserName && Password == user.PassWord)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Success", "Welcome " + user.Name, "Continue");
                    
        //            await Navigation.PushAsync(new Views.LoggedInPage());
        //            return;
        //        }

        //    }

        //    await App.Current.MainPage.DisplayAlert("Failed to log in", "Wrong username or password", "Try again");
        //}
    }
}
