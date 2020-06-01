using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BirthdayControlMVC.Models;

namespace BirthdayControlMVC.Controllers
{
    public class UsuarioController : Controller
    {

        private static Usuarios Usuarios = new Usuarios();

        public IActionResult Index()
        {
            return View(Usuarios.ListaUsuarios);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsuarioModel UsuarioModel)
        {
            Usuarios.CriarUsuario(UsuarioModel);
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int UsuarioID)
        {
            var usr = Usuarios.ListaUsuarios.Where(u => u.UsuarioID == UsuarioID).FirstOrDefault();
            return View(usr);
        }

        [HttpPost]
        public ActionResult Edit(UsuarioModel UsuarioModel)
        {
            Usuarios.AtualizaUsuario(UsuarioModel);
            return RedirectToAction("Index");
        }

        public ViewResult Delete(int UsuarioID)
        {
            var usr = Usuarios.ListaUsuarios.Where(u => u.UsuarioID == UsuarioID).FirstOrDefault();
            return View(usr);

        }

        [HttpPost]
        public ActionResult Delete(UsuarioModel UsuarioModel)
        {
            Usuarios.DeletarUsuario(UsuarioModel);
            return RedirectToAction("Index");
        }

     
        public ViewResult Details(int UsuarioID)
        {
            var usr = Usuarios.ListaUsuarios.Where(u => u.UsuarioID == UsuarioID).FirstOrDefault();
            return View(usr);

        }

   
        [HttpGet]
        public ActionResult Search(string search)
        {
            if (search != null)
            {
                var usr = Usuarios.ListaUsuarios.Where(u => u.Nome.Contains(search));
                return View(usr);
            }
            else
            {
                return View(Usuarios.ListaUsuarios);
            }
           
        }

    }
}
