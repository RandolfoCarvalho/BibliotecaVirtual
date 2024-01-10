using BibliotecaVirtual.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Data
{
    public class MysqlContext :DbContext
    {
        public MysqlContext() { }
        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options)
        {

        }
        public DbSet<Livro> Livros { get; set; }
    }
}
