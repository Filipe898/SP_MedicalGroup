using System;
using System.Collections.Generic;

namespace Senai.Revisao.Api.Domains
{
    public partial class TSmgPacientes
    {
        public TSmgPacientes()
        {
            TSmgConsultas = new HashSet<TSmgConsultas>();
        }

        public int IdPaciente { get; set; }
        public string NumRg { get; set; }
        public string NumCpf { get; set; }
        public string DsEndereco { get; set; }
        public DateTime DsDataNascimento { get; set; }
        public int? IdUsuario { get; set; }

        public TSmgUsuarios IdUsuarioNavigation { get; set; }
        public ICollection<TSmgConsultas> TSmgConsultas { get; set; }
    }
}
