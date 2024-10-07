using Microsoft.AspNetCore.Mvc;
using netchallenge.Application.Services;
using netchallenge.Domain.Entities;

namespace netchallenge.Controllers
{
    public class PacientesController : Controller
    {
        private readonly PacienteService _pacienteService;

        public PacientesController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

      
        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteService.GetAllPacientesAsync();
            return View("Index", pacientes);
        }

       
        public async Task<IActionResult> Details(long id)  
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Email,DataNascimento,Genero,Telefone,Logradouro,Bairro,Cep,Complemento,Numero,Uf,Cidade")] Paciente paciente)
        {
            if (await _pacienteService.EmailExistsAsync(paciente.Email))
            {
                ModelState.AddModelError("Email", "Este email já está em uso.");
                return View(paciente);
            }

            if (ModelState.IsValid)
            {
                await _pacienteService.AddPacienteAsync(paciente);
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        public async Task<IActionResult> Edit(long id) 
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Email,DataNascimento,Genero,Telefone,Logradouro,Bairro,Cep,Complemento,Numero,Uf,Cidade")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _pacienteService.UpdatePacienteAsync(paciente);
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }
        
        public async Task<IActionResult> Delete(long id)  
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }
      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)  
        {
            await _pacienteService.DeletePacienteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}