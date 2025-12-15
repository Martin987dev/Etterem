using EtteremApi.Models.Dtos;
using EtteremApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtteremApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesController : ControllerBase
    {
        private readonly IRendeles _rendeles;
        public RendelesController(IRendeles rendeles)
        {
            _rendeles = rendeles;
        }

        [HttpPost("AddNewRendeles")]
        public async Task<IActionResult> AddNewRendeles(AddRendelesDto addRendelesDto)
        {
            if (addRendelesDto != null) {
                return StatusCode(201, await _rendeles.AddNewRendeles(addRendelesDto));
            }
            return StatusCode(404,await _rendeles.AddNewRendeles(addRendelesDto));
        }

        [HttpGet("GetAllRendeles")]
        public async Task<IActionResult> GetAllRendeles()
        {
            return StatusCode(201, await _rendeles.GettAllRendeles());
        }
        [HttpGet("GettAllRecordWithCard")]
        public async Task<IActionResult> GetKartyaRendelesek()
        {
            return StatusCode(201,await _rendeles.GetRecordWithCard());
        }
        [HttpGet("GetAllRendelesWithFood")]
        public async Task<IActionResult> GetAllRendelesWithFood()
        {
            return StatusCode(201,await _rendeles.GetAllRendelesWithFood());
        }
        [HttpGet("GetAllRecordOrderByRendeles")]
        public async Task<IActionResult> GetAllRecordOrderByRendeles()
        {
            return StatusCode(201, await _rendeles.GetAllRecordOrderByRendeles());
        }

        [HttpGet("GetJustTermekCola")]        
        public async Task<IActionResult> GetJustCola()
        {
            return StatusCode(201, await _rendeles.GetJustTermekCola());
        }

        [HttpGet("EachRendelesCount")]
        public async Task<IActionResult> EachRendelesCount()
        {
            return StatusCode(201, await _rendeles.EachRendelesCount());
        }
    }
}
