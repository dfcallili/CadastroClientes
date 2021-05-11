using Cadastro.Cliente.Domain.Clientes;
using Cadastro.Cliente.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Cadastro.Cliente.Infra.Data.Context
{
    public class CadastroClienteDbContext : DbContext
    {
        public CadastroClienteDbContext()
        {
        }

        public CadastroClienteDbContext(DbContextOptions<CadastroClienteDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var connectionString = "Server=localhost;port=3306;DataBase=ProjetoCliente;Uid=root;Pwd=secret";
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 1, 40)),
                mySqlOptionsAction => 
                mySqlOptionsAction.SchemaBehavior(
                    Pomelo.EntityFrameworkCore.MySql.Infrastructure.MySqlSchemaBehavior.Ignore));
        }

        public DbSet<EnderecoCrMall> Enderecos { get; set; }
        public DbSet<ClienteCrmall> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoCrmallMapping());
            modelBuilder.ApplyConfiguration(new ClienteCrmallMapping());

        }
    }

}
