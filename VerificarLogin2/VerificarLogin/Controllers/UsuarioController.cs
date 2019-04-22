using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerificarLogin.Models;
using VerificarLogin.ViewModels;
using VerificarLogin.Utils;
using System.Security.Claims;

namespace VerificarLogin.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioContext db = new UsuarioContext();
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar (UsuariosViewModels viewModels)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModels);
            }

            if(db.Usuarios.Count(u => u.Login == viewModels.Login) > 0)
            {
                ModelState.AddModelError("Login", "Este login ja esta em uso!");
                return View (viewModels);
            }
            Usuario novoUsuario = new Usuario
            {
                Nome = viewModels.Nome,
                Login = viewModels.Login,
                Senha = Hash.GerarHash(viewModels.ConfirmarSenha)
            };

            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();
            TempData["Mensagem"] = "Cadastro realizado com Sucesso!";

            return RedirectToAction("Index", "Home");
            

            
        }

        public ActionResult Login(LoginViewModels viewModels)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModels);
            }
            var usuario = db.Usuarios.FirstOrDefault(u => u.Login == viewModels.Login);

            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Usuario ou senha não conferem, favor verificar e tentar novamente!");
                return View(viewModels);
            }

 
            if (usuario.Senha != Hash.GerarHash(viewModels.Senha))
            {
                ModelState.AddModelError("Login", "Usuario ou Senha não confere, favor verificar e tentar novamente!");
                return View(viewModels);
            }

            var identity = new ClaimsIdentity(new[]{

                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Login)
            },"ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewModels.UrlRetorno) || Url.IsLocalUrl(viewModels.UrlRetorno))
            {
                return Redirect(viewModels.UrlRetorno);
            }
            else
            {
                return RedirectToAction("Index", "Painel");
            }

            
        }

        public ActionResult LogOut(LoginViewModels viewModels)
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}