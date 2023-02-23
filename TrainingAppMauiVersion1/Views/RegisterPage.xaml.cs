using MongoDB.Driver;
using TrainingAppMauiVersion1.Models;

namespace TrainingAppMauiVersion1.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnClickedRegisterButton(object sender, EventArgs e)
    {
        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase("TrainingAppPerson");
        var myCollection = database.GetCollection<Person>("MyUsers");
        //Skapa en knapp för att registera personen om alla inmatningar är korrekta
        //och sen gå tillbaka till mainpage, för att logga in med valda parametrar
        Person person = new Person()
        {
            Id = new Guid(),
            UserName = RegisterUserName.Text,
            PassWord = RegisterPassWord.Text,
            Name = RegisterName.Text,
            Birthday = Convert.ToDateTime(RegisterBirthDate.Text),
            Weight = Convert.ToInt32(RegisterWeight.Text),
            Height = Convert.ToInt32(RegisterHeight.Text),
            Email = RegisterEmail.Text
        };
        Task savePerson = SaveUser(person, myCollection);
        await savePerson;
        await Navigation.PopAsync();
    }
    private static async Task SaveUser(Person person, IMongoCollection<Person> myCollection)
    {
        await myCollection.InsertOneAsync(person);
    }
}