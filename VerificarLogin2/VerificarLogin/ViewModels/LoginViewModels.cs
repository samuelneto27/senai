using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerificarLogin.ViewModels
{
    public class LoginViewModels
    {
        [HiddenInput]
        public string UrlRetorno { get; set; }


        [Required(ErrorMessage ="Informe o login!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a Senha!")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="A senha deve conter no minimo 6 caracteres.")]
        public string Senha { get; set; }
    }
}