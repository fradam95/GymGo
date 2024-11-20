using GymGo.Models;

namespace GymGo.Pages.WorkoutSession;

public partial class WorkoutSessionPage : ContentPage
{
	public WorkoutSessionPage()
	{
		InitializeComponent();
	}

	public void OnNewButtonClicked(object sender, EventArgs e)
	{
		statusMessage.Text = "";

		App.TrainingMainTypeRepository.AddNewTrainingType(newTrainingType.Text);
		statusMessage.Text = App.TrainingMainTypeRepository.StatusMessage;
	}

	public void OnGetButtonClicked(object sender, EventArgs e)
	{
		statusMessage.Text = "";

		List<TrainingMainType> trainingMainTypes = App.TrainingMainTypeRepository.GetTrainingMainTypes();
		peopleList.ItemsSource = trainingMainTypes;
	}
}