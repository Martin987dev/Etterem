using EtteremApi.Models.Dtos;

namespace EtteremApi.Services.IServices
{
    public interface IKapcsolo
    {
        Task<object> PostNewRelation(AddRelationDto addRelationDto);
    }
}
