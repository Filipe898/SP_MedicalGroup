using System;
using System.Collections.Generic;

namespace Senai.Revisao.Api.Domains
{
    public partial class TSmgStatus
    {
        public TSmgStatus()
        {
            TSmgConsultas = new HashSet<TSmgConsultas>();
        }

        public int IdStatus { get; set; }
        public string DsStatus { get; set; }

        public ICollection<TSmgConsultas> TSmgConsultas { get; set; }
    }
}
