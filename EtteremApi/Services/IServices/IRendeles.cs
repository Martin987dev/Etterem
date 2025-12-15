using EtteremApi.Models.Dtos;

namespace EtteremApi.Services.IServices
{
    public interface IRendeles
    {
        Task<object> AddNewRendeles(AddRendelesDto addRendelesDto);

        Task<object> GettAllRendeles();

        Task<object> GetRecordWithCard();
        Task<object> GetAllRendelesWithFood();

        Task<object> GetAllRecordOrderByRendeles();

        Task<object> GetJustTermekCola();

        Task<object> EachRendelesCount();


    }
}
