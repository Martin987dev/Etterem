using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtteremApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermekController : ControllerBase
    {
        private readonly ITermekek _termek;
        public TermekController(ITermekek termek)
        {
            _termek = termek;
        }

        [HttpPost("AddNewTermek")]
        public async Task<IActionResult> AddNewRendeles(AddTermekDto addTermekDto)
        {
            if (addTermekDto != null)
            {
                return StatusCode(201, await _termek.AddNewTermek(addTermekDto));
            }
            return StatusCode(404, await _termek.AddNewTermek(addTermekDto));
        }

        [HttpGet("GetAllTermek")]
        public async Task<IActionResult> GetAllRendeles()
        {
            return StatusCode(201, await _termek.GetAllTermekeks());
        }
    }
}
