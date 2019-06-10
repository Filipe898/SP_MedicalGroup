using System;
using System.Collections.Generic;

namespace Senai.Revisao.Api.Domains
{
    public partial class TSmgConsultas
    {
        public int IdConsulta { get; set; }
        public string DsDescricao { get; set; }
        public DateTime DatDataConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public int? IdStatus { get; set; }

        public TSmgMedicos IdMedicoNavigation { get; set; }
        public TSmgPacientes IdPacienteNavigation { get; set; }
        public TSmgStatus IdStatusNavigation { get; set; }
    }
}
