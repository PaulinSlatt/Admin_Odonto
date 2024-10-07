using netchallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netchallenge.Application.Interfaces
{
    public interface ISinistroRepository
    {
        Task<IEnumerable<Sinistro>> GetAllAsync();
        Task<Sinistro> GetByIdAsync(long id);
        Task AddAsync(Sinistro sinistro);
        Task UpdateAsync(Sinistro sinistro);
        Task DeleteAsync(long id);
    }
}