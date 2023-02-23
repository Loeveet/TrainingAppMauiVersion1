namespace TrainingAppMauiVersion1.Views;

public partial class LoggedInPage : ContentPage
{
	public LoggedInPage()
	{
		InitializeComponent();
	}

    private async void OnClickedWeatherPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WeatherPage());

    }
}