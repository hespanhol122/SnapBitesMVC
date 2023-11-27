namespace Snapbites.Models
{

    public class Interesses
    {
        public int idInteresses { get; set; }
        public string nome { get; set; }

        public List<interessesUsuario> rInteressesUsuario { get; set; }
    }
}