using Snapbites.Models;

namespace Snapbites.Models
{

    public class Publicacao
    {
        private int idPublicacao { get; set; }
        private string descricao { get; set; }
        private int curtidas { get; set; }
        private int naoCurtidas { get; set; }
        private DateTime dataHora { get; set; }

        private int idImagem { get; set; }
        public virtual Imagem Imagem { get; set; }

        private int idComentario { get; set; }
        public virtual Comentario Comentario { get; set; }
    }
}