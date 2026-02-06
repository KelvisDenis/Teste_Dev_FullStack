using Microsoft.AspNetCore.Mvc;
using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Application.Services.Interfaces;

namespace Teste_Dev_FullStack.API.Controllers
{
    [ApiController]
    [Route("api/v1/persons")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreatePersonDto dto)
        {
            var result = await _personService.CreateAsync(dto);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetAll), result.Value);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _personService.GetAllAsync();
            return Ok(result.Value);
        }

        [HttpGet("totals")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTotals()
        {
            var result = await _personService.GetPersonsTotalsAsync();

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }


        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _personService.DeleteAsync(id);

            if (result.IsFailure)
                return NotFound(result.Error);

            return NoContent();
        }
    }
}
