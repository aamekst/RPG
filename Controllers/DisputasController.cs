using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {
        
        private readonly DataContext _context;

        public DisputasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsync(Disputa d)
        {
            try
            {
                personagem atacante = await _context.personagens
                     .Include(p => p.Arma)
                     .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                     personagem oponente = await _context.personagens
                     .Include(p => p.Arma)
                     .FirstOrDefaultAsync(p => p.Id ==d.OponenteId);


                    int dano = atacante.Arma.Dano + (new Random().Next(atacante.Forca));

                    dano = dano - new Random().Next(oponente.Defesa);

                    if (dano > 0)
                    oponente.Pontosvida = oponente.Pontosvida - (int)dano;
                    if (oponente.Pontosvida <= 0)
                    d.Narracao = $"{oponente.Nome} foi derrotado";

                    _context.personagens.Update(oponente);
                    await _context.SaveChangesAsync();

                     
                  StringBuilder dados = new StringBuilder();
                  dados.AppendFormat("Atacante: {0}", atacante.Nome);
                  dados.AppendFormat("Oponente: {0}", oponente.Nome);
                  dados.AppendFormat("Pontos de vida do Atacante: {0}", atacante.Pontosvida);
                  dados.AppendFormat("Pontos de voida do Oponente: {0}", oponente.Pontosvida);
                  dados.AppendFormat("Arma Utilizada: {0}", atacante.Arma.Nome);
                  dados.AppendFormat("Dano: {0}", dano);


                  d.Narracao += dados.ToString();
                  d.DataDisputa = DateTime.Now;
                  _context.Disputas.Add(d);
                  _context.SaveChanges();










                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

     

































    }
}
