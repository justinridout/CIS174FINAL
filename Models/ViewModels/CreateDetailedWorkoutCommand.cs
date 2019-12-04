using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class CreateDetailedWorkoutCommand
    {
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }

        public WorkoutDetailed ToExerciseList()
        {
            return new WorkoutDetailed
            {
                ExerciseName = ExerciseName,
                Sets = Sets,
                Reps = Reps,
                Weight = Weight,
            };
        }
    }
}
