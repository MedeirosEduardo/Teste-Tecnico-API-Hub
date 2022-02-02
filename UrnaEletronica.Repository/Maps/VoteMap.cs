using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrnaEletronica.Domain;

namespace UrnaEletronica.Repository
{
    public class VoteMap : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("t_votes");

            builder.HasKey(x => x.IdVote);
            builder.Property(x => x.IdVote).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.IdCandidate).HasColumnName("candidate_id").IsRequired();
            builder.Property(x => x.VoteDate).HasColumnName("vote_date").IsRequired();
        }
    }
}
