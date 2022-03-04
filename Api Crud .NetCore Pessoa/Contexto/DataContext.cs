using Api_Crud_.NetCore_Pessoa.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;

namespace Api_Crud_.NetCore_Pessoa.Contexto
{
    public class DataContexto : DbContext
    {
        public DataContexto(DbContextOptions<DataContexto> opcoes) : base(opcoes)
        {
            
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pessoa>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.CnpjCpf).IsUnique();
            });
        }
    }
}
