﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RpgApi.Data;

namespace RpgApi.script05._05.sql
{
    [DbContext(typeof(DataContext))]
    [Migration("20220505225753_script")]
    partial class script
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

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = new byte[] { 104, 40, 74, 218, 189, 199, 75, 112, 242, 69, 110, 25, 8, 227, 32, 229, 145, 166, 33, 108, 25, 23, 175, 227, 188, 255, 107, 124, 47, 246, 213, 81, 170, 70, 182, 13, 191, 67, 133, 176, 213, 115, 116, 162, 229, 164, 224, 9, 155, 79, 84, 157, 185, 71, 73, 66, 8, 231, 157, 94, 212, 145, 173, 103 },
                            PasswordSalt = new byte[] { 87, 13, 126, 246, 188, 199, 228, 47, 208, 85, 60, 167, 152, 165, 159, 57, 83, 100, 114, 245, 235, 95, 191, 20, 177, 141, 31, 72, 58, 35, 148, 225, 69, 16, 58, 244, 134, 32, 114, 11, 122, 139, 48, 89, 254, 246, 246, 171, 35, 43, 156, 101, 245, 129, 158, 98, 39, 174, 215, 194, 11, 220, 50, 52, 113, 182, 170, 243, 165, 59, 58, 6, 93, 211, 170, 37, 132, 2, 225, 1, 3, 57, 109, 133, 227, 233, 204, 105, 40, 4, 245, 34, 60, 225, 70, 188, 2, 248, 253, 15, 227, 176, 174, 241, 42, 231, 247, 176, 227, 106, 173, 60, 236, 191, 133, 38, 164, 248, 132, 17, 183, 29, 153, 47, 58, 134, 73, 197 },
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