using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VerificarLogin.Models
{
    [Table("Medico")]
    public class Medico
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Favor inserir seu nome.")]
        public string Nome { get; set; }



        [Required(ErrorMessage = "Favor Inserir o registro de C.R.M.")]
        public string CRM { get; set; }


        public int EspecialidadeId { get; set; }
        [ForeignKey("EspecialidadeId")]
        public Especialidade Especialidade { get; set; }
        //[Required(ErrorMessage = "Favor Inserir sua Especialidade.")]
        //[ForeignKey("Especialidades")]
        //public string Especialidades { get; set; }


        [Required(ErrorMessage = "Favor Inserir seu Endereço Completo.")]
        public string Endereco { get; set; }


        [Required(ErrorMessage = "Favor Inserir seu Bairro.")]
        public string Bairro { get; set; }


        [Required(ErrorMessage = "Favor Inserir sua Cidade.")]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "Favor Inserir seu Estado.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Favor Inserir seu Telefone.")]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "Favor Inserir seu E-Mail de contato.")]
        public string Email { get; set; }

        public string WebSite { get; set; }


        [Required(ErrorMessage = "Atende Por Convenio?")]
        public bool AtendePorConvenio { get; set; }



    }
}