using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VerificarLogin.Models
{

    [Table("Especialidade")]
public class Especialidade
{
    public int EspecialidadeId { get; set; }
    public string Especialidades { get; set; }
}
}