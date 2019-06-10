using System;
using System.Collections.Generic;

namespace Senai.Revisao.Api.Domains
{
    public partial class TSmgEspecialidades
    {
        public TSmgEspecialidades()
        {
            TSmgMedicos = new HashSet<TSmgMedicos>();
        }

        public int IdEspecialidade { get; set; }
        public string NmEspecialidade { get; set; }

        public ICollection<TSmgMedicos> TSmgMedicos { get; set; }
    }
}
