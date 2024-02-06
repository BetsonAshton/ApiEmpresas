using ApiEmpresas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("FUNCIONARIO");

            builder.HasKey(f => f.IdFuncionario);

            builder.Property(f => f.IdFuncionario)
                .HasColumnName("IDFUNCIONARIO");

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();


            builder.Property(f => f.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(f => f.Cpf)
                .IsUnique();

            builder.Property(f => f.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(f => f.Matricula)
               .IsUnique();

            builder.Property(f => f.DataAdmissao)
               .HasColumnName("DATAADMISSAO")
               .IsRequired();


            builder.Property(f => f.IdEmpresa)
                .HasColumnName("IDEMPRESA")
                .IsRequired();

            builder.HasOne(f => f.Empresa)
                .WithMany(e => e.Funcionarios)
                .HasForeignKey(f => f.IdEmpresa);
        }
    }
}
