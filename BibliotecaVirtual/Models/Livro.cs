using BibliotecaVirtual.Enums;

namespace BibliotecaVirtual.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genero { get; set; }
        public DateTime AnoPublicacao { get; set; }
        public int NumeroPaginas { get; set; }

        public string Sinopse { get; set; }
        public DisponibilidadeLivro Disponibilidade { get; set; }
    }
}
