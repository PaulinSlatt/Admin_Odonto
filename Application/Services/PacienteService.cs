using netchallenge.Application.Interfaces;
using netchallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netchallenge.Application.Services
{
    public class PacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<Paciente>> GetAllPacientesAsync()
        {
            return await _pacienteRepository.GetAllAsync();
        }

        public async Task<Paciente?> GetPacienteByIdAsync(long id)
        {
            return await _pacienteRepository.GetByIdAsync(id);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            var existingPaciente = await _pacienteRepository.GetByEmailAsync(email);
            return existingPaciente != null;
        }

        public async Task AddPacienteAsync(Paciente paciente)
        {
            await _pacienteRepository.AddAsync(paciente);
        }

        public async Task UpdatePacienteAsync(Paciente paciente)
        {
            await _pacienteRepository.UpdateAsync(paciente);
        }

        public async Task DeletePacienteAsync(long id)
        {
            await _pacienteRepository.DeleteAsync(id);
        }
    }
}