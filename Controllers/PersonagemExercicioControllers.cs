using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Model;
using RpgApi.Model.Enuns;

namespace RpgApi.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class PersonagemExercicioController : ControllerBase
    {
        //Criação de uma lista já adicionando os objetos dentro.
        private static List<personagem> personagens = new List<personagem>() {
            new personagem() { Id = 1, Nome = "Nate", Pontosvida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnuns.Cavaleiro}, 
            new personagem() { Id = 2, Nome = "Maddy", Pontosvida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnuns.Cavaleiro},
            new personagem() { Id = 3, Nome = "Cinzeiro", Pontosvida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnuns.Clerigo },
            new personagem() { Id = 4, Nome = "Cass", Pontosvida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnuns.Mago },
            new personagem() { Id = 5, Nome = "Rue", Pontosvida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnuns.Cavaleiro },
            new personagem() { Id = 6, Nome = "Lexi", Pontosvida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnuns.Clerigo },
            new personagem() { Id = 7, Nome = "Fez", Pontosvida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnuns.Mago }
        };

        
        [HttpGet("GetByClasse/{classeId}")]
        public IActionResult GetByClasse(int classeId)
        {
            List<personagem> listaFinal =  personagens.FindAll(p => p.Classe == (ClasseEnuns)classeId);

            if(listaFinal.Count == 0)
                return NotFound("Nenhum personagem encontrado.");

            return Ok(listaFinal);
        }

        
        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetbyNome(string nome)
        {
            personagem p = personagens.Find(p => p.Nome == nome);

            if(p == null)            
                return NotFound("nenhum personagem com este nome foi encontrado.");
            
            return Ok(p);

           
        }

       
        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(personagem novoPersonagem)
        {
            if(novoPersonagem.Defesa < 10 || novoPersonagem.Inteligencia > 35)
                return BadRequest("Personagens devem ter defesa a partir de 10 e inteligência maior que 30");

            personagens.Add(novoPersonagem);
            
            return Ok(personagens);
        }


       
        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(personagem novoPersonagem)
        {
            if(novoPersonagem.Classe == ClasseEnuns.Mago && novoPersonagem.Inteligencia < 35)
                return BadRequest("Personagens do tipo Mago não podem ter inteligência menor que 35.");

            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

       
        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {
            List<personagem> listaSemCavaleiro = 
                personagens.FindAll(p => p.Classe != ClasseEnuns.Cavaleiro)
                    .OrderByDescending(ord => ord.Pontosvida) //OrderByDescending using System.Linq                   
                    .ToList();

            return Ok(listaSemCavaleiro);
        }

      
        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            int quantidade = personagens.Count;
            int somaInteligencia = personagens.Sum(p => p.Inteligencia);

        
            string msg = 
                string.Format("A lista contém {0} personagens e o somatório da inteligência é {1}", quantidade, somaInteligencia);            
            return Ok(msg);

            
        }

        
    }
}



