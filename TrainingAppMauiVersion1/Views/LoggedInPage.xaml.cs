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

    private async void OnClickedExistingTrainingProgramsPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExistingTrainingProgramsPage());
    }

    private async void OnClickedCreateTrainingProgramsPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateTrainingProgramsPage());
    }

    private async void OnClickedOtherExercisesPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OtherExercisesPage());
    }

    private async void OnClickedSearchForOtherExercisesPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SearchForOtherExercisesPage());
    }
}