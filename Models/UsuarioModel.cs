using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anuncios.mvc.Models
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50,ErrorMessage="O nome não pode passar de 50 caracteres")]

        public string Nome { get; set; }
        [MaxLength(80,ErrorMessage = "O email não pode passar de 50 caracteres")]
        public string Email { get; set; }

        [MaxLength(10, ErrorMessage = "A senha não pode passar de 10 caracteres")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAtivacao { get; set; }

       

       

    


    }
}
