using Microsoft.AspNetCore.Mvc;
using netchallenge.Domain.Entities;
using netchallenge.Application.Services;

namespace netchallenge.Controllers
{
    public class RecomendacoesController : Controller
    {
        private readonly RecomendacaoService _recomendacaoService;

        public RecomendacoesController(RecomendacaoService recomendacaoService)
        {
            _recomendacaoService = recomendacaoService;
        }

        public async Task<IActionResult> Index()
        {
            var recomendacoes = await _recomendacaoService.GetAllRecomendacoesAsync();
            return View(recomendacoes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recomendacao recomendacao)
        {
            if (ModelState.IsValid)
            {
                await _recomendacaoService.AddRecomendacaoAsync(recomendacao);
                return RedirectToAction(nameof(Index));
            }
            return View(recomendacao);
        }
        public async Task<IActionResult> Edit(long id)
        {
            var recomendacao = await _recomendacaoService.GetRecomendacaoByIdAsync(id);
            if (recomendacao == null)
            {
                return NotFound();
            }
            return View(recomendacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Recomendacao recomendacao)
        {
            if (id != recomendacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _recomendacaoService.UpdateRecomendacaoAsync(recomendacao);
                return RedirectToAction(nameof(Index));
            }
            return View(recomendacao);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var recomendacao = await _recomendacaoService.GetRecomendacaoByIdAsync(id);
            if (recomendacao == null)
            {
                return NotFound();
            }
            return View(recomendacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _recomendacaoService.DeleteRecomendacaoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}