namespace Snapbites.Models
{
    public class Niveis
    {
        public int idNivel { get; set; }
        public int nivel { get; set; }
        public string descricao { get; set; }

        public List<Usuario> rUsuario { get; set; }
    }
}