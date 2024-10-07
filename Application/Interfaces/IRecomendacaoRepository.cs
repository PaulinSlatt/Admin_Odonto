using netchallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netchallenge.Application.Interfaces
{
    public interface IRecomendacaoRepository
    {
        Task<IEnumerable<Recomendacao>> GetAllAsync();
        Task<Recomendacao> GetByIdAsync(long id);
        Task AddAsync(Recomendacao recomendacao);
        Task UpdateAsync(Recomendacao recomendacao);
        Task DeleteAsync(long id);
    }
}
