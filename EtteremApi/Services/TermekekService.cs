using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services.IServices;
using Microsoft.AspNetCore.Components.RenderTree;

namespace EtteremApi.Services
{
    public class TermekekService : ITermekek
    {
        private readonly RestaurantContext _context;
        public TermekekService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<object> AddNewTermek(AddTermekDto addTermekDto)
        {
            try
            {
                var result = new ResultResponseDto();
                var termek = new Termekek
                {
                    Etel = addTermekDto.Etel,
                    Arak = addTermekDto.Arak
                };
                if (termek != null)
                {
                    await _context.Termekeks.AddAsync(termek);
                    await _context.SaveChangesAsync();
                    result.Message = "Sikeres rendelés létrehozás";
                    result.result = termek;
                    return result;
                }
                result.Message = "Sikertelen rendelés létrehozás";
                result.result = termek;
                return result;

            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<object> GetAllTermekeks()
        {
            try
            {
                var result = new ResultResponseDto();
                result.Message = "Sikeres rendelés lekérdezés";
                result.result = _context.Termekeks.ToList();
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
