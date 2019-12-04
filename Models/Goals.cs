using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Goals
    {
        [Key]
        public int GoalId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        [Range(0, 9999)]
        public int HighestSquat { get; set; }
        [Range(0, 9999)]
        public int HighestBench { get; set; }
        [Range(0, 9999)]
        public int HighestDeadlift { get; set; }
        [Range(0, 9999)]
        public int GoalSquat { get; set; }
        [Range(0, 9999)]
        public int GoalDeadlift { get; set; }
        [Range(0, 9999)]
        public int GoalBench { get; set; }
    }
}
