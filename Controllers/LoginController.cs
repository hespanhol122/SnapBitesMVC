using Microsoft.AspNetCore.Mvc;
using Snapbites.Models;
using SnapBites.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SnapBites.Controllers
{
    public class LoginController : Controller
    {
        private readonly Repositories.ADO.SQLServer.UsuarioDAO repository;
        private readonly Services.ISessao sessao;

        public LoginController(IConfiguration configuration, Services.ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.UsuarioDAO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        public IActionResult Login()
        {
            return this.sessao.getTokenLogin() == null ? View() : RedirectToAction("Index", "Home");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Interesses() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginEntrar(UsuarioViewModel usuario)
        {
            if (!string.IsNullOrEmpty(usuario.nome) && !string.IsNullOrEmpty(usuario.senha))
            {
                if (this.repository.check(usuario))
                {
                    var loginResultado = repository.getTipo(usuario);
                    this.sessao.addTokenLogin(usuario);

                    //if (loginResultado.TipoUsuario == "1")
                    //    return RedirectToAction("Index", "Feed");
                    return RedirectToAction("Index", "Feed");

                }
                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inváilidos!");

                return RedirectToAction("Feed", "Feed");
            }
            return View();
        }

        public IActionResult Logout()
        {
            this.sessao.deleteTokenLogin();
            return RedirectToAction("Index","Home");
        }
    }
}