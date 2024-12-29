using IleriWebProje.Data.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
