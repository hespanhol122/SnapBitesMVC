namespace Snapbites.Models
{

    public class Interesses
    {
        private int idInteresses { get; set; }
        private string nome { get; set; }

        private List<interessesUsuario> rInteressesUsuario { get; set; }
    }
}