using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }

        public ConsultasController()
        {
            ConsultaRepository = new ConsultaRepository();
        }

        [Authorize(Roles = "ADM")]
        [HttpGet]
        public IActionResult ListarConsultas()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                string idTipoUsuario = Convert.ToString(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);
                return Ok(ConsultaRepository.ListarConsultas(id, idTipoUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "ADM")]
        [HttpPost]
        public IActionResult Cadastrar(TSmgConsultas consulta)
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    ctx.TSmgConsultas.Add(consulta);
                    ctx.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "ADM")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    TSmgConsultas consultaProcurado = ctx.TSmgConsultas.Find(id);

                    if (consultaProcurado == null)
                    {
                        return NotFound();
                    }

                    ctx.TSmgConsultas.Remove(consultaProcurado);
                    ctx.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "ADM")]
        [HttpPut]
        public IActionResult Alterar(TSmgConsultas consulta)
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    TSmgConsultas consultaExiste = ctx.TSmgConsultas.Find(consulta.IdConsulta);

                    if (consultaExiste == null)
                    {
                        return NotFound();
                    }

                    consultaExiste.DsDescricao = consulta.DsDescricao;
                    ctx.TSmgConsultas.Update(consultaExiste);
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