using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerificarLogin.ViewModels;

namespace VerificarLogin.Controllers
{
    public class PainelController : Controller
    {
        // Metodo de validação para login. esta pagina so ira ser acessada se estiver logado.   
        [AuthorizeCustom]
        public ActionResult Index()
        {
            return View();
        }

    }
}