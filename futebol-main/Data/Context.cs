using futebol.Data.Map;
using futebol.IService;
using futebol.Models;
using Microsoft.EntityFrameworkCore;

namespace futebol.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<time> time { get; set; }
        public DbSet<jogador> jogador { get; set; }
        public DbSet<competicao> competicao { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("mini_mundo_futebol");
            modelBuilder.Entity<time>().HasKey(t => t.nome_time);
            modelBuilder.Entity<competicao>().HasKey(c => c.nome_competicao);
            
            modelBuilder.ApplyConfiguration(new jogadorMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
