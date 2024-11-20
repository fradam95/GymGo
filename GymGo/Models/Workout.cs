using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GymGo.Models;

public class Workout
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string WorkoutName { get; set; } // Opcionális név vagy címke az edzéshez
    public DateTime Date { get; set; } // Az edzés dátuma

    [Ignore]
    public List<Set> Sets { get; set; } //Ez nem kerül mentésre az SQLite adatbázisba, csak lekérésnél használjuk

}
