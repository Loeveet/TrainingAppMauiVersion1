using TrainingAppMauiVersion1.ViewModels;

namespace TrainingAppMauiVersion1.Views;

public partial class OtherExercisesPage : ContentPage
{
	public OtherExercisesPage()
	{
		InitializeComponent();
        BindingContext = new OtherExercisesViewModel();
    }

	//L�gg in en s�kfunktion s� man f�r fris�ka p� aktivitet. N�r man s�kt s�
	//skrivs svaret ut under. M�ste g� att fixa. 
}