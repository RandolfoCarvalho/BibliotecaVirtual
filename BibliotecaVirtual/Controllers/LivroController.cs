using BibliotecaVirtual.Data;
using BibliotecaVirtual.Models;
using BibliotecaVirtual.Models.ViewModels;
using BibliotecaVirtual.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BibliotecaVirtual.Controllers
{
    public class LivroController : Controller
    {
        private readonly MysqlContext _context;
        private readonly LivrosService _service;


        public LivroController(MysqlContext context, LivrosService livroService)
        {
            _context = context;
            _service = livroService;
        }
        //Listar
        public IActionResult Listar()
        {
            return View(_service.FindAll());
        }
        public async Task<IActionResult> Criar()
        {
            var viewModel = new LivroFormView();
            return View(viewModel);
        }

        [HttpPost]
        //impedir ataques csrf
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("O livro não pode ser nulo");
            }
            await _service.CriarAsync(livro);
            return RedirectToAction(nameof(Listar));
        }
        public async Task<IActionResult> Editar(int id)
        {
            var result = _service.FindById(id);
            var viewModel = new LivroFormView() { Livro = result};
            return View(viewModel);
        }
        //Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, Livro livro)
        {
            if (!ModelState.IsValid)
            {
                //barra a requisição mesmo com o js desabilitado
                var result = new LivroFormView { Livro = livro };
                return View(result);
            }
            if (id != livro.Id)
            {
                return BadRequest("Erro ao editar o livro");
            }
            try
            {
                await _service.EditAsync(livro);
                return RedirectToAction(nameof(Listar));
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public IActionResult Deletar(int id)
        {
            _service.Remove(id);
            return RedirectToAction(nameof(Listar));
        }
        public IActionResult Filtro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Filtro(DateTime DataInicio, DateTime DataFim)
        {
            var dadosFiltrados = _context.Livros.Where(p => p
            .AnoPublicacao >= DataInicio && p
            .AnoPublicacao <= DataFim).ToList();

            return View(dadosFiltrados);
        }
    }
}
