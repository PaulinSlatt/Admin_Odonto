using netchallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netchallenge.Application.Interfaces
{
    public interface ITratamentoRepository
    {
        Task<IEnumerable<Tratamento>> GetAllAsync();
        Task<Tratamento> GetByIdAsync(long id);  
        Task AddAsync(Tratamento tratamento);
        Task UpdateAsync(Tratamento tratamento);
        Task DeleteAsync(long id);  
    }
}