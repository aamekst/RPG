using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RpgApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;



namespace RpgApi.Controllers
{
    [Authorize(Roles = "Jogador, Admin")]
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public PersonagensController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                personagem p = await _context.personagens
                    .Include(ar => ar.Arma)
                    .Include(us => us.Usuario)
                    .Include(ph => ph.PersonagemHabilidade)
                        .ThenInclude(h => h.Habilidade)
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<personagem> lista = await _context.personagens.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(personagem novoPersonagem)
        {
            try
            {
                if (novoPersonagem.Pontosvida > 100)
                {
                    throw new Exception("Pontos de vida não poder ser maior que 100");
                }

                //int usuarioId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstOrDefault(ClaimTypes.NameIdentifier));
                novoPersonagem.Usuario = _context.usuarios.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());

                _context.personagens.Update(novoPersonagem);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(personagem novoPersonagem)
        {
            try
            {
                if (novoPersonagem.Pontosvida > 100)
                {
                    throw new Exception("Pontos de vida não poder ser maior que 100");
                }

                //int usuarioId = int.Parse(_httpContextAccessor.HttpContext.User.FirstOrDefault(ClaimTypes.NameIdentifier));


                novoPersonagem.Usuario = _context.usuarios.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());

                await _context.personagens.AddAsync(novoPersonagem);
                await _context.SaveChangesAsync();

                return Ok(novoPersonagem.Id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                personagem pRemover = await _context.personagens
                 .FirstOrDefaultAsync(p => p.Id == id);

                _context.personagens.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeletePersonagemHabilidade")]
        public async Task<IActionResult> DeleteAsync(PersonagemHabilidade ph)
        {
            try
            {
                PersonagemHabilidade phRemover = await _context.PersonagemHabilidades
                .FirstOrDefaultAsync(phBusca => phBusca.PersonagemId == ph.PersonagemId
                && phBusca.HabilidadeId == ph.HabilidadeId);
                if (phRemover == null)
                    throw new System.Exception("Personagem ou Habilidade não encontrados");
                _context.PersonagemHabilidades.Remove(phRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetByUser")]

        public async Task<IActionResult> GetByUserAsync()
        {
            try
            {
                int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                List<personagem> list = await _context.personagens
                    .Where(u => u.Usuario.Id == id).ToListAsync();

                return Ok(list);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        private int ObterUsuarioId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        private string ObterPerfilUsuario()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }

        [HttpGet("GetByPerfil")]
        public async Task<IActionResult> GetByPerfilAsync()
        {
            try
            {
                List<personagem> lista = new List<personagem>();

                if (ObterPerfilUsuario() == "Admin")
                {
                    lista = await _context.personagens.ToListAsync();
                }
                else
                {
                    lista = await _context.personagens
                            .Where(p => p.Usuario.Id == ObterUsuarioId()).ToListAsync();
                }
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("RestaurarPontosVida")]
        public async Task<IActionResult> RestaurarPontosVidaAsync(personagem p)
        {
            try
            {
                int linhasAfetadas = 0;
                personagem pEncontrado =
                await _context.personagens.FirstOrDefaultAsync(pBusca => pBusca.Id == p.Id);
                pEncontrado.Pontosvida = 100;

                bool atualizou = await TryUpdateModelAsync<personagem>(pEncontrado, "p",
                 pAtualizar => pAtualizar.Pontosvida);
                // EF vai detectar e atualizar apenas as colunas que foram alteradas.
                if (atualizou)
                    linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("AtualizarFoto")]
        public async Task<IActionResult> AtualizarFoto(personagem p)

        {
            try
            {
                personagem personagem = await _context.personagens
                    .FirstOrDefaultAsync(x => x.Id == p.Id);
                personagem.FotoPersonagem = p.FotoPersonagem;
                var attach = _context.Attach(personagem);
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.FotoPersonagem).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);


            }
            catch (System.Exception ex)
            { return BadRequest(ex.Message); }
        }



        [HttpPut("ZerarRanking")]
        public async Task<IActionResult> ZerarRankingAsync(personagem p)
        {
            try
            {
                personagem pEncontrado =
                    await _context.personagens.FirstOrDefaultAsync(pBusca => pBusca.Id == p.Id);

                pEncontrado.Disputas = 0;
                pEncontrado.Vitorias = 0;
                pEncontrado.Derrotas = 0;
                int linhasAfetadas = 0;

                bool atualizou = await TryUpdateModelAsync<personagem>(pEncontrado, "p", pAtualizar => pAtualizar.Disputas, pAtualizar => pAtualizar.Vitorias, pAtualizar => pAtualizar.Derrotas); // EF vai detectar e atualizar apenas as colunas que foram alteradas.
                if (atualizou)
                    linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("ZerarRankingRestaurarVidas")]
        public async Task<IActionResult> ZerarRankingRestaurarVidasAsync()
        {
            try
            {
                List<personagem> lista = await _context.personagens.ToListAsync();
                foreach (personagem p in lista)
                {
                    await ZerarRankingAsync(p);
                    await RestaurarPontosVidaAsync(p);
                }
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


























    }



}




