using EtteremApi.Models.Dtos;

namespace EtteremApi.Services.IServices
{
    public interface ITermekek
    {
        Task<object> AddNewTermek(AddTermekDto addTermekDto);
        Task<object> GetAllTermekeks();

        
    }
}
