using Microsoft.EntityFrameworkCore;
using RpgApi.Model;
using RpgApi.Model.Enuns;
using RpgApi.Utils;

namespace RpgApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<personagem> personagens { get; set;}
        public DbSet<Arma> Armas { get; set; }
        public DbSet<Disputa> Disputas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<PersonagemHabilidade> PersonagemHabilidades { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity <personagem>().HasData //define dados 
            (
                new personagem() { Id = 1, Nome = "Nathaniel", Pontosvida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnuns.Cavaleiro}, 
                new personagem() { Id = 2, Nome = "Maddy", Pontosvida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnuns.Cavaleiro},
                new personagem() { Id = 3, Nome = "Cinzeiro", Pontosvida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnuns.Clerigo },
                new personagem() { Id = 4, Nome = "Cass", Pontosvida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnuns.Mago },
                new personagem() { Id = 5, Nome = "Rue", Pontosvida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnuns.Cavaleiro },
                new personagem() { Id = 6, Nome = "Lexi", Pontosvida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnuns.Clerigo },
                new personagem() { Id = 7, Nome = "Fez", Pontosvida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnuns.Mago }


            );

                Usuario user = new Usuario();
                Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
                user.Id = 1;
                user.Username = "UsuarioAdmin";
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;

                Usuario user2 = new Usuario();
                Criptografia.CriarPasswordHash("564790", out byte[] hash2, out byte[] salt2);
                user2.Id = 2;
                user2.Username = "Usuariomaster";
                user2.PasswordString = string.Empty;
                user2.PasswordHash = hash2;
                user2.PasswordSalt = salt2;

                Usuario user3 = new Usuario();
                Criptografia.CriarPasswordHash("564790", out byte[] hash3, out byte[] salt3);
                user3.Id = 2;
                user3.Username = "ana";
                user3.PasswordString = string.Empty;
                user3.PasswordHash = hash3;
                user3.PasswordSalt = salt3;

               modelBuilder.Entity<Usuario>().HasData(user);

               modelBuilder.Entity<Arma>().HasData
            (                  
                new Arma() { Id = 1, Nome="Arco e Flecha", Dano=35,PersonagemId=1 }, 
                new Arma() { Id = 2, Nome="Espada", Dano=33,PersonagemId=2},     
                new Arma() { Id = 3, Nome="Machado", Dano=31,PersonagemId=3 }                
            );

            modelBuilder.Entity<PersonagemHabilidade>()
                .HasKey(ph => new {ph.PersonagemId, ph.HabilidadeId });

    

            modelBuilder.Entity<PersonagemHabilidade>().HasData
            (                  
                new PersonagemHabilidade() { PersonagemId = 1, HabilidadeId =1 }, 
                new PersonagemHabilidade() { PersonagemId = 1, HabilidadeId =2 }, 
                new PersonagemHabilidade() { PersonagemId = 2, HabilidadeId =2 }, 
                new PersonagemHabilidade() { PersonagemId = 3, HabilidadeId =2 }, 
                new PersonagemHabilidade() { PersonagemId = 3, HabilidadeId =3 }, 
                new PersonagemHabilidade() { PersonagemId = 4, HabilidadeId =3 }, 
                new PersonagemHabilidade() { PersonagemId = 5, HabilidadeId =1 }, 
                new PersonagemHabilidade() { PersonagemId = 6, HabilidadeId =2 }, 
                new PersonagemHabilidade() { PersonagemId = 7, HabilidadeId =3 }                               
            );

            modelBuilder.Entity<Habilidade>().HasData
            (
                new Habilidade(){Id=1, Nome="Adormecer", Dano=39},
                new Habilidade(){Id=2, Nome="Congelar", Dano=41},
                new Habilidade(){Id=3, Nome="Hipnotizar", Dano=37}
            );

            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Jogador");
        

        }

    }
}