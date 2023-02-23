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
        var users = await Person.GetUsersFromMongoDB();

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

}

