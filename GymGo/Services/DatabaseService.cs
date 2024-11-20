using GymGo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymGo.Models.Excercise;

namespace GymGo.Services;

public class DatabaseService
{
    string _dbPath;

    public string StatusMessage { get; set; }

    public SQLiteAsyncConnection conn;

    public DatabaseService(string dbPath)
    {
        conn = new SQLiteAsyncConnection(dbPath);
        conn.CreateTableAsync<Workout>().Wait();
        conn.CreateTableAsync<Excercise>().Wait();
        conn.CreateTableAsync<Set>().Wait();
        conn.CreateTableAsync<Rep>().Wait();
        SeedExercisesAsync().Wait();
    }
    public async Task SeedExercisesAsync()
    {
        var count = await conn.Table<Exercise>().CountAsync();
        if (count == 0)
        {
            var defaultExercises = new List<Exercise>
                    {
                        new Exercise { ExerciseName = "Bench Press" },
                        new Exercise { ExerciseName = "Squat" },
                        new Exercise { ExerciseName = "Deadlift" }
                    };

            await conn.InsertAllAsync(defaultExercises);
        }
    }

    public Task<List<Workout>> GetWorkoutsAsync()
    {
        return conn.Table<Workout>().ToListAsync();
    }

    public Task<int> SaveWorkoutAsync(Workout workout)
    {
        if (workout.Id != 0)
        {
            return conn.UpdateAsync(workout);
        }
        else
        {
            return conn.InsertAsync(workout);
        }
    }

    public Task<int> DeleteWorkoutAsync(Workout workout)
    {
        return conn.DeleteAsync(workout);
    }

    // Set CRUD
    public Task<List<Set>> GetSetsForWorkoutAsync(int workoutId)
    {
        return conn.Table<Set>().Where(s => s.WorkoutId == workoutId).ToListAsync();
    }

    public Task<int> SaveSetAsync(Set set)
    {
        if (set.Id != 0)
        {
            return conn.UpdateAsync(set);
        }
        else
        {
            return conn.InsertAsync(set);
        }
    }

    // Rep CRUD
    public Task<List<Rep>> GetRepsForSetAsync(int setId)
    {
        return conn.Table<Rep>().Where(r => r.SetId == setId).ToListAsync();
    }

    public Task<int> SaveRepAsync(Rep rep)
    {
        if (rep.Id != 0)
        {
            return conn.UpdateAsync(rep);
        }
        else
        {
            return conn.InsertAsync(rep);
        }
    }

    // Exercise CRUD
    public Task<List<Exercise>> GetExercisesAsync()
    {
        return conn.Table<Exercise>().ToListAsync();
    }

    public Task<int> SaveExerciseAsync(Exercise exercise)
    {
        if (exercise.Id != 0)
        {
            return conn.UpdateAsync(exercise);
        }
        else
        {
            return conn.InsertAsync(exercise);
        }
    }

}
