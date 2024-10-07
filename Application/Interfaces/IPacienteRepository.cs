using netchallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netchallenge.Application.Interfaces;

public interface IPacienteRepository
{
    Task<IEnumerable<Paciente>> GetAllAsync();
    Task<Paciente?> GetByIdAsync(long id);
    Task<Paciente?> GetByEmailAsync(string email);  
    Task AddAsync(Paciente paciente);
    Task UpdateAsync(Paciente paciente);
    Task DeleteAsync(long id);
}
