namespace SnapBites.Models
{
    public class UsuarioViewModel
    {
        public int idUsuario { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public int atividade { get; set; }

        public UsuarioViewModel()
        {
            this.idUsuario = 0;
            this.nome = string.Empty;
            this.senha = string.Empty;
            this.email = string.Empty;
            this.atividade = 0;
        }
    }
}
