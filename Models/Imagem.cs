using System.Runtime.CompilerServices;

namespace Snapbites.Models
{

    public class Imagem
    {
        private int idImagem { get; set; }
        private string imagemUrl { get; set; }

        public Imagem()
        {
            this.idImagem = 0;
            this.imagemUrl = string.Empty;
        }

        /*private int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        private List<Publicacao> rPublicacao { get; set; }*/
    }
}