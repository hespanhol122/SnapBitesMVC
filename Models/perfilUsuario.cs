using System;

namespace Snapbites.Models
{

    public class perfilUsuario
    {
        public int idPerfil { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateOnly dataNascimento { get; set; }
        public string sobre { get; set; }
        public string fotoPerfil { get; set; }

        public int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}