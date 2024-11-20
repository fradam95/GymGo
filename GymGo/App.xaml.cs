namespace GymGo
{
    public partial class App : Application
    {
        public static TrainingMainTypeRepository TrainingMainTypeRepository {  get; set; }
        public App(TrainingMainTypeRepository trainingMainTypeRepository)
        {
            InitializeComponent();

            MainPage = new AppShell();

            TrainingMainTypeRepository = trainingMainTypeRepository;
        }
    }
}
