using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class WorkoutDetailed
    {
        [Key]
        public int DetailedId { get; set; }
        [ForeignKey("WorkoutId")]
        public int WorkoutId { get; set; }
        [StringLength(100)]
        public string ExerciseName { get; set; }
        [Range(0,100)]
        public int Sets { get; set; }
        [Range(0, 100)]
        public int Reps { get; set; }
        [Range(0,9999)]
        public int Weight { get; set; }
    }
}
