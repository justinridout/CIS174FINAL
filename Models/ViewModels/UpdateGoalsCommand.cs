using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class UpdateGoalsCommand : EditGoalsBase
    {

        public int Id { get; set; }

        public void UpdateGoals(Goals goals)
        {
            goals.GoalSquat = GoalSquat;
            goals.GoalDeadlift = GoalDeadlift;
            goals.GoalBench = GoalBench;
        }
    }
}
