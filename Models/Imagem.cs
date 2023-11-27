namespace Snapbites.Models
{

    public class Imagem
    {
        public int idImagem { get; set; }
        public string imagemUrl { get; set; }

        public int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public List<Publicacao> rPublicacao { get; set; }
    }
}