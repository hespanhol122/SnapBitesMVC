using Snapbites.Models;

namespace Snapbites.Models
{

    public class Publicacao
    {
        public int idPublicacao { get; set; }
        public string descricao { get; set; }
        public int curtidas { get; set; }
        public int naoCurtidas { get; set; }
        public DateTime dataHora { get; set; }

        public int idImagem { get; set; }
        public virtual Imagem Imagem { get; set; }

        public int idComentario { get; set; }
        public virtual Comentario Comentario { get; set; }
    }
}