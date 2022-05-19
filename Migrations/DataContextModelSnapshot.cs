﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RpgApi.Data;

namespace RpgApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RpgApi.Model.Arma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dano")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonagemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonagemId")
                        .IsUnique();

                    b.ToTable("Armas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dano = 35,
                            Nome = "Arco e Flecha",
                            PersonagemId = 1
                        },
                        new
                        {
                            Id = 2,
                            Dano = 33,
                            Nome = "Espada",
                            PersonagemId = 2
                        },
                        new
                        {
                            Id = 3,
                            Dano = 31,
                            Nome = "Machado",
                            PersonagemId = 3
                        });
                });

            modelBuilder.Entity("RpgApi.Model.Disputa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AtacanteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataDisputa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Narracao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OponenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Disputas");
                });

            modelBuilder.Entity("RpgApi.Model.Enuns.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Perfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Jogador");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = new byte[] { 63, 108, 104, 168, 82, 133, 116, 188, 5, 82, 78, 53, 187, 63, 76, 107, 241, 13, 110, 105, 231, 147, 84, 83, 71, 104, 92, 98, 223, 54, 188, 72, 56, 197, 69, 144, 246, 51, 96, 82, 152, 148, 10, 222, 106, 55, 141, 103, 202, 128, 131, 123, 130, 231, 63, 71, 245, 131, 134, 29, 134, 168, 178, 88 },
                            PasswordSalt = new byte[] { 190, 165, 180, 163, 108, 81, 228, 62, 173, 64, 226, 230, 112, 82, 104, 23, 5, 205, 103, 69, 68, 235, 224, 162, 52, 18, 40, 27, 150, 1, 254, 232, 0, 166, 37, 204, 37, 193, 155, 121, 21, 188, 195, 65, 5, 84, 145, 30, 44, 36, 224, 74, 251, 26, 158, 133, 188, 122, 230, 59, 55, 121, 93, 246, 31, 97, 149, 33, 176, 76, 150, 197, 75, 64, 196, 104, 85, 116, 163, 59, 175, 168, 206, 16, 85, 198, 240, 54, 239, 28, 231, 132, 216, 86, 83, 218, 16, 60, 145, 71, 83, 108, 158, 34, 89, 42, 58, 18, 118, 63, 195, 227, 52, 49, 27, 189, 169, 197, 137, 14, 253, 75, 65, 166, 23, 73, 207, 214 },
                            Username = "UsuarioAdmin"
                        });
                });

            modelBuilder.Entity("RpgApi.Model.Habilidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dano")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Habilidades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dano = 39,
                            Nome = "Adormecer"
                        },
                        new
                        {
                            Id = 2,
                            Dano = 41,
                            Nome = "Congelar"
                        },
                        new
                        {
                            Id = 3,
                            Dano = 37,
                            Nome = "Hipnotizar"
                        });
                });

            modelBuilder.Entity("RpgApi.Model.PersonagemHabilidade", b =>
                {
                    b.Property<int>("PersonagemId")
                        .HasColumnType("int");

                    b.Property<int>("HabilidadeId")
                        .HasColumnType("int");

                    b.HasKey("PersonagemId", "HabilidadeId");

                    b.HasIndex("HabilidadeId");

                    b.ToTable("PersonagemHabilidades");

                    b.HasData(
                        new
                        {
                            PersonagemId = 1,
                            HabilidadeId = 1
                        },
                        new
                        {
                            PersonagemId = 1,
                            HabilidadeId = 2
                        },
                        new
                        {
                            PersonagemId = 2,
                            HabilidadeId = 2
                        },
                        new
                        {
                            PersonagemId = 3,
                            HabilidadeId = 2
                        },
                        new
                        {
                            PersonagemId = 3,
                            HabilidadeId = 3
                        },
                        new
                        {
                            PersonagemId = 4,
                            HabilidadeId = 3
                        },
                        new
                        {
                            PersonagemId = 5,
                            HabilidadeId = 1
                        },
                        new
                        {
                            PersonagemId = 6,
                            HabilidadeId = 2
                        },
                        new
                        {
                            PersonagemId = 7,
                            HabilidadeId = 3
                        });
                });

            modelBuilder.Entity("RpgApi.Model.personagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Classe")
                        .HasColumnType("int");

                    b.Property<int>("Defesa")
                        .HasColumnType("int");

                    b.Property<int>("Derrotas")
                        .HasColumnType("int");

                    b.Property<int>("Disputas")
                        .HasColumnType("int");

                    b.Property<int>("Forca")
                        .HasColumnType("int");

                    b.Property<byte[]>("FotoPersonagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Inteligencia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pontosvida")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("Vitorias")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("personagens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Classe = 1,
                            Defesa = 23,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 17,
                            Inteligencia = 33,
                            Nome = "Nathaniel",
                            Pontosvida = 100,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 2,
                            Classe = 1,
                            Defesa = 25,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 15,
                            Inteligencia = 30,
                            Nome = "Maddy",
                            Pontosvida = 100,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 3,
                            Classe = 3,
                            Defesa = 21,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 18,
                            Inteligencia = 35,
                            Nome = "Cinzeiro",
                            Pontosvida = 100,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 4,
                            Classe = 2,
                            Defesa = 18,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 18,
                            Inteligencia = 37,
                            Nome = "Cass",
                            Pontosvida = 100,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 5,
                            Classe = 1,
                            Defesa = 17,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 20,
                            Inteligencia = 31,
                            Nome = "Rue",
                            Pontosvida = 100,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 6,
                            Classe = 3,
                            Defesa = 13,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 21,
                            Inteligencia = 34,
                            Nome = "Lexi",
                            Pontosvida = 100,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 7,
                            Classe = 2,
                            Defesa = 11,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 25,
                            Inteligencia = 35,
                            Nome = "Fez",
                            Pontosvida = 100,
                            Vitorias = 0
                        });
                });

            modelBuilder.Entity("RpgApi.Model.Arma", b =>
                {
                    b.HasOne("RpgApi.Model.personagem", "personagem")
                        .WithOne("Arma")
                        .HasForeignKey("RpgApi.Model.Arma", "PersonagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("personagem");
                });

            modelBuilder.Entity("RpgApi.Model.PersonagemHabilidade", b =>
                {
                    b.HasOne("RpgApi.Model.Habilidade", "Habilidade")
                        .WithMany("PersonagemHabilidades")
                        .HasForeignKey("HabilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RpgApi.Model.personagem", "personagem")
                        .WithMany("PersonagemHabilidade")
                        .HasForeignKey("PersonagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habilidade");

                    b.Navigation("personagem");
                });

            modelBuilder.Entity("RpgApi.Model.personagem", b =>
                {
                    b.HasOne("RpgApi.Model.Enuns.Usuario", "Usuario")
                        .WithMany("personagens")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("RpgApi.Model.Enuns.Usuario", b =>
                {
                    b.Navigation("personagens");
                });

            modelBuilder.Entity("RpgApi.Model.Habilidade", b =>
                {
                    b.Navigation("PersonagemHabilidades");
                });

            modelBuilder.Entity("RpgApi.Model.personagem", b =>
                {
                    b.Navigation("Arma");

                    b.Navigation("PersonagemHabilidade");
                });
#pragma warning restore 612, 618
        }
    }
}
