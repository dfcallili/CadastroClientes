using Cadastro.Cliente.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Cliente.Infra.Data.Mapping
{
    public class ClienteCrmallMapping : IEntityTypeConfiguration<ClienteCrmall>
    {
        public void Configure(EntityTypeBuilder<ClienteCrmall> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.DataDeNascimento)
                .IsRequired();

            builder.Property(c => c.Sexo)
                .IsRequired();

            // Relationships
            builder.HasOne(c => c.Endereco)
                .WithMany()
                .HasForeignKey(c => c.EnderecoId);

            builder.Ignore(t => t.CascadeMode);
            builder.Ignore(t => t.ValidationResult);

            // Table & Column Mappings
            builder.ToTable("ClienteCrmall", "ProjetoCliente");
        }
    }
}
