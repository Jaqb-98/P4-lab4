using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CollegeFootballAPI.Configurations
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.ToTable("Coaches");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Team)
           .WithOne(x => x.Coach)
           .HasForeignKey<Team>(x => x.CoachId);

        }
    }
}
