using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using GymGo.Services;
using static GymGo.Models.Excercise;

namespace GymGo.Pages.PreviousWorkout;

public partial class PreviousWorkoutViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;

    public event PropertyChangedEventHandler? PropertyChanged;

    private ObservableCollection<Exercise> AvailableExercises { get; }
    public string NewExerciseName { get; set; }

    public ICommand AddSetCommand { get; }

    public PreviousWorkoutViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;

        AvailableExercises = new ObservableCollection<Exercise>();
        LoadExercises();

        AddSetCommand = new Command(OnAddSet);
    }

    private async void LoadExercises()
    {
        var exercises = await _databaseService.GetExercisesAsync();
        foreach (var exercise in exercises)
        {
            AvailableExercises.Add(exercise);
        }
    }

    private async void OnAddSet()
    {
        if (!string.IsNullOrEmpty(NewExerciseName))
        {
            // Hozzáadjuk az új gyakorlatot az adatbázishoz
            var newExercise = new Exercise { ExerciseName = NewExerciseName };
            await _databaseService.SaveExerciseAsync(newExercise);

            // Frissítjük a listát
            AvailableExercises.Add(newExercise);
            NewExerciseName = string.Empty;
        }

        // Példa: Szett hozzáadása egy kiválasztott edzéshez (feltételezve, hogy van egy CurrentWorkoutID)
        var selectedExercise = (Exercise)ExercisePicker.SelectedItem;
        if (selectedExercise != null)
        {
            var newSet = new Set
            {
                WorkoutId = CurrentWorkoutId, // Használd a megfelelő edzés azonosítót
                ExerciseId = selectedExercise.Id,
                SetNumber = GetNextSetNumber() // Ezt a metódust meg kell írnod, hogy megfelelő szett számot adjon
            };

            await _databaseService.SaveSetAsync(newSet);
        }
    }
}
