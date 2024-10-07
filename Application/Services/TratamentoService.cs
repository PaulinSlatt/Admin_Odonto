using netchallenge.Application.Interfaces;
using netchallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netchallenge.Application.Services
{
    public class TratamentoService
    {
        private readonly ITratamentoRepository _tratamentoRepository;

        public TratamentoService(ITratamentoRepository tratamentoRepository)
        {
            _tratamentoRepository = tratamentoRepository;
        }

        public async Task<IEnumerable<Tratamento>> GetAllTratamentosAsync()
        {
            return await _tratamentoRepository.GetAllAsync();
        }

        public async Task<Tratamento> GetTratamentoByIdAsync(long id)  
        {
            return await _tratamentoRepository.GetByIdAsync(id);
        }

        public async Task AddTratamentoAsync(Tratamento tratamento)
        {
            await _tratamentoRepository.AddAsync(tratamento);
        }

        public async Task UpdateTratamentoAsync(Tratamento tratamento)
        {
            await _tratamentoRepository.UpdateAsync(tratamento);
        }

        public async Task DeleteTratamentoAsync(long id)
        {
            await _tratamentoRepository.DeleteAsync(id);
        }
    }
}