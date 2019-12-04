using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class UpdateWorkoutCommand : EditWorkoutBase
    {
        public int Id { get; set; }

        public void UpdateWorkout(WorkoutSummary workout)
        {
            workout.TargetedMuscleGroup = TargetedMuscleGroup;
            workout.Date = Date;
        }
    }
}
