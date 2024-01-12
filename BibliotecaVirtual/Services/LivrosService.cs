using BibliotecaVirtual.Data;
using BibliotecaVirtual.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BibliotecaVirtual.Services
{
    public class LivrosService
    {
        private readonly MysqlContext _context;

        public LivrosService(MysqlContext context)
        {
            _context = context;
        }
        public List<Livro> FindAll()
        {
            return _context.Livros.ToList();
        }
        public Livro FindById(int id)
        {
            var result = _context.Livros.SingleOrDefault(p => p.Id == id);
            return result;
        }

        public async Task CriarAsync(Livro livro)
        {
            _context.Add(livro);
            await _context.SaveChangesAsync();
        }
    }
}
