namespace Snapbites.Models
{

    public class Comentario
    {
        public int idComentario { get; set; }
        public string texto { get; set; }
        public DateTime dataHora { get; set; }

        public Comentario() 
        {
            this.idComentario = 0;
            this.texto = string.Empty;
            this.dataHora = DateTime.Now;
        } 

        /*public int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }*/
    }
}