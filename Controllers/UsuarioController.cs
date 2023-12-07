using Microsoft.AspNetCore.Mvc;
using SnapBites.Models;
using System.Runtime.CompilerServices;

namespace SnapBites.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Repositories.ADO.SQLServer.UsuarioDAO repository;

        public UsuarioController(IConfiguration configuration)
        {
            this.repository = new Repositories.ADO.SQLServer.UsuarioDAO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
        }

        [HttpGet]
        public IActionResult Cadastro(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(UsuarioViewModel usuario)
        {
            try
            {
                this.repository.add(usuario);
                return RedirectToAction("Interesses", "Login");
            }
            catch 
            {
                return RedirectToAction("Home", "Index");
            }
        }


    }
}
