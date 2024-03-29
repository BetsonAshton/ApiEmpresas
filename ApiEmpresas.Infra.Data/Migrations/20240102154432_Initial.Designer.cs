﻿// <auto-generated />
using System;
using ApiEmpresas.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiEmpresas.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240102154432_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiEmpresas.Domain.Entities.Empresa", b =>
                {
                    b.Property<Guid?>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDEMPRESA");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOMEFANTASIA");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("RAZAOSOCIAL");

                    b.HasKey("IdEmpresa");

                    b.ToTable("EMPRESA", (string)null);
                });

            modelBuilder.Entity("ApiEmpresas.Domain.Entities.Funcionario", b =>
                {
                    b.Property<Guid?>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDFUNCIONARIO");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAADMISSAO");

                    b.Property<Guid>("IdEmpresa")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDEMPRESA");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("MATRICULA");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.HasKey("IdFuncionario");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("FUNCIONARIO", (string)null);
                });

            modelBuilder.Entity("ApiEmpresas.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("ApiEmpresas.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ApiEmpresas.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
