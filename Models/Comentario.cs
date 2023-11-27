namespace Snapbites.Models
{

    public class Comentario
    {
        public int idComentario { get; set; }
        public string texto { get; set; }
        public DateTime dataHora { get; set; }

        public int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}