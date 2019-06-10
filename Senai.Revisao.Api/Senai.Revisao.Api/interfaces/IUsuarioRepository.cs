using Senai.Revisao.Api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Revisao.Api.interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(TSmgUsuarios usuario);

        List<TSmgUsuarios> Listar();

        TSmgUsuarios BuscarPorEmailESenha(string email, string senha);

        void Deletar(int id);

        void Alterar(TSmgUsuarios usuario);
    }

}
