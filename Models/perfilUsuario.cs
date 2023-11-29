using System;

namespace Snapbites.Models
{

    public class perfilUsuario
    {
        private int idPerfil { get; set; }
        private string nome { get; set; }
        private string sobrenome { get; set; }
        private DateOnly dataNascimento { get; set; }
        private string sobre { get; set; }
        private string fotoPerfil { get; set; }

        private int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}