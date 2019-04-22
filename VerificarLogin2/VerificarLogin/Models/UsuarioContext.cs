using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VerificarLogin.Models
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext() : base("Usuarios")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Especialidade> Especialidades { get; set; }
    }
}