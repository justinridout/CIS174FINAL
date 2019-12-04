using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class CreateGoalsCommand :EditGoalsBase
    {
        public Goals ToGoals(ApplicationUser createdBy)
        {
            return new Goals
            {
                GoalBench = GoalBench,
                GoalSquat = GoalSquat,
                GoalDeadlift = GoalDeadlift,
                HighestBench = HighestBench,
                HighestSquat = HighestSquat,
                HighestDeadlift = HighestDeadlift,
                CreatedById = createdBy.Id,
                DateCreated = DateTime.Now
            };
        }
    }
}
