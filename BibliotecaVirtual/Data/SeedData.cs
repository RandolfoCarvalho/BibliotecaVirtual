/* using BibliotecaVirtual.Data;
using BibliotecaVirtual.Enums;
using BibliotecaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public  class SeedData
{
      public  readonly MysqlContext _context;
      public SeedData(MysqlContext context)
    {
        _context = context;
    }
 
    // Verifica se há livros no banco de dados
    public void Seed()
    {
        if (_context.Livros.Any())
        {
            return;
        }
        // add alguns livros
        _context.Livros.AddRange(
            new Livro { Name = "Livro 1", Genero = "Ficção", AnoPublicacao = new DateTime(2020, 1, 1), NumeroPaginas = 200, Sinopse = "Sinopse do Livro 1", Disponibilidade = DisponibilidadeLivro.Disponivel },
            new Livro { Name = "Livro 2", Genero = "Não Ficção", AnoPublicacao = new DateTime(2021, 1, 1), NumeroPaginas = 250, Sinopse = "Sinopse do Livro 2", Disponibilidade = DisponibilidadeLivro.Disponivel },
            new Livro { Name = "Livro 3", Genero = "Mistério", AnoPublicacao = new DateTime(2019, 1, 1), NumeroPaginas = 180, Sinopse = "Sinopse do Livro 3", Disponibilidade = DisponibilidadeLivro.Disponivel },
            new Livro { Name = "Livro 4", Genero = "Romance", AnoPublicacao = new DateTime(2022, 1, 1), NumeroPaginas = 300, Sinopse = "Sinopse do Livro 4", Disponibilidade = DisponibilidadeLivro.Disponivel },
            new Livro { Name = "Livro 5", Genero = "Aventura", AnoPublicacao = new DateTime(2020, 6, 1), NumeroPaginas = 220, Sinopse = "Sinopse do Livro 5", Disponibilidade = DisponibilidadeLivro.Disponivel }
        );

        _context.SaveChanges();
    }           
}
*/