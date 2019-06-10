using System;
using System.Collections.Generic;

namespace Senai.Revisao.Api.Domains
{
    public partial class TSmgUsuarios
    {
        public TSmgUsuarios()
        {
            TSmgMedicos = new HashSet<TSmgMedicos>();
            TSmgPacientes = new HashSet<TSmgPacientes>();
        }

        public int IdUsuarios { get; set; }
        public string NmUsuario { get; set; }
        public string DsSenha { get; set; }
        public string DsEmail { get; set; }
        public string NumTelefone { get; set; }
        public int? IdClinica { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TSmgClinica IdClinicaNavigation { get; set; }
        public TSmgTipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<TSmgMedicos> TSmgMedicos { get; set; }
        public ICollection<TSmgPacientes> TSmgPacientes { get; set; }
    }
}
