using EtteremApi.Models.Dtos;
using EtteremApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtteremApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KapcsoloController : ControllerBase
    {
        private readonly IKapcsolo _kapcsolo;
        public KapcsoloController(IKapcsolo kapcsolo)
        {
            _kapcsolo = kapcsolo;
        }
        [HttpPost("PostRelation")]
        public async Task<IActionResult> PostNewRelation(AddRelationDto addRelationDto)
        {
            var requestResult = await _kapcsolo.PostNewRelation(addRelationDto) as ResultResponseDto;
            if(requestResult.result != null)
            {
                return Ok(requestResult);
            }
            else if(requestResult.result == null)
            {
                return NotFound(requestResult);
            }
            else
            {
                return BadRequest(requestResult);
            }
        }


    }
}
