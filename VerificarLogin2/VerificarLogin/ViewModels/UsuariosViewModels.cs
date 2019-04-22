using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VerificarLogin.ViewModels
{
    public class UsuariosViewModels
    {
        [Required(ErrorMessage = "Favor preencher o nome!")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor inserir Login!")]
        [MinLength(6, ErrorMessage = "O Login deve conter no minimo 6 caracteres e no maximo 30.")]
        [MaxLength(30)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Favor inserir a senha!")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve conter no minimo 6 caracteres e no maximo 20.")]
        [MaxLength(100)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [MinLength(6, ErrorMessage = "A senha deve conter no minimo 6 caracteres")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e a confirmação nao são iguais!")]
        public string ConfirmarSenha { get; set; }
    }
}
