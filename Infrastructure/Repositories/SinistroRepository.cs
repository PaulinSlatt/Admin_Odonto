using netchallenge.Application.Interfaces;
using netchallenge.Domain.Entities;
using netchallenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netchallenge.Infrastructure.Repositories
{
    public class SinistroRepository : ISinistroRepository
    {
        private readonly ApplicationDbContext _context;

        public SinistroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sinistro>> GetAllAsync()
        {
            return await _context.Sinistros.ToListAsync();
        }

        public async Task<Sinistro?> GetByIdAsync(long id)
        {
            return await _context.Sinistros.FindAsync(id);
        }

        public async Task AddAsync(Sinistro sinistro)
        {
            await _context.Sinistros.AddAsync(sinistro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sinistro sinistro)
        {
            _context.Sinistros.Update(sinistro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var sinistro = await _context.Sinistros.FindAsync(id);
            if (sinistro != null)
            {
                _context.Sinistros.Remove(sinistro);
                await _context.SaveChangesAsync();
            }
        }
    }
}