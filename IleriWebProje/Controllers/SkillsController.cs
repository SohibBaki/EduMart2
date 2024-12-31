using IleriWebProje.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IleriWebProje.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace IleriWebProje.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillsService _service;

        public SkillsController(ISkillsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allSkills = await _service.GetAllAsync(n => n.Platforms);
            return View(allSkills);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allSkills = await _service.GetAllAsync(n => n.Platforms);

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResultNew = allSkills.Where(n => string.Equals(n.SkillName, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.SkillDescription, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allSkills);
        }

        // Get: Skills/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var skillDetails = await _service.GetSkillByIdAsync(id);
            if (skillDetails == null)
            {
                return NotFound();
            }
            return View(skillDetails);
        }

        //GET: Skills/Create
        public async Task<IActionResult> Create()
        {
            var skillDropdownsData = await _service.GetNewSkillDropdownValuesAsync();

            ViewBag.Platforms = new SelectList(skillDropdownsData.platforms, "Id", "PlatformName");
            ViewBag.SkillOrganizers = new SelectList(skillDropdownsData.skillOrganizers, "Id", "FullName");
            ViewBag.Mentors = new SelectList(skillDropdownsData.mentors, "Id", "FullName");

            var model = new NewSkillsVM
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewSkillsVM skill)
        {
            if (!ModelState.IsValid)
            {
                var skillDropdownsData = await _service.GetNewSkillDropdownValuesAsync();

                ViewBag.Platforms = new SelectList(skillDropdownsData.platforms, "Id", "PlatformName");
                ViewBag.SkillOrganizers = new SelectList(skillDropdownsData.skillOrganizers, "Id", "FullName");
                ViewBag.Mentors = new SelectList(skillDropdownsData.mentors, "Id", "FullName");

                return View(skill);
            }

            await _service.AddNewSkillAsync(skill);
            return RedirectToAction(nameof(Index));
        }


        //GET: Skills/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var skillDetails = await _service.GetSkillByIdAsync(id);
            if (skillDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewSkillsVM()
            {
                Id = skillDetails.Id,
                SkillName = skillDetails.SkillName,
                Description = skillDetails.SkillDescription,
                Price = skillDetails.Price,
                StartDate = skillDetails.StartDate,
                EndDate = skillDetails.EndDate,
                ImageURL = skillDetails.ImageURL,
                PlatformId = skillDetails.PlatformId,
                SkillCategory = skillDetails.SkillCategory,
                SkillOrganizerID = skillDetails.SkillOrganizerID,
                MentorIds = skillDetails.Mentors_Skills.Select(n => n.MentorID).ToList()
            };

            var skillDropdownsData = await _service.GetNewSkillDropdownValuesAsync();

            ViewBag.Platforms = new SelectList(skillDropdownsData.platforms, "Id", "PlatformName");
            ViewBag.SkillOrganizers = new SelectList(skillDropdownsData.skillOrganizers, "Id", "FullName");
            ViewBag.Mentors = new SelectList(skillDropdownsData.mentors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewSkillsVM skill)
        {
            if(id != skill.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var skillDropdownsData = await _service.GetNewSkillDropdownValuesAsync();

                ViewBag.Platforms = new SelectList(skillDropdownsData.platforms, "Id", "PlatformName");
                ViewBag.SkillOrganizers = new SelectList(skillDropdownsData.skillOrganizers, "Id", "FullName");
                ViewBag.Mentors = new SelectList(skillDropdownsData.mentors, "Id", "FullName");

                return View(skill);
            }

            await _service.UpdateSkillAsync(skill);
            return RedirectToAction(nameof(Index));
        }
    }
}
