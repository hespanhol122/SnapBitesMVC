using Microsoft.AspNetCore.Mvc;
using SnapBites.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SnapBites.Repositories.ADO.SQLServer;

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

                    if (loginResultado.TipoUsuario == "1")
                        return RedirectToAction("Feed", "Admin");
                    return RedirectToAction("Feed", "Feed");

                }
                else 
                {
                    ModelState.AddModelError("", "Usuário e/ou Senha Inváilidos!");

                    return RedirectToAction("Login", "Login");
                }
                
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