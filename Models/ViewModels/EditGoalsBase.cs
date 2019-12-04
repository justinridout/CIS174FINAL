using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class EditGoalsBase
    {
        
        [DisplayName("Squat Personal Best")]
        [Range(0, 9999)]
        public int HighestSquat { get; set; }
        [DisplayName("Deadlift Personal Best")]
        [Range(0, 9999)]
        public int HighestDeadlift { get; set; }
        [DisplayName("Bench Personal Best")]
        [Range(0, 9999)]
        public int HighestBench { get; set; }
        [DisplayName("Squat Goal")]
        [Range(0, 9999)]
        public int GoalSquat { get; set; }
        [DisplayName("Deadlift Goal")]
        [Range(0, 9999)]
        public int GoalDeadlift { get; set; }
        [DisplayName("Bench Goal")]
        [Range(0, 9999)]
        public int GoalBench { get; set; }
    }
}
