using Microsoft.AspNetCore.Mvc;
using netchallenge.Domain.Entities;
using netchallenge.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace netchallenge.Controllers
{
    public class TratamentosController : Controller
    {
        private readonly TratamentoService _tratamentoService;

        public TratamentosController(TratamentoService tratamentoService)
        {
            _tratamentoService = tratamentoService;
        }

        // GET: Tratamentos
        public async Task<IActionResult> Index()
        {
            var tratamentos = await _tratamentoService.GetAllTratamentosAsync();
            return View(tratamentos);
        }

        // GET: Tratamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tratamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Tipo,Custo")] Tratamento tratamento)
        {
            if (ModelState.IsValid)
            {
                await _tratamentoService.AddTratamentoAsync(tratamento);
                return RedirectToAction(nameof(Index));
            }
            return View(tratamento);
        }

        // GET: Tratamentos/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var tratamento = await _tratamentoService.GetTratamentoByIdAsync(id);
            if (tratamento == null)
            {
                return NotFound();
            }
            return View(tratamento);
        }

        // POST: Tratamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Descricao,Tipo,Custo")] Tratamento tratamento)
        {
            if (id != tratamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _tratamentoService.UpdateTratamentoAsync(tratamento);
                return RedirectToAction(nameof(Index));
            }
            return View(tratamento);
        }


        // GET: Tratamentos/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var tratamento = await _tratamentoService.GetTratamentoByIdAsync(id);
            if (tratamento == null)
            {
                return NotFound();
            }
            return View(tratamento);
        }

        // POST: Tratamentos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _tratamentoService.DeleteTratamentoAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Tratamentos/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var tratamento = await _tratamentoService.GetTratamentoByIdAsync(id);
            if (tratamento == null)
            {
                return NotFound();
            }
            return View(tratamento);
        }
    }
}