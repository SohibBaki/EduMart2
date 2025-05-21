using EduMart.Data;
using EduMart.Data.Services;
using EduMart.Data.Static;
using EduMart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduMart.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PlatformsController : Controller
    {
        private readonly IPlatformService _service;
        public PlatformsController(IPlatformService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task <IActionResult> Index()
        {
             var allPlatforms = await _service.GetAllAsync();
            return View(allPlatforms);
        }

        // Get SkillOrganizers/ Details /1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var platformDetails = await _service.GetByIdAsync(id);
            if (platformDetails == null)
            {
                return View("NotFound");
            }
            return View(platformDetails);
        }

        // Get Platforms/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PlatformLogo, PlatformName, Description")] Platforms platform)
        {
            if (!ModelState.IsValid)
            {
                // Log the model state errors
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(platform);
            }
            await _service.AddAsync(platform);
            return RedirectToAction(nameof(Index));
        }

        //Get: Skill Organizers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var platformsDetails = await _service.GetByIdAsync(id);
            if (platformsDetails == null)
            {
                return View("NotFound");
            }
            return View(platformsDetails);
        }

        // Get: Platform Update
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, PlatformLogo, PlatformName, Description")] Platforms platforms)
        {
            if (id != platforms.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(platforms);
            }

            try
            {
                await _service.UpdateAsync(id, platforms);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PlatformsExists(platforms.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PlatformsExists(int id)
        {
            var platforms = await _service.GetByIdAsync(id);
            return platforms != null;
        }

        //Get: PLatform/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var platformDetails = await _service.GetByIdAsync(id);
            if (platformDetails == null)
            {
                return View("NotFound");
            }
            return View(platformDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platformDetails = await _service.GetByIdAsync(id);
            if (platformDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
