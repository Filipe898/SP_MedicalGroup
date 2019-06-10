using Microsoft.EntityFrameworkCore;
using Senai.Revisao.Api.Domains;
using Senai.Revisao.Api.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Revisao.Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Alterar(TSmgUsuarios usuario)
        {
            throw new NotImplementedException();
        }

        public TSmgUsuarios BuscarPorEmailESenha(string email, string senha)
        {
            using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
            {
                TSmgUsuarios usuarioBuscado = ctx.TSmgUsuarios.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.DsEmail== email && x.DsSenha == senha);
                if (usuarioBuscado == null)
                {
                    return null;
                }
                return usuarioBuscado;
            }
        }

        public void Cadastrar(TSmgUsuarios usuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<TSmgUsuarios> Listar()
        {
            throw new NotImplementedException();
        }
    }
}

