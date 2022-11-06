using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anuncios.mvc.Models
{
    [Table("Login")]
    public class LoginRequestModel

    {
        [Key]


        [MaxLength(80, ErrorMessage = "O email não pode passar de 50 caracteres")]
        public string Email { get; set; }

        [MaxLength(10, ErrorMessage = "A senha não pode passar de 10 caracteres")]
        public string Senha { get; set; }
    }
}
