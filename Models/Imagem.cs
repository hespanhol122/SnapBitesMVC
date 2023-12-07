using System.Runtime.CompilerServices;

namespace SnapBites.Models
{

    public class Imagem
    {
        public int idImagem { get; set; }
        public string imagemUrl { get; set; }

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