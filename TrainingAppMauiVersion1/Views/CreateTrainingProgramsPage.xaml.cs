using TrainingAppMauiVersion1.ViewModels;

namespace TrainingAppMauiVersion1.Views;

public partial class CreateTrainingProgramsPage : ContentPage
{
	public CreateTrainingProgramsPage()
	{
		InitializeComponent();
        BindingContext = new CreateTrainingProgramsViewModel();
    }
}