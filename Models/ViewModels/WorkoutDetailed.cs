using System;
using System.Collections.Generic;

namespace FinalProject.Models.ViewModels
{
    public class WorkoutDetailedViewModel
    {
        public int Id { get; set; }
        public string TargetedMuscleGroup { get; set; }
        public DateTime Date { get; set; }
        public bool CanEditWorkout { get; set; }
        public IEnumerable<Item> Exercises { get; set; }

        public class Item
        {
            public string ExerciseName { get; set; }
            public int reps { get; set; }
            public int weight { get; set; }
            public int sets { get; set; }
        }
    }
}
