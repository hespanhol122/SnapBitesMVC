using Snapbites.Models;

namespace Snapbites.Models
{

    public class interessesUsuario
    {
        public int idInterUsuario { get; set; }
        public int idUsuario { get; set; }

        public interessesUsuario()
        {
            idInterUsuario = 0;
            this.idUsuario = 0;
        }

        
        /*public virtual Usuario Usuario { get; set; }

        public int idInteresses { get; set; }
        public virtual Interesses Interesses { get; set; }*/

    }
}