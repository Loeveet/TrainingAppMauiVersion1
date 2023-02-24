using TrainingAppMauiVersion1.ViewModels;

namespace TrainingAppMauiVersion1.Views;

public partial class OtherExercisesPage : ContentPage
{
	public OtherExercisesPage()
	{
		InitializeComponent();
        BindingContext = new OtherExercisesViewModel();
    }

	//Lägg in en sökfunktion så man får frisöka på aktivitet. När man sökt så
	//skrivs svaret ut under. Måste gå att fixa. 
}