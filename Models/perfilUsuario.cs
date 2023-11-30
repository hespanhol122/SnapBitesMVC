using Microsoft.Identity.Client;
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

        public perfilUsuario() 
        {
            this.idPerfil = 0;
            this.nome = string.Empty;
            this.sobrenome = string.Empty;
            this.dataNascimento = new DateOnly();
            this.sobre = string.Empty;
            this.fotoPerfil = string.Empty;
        }

        /*private int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }*/
    }
}