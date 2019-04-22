using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VerificarLogin.ViewModels
{
    public class AlterarSenhaViewModels
    {
        [Required(ErrorMessage ="Informe a senha atual")]
        [DataType(DataType.Password)]
        [Display(Name ="Senha Atual")]
        public string SenhaAtual { get; set; }


        [Required(ErrorMessage = "Informe a nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }


        [Required(ErrorMessage = "Informe a nova senha novamente")]
        [DataType(DataType.Password)]
        [Display(Name = "Informe a senha novamente")]
        [Compare(nameof(NovaSenha), ErrorMessage =("As senhas não conferem!"))]
        public string ConfirmacaoSenha { get; set; }

    }
}