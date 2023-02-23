using MongoDB.Driver;
using TrainingAppMauiVersion1.Models;
using TrainingAppMauiVersion1.ViewModels;

namespace TrainingAppMauiVersion1;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }


    private async void OnClickedLoggedIn(object sender, EventArgs e)
    {

        // Försökte lyfta in metoden att hämta users i viewmodel, men fick det inte att fungera. Just nu fungerar det som det ska
        // men det är inte så det ska vara. Kolla mainpageviewmodel och försök fixa.


        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase("TrainingAppPerson");
        var myCollection = database.GetCollection<Person>("MyUsers");

        Task<List<Person>> getAllUsers = GetAllUsers(myCollection);
        var users = await getAllUsers;

        foreach (var user in users)
        {
            if (MyUserName.Text == user.UserName && MyPassword.Text == user.PassWord)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Welcome " + user.Name, "Continue");
                await Navigation.PushAsync(new Views.LoggedInPage());
                return;
            }

        }

        await App.Current.MainPage.DisplayAlert("Failed to log in", "Wrong username or password", "Try again");
    }

    private async void OnClickedRegister(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.RegisterPage());
    }

    private static async Task<List<Person>> GetAllUsers(IMongoCollection<Person> myCollection)
    {
        var allUsers = await myCollection.AsQueryable().ToListAsync();
        return allUsers;
    }

}

