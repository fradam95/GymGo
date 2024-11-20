using SQLite;

namespace GymGo.Models;

public class Excercise
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string ExerciseName { get; set; }
    }
}