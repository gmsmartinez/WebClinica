using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebClinica.Models
{
    public class ClinicaDBContext:DbContext
    {
        public ClinicaDBContext() : base("DBClinica") { }
        public DbSet<Medico> Medicos { get; set; }
    }
}