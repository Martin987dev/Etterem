using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services.IServices;

namespace EtteremApi.Services
{
    public class KapcsoloService : IKapcsolo
    {
        private readonly RestaurantContext _context;
        public KapcsoloService(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<object> PostNewRelation(AddRelationDto addRelationDto)
        {
            try
            {
                var result = new ResultResponseDto();
                var relation = new Kapcsolo
                {
                    RendelesId = addRelationDto.RendelesId,
                    TermekekId = addRelationDto.TermekekId,
                };
                if(relation != null)
                {
                    await _context.Kapcsolos.AddAsync(relation);
                    await _context.SaveChangesAsync();
                    result.Message = "Sikeres összerendezés.";
                    result.result = relation;
                    return result;
                }
                result.Message = "Sikertelen összerendezés.";
                result.result = relation;
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.Message = ex.Message;
                return result;
            }
        }
    }
}
