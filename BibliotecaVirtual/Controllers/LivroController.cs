using BibliotecaVirtual.Data;
using BibliotecaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.Controllers
{
    public class LivroController : Controller
    {
        public readonly MysqlContext _context;

        public LivroController(MysqlContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (livro == null)
            {
                return BadRequest("O livro não pode ser nulo");
            }
            _context.Add(livro);
            _context.SaveChanges();
            return Ok("Livro criado com sucesso");
        }
    }
}
