using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Revisao.Api.Domains;
using Senai.Revisao.Api.interfaces;
using Senai.Revisao.Api.Repositories;

namespace Senai.Revisao.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    return Ok(ctx.TSmgUsuarios.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(TSmgUsuarios usuario)
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    ctx.TSmgUsuarios.Add(usuario);
                    ctx.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Adm")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    TSmgUsuarios usuarioProcurado = ctx.TSmgUsuarios.Find(id);

                    if (usuarioProcurado == null)
                    {
                        return NotFound();
                    }

                    ctx.TSmgUsuarios.Remove(usuarioProcurado);
                    ctx.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Adm")]
        [HttpPut]
        public IActionResult Alterar(TSmgUsuarios usuario)
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    TSmgUsuarios usuarioExiste = ctx.TSmgUsuarios.Find(usuario.IdUsuarios);

                    if (usuarioExiste == null)
                    {
                        return NotFound();
                    }

                    usuarioExiste.DsSenha = usuario.DsSenha;
                    ctx.TSmgUsuarios.Update(usuarioExiste);
                    ctx.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}