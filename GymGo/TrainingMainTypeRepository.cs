using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using GymGo.Models;
using System.Xml.Linq;

namespace GymGo;

public class TrainingMainTypeRepository
{
    string _dbPath;

    public string StatusMessage { get; set; }

    private SQLiteConnection conn;

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<TrainingMainType>();
    }

    public TrainingMainTypeRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void AddNewTrainingType(string name)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));

        int result = 0;
        try
        {
            Init();

            result = conn.Insert(new TrainingMainType { TrainingMainName = name });

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            throw;
        }
    }

    public List<TrainingMainType> GetTrainingMainTypes()
    {
        try
        {
            Init();

            return conn.Table<TrainingMainType>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. Error: {1}", ex.Message);
            throw;
        } 
    }

}
