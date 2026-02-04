using Microsoft.AspNetCore.Mvc;
using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Application.Services.Interfaces;

namespace Teste_Dev_FullStack.API.Controllers
{
    [ApiController]
    [Route("api/v1/transections")]
    public class TransectionController : ControllerBase
    {
        private readonly ITransectionService _transectionService;

        public TransectionController(ITransectionService transectionService)
        {
            _transectionService = transectionService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTransectionDto dto)
        {
            var result = await _transectionService.CreateAsync(dto);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetAll), result.Value);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _transectionService.GetAllAsync();
            return Ok(result.Value);
        }
    }
}
