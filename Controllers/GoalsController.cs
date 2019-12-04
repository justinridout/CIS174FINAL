using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Models.ViewModels;
using FinalProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class GoalsController : Controller
    {

        public WorkoutService _service;
        private readonly UserManager<ApplicationUser> _userService;
        private readonly IAuthorizationService _authService;

        public GoalsController(WorkoutService service,
            UserManager<ApplicationUser> userService,
            IAuthorizationService authService)
        {
            _service = service;
            _userService = userService;
            _authService = authService;
        }
        public async Task<IActionResult> Index()
        {
            var appUser = await _userService.GetUserAsync(User);
            var models = _service.GetGoals(appUser);

            return View(models);
        }

        public IActionResult Create()
        {
            return View(new CreateGoalsCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGoalsCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var appUser = await _userService.GetUserAsync(User);
                    var id = _service.CreateGoal(command, appUser);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the goal"
                    );
            }
            return View(command);
        }

        public IActionResult Edit(int id)
        {
            var model = _service.GetGoalForUpdate(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        
    }
}