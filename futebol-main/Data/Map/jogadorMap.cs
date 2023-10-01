using futebol.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace futebol.Data.Map
{
    public class jogadorMap : IEntityTypeConfiguration<jogador>
    {
        public void Configure(EntityTypeBuilder<jogador> builder)
        {
            builder.HasKey(x => x.id_jogador);

            builder.HasOne(x => x.Time)
                   .WithMany(time => time.jogadores) // Supondo que "jogadores" seja a propriedade de navegação em "time"
                   .HasForeignKey(x => x.nome_time);
        }
    }
}
