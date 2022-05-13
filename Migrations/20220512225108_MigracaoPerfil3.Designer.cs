﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RpgApi.Data;

namespace RpgApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220512225108_MigracaoPerfil3")]
    partial class MigracaoPerfil3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("RpgApi.Model.Enuns.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

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
                        .IsRequired()
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
                            PasswordHash = new byte[] { 119, 213, 19, 188, 113, 183, 167, 239, 33, 50, 18, 51, 220, 195, 238, 167, 117, 128, 218, 38, 190, 248, 39, 110, 92, 208, 146, 51, 185, 77, 150, 243, 36, 160, 180, 228, 113, 223, 179, 67, 243, 47, 207, 108, 250, 255, 187, 77, 143, 106, 229, 147, 75, 187, 142, 246, 131, 46, 77, 147, 237, 29, 33, 121 },
                            PasswordSalt = new byte[] { 224, 143, 23, 247, 132, 86, 6, 118, 20, 37, 127, 201, 1, 64, 201, 24, 48, 34, 124, 86, 178, 134, 222, 197, 185, 206, 68, 147, 21, 14, 115, 5, 247, 40, 100, 207, 198, 255, 116, 8, 21, 179, 94, 198, 46, 132, 32, 202, 42, 194, 56, 76, 215, 191, 61, 233, 243, 246, 254, 143, 116, 225, 72, 199, 42, 100, 66, 253, 5, 41, 202, 22, 219, 82, 221, 88, 39, 140, 40, 219, 117, 139, 47, 226, 69, 194, 125, 40, 21, 223, 188, 169, 36, 100, 54, 19, 254, 45, 174, 123, 2, 52, 5, 1, 235, 180, 130, 164, 211, 254, 83, 21, 16, 214, 81, 152, 30, 178, 144, 132, 244, 78, 60, 139, 114, 235, 210, 60 },
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

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("personagens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Classe = 1,
                            Defesa = 23,
                            Forca = 17,
                            Inteligencia = 33,
                            Nome = "Nathaniel",
                            Pontosvida = 100
                        },
                        new
                        {
                            Id = 2,
                            Classe = 1,
                            Defesa = 25,
                            Forca = 15,
                            Inteligencia = 30,
                            Nome = "Maddy",
                            Pontosvida = 100
                        },
                        new
                        {
                            Id = 3,
                            Classe = 3,
                            Defesa = 21,
                            Forca = 18,
                            Inteligencia = 35,
                            Nome = "Cinzeiro",
                            Pontosvida = 100
                        },
                        new
                        {
                            Id = 4,
                            Classe = 2,
                            Defesa = 18,
                            Forca = 18,
                            Inteligencia = 37,
                            Nome = "Cass",
                            Pontosvida = 100
                        },
                        new
                        {
                            Id = 5,
                            Classe = 1,
                            Defesa = 17,
                            Forca = 20,
                            Inteligencia = 31,
                            Nome = "Rue",
                            Pontosvida = 100
                        },
                        new
                        {
                            Id = 6,
                            Classe = 3,
                            Defesa = 13,
                            Forca = 21,
                            Inteligencia = 34,
                            Nome = "Lexi",
                            Pontosvida = 100
                        },
                        new
                        {
                            Id = 7,
                            Classe = 2,
                            Defesa = 11,
                            Forca = 25,
                            Inteligencia = 35,
                            Nome = "Fez",
                            Pontosvida = 100
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