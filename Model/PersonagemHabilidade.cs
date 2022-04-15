namespace RpgApi.Model
{
    public class PersonagemHabilidade
    {
        public int PersonagemId { get; set; }
        public personagem personagem { get; set; }
        public int HabilidadeId { get; set; }
        public Habilidade Habilidade { get; set; }
    }
}