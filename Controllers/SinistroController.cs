using Microsoft.AspNetCore.Mvc;
using netchallenge.Domain.Entities;
using netchallenge.Application.Services;

namespace netchallenge.Controllers
{
    public class SinistrosController : Controller
    {
        private readonly SinistroService _sinistroService;

        public SinistrosController(SinistroService sinistroService)
        {
            _sinistroService = sinistroService;
        }

        // GET: Sinistros
        public async Task<IActionResult> Index()
        {
            var sinistros = await _sinistroService.GetAllSinistrosAsync();
            return View(sinistros);
        }

        // GET: Sinistros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sinistros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacienteId,TratamentoId,DataOcorrencia,ValorReembolsado,Status")] Sinistro sinistro)
        {
            if (ModelState.IsValid)
            {
                await _sinistroService.AddSinistroAsync(sinistro);
                return RedirectToAction(nameof(Index));
            }
            return View(sinistro);
        }

        // GET: Sinistros/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var sinistro = await _sinistroService.GetSinistroByIdAsync(id);
            if (sinistro == null)
            {
                return NotFound();
            }
            return View(sinistro);
        }

        // POST: Sinistros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PacienteId,TratamentoId,DataOcorrencia,ValorReembolsado,Status")] Sinistro sinistro)
        {
            if (id != sinistro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _sinistroService.UpdateSinistroAsync(sinistro);
                return RedirectToAction(nameof(Index));
            }
            return View(sinistro);
        }

        // GET: Sinistros/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var sinistro = await _sinistroService.GetSinistroByIdAsync(id);
            if (sinistro == null)
            {
                return NotFound();
            }
            return View(sinistro);
        }

        // POST: Sinistros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _sinistroService.DeleteSinistroAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}