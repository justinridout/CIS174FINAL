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
    [Authorize]
    public class WorkoutController : Controller
    {

        private readonly WorkoutService _service;
        private readonly UserManager<ApplicationUser> _userService;
        private readonly IAuthorizationService _authService;

        public WorkoutController(WorkoutService service,
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
            var models = _service.GetPersonalWorkouts(appUser);
            return View(models);
        }

        public IActionResult GlobalWorkouts()
        {
            var models = _service.GetWorkouts();
            return View(models);
        }

        public async Task<IActionResult> View(int id)
        {
            var model = _service.GetWorkoutDetailed(id);
            if(model == null)
            {
                return NotFound();
            }

            var workout = _service.GetWorkout(id);
            var isAuthorized = await _authService.AuthorizeAsync(User, workout, "CanManageWorkout");
            model.CanEditWorkout = isAuthorized.Succeeded;
            return View(model);
        }

        public async Task<IActionResult> ViewGlobal(int id)
        {
            var model = _service.GetWorkoutDetailed(id);
            if (model == null)
            {
                return NotFound();
            }

            var workout = _service.GetWorkout(id);
            var isAuthorized = await _authService.AuthorizeAsync(User, workout, "CanManageWorkout");
            model.CanEditWorkout = isAuthorized.Succeeded;
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new CreateWorkoutSummaryCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkoutSummaryCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var appUser = await _userService.GetUserAsync(User);
                    var id = _service.CreateWorkoutSummary(command, appUser);
                    return RedirectToAction(nameof(View), new { id = id });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the workout"
                    );
            }

            return View(command);
        }

        public IActionResult Edit(int id)
        {
            var model = _service.GetWorkoutForUpdate(id);
            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateWorkoutCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.UpdateWorkout(command);
                    return RedirectToAction(nameof(View), new { id = command.Id });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the workout"
                    );
            }
            return View(command);
        }

        
        [HttpPost]
        public IActionResult DeleteWorkout(int id)
        {
            _service.DeleteWorkout(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteWorkoutGlobal(int id)
        {
            _service.DeleteWorkout(id);
            return RedirectToAction(nameof(GlobalWorkouts));
        }

    }
}