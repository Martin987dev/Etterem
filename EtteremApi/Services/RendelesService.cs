using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace EtteremApi.Services
{
    public class RendelesService : IRendeles
    {
        private readonly RestaurantContext _context;
        public RendelesService(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<object> AddNewRendeles(AddRendelesDto addRendelesDto)
        {
            try
            {
                var result = new ResultResponseDto();
                var rendeles = new Rendeles
                {
                    Asztalszam = addRendelesDto.AsztalSzam,
                    Fizetesimod = addRendelesDto.Fizetesimod
                };
                if (rendeles != null) {
                    await _context.Rendeles.AddAsync(rendeles);
                    await _context.SaveChangesAsync();
                    result.Message = "Sikeres rendelés létrehozás";
                    result.result = rendeles;
                    return result;
                }
                result.Message = "Sikertelen rendelés létrehozás";
                result.result = rendeles;
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<object> EachRendelesCount()
        {
            try
            {
                var result = new ResultResponseDto();
                result.Message = "Sikeres lekérdezés";
                result.result = _context.Rendeles.GroupBy(r => r.Id)
                    .Select(g => new
                    {
                        RendelesId = g.Key,
                        Count = g.Count()
                    }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.Message = ex.Message;
                return result;

            }
        }

        public async Task<object> GetAllRecordOrderByRendeles()
        {
            try
            {
                var result = new ResultResponseDto();
                result.Message = "Sikeres lekérdezés";
                result.result = _context.Rendeles.OrderBy(r => r.Id).ToList();
                return result;

            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<object> GetAllRendelesWithFood()
        {
            try
            {
                var result = new ResultResponseDto();

                var query =
                    from r in _context.Rendeles
                    join k in _context.Kapcsolos on r.Id equals k.RendelesId
                    join t in _context.Termekeks on k.TermekekId equals t.Id
                    select new
                    {
                        RendelesId = r.Id,
                        TermekNev = t.Etel,
                        Ar = t.Arak
                    };

                result.result = await query.ToListAsync();
                result.Message = "Sikeres lekérdezés";

                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<object> GetJustTermekCola()
        {
            try
            {
                var result = new ResultResponseDto();
                result.Message = "Sikeres lekérdezés";
                result.result = _context.Termekeks.Where(t => t.Etel == "Kóla").Select(t => t.Id).ToList();
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<object> GetRecordWithCard()
        {
            try
            {
                var result = new ResultResponseDto();
                result.result =  await _context.Rendeles
                .Where(r => r.Fizetesimod == "Kártya")
                .Select(r => r.Id)
                .ToListAsync();
                result.Message = "Sikeres lekérdezés";
                return result;
            } 
            catch (Exception)
            {
                var result = new ResultResponseDto();
                result.Message = "Hiba a lekérdezés során";
                return result;
            }
        }

        public async Task<object> GettAllRendeles()
        {
            try
            {
                var result = new ResultResponseDto();
                result.Message = "Sikeres rendelés lekérdezés";
                result.result = _context.Rendeles.ToList();
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
