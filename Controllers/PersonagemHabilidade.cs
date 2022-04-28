using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RpgApi.Model.Enuns;
using RpgApi.Model;
using RpgApi.Utils;
using RpgApi.Data;
using System;

namespace RpgApi.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class PersonagemHabilidadeController : ControllerBase
    { //codificação geral dentro da controller

    private readonly DataContext _context;

    public PersonagemHabilidadeController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade NovoPersonagemHabilidade)
    {
        try{
            
            personagem personagem = await _context.personagens
            .Include(p => p.Arma)
            .Include(p => p.PersonagemHabilidade).ThenInclude(ps => ps.Habilidade)
            .FirstOrDefaultAsync(p => p.Id == NovoPersonagemHabilidade.PersonagemId);

            Habilidade habilidade = await _context.Habilidades 
             .FirstOrDefaultAsync(h => h.Id == NovoPersonagemHabilidade.HabilidadeId);
        
        if (personagem == null)
            throw new System.Exception("Personagem não encontrada para o Id informado");


        Habilidade habilidades = await _context.Habilidades
            .FirstOrDefaultAsync(h => h.Id == NovoPersonagemHabilidade.HabilidadeId);

        if (habilidades == null)
            throw new System.Exception("Habilidade não encontrada para o Id informado");


        PersonagemHabilidade ph = new PersonagemHabilidade();
        ph.personagem = personagem;
        ph.Habilidade = habilidade;
        await _context.PersonagemHabilidades.AddAsync(ph);
        int linhaAfetadas = await _context.SaveChangesAsync();

        return Ok(linhaAfetadas);

        }

        catch(System.Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpGet("id")] //Busca pelo Id

    public async Task<IActionResult> GetSingle(int id)
    {
    
        try
        {
            personagem p = await _context.personagens
            .Include(ar => ar.Arma)// Inclui na propriedade arma do objeto
            .Include(ph => ph.PersonagemHabilidade)
                .ThenInclude(h => h.Habilidade)//Inclui na lista de personagens de p
            .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

         return Ok(p);

        }
        catch (System.Exception ex)
        { 
            return BadRequest(ex.Message);

        }

    }

    
    }

}