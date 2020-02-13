﻿// <auto-generated />
using System;
using AtleticaCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AtleticaCore.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AtleticaCore.Model.Log", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ACTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DATAHORA")
                        .HasColumnType("datetime2");

                    b.Property<string>("LOGIN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("AtleticaCore.Model.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("APROVADO")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMAIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LOGIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NOME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SALT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SENHA")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            APROVADO = false,
                            EMAIL = "danilo@gmail.com",
                            NOME = "DANILO"
                        },
                        new
                        {
                            ID = 2,
                            APROVADO = false,
                            EMAIL = "bibi@gmail.com",
                            NOME = "BIBI"
                        },
                        new
                        {
                            ID = 3,
                            APROVADO = false,
                            EMAIL = "bibi@gmail.com",
                            NOME = "CARLOS"
                        },
                        new
                        {
                            ID = 4,
                            APROVADO = false,
                            EMAIL = "bibi@gmail.com",
                            NOME = "JOELTON"
                        },
                        new
                        {
                            ID = 5,
                            APROVADO = false,
                            EMAIL = "bibi@gmail.com",
                            NOME = "GIL BROTHER"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
