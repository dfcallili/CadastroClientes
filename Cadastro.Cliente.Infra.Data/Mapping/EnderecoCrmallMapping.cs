using Cadastro.Cliente.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Cliente.Infra.Data.Mapping
{
    public class EnderecoCrmallMapping : IEntityTypeConfiguration<EnderecoCrMall>
    {
        public void Configure(EntityTypeBuilder<EnderecoCrMall> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(c => c.Cep)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.Logradouro)
                .HasMaxLength(200);

            builder.Property(c => c.Numero)
                .HasMaxLength(200);

            builder.Property(c => c.Complemento)
                .HasMaxLength(200);

            builder.Property(c => c.Bairro)
                .HasMaxLength(200);

            builder.Property(c => c.Uf)
                .HasMaxLength(2);

            builder.Property(c => c.Localidade)
                .HasMaxLength(200);

            // Table & Column Mappings
            builder.ToTable("EnderecoCrmall", "ProjetoCliente");
        }
    }
}
