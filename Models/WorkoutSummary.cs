using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class WorkoutSummary
    {
        [Key]
        public int WorkoutId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [StringLength(100)]
        public string TargetedMuscleGroup { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }

        public ICollection<WorkoutDetailed> Exercises { get; set; }
    }
}
