using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Model;
using RpgApi.Model.Enuns;
using RpgApi.Utils;



namespace RpgApi.Controllers
{

    [ApiController]
    [Route("[Controller]")]

    public class UsuarioController: ControllerBase
    {
        private readonly DataContext _context;

        public UsuarioController(DataContext context)
        {
            _context = context;
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

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.usuarios
                   .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia
                    .VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    usuario.DataAcesso = System.DateTime.Now;
                    _context.usuarios.Update(usuario);
                    await _context.SaveChangesAsync(); 
                    
                    return Ok(usuario.Id);
                }
            }
            catch (System.Exception ex)
            { 
                return BadRequest(ex.Message); 
            }
        }


    }
}