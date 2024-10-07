using netchallenge.Application.Interfaces;
using netchallenge.Domain.Entities;
using netchallenge.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netchallenge.Application.Services
{
    public class RecomendacaoService
    {
        private readonly IRecomendacaoRepository _recomendacaoRepository;

        public RecomendacaoService(IRecomendacaoRepository recomendacaoRepository)
        {
            _recomendacaoRepository = recomendacaoRepository;
        }

        public async Task<IEnumerable<Recomendacao>> GetAllRecomendacoesAsync()
        {
            return await _recomendacaoRepository.GetAllAsync();
        }

       
        public async Task<Recomendacao> GetRecomendacaoByIdAsync(long id)
        {
            return await _recomendacaoRepository.GetByIdAsync(id);
        }

        public async Task AddRecomendacaoAsync(Recomendacao recomendacao)
        {
            await _recomendacaoRepository.AddAsync(recomendacao);
        }

        public async Task UpdateRecomendacaoAsync(Recomendacao recomendacao)
        {
            await _recomendacaoRepository.UpdateAsync(recomendacao);
        }

       
        public async Task DeleteRecomendacaoAsync(long id)
        {
            await _recomendacaoRepository.DeleteAsync(id);
        }
    }
}