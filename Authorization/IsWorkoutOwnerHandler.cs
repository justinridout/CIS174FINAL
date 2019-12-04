using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Authorization
{
    public class IsWorkoutOwnerHandler : AuthorizationHandler<IsWorkoutOwnerRequirement, WorkoutSummary>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsWorkoutOwnerHandler (UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsWorkoutOwnerRequirement requirement,
            WorkoutSummary resource)
        {
            var appUser = await _userManager.GetUserAsync(context.User);
            if(appUser == null)
            {
                return;
            }
            if(resource.CreatedById == appUser.Id)
            {
                context.Succeed(requirement);
            }
        }
    }
}
