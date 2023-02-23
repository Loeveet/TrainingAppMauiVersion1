namespace TrainingAppMauiVersion1.Views;

public partial class WeatherPage : ContentPage
{
	public WeatherPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.WeatherPageViewModel();
    }


}