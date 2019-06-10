using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Revisao.Api.Domains;

namespace Senai.Revisao.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {

        [Authorize(Roles = "Adm")]
        [HttpGet]
        public IActionResult ListarClinicas()
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    return Ok(ctx.TSmgClinica.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private IActionResult Ok(object p)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Adm")]
        [HttpPost]
        public IActionResult Cadastar (TSmgClinica clinica)
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    ctx.TSmgClinica.Add(clinica);
                    ctx.SaveChanges();
                }
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        //cadastrar consulta

        [Authorize(Roles = "Adm")]
        [HttpPut]
        public IActionResult Alterar(TSmgClinica clinica)
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    TSmgClinica clinicaExiste = ctx.TSmgClinica.Find(clinica.IdClinica);

                    if(clinicaExiste == null)
                    {
                        return NotFound();
                    }

                    clinicaExiste.NmClinica = clinica.NmClinica;
                    ctx.TSmgClinica.Update(clinicaExiste);
                    ctx.SaveChanges();
                }
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        // atualizar consultas

        [Authorize(Roles = "Adm")]
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            try
            {
                using (SP_Medical_Group_TESTE1Context ctx = new SP_Medical_Group_TESTE1Context())
                {
                    TSmgClinica clinicaProcurado = ctx.TSmgClinica.Find(id);

                    if(clinicaProcurado == null)
                    {
                        return NotFound();
                    }

                    ctx.TSmgClinica.Remove(clinicaProcurado);
                    ctx.SaveChanges();
                }
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            // deletar 
        }
    }
}