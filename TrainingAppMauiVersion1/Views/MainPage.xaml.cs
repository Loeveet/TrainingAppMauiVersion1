using CommunityToolkit.Mvvm.Input;
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
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as MainPageViewModel).GetAWeather();
    }
    public async void OnClickedLoggedIn1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.LoggedInPage());
    }


    private async void OnClickedRegister(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.RegisterPage());
    }

}

