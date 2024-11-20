using GymGo.Pages.WorkoutSession;
using GymGo.Pages.PreviousWorkout;
using GymGo.Pages.Tabata;
using Microsoft.Extensions.Logging;
using GymGo.Services;

namespace GymGo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = FileAccessHelper.GetLocalFilePath("gymgo.db3");
            builder.Services.AddSingleton<TrainingMainTypeRepository>(s => ActivatorUtilities.CreateInstance<TrainingMainTypeRepository>(s, dbPath));
            builder.Services.AddSingleton<DatabaseService>(s => new DatabaseService(dbPath));

            builder.Services.AddSingleton<WorkoutSessionPage>();
            builder.Services.AddSingleton<TabataView>();
            builder.Services.AddSingleton<PreviousWorkoutView>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
