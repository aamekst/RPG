using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RpgApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensController: ControllerBase
    {
        private readonly DataContext _context;

        public PersonagensController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSingle(int id) 
        {
            try
            {
                personagem p = await _context.personagens
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                return Ok (p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  

        [HttpGet ("GetAll")]

        public async Task<IActionResult> Get()
        {
            try
            {
               List<personagem> lista = await _context.personagens.ToListAsync();
                return Ok (lista);
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
               if(novoPersonagem.Pontosvida > 100)
               {
                   throw new Exception ("Pontos de vida não poder ser maior que 100");
               }
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
               if(novoPersonagem.Pontosvida > 100)
               {
                   throw new Exception ("Pontos de vida não poder ser maior que 100");
               }
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
        
    }

}

