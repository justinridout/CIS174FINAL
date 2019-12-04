using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class EditWorkoutBase
    {
        [StringLength(100)]
        [DisplayName("Targeted Muscle Group")]
        public string TargetedMuscleGroup { get; set; }
        public DateTime Date { get; set; }
        
    }
}
