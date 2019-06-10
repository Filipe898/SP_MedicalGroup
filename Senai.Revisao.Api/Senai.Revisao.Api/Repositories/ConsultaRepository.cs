using Senai.Revisao.Api.Domains;
using Senai.Revisao.Api.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Revisao.Api.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {

        public void Alterar(TSmgConsultas consulta)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TSmgConsultas consulta)
        {
            throw new NotImplementedException();
        }

        public void TSmgCadastrar(TSmgConsultas consulta)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<TSmgConsultas> ListarConsultas(int id, string idTipoUsuario)
        {
            using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
            {
                if (idTipoUsuario == "Adm")
                {
                    ctx.TSmgConsultas.ToList();

                    return ctx.TSmgConsultas.ToList();
                }

                if (idTipoUsuario == "Medico")
                {
                    TSmgMedicos medico;
                    medico = ctx.TSmgMedicos.FirstOrDefault(x => x.IdUsuarios == id);

                    return ctx.TSmgConsultas.Where(x => x.IdMedico == medico.IdMedico).ToList();
                }

                if (idTipoUsuario == "Paciente")
                {
                    TSmgStatus status;
                    status = ctx.TSmgStatus.FirstOrDefault(x => x.IdStatus == id);

                    return ctx.TSmgConsultas.Where(x => x.IdStatus == status.IdStatus).ToList();
                }

                return null;
            }
        }

        List<TSmgConsultas> IConsultaRepository.ListarConsultas(int id, string idTipoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
