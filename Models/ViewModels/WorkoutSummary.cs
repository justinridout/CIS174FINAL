using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class WorkoutSummaryViewModel
    {
        public string CreatedByName { get; set; }
        public int Id { get; set; }
        public string TargetedMuscleGroup { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfExercises { get; set; }
        public bool CanViewWorkout { get; set; }

        public static WorkoutSummaryViewModel FromWorkoutSummary(WorkoutSummary workout)
        {
            return new WorkoutSummaryViewModel
            {
                Id = workout.WorkoutId,
                TargetedMuscleGroup = workout.TargetedMuscleGroup,
                Date = workout.Date,
                NumberOfExercises = workout.Exercises.Count,
                CreatedByName = workout.CreatedByName,
            };
        }
    }
}
