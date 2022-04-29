using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RpgApi.Model;
using System.Collections.Generic;
using System.Linq;
using RpgApi.Utils;
using RpgApi.Model.Enuns;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Authorization;



namespace RpgApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]

    public class UsuarioController: ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UsuarioController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        private async Task<bool> UsuarioExistente(string username)
        {
            if (await _context.usuarios.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;

            }
            return false;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.Username))
                    throw new System.Exception("Nome de usuário já existe");

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.usuarios.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuarios = await _context.usuarios
                   .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuarios == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia
                    .VerificarPasswordHash(credenciais.PasswordString, usuarios.PasswordHash, usuarios.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    usuarios.DataAcesso = System.DateTime.Now;
                    _context.usuarios.Update(usuarios);
                    await _context.SaveChangesAsync(); 
                    
                    return Ok(CriarToken(usuarios));
                }
            }
            catch (System.Exception ex)
            { 
                return BadRequest(ex.Message); 
            }
        }


        [HttpGet ("GetAll")]
        
        public async Task<IActionResult> GetAll()
        {
            try
            {
               List<Usuario> lista = await _context.usuarios.ToListAsync();
                return Ok (lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  


           private string CriarToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Username)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration.GetSection("ConfiguracaoToken:Chave").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


















    }
}