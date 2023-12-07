using Microsoft.AspNetCore.Mvc;
using SnapBites.Models;
using System.Diagnostics;
using SnapBites.Repositories.ADO.SQLServer;

namespace SnapBites.Controllers
{
    public class AdminController : Controller
    {
        private readonly Repositories.ADO.SQLServer.UsuarioDAO repository;

        public AdminController(IConfiguration configuration)
        {
            this.repository = new Repositories.ADO.SQLServer.UsuarioDAO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
        }

        public IActionResult Feed()
        {
            return View();
        }

        public IActionResult Publicar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListaUsuario()
        {
            return View(this.repository.getAll()) ;
        }

        [HttpGet]
        public IActionResult Editar(int id) 
        {
            return View(this.repository.getByIdUsuario(id));
        }

        public IActionResult Editar(int id, UsuarioViewModel usuario)
        {
            try 
            {
                this.repository.update(id, usuario);
                return RedirectToAction(nameof(ListaUsuario));
            } 
            catch 
            {
                return View();
            }           
        } 
        public IActionResult Detalhes(int id)
        {
            return View(this.repository.getByIdUsuario(id));
        }

        public IActionResult Deletar(int id)
        {
            this.repository.delete(id);
            return RedirectToAction(nameof(ListaUsuario));
        }
    }
}
