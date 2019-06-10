using Senai.Revisao.Api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Revisao.Api.interfaces
{
    interface IConsultaRepository
    {
        void Cadastrar(TSmgConsultas consulta);

        List<TSmgConsultas> ListarConsultas(int id, string idTipoUsuario);

        void Deletar(int id);

        void Alterar(TSmgConsultas consulta);
    }
}
