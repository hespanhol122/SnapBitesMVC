namespace SnapBites.Models
{
    public class Niveis
    {
        public int idNivel { get; set; }
        public string nivel { get; set; }
        public string descricao { get; set; }

        public Niveis() 
        {
            this.idNivel = 0;
            this.nivel = string.Empty;
            this.descricao = string.Empty;
        }

        /*public List<Usuario> rUsuario { get; set; }*/
    }
}