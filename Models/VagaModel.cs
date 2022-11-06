using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anuncios.mvc.Models
{
    [Table("Vagas")]
    public class VagaModel
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50, ErrorMessage = "O titulo não pode passar de 50 caracteres")]
        public string Titulo { get; set; }


        [MaxLength(50, ErrorMessage = "O Descricao não pode passar de 50 caracteres")]
        public string Descricacao { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime DataEncerramento { get; set; }

        public Decimal Remuneracao { get; set; }

        [MaxLength(50, ErrorMessage = "O Anunciante não pode passar de 50 caracteres")]
        public string Anunciante { get; set; }


        [MaxLength(50, ErrorMessage = "A rua  não pode passar de 50 caracteres")]
        public string Rua { get; set; }

        [MaxLength(50, ErrorMessage = "O Bairro não pode passar de 50 caracteres")]
        public string Bairro { get; set; }

        [MaxLength(50, ErrorMessage = "A cidade não pode passar de 50 caracteres")]
        public string Cidade { get; set; }
        [MaxLength(2, ErrorMessage = "O Estado não pode passar de 2 caracteres")]
        public string Estado { get; set; }

        [MaxLength(50, ErrorMessage = "O Email não pode passar de 50 caracteres")]
        public string Email { get; set; }
        [MaxLength(15, ErrorMessage = "O telefone não pode passar de 15 caracteres")]
        public string Telefone { get; set; }


        
    }
}
