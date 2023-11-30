using Snapbites.Models;

namespace SnapBites.Services
{
    public interface ISessao
    {
        void addTokenLogin(Usuario usuario);

        Usuario getTokenLogin();

        void deleteTokenLogin();
    }
}
