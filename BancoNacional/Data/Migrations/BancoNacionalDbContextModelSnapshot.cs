﻿// <auto-generated />
using System;
using BancoNacional.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancoNacional.Data.Migrations
{
    [DbContext(typeof(BancoNacionalDbContext))]
    partial class BancoNacionalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BancoNacional.Models.Agencias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GerenteId")
                        .HasColumnType("int");

                    b.Property<string>("LOCALIZACAO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NOME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NUMERO_CLIENTES")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AGENCIAS");
                });

            modelBuilder.Entity("BancoNacional.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<string>("NOME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SALDO")
                        .HasColumnType("int");

                    b.Property<int>("TIPO_CONTA")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.ToTable("CLIENTES");
                });

            modelBuilder.Entity("BancoNacional.Models.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DONO")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DONO");

                    b.ToTable("CONTA_CORRENTE");
                });

            modelBuilder.Entity("BancoNacional.Models.ContaPoupanca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DONO")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DONO");

                    b.ToTable("CONTA_POUPANCA");
                });

            modelBuilder.Entity("BancoNacional.Models.Gerentes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<int?>("GerenteId")
                        .HasColumnType("int");

                    b.Property<string>("NOME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("GerenteId");

                    b.ToTable("GERENTES");
                });

            modelBuilder.Entity("BancoNacional.Models.Clientes", b =>
                {
                    b.HasOne("BancoNacional.Models.Agencias", "Agencia")
                        .WithMany()
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agencia");
                });

            modelBuilder.Entity("BancoNacional.Models.ContaCorrente", b =>
                {
                    b.HasOne("BancoNacional.Models.Clientes", "Dono")
                        .WithMany()
                        .HasForeignKey("DONO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dono");
                });

            modelBuilder.Entity("BancoNacional.Models.ContaPoupanca", b =>
                {
                    b.HasOne("BancoNacional.Models.Clientes", "Dono")
                        .WithMany()
                        .HasForeignKey("DONO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dono");
                });

            modelBuilder.Entity("BancoNacional.Models.Gerentes", b =>
                {
                    b.HasOne("BancoNacional.Models.Agencias", "Agencia")
                        .WithMany()
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BancoNacional.Models.Gerentes", "Gerente")
                        .WithMany()
                        .HasForeignKey("GerenteId");

                    b.Navigation("Agencia");

                    b.Navigation("Gerente");
                });
#pragma warning restore 612, 618
        }
    }
}
