using System;
using System.Collections.Generic;

namespace Senai.Revisao.Api.Domains
{
    public partial class TSmgMedicos
    {
        public TSmgMedicos()
        {
            TSmgConsultas = new HashSet<TSmgConsultas>();
        }

        public int IdMedico { get; set; }
        public string NumCrm { get; set; }
        public int? IdUsuarios { get; set; }
        public int? IdEspecialidade { get; set; }

        public TSmgEspecialidades IdEspecialidadeNavigation { get; set; }
        public TSmgUsuarios IdUsuariosNavigation { get; set; }
        public ICollection<TSmgConsultas> TSmgConsultas { get; set; }
    }
}
