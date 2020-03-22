using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CollegeFootballAPI.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {


        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");
            builder.HasKey(x => x.Id);
    


        }
    }
}
