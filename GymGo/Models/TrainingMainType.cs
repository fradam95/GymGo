using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GymGo.Models;

[Table ("TrainingMainTypes")]
public class TrainingMainType
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Unique, MaxLength(50)]
    public string TrainingMainName { get; set; }
}
