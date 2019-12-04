using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Services
{
    public class WorkoutService
    {

        readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WorkoutService(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        //SERVICE METHODS FOR WORKOUTS
        //METHODS FOR GOALS DOWN AT THE BOTTOM
        public ICollection<WorkoutSummaryViewModel> GetWorkouts()
        {
            return _context.WorkoutSummary
                .Where(x => !x.IsDeleted)
                .Select(x => new WorkoutSummaryViewModel
                {
                    Id = x.WorkoutId,
                    TargetedMuscleGroup = x.TargetedMuscleGroup,
                    Date = x.Date,
                    NumberOfExercises = x.Exercises.Count,
                    CreatedByName = x.CreatedByName
                })
                .ToList();
        }

        public ICollection<WorkoutSummaryViewModel> GetPersonalWorkouts(ApplicationUser createdBy)
        {
            return _context.WorkoutSummary
                .Where(x => x.CreatedById == createdBy.Id)
                .Where(x => !x.IsDeleted)
                .Select(x => new WorkoutSummaryViewModel
                {
                    Id = x.WorkoutId,
                    TargetedMuscleGroup = x.TargetedMuscleGroup,
                    Date = x.Date,
                    NumberOfExercises = x.Exercises.Count,
                })
                .ToList();
        }

        public bool DoesWorkoutExist(int id)
        {
            return _context.WorkoutSummary
                .Where(x => x.WorkoutId == id)
                .Any();
        }

        public WorkoutDetailedViewModel GetWorkoutDetailed(int id)
        {
            return _context.WorkoutSummary
                .Where(x => x.WorkoutId == id)
                .Select(x => new WorkoutDetailedViewModel
                {
                    Id = x.WorkoutId,
                    TargetedMuscleGroup = x.TargetedMuscleGroup,
                    Date = x.Date,
                    Exercises = x.Exercises
                    .Select(item => new WorkoutDetailedViewModel.Item
                    {
                        ExerciseName = item.ExerciseName,
                        sets = item.Sets,
                        reps = item.Reps,
                        weight = item.Weight
                    })
                })
                .SingleOrDefault();
        }

        public WorkoutSummary GetWorkout(int workoutId)
        {
            return _context.WorkoutSummary
                .Where(x => x.WorkoutId == workoutId)
                .SingleOrDefault();
        }

        public UpdateWorkoutCommand GetWorkoutForUpdate(int workoutId)
        {
            return _context.WorkoutSummary
                .Where(x => x.WorkoutId == workoutId)
                .Select(x => new UpdateWorkoutCommand
                {
                    TargetedMuscleGroup = x.TargetedMuscleGroup,
                    Date = x.Date,
                })
                .SingleOrDefault();
        }

        public int CreateWorkoutSummary(CreateWorkoutSummaryCommand cmd, ApplicationUser createdBy)
        {
            var workout = cmd.ToWorkout(createdBy);
            _context.Add(workout);
            _context.SaveChanges();
            return workout.WorkoutId;
        }

        public void UpdateWorkout(UpdateWorkoutCommand cmd)
        {
            var workout = _context.WorkoutSummary.Find(cmd.Id);
            if(workout == null) { throw new Exception("Undable to find the workout"); }

            cmd.UpdateWorkout(workout);
            _context.SaveChanges();
        }

       
        public void DeleteWorkout(int workoutId)
        {
            var workout = _context.WorkoutSummary.Find(workoutId);
            if (workout == null) { throw new Exception("Unable to delete a workout that doesnt exist"); }

            workout.IsDeleted = true;
            _context.SaveChanges();
        }



        //SERVICE METHODS FOR GOALS

        public ICollection<GoalsSummaryViewModel> GetGoals(ApplicationUser user)
        {
            return _context.Goals
                .Where(x => x.CreatedById == user.Id)
                .Select(x => new GoalsSummaryViewModel
                {
                    Id = x.GoalId,
                    GoalBench = x.GoalBench,
                    GoalDeadlift = x.GoalDeadlift,
                    GoalSquat = x.GoalSquat,
                    HighestBench = x.HighestBench,
                    HighestDeadlift = x.HighestDeadlift,
                    HighestSquat = x.HighestSquat,
                    DateCreated = x.DateCreated
                })
                .OrderByDescending(x => x.DateCreated).Take(1)
                .ToList();
        }

        public bool DoesGoalExist(int id)
        {
            return _context.Goals
                .Where(x => x.GoalId == id)
                .Any();
        }

        public UpdateGoalsCommand GetGoalForUpdate(int goalId)
        {
            return _context.Goals
                .Where(x => x.GoalId == goalId)
                .Select(x => new UpdateGoalsCommand
                {
                    GoalBench = x.GoalBench,
                    GoalDeadlift = x.GoalDeadlift,
                    GoalSquat = x.GoalSquat,
                })
                .SingleOrDefault();
        }

        public int CreateGoal(CreateGoalsCommand cmd, ApplicationUser appUser)
        {
            var goals = cmd.ToGoals(appUser);
            _context.Add(goals);
            _context.SaveChanges();
            return goals.GoalId;
        }

    }
}
