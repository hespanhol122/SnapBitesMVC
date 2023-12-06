using Snapbites.Models;
using SnapBites.Models;

namespace SnapBites.Services
{
    public interface ISessao
    {
        void addTokenLogin(UsuarioViewModel usuario);

        UsuarioViewModel getTokenLogin();

        void deleteTokenLogin();
    }
}
