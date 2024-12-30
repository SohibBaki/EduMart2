using IleriWebProje.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IleriWebProje.Data.ViewModels;

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

    }
}
