using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using VerificarLogin.Models;
using VerificarLogin.Utils;
using VerificarLogin.ViewModels;

namespace VerificarLogin.Controllers
{
    public class PerfilController : Controller
            {
        private UsuarioContext db = new UsuarioContext();
        // GET: Perfil
        [AuthorizeCustom]
        public ActionResult Index()
        {

            return View();
        } 
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [AuthorizeCustom]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModels viewModels)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(
                c => c.Type == "Login").Value;
            var usuario = db.Usuarios.FirstOrDefault(
                u => u.Login == login);

            if(Hash.GerarHash(viewModels.SenhaAtual) != usuario.Senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha Incorreta!");
                return View();
            }
            usuario.Senha = Hash.GerarHash(viewModels.NovaSenha);
            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Painel");
                

                }
    }
}
