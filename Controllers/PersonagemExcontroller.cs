using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RpgApi.Model;
using RpgApi.Model.Enuns;
using System.Linq;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route ("[Controller]")]

    public class PersonagemExController : ControllerBase
    {
        private static List<personagem> personagens = new List<personagem>()
        {
            new personagem() { Id = 1, Nome = "Nathaniel", Pontosvida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnuns.Cavaleiro}, 
            new personagem() { Id = 2, Nome = "Maddy", Pontosvida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnuns.Cavaleiro},
            new personagem() { Id = 3, Nome = "Cinzeiro", Pontosvida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnuns.Clerigo },
            new personagem() { Id = 4, Nome = "Cass", Pontosvida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnuns.Mago },
            new personagem() { Id = 5, Nome = "Rue", Pontosvida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnuns.Cavaleiro },
            new personagem() { Id = 6, Nome = "Lexi", Pontosvida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnuns.Clerigo },
            new personagem() { Id = 7, Nome = "Fez", Pontosvida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnuns.Mago }
        };


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(personagens);
        }

        public IActionResult GetFirts()
        {
            personagem p = personagens[0];
            return Ok(p);
        }
        
       [HttpGet("{Id}")]

        public IActionResult GetSingle(int Id)
        {
            return Ok(personagens.FirstOrDefault (x => x.Id == Id));
        }

        [HttpPost]
        public IActionResult Addpersonagem (personagem novo)
        {
            if(novo.Inteligencia == 0)
                return BadRequest ("inteligência não pode ter valor igual a 0.");
                
            personagens.Add(novo);
            return Ok (personagens);
        }

        [HttpPut]

        public IActionResult UpdatePersosnagem (personagem p)
        {
            personagem personagemAlt = personagens.Find(pe => pe. Id == p.Id);
            personagemAlt.Nome = p.Nome;
            personagemAlt.Pontosvida = p.Pontosvida;
            personagemAlt.Forca = p.Forca;
            personagemAlt.Defesa = p.Defesa;
            personagemAlt.Inteligencia = p.Inteligencia;
            personagemAlt.Classe = p.Classe;   

            return Ok(personagens);

        }
        [HttpDelete("{Id}")]

        public IActionResult Delete(int Id)
        {
            personagens.RemoveAll(pers => pers.Id == Id);

            return Ok(personagens);

        }

  

     

















        }
        
    }