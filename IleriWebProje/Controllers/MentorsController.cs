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
    public class MentorsController : Controller
    {
        private readonly IMentorsService _service;

        public MentorsController(IMentorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMentors = await _service.GetAllAsync();
            return View(allMentors);
        }

        // Get Mentors/ Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, About")] Mentors mentor)
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
                return View(mentor);
            }
            await _service.AddAsync(mentor);
            return RedirectToAction(nameof(Index));
        }

        // Get Mentors/ Details/ 1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var mentorDetails = await _service.GetByIdAsync(id);
            if(mentorDetails == null)
            {
                return View("NotFound");
            }
            return View(mentorDetails);

        }

        //Get: Mentor/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var mentorDetails = await _service.GetByIdAsync(id);
            if (mentorDetails == null)
            {
                return View("NotFound");
            }
            return View(mentorDetails);
        }

        // Get: Mentor Update
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL, FullName, About")] Mentors mentor)
        {
            if (id != mentor.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(mentor);
            }

            try
            {
                await _service.UpdateAsync(id, mentor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MentorExists(mentor.Id))
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

        private async Task<bool> MentorExists(int id)
        {
            var mentor = await _service.GetByIdAsync(id);
            return mentor != null;
        }

        //Get: Mentor/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var mentorDetails = await _service.GetByIdAsync(id);
            if (mentorDetails == null)
            {
                return View("NotFound");
            }
            return View(mentorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mentorDetails = await _service.GetByIdAsync(id);
            if (mentorDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }




    }
}
