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
    [Migration("20220408003401_MigracaoUsuario")]
    partial class MigracaoUsuario
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

                    b.HasKey("Id");

                    b.ToTable("Armas");
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
                            PasswordHash = new byte[] { 236, 238, 232, 157, 121, 115, 190, 80, 214, 24, 192, 139, 208, 97, 65, 57, 8, 91, 121, 137, 165, 251, 171, 220, 70, 93, 176, 101, 101, 27, 142, 154, 155, 208, 174, 177, 138, 39, 153, 187, 84, 161, 33, 189, 9, 134, 6, 67, 84, 158, 112, 47, 127, 126, 250, 3, 242, 237, 72, 88, 59, 33, 127, 227 },
                            PasswordSalt = new byte[] { 209, 23, 116, 217, 52, 254, 243, 228, 206, 155, 165, 107, 60, 190, 206, 254, 22, 246, 137, 146, 230, 25, 122, 183, 86, 253, 175, 190, 119, 3, 101, 18, 135, 92, 222, 99, 158, 77, 21, 184, 189, 100, 27, 48, 227, 63, 252, 162, 162, 37, 72, 235, 140, 175, 115, 77, 237, 196, 228, 66, 212, 83, 236, 70, 117, 164, 189, 165, 162, 108, 88, 45, 25, 183, 189, 75, 174, 208, 55, 65, 66, 70, 118, 42, 189, 76, 175, 132, 230, 121, 235, 94, 216, 50, 218, 182, 81, 205, 63, 130, 25, 251, 159, 94, 168, 84, 204, 0, 197, 90, 100, 223, 205, 217, 32, 50, 138, 60, 18, 223, 54, 201, 53, 111, 121, 115, 182, 232 },
                            Username = "UsuarioAdmin"
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
#pragma warning restore 612, 618
        }
    }
}