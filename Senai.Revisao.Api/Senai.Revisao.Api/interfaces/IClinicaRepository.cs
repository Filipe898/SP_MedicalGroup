using Senai.Revisao.Api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Revisao.Api.interfaces
{
    interface IClinicaRepository
    {
        void Cadastrar(TSmgClinica clinica);

        void Deletar(int id);

        void Alterar(TSmgClinica clinica);

        List<TSmgClinica> Listar();
    }
}
