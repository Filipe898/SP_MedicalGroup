using System;
using System.Collections.Generic;

namespace Senai.Revisao.Api.Domains
{
    public partial class TSmgClinica
    {
        public TSmgClinica()
        {
            TSmgUsuarios = new HashSet<TSmgUsuarios>();
        }

        public int IdClinica { get; set; }
        public string NmClinica { get; set; }
        public string DsRazaoSocial { get; set; }
        public string NumCnpj { get; set; }
        public string DsEndereco { get; set; }
        public string DsHorarioAtendimento { get; set; }

        public ICollection<TSmgUsuarios> TSmgUsuarios { get; set; }
    }
}
