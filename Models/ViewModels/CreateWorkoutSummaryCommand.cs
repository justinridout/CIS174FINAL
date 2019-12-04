using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class CreateWorkoutSummaryCommand : EditWorkoutBase
    {
        public IList<CreateDetailedWorkoutCommand> Exercises { get; set; } = new List<CreateDetailedWorkoutCommand>();

        public WorkoutSummary ToWorkout(ApplicationUser createdBy)
        {
            return new WorkoutSummary
            {
                TargetedMuscleGroup = TargetedMuscleGroup,
                Date = DateTime.Now,
                Exercises = Exercises?.Select(x => x.ToExerciseList()).ToList(),
                CreatedById = createdBy.Id,
                CreatedByName = createdBy.FirstName + " " + createdBy.LastName
            };
        }
    }
}
