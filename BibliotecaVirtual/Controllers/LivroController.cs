using BibliotecaVirtual.Data;
using BibliotecaVirtual.Models;
using BibliotecaVirtual.Models.ViewModels;
using BibliotecaVirtual.Services;
using Microsoft.AspNetCore.Mvc;

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
            return Ok("Livro criado com sucesso " + livro);
        }

        //Editar
        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Livro livro)
        {
            await _service.EditAsync(livro);
            return Ok(livro);
        }
        public IActionResult Deletar(int id)
        {
            _service.Remove(id);
            return Ok("Livro removido com sucesso");
        }
    }
}
