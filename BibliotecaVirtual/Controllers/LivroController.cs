using BibliotecaVirtual.Data;
using BibliotecaVirtual.Models;
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
            return Ok(_service.FindAll());
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Livro livro)
        {
            if (livro == null)
            {
                return BadRequest("O livro não pode ser nulo");
            }
            await _service.CriarAsync(livro);
            return Ok("Livro criado com sucesso " + livro);
        }

        //Editar
        [HttpPost]
        public async Task<IActionResult> Editar([FromBody] Livro livro)
        {
            await _service.EditAsync(livro);
            return  new ObjectResult(livro.ToString());
        }

    }
}
