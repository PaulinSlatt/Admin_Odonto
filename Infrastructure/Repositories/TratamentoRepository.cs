using netchallenge.Application.Interfaces;
using netchallenge.Domain.Entities;
using netchallenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netchallenge.Infrastructure.Repositories
{
    public class TratamentoRepository : ITratamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public TratamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tratamento>> GetAllAsync()
        {
            return await _context.Tratamentos.ToListAsync();
        }

        public async Task<Tratamento?> GetByIdAsync(long id)  
        {
            return await _context.Tratamentos.FindAsync(id);
        }

        public async Task AddAsync(Tratamento tratamento)
        {
            await _context.Tratamentos.AddAsync(tratamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tratamento tratamento)
        {
            _context.Tratamentos.Update(tratamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var tratamento = await _context.Tratamentos.FindAsync(id);
            if (tratamento != null)
            {
                _context.Tratamentos.Remove(tratamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}