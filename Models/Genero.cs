namespace Snapbites.Models
{

    public class Genero
    {

        public int idGenero { get; set; }
        public string genero { get; set; }

        public Genero() 
        {
            this.idGenero = 0;
            this.genero = string.Empty;
        }

        /*public List<Usuario> rUsuario { get; set; }*/

    }
}