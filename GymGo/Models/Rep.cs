using SQLite;
namespace GymGo.Models;

public class Rep
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int SetId { get; set; } // Külső kulcs, amely kapcsolódik a Set táblához
    public int Repetitions { get; set; } // Ismétlésszám
    public double Weight { get; set; } // Használt súly kg-ban
}
