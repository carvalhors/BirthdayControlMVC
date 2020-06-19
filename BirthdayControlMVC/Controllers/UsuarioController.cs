using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BirthdayControlMVC.Models;
using BirthdayControlMVC.Data;

namespace BirthdayControlMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return View(new UsuarioRepositorySql().ListarTodosUsuarios("T"));
            }
            else
            {
                var RepositorioUsuario = new UsuarioRepositorySql().ListarTodosUsuarios("T");
                return View(RepositorioUsuario.Where(u => u.Nome.Contains(search)));
            }
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsuarioModel UsuarioModel)
        {
            var RepositorioUsuario = new UsuarioRepositorySql();

            //Salvar no banco
            RepositorioUsuario.SalvarUsuarioDb(UsuarioModel);

            //Salva na Memória
            //Usuarios.CriarUsuario(UsuarioModel);
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int UsuarioID)
        {
            var RepositorioUsuario = new UsuarioRepositorySql().ListarTodosUsuarios("T");
            var usr = RepositorioUsuario.Where(u => u.UsuarioID == UsuarioID).FirstOrDefault();
            return View(usr);
        }

        [HttpPost]
        public ActionResult Edit(UsuarioModel UsuarioModel)
        {
            var RepositorioUsuario = new UsuarioRepositorySql();
            RepositorioUsuario.EditarUsuarioDb(UsuarioModel);

            return RedirectToAction("Index");
        }

        public ViewResult Delete(int UsuarioID)
        {
            var RepositorioUsuario = new UsuarioRepositorySql().ListarTodosUsuarios("T");
            var usr = RepositorioUsuario.Where(u => u.UsuarioID == UsuarioID).FirstOrDefault();
            return View(usr);

        }

        [HttpPost]
        public ActionResult Delete(UsuarioModel UsuarioModel)
        {
            var RepositorioUsuario = new UsuarioRepositorySql();
            RepositorioUsuario.DeletarUsuarioDb(UsuarioModel);
            return RedirectToAction("Index");
        }


        public ViewResult Details(int UsuarioID)
        {
            var RepositorioUsuario = new UsuarioRepositorySql().ListarTodosUsuarios("T");
            var usr = RepositorioUsuario.Where(u => u.UsuarioID == UsuarioID).FirstOrDefault();
            return View(usr);

        }       

        [HttpGet]
        public ActionResult Aniversariantes(int tipo)
        {
            if (tipo == 1)
            {
                var RepositorioUsuario = new UsuarioRepositorySql().ListarTodosUsuarios("D");
                return View(RepositorioUsuario);
            }
            else
            {
                var RepositorioUsuario = new UsuarioRepositorySql().ListarTodosUsuarios("N");
                return View(RepositorioUsuario);
            }

        }

    }
}
