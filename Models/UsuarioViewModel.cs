using System.ComponentModel.DataAnnotations;

namespace SnapBites.Models
{
    public class UsuarioViewModel
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória!", AllowEmptyStrings = false)]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Mínimo de 3 e máximo de 8 caracteres.")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Email é obrigatório!", AllowEmptyStrings = false)]
        public string email { get; set; }
        public bool atividade { get; set; }

        public UsuarioViewModel()
        {
            this.idUsuario = 0;
            this.nome = string.Empty;
            this.senha = string.Empty;
            this.email = string.Empty;
            this.atividade = false;
        }
    }
}