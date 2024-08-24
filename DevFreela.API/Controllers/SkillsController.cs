using DevFreela.Core.Entities;
using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using DevFreela.Application.Commands.InsertSkill;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSkillsQuery();
            var result = await _mediator.Send(query); 
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(InsertSkillCommand command) 
        {

            var result = await _mediator.Send(command);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
