using MiniPerson.Domain.DTO;
using MiniPerson.Domain.Entities;

namespace MiniPerson.Contract.Person.Queries
{
    public interface IPersonRepository
    {
        Task<PersonDto> GetByPersonAsync(string fullName, string date);
        Task<List<PersonAllDto>> GetAllAsync();
        Task<long> InsertAsync(MiniPerson.Domain.Entities.Person person);
    }
}