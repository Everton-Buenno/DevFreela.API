using DevFreela.Core.Entities;
using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {

        private readonly DevFreelaDbContext _context;

        public SkillsController(DevFreelaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var skills = _context.Skills.ToList();
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model) 
        {
            var skill = new Skill(model.Description);
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
