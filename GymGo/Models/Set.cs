using SQLite;

namespace GymGo.Models;

public class Set
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int WorkoutId { get; set; }
    public string ExcerciseId { get; set;}
}