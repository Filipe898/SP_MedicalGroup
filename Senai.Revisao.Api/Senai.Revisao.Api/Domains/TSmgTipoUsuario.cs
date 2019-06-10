using System;
using System.Collections.Generic;

namespace Senai.Revisao.Api.Domains
{
    public partial class TSmgTipoUsuario
    {
        public TSmgTipoUsuario()
        {
            TSmgUsuarios = new HashSet<TSmgUsuarios>();
        }

        public int IdTipoUsuario { get; set; }
        public string NmUsuario { get; set; }

        public ICollection<TSmgUsuarios> TSmgUsuarios { get; set; }
    }
}
