using IleriWebProje.Data;
using IleriWebProje.Data.Services;
using IleriWebProje.Data.Static;
using IleriWebProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IleriWebProje.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class SkillOrganizersController : Controller
    {
        private readonly ISkillOrganizersService _service;
        public SkillOrganizersController(ISkillOrganizersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allskill_Organizers = await _service.GetAllAsync();
            return View(allskill_Organizers);
        }

        [AllowAnonymous]
        // Get SkillOrganizers/ Details /1
        public async Task<IActionResult> Details(int id)
        {
            var skillOrganizersDetails = await _service.GetByIdAsync(id);
            if (skillOrganizersDetails == null)
            {
                return View("NotFound");
            }
            return View(skillOrganizersDetails);
        }

        // Get SkillOrganizers/ Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, About")] SkillOrganizers skillOrganizers)
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
                return View(skillOrganizers);
            }
            await _service.AddAsync(skillOrganizers);
            return RedirectToAction(nameof(Index));
        }

        //Get: Skill Organizers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var skillOrganizerDetails = await _service.GetByIdAsync(id);
            if (skillOrganizerDetails == null)
            {
                return View("NotFound");
            }
            return View(skillOrganizerDetails);
        }

        // Get: Mentor Update
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL, FullName, About")] SkillOrganizers skillOrganizers)
        {
            if (id != skillOrganizers.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(skillOrganizers);
            }

            try
            {
                await _service.UpdateAsync(id, skillOrganizers);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SkillOrganizerExists(skillOrganizers.Id))
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

        private async Task<bool> SkillOrganizerExists(int id)
        {
            var mentor = await _service.GetByIdAsync(id);
            return mentor != null;
        }

        //Get: Skill Organizer/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var skillOrganizersDetails = await _service.GetByIdAsync(id);
            if (skillOrganizersDetails == null)
            {
                return View("NotFound");
            }
            return View(skillOrganizersDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillOrganizersDetails = await _service.GetByIdAsync(id);
            if (skillOrganizersDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
   
    }

} 
