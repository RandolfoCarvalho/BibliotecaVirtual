using BibliotecaVirtual.Data;
using BibliotecaVirtual.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

        public async Task EditAsync(Livro livro)
        {
            var result =  _context.Livros.SingleOrDefault(x => x.Id == livro.Id);
            if (result == null)
            {
                throw new KeyNotFoundException("Id not Found");
            }
            try
            {
                _context.Entry(result).CurrentValues.SetValues(livro);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void Remove(int id)
        {
            var result = FindById(id);
            _context.Remove(result);
            _context.SaveChanges();
        }
    }
}
