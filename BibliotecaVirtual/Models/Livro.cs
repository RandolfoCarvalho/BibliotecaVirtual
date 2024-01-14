using BibliotecaVirtual.Enums;
using System.ComponentModel;

namespace BibliotecaVirtual.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genero { get; set; }
        [DisplayName("Ano de publicação")]
        public DateTime AnoPublicacao { get; set; }
        [DisplayName("Numero de páginas")]
        public int NumeroPaginas { get; set; }

        public string Sinopse { get; set; }
        public DisponibilidadeLivro Disponibilidade { get; set; }

    }
}
