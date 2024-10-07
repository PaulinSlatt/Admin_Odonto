using netchallenge.Application.Interfaces;
using netchallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netchallenge.Application.Services
{
    public class SinistroService
    {
        private readonly ISinistroRepository _sinistroRepository;

        public SinistroService(ISinistroRepository sinistroRepository)
        {
            _sinistroRepository = sinistroRepository;
        }

        public async Task<IEnumerable<Sinistro>> GetAllSinistrosAsync()
        {
            return await _sinistroRepository.GetAllAsync();
        }

        public async Task<Sinistro> GetSinistroByIdAsync(long id)
        {
            return await _sinistroRepository.GetByIdAsync(id);
        }

        public async Task AddSinistroAsync(Sinistro sinistro)
        {
            await _sinistroRepository.AddAsync(sinistro);
        }

        public async Task UpdateSinistroAsync(Sinistro sinistro)
        {
            await _sinistroRepository.UpdateAsync(sinistro);
        }

        public async Task DeleteSinistroAsync(long id)
        {
            await _sinistroRepository.DeleteAsync(id);
        }
    }
}