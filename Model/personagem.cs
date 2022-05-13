using RpgApi.Model.Enuns;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace RpgApi.Model
{
    public class personagem 
    {
        public int Id { get; set; }

        public string Nome  { get; set; }

        public int Pontosvida { get; set; }

        public int Forca { get; set; }

        public int Defesa { get; set; }

        public int Inteligencia { get; set; }

        public ClasseEnuns Classe { get; set; }

        public byte[] FotoPersonagem {get; set;}
        
        public int Disputas { get; set;}

        public int Vitorias { get; set;}
        
        public int Derrotas { get; set;}
        
        [JsonIgnore]

        public Usuario Usuario { get; set;}

        [JsonIgnore]

        public Arma Arma { get; set;}

        public List<PersonagemHabilidade> PersonagemHabilidade { get; set;}




    }
}