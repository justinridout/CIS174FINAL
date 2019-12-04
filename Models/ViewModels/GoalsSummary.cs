using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class GoalsSummaryViewModel
    {
        public int Id { get; set; }
        public int GoalSquat { get; set; }
        public int GoalDeadlift { get; set; }
        public int GoalBench { get; set; }
        public int HighestSquat { get; set; }
        public int HighestBench { get; set; }
        public int HighestDeadlift { get; set; }
        public DateTime DateCreated { get; set; }

        public static GoalsSummaryViewModel FromGoals(Goals goals)
        {
            return new GoalsSummaryViewModel
            {
                Id = goals.GoalId,
                HighestBench = goals.HighestBench,
                HighestDeadlift = goals.HighestDeadlift,
                HighestSquat = goals.HighestSquat,
                GoalBench = goals.GoalBench,
                GoalDeadlift = goals.GoalDeadlift,
                GoalSquat = goals.GoalSquat,
                DateCreated = goals.DateCreated
            };
        }
    }
}
