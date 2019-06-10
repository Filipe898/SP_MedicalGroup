using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Revisao.Api.Domains;
using Senai.Revisao.Api.interfaces;
using Senai.Revisao.Api.Repositories;
using Senai.Revisao.Api.ViewModel;

namespace Senai.Revisao.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                TSmgUsuarios usuario = UsuarioRepository.BuscarPorEmailESenha(login.email, login.senha);

                if (usuario == null)
                {
                    return NotFound();
                }

                var claims = new[]
                {
                   new Claim(JwtRegisteredClaimNames.Email, usuario.DsEmail),
                   new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuarios.ToString()),
                   new Claim(ClaimTypes.Role, usuario.IdTipoUsuarioNavigation.NmUsuario),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmg-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "spmg",
                    audience: "spmg",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}