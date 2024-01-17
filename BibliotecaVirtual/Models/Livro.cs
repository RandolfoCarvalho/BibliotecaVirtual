using BibliotecaVirtual.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaVirtual.Models
{
    public class Livro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [DisplayName("Ano de publicação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AnoPublicacao { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [DisplayName("Numero de páginas")]
        public int NumeroPaginas { get; set; }
        [Required(ErrorMessage = "A {0} é obrigatória")]
        public string Sinopse { get; set; }
        [Required(ErrorMessage = "A {0} é obrigatória")]
        public DisponibilidadeLivro Disponibilidade { get; set; }

    }
}
