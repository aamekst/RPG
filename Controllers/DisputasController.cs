using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

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

        [HttpPost("Habilidade")]
    public async Task<IActionResult> AtaqueComHabilidadesAsync(Disputa d)
    {
        try{
            //programação dos proximos passos aqui
            personagem atacante = await _context.personagens
            .Include(p => p.PersonagemHabilidade).ThenInclude(ph => ph.Habilidade)
            .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

            personagem oponente = await _context.personagens
            .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

            PersonagemHabilidade ph = await _context.PersonagemHabilidades
            .Include(p => p.Habilidade)
            .FirstOrDefaultAsync(phBusca => phBusca.HabilidadeId == d.HabilidadeId);
            
            if (ph == null)
            d.Narracao = $"{atacante.Nome} não possui está habilidade";
            
            else
            {
                int dano = ph.Habilidade.Dano + (new Random().Next(atacante.Inteligencia));
                dano = dano - new Random().Next(oponente.Defesa);



                if(dano > 0)
                oponente.Pontosvida = oponente.Pontosvida - dano;

                if(oponente.Pontosvida <=0)
                d.Narracao += $"{oponente.Nome} foi derrotado!";

                _context.personagens.Update(oponente);
                await _context.SaveChangesAsync();

                 StringBuilder dados = new StringBuilder();
                dados.AppendFormat(" Atacante: {0}. ", atacante.Nome);
                dados.AppendFormat(" Oponente: {0}. ", oponente.Nome);
                dados.AppendFormat(" Pontos de vida do atacante: {0}. ", atacante.Pontosvida);
                dados.AppendFormat(" Pontos de vida do oponente: {0}. ", oponente.Pontosvida);
                dados.AppendFormat(" Arma utilizada: {0}", ph.Habilidade.Nome);
                dados.AppendFormat(" Dano: {0}", dano);
                
                d.Narracao += dados.ToString();
                d.DataDisputa = DateTime.Now;
                _context.Disputas.Add(d);
                _context.SaveChanges();
 
            }

            return Ok(d);
        }
        catch(System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }    


    [HttpGet("PersonagemRandom")]  

    public async Task<IActionResult> Sorteio()
    {
        List<personagem> personagens =
        await _context.personagens.ToListAsync();
        
        //Sorteio com numero da quantidade de personagens
        int sorteio = new Random().Next(personagens.Count);

        //busca na lista pelo indice  sorteado (Não é o Id)
        personagem p = personagens[sorteio];

        string msg =
        string.Format("Nº Sorteado {0}. Personagem: {1}", sorteio, p.Nome);

        return Ok(msg);
        
    }  


    [HttpGet("DisputaEmGrupo")]

    public async Task<IActionResult> DisputaEmGrupo (Disputa d)

    {
        try
        {
            //Busca na base dos personagens informados no parametro incluindo Armas e Habilidades
            List<personagem> personagens = await _context.personagens
            .Include(p => p.Arma)
            .Include(p => p.PersonagemHabilidade).ThenInclude(ph => ph.Habilidade)
            .Where(p => d.ListaIdPersonagens.Contains(p.Id)).ToListAsync();


            //Contagem de personagens vivos na lista obtida do banco de dados 
             int qtdPersonagensVivos = personagens.FindAll(p => p.Pontosvida > 0).Count;



             //Enquanto houver mais de um personagem vivo haverá disputa
             while (qtdPersonagensVivos > 1)
             {
                 //ATENÇÃO: todas as etapas a seguir dever ficar aqui dentro do while
              //Seleciona personagens com pontos vida positivos e depois faz sorteio.


             List<personagem> atacantes = personagens.Where(p => p.Pontosvida > 0).ToList();
             personagem atacante = atacantes[new Random().Next(atacantes.Count)];
             d.AtacanteId = atacante.Id;


            //Seleciona personagens com pontos vida positivos, exceto o atacante escolhido e depois faz sorteio.
            List<personagem> oponentes = personagens.Where(p => p.Id != atacante.Id && p.Pontosvida > 0).ToList();
            personagem oponente = oponentes[new Random().Next(oponentes.Count)];
            d.OponenteId = oponente.Id;


            //declara e redefine a cada passagem do while o valor das variáveis que serão usadas.
           int dano = 0;
           string ataqueUsado = string.Empty;
           string resultado = string.Empty;

           //Sorteia entre O e 1: O é umataque com arma e 1 é um ataque com habilidades
            bool ataqueUsaArma = (new Random().Next(1) == 0);

            if (ataqueUsaArma && atacante.Arma != null)
            {
                //programação do ataque com arma
               //Sorteio da Força
               
                dano = atacante.Arma.Dano + (new Random().Next(atacante.Forca));
                dano = dano - new Random().Next(oponente.Defesa); //Sorteio da defesa
                ataqueUsado = atacante.Arma.Nome;

                if (dano > 0)
                oponente.Pontosvida = oponente.Pontosvida - (int)dano;

                //formata a mensagem 

                resultado =
                string.Format("{0} atacou {1} usado {2} com dano {3}." , atacante.Nome, oponente.Nome, ataqueUsado, dano);
                d.Narracao += resultado; // Concatena o resultado com as narrações existentes.
                d. Resultados .Add(resultado);//Adiciona o resulta atual na lista de resultados.



            } 

           else if (atacante.PersonagemHabilidade.Count != 0)//Verifica se o personagem tem habilidades
            {
            //Programação do ataque com habilidade
           
                //Programação do ataque com habilidade

                //Realiza o sorteio entre as habilidade existentes e na linha seguinte a seleciona.

                int sorteioHabilidadeld = new Random().Next(atacante. PersonagemHabilidade.Count);
                Habilidade habilidadeEscolhida = atacante.PersonagemHabilidade [sorteioHabilidadeld].Habilidade;
                ataqueUsado = habilidadeEscolhida.Nome;


                //Sorteio da inteligência somada ao dano

                dano = habilidadeEscolhida.Dano + (new Random().Next(atacante. Inteligencia));
                dano = dano - new Random() .Next (oponente.Defesa);//Sorteio da defesa.

                if (dano > 0)

                oponente.Pontosvida = oponente.Pontosvida - (int)dano;


                resultado = 
                string.Format("{0} atacou {1} usado {2} com dano {3}." , atacante.Nome, oponente.Nome, ataqueUsado, dano);

                d.Narracao += resultado;
                d. Resultados .Add(resultado);


                        }
        //ATENÇÃO aqui ficará a programação da verificação do ataque usado e verificação se existen mais de um personagem vivo
           if (!string.IsNullOrEmpty(ataqueUsado))

                { //Incrementando os dados dos combates
                    atacante.Vitorias++;
                    oponente.Vitorias++;
                    atacante.Disputas++;
                    oponente.Disputas++;

                    d.Id = 0;//Zera o Id para poder salvar os dados de disputa sem erro de chave.
                    d.DataDisputa = DateTime.Now;
                    _context.Disputas.Add(d);
                    await _context.SaveChangesAsync();
                }

                qtdPersonagensVivos = personagens.FindAll(p => p.Pontosvida > 0).Count;

                if(qtdPersonagensVivos == 1)//Havendo só um personagem vivo, existe um CAMPEÃO!
                {
                    string resultadoFinal =
                     $"{atacante.Nome.ToUpper()}é CAMPEÃO com {atacante.Pontosvida} pontos de vida!";
                    
                    d.Narracao += resultadoFinal;//Concatena o resultado final com as demais narrações.
                    d.Resultados.Add(resultadoFinal);//Concaten o resultado final com os demais resultados.

                    break;//break vai parar o while
                }

             }//Fim do while

             //Código após o fechamento do while. Atualizará os pontos de vida, disputas, vitórias e derrotas de todos os personagens ao final das batalhas
             _context.personagens.UpdateRange(personagens);
             await _context.SaveChangesAsync();

             return Ok (d);//retorna os dados da disputa 
        }
          catch(System.Exception ex)
        {
          return BadRequest(ex.Message);
        }
    }

      [HttpDelete("ApagarDisputas")] 
        public async Task<IActionResult> DeleteAsync()
        {
            try
            {
              List<Disputa> disputas = await _context.Disputas.ToListAsync();

              _context.Disputas.RemoveRange(disputas);
              await _context.SaveChangesAsync(); 

              return Ok("Disputas apagadas"); 
            }
            catch (System.Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }
  

    [HttpGet("Listar")]


        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Disputa> disputas = await _context.Disputas.ToListAsync(); 
                return Ok(disputas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

     

































    }
}
