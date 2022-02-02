using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrnaEletronica.Domain;

namespace UrnaEletronica.Repository
{
    public class CandidateMaps : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("t_candidates");

            builder.HasKey(x => x.IdCandidate);
            builder.Property(x => x.IdCandidate).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.FullName).HasColumnName("full_name").HasMaxLength(150).IsRequired();
            builder.Property(x => x.VicesName).HasColumnName("vice_name").HasMaxLength(150).IsRequired();
            builder.Property(x => x.RegistreDate).HasColumnName("registre_date").IsRequired();
            builder.Property(x => x.PartyLegend).HasColumnName("party_legend").IsRequired();
        }
    }
}
