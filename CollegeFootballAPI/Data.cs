using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeFootballAPI
{
    public class Data
    {
      

        public async Task<Coach> GetTeamCoachAsync(string teamName)
        {
            await using var context = new CollegeFootballContext();
            context.Database.OpenConnection();
            var coach = context.Seasons.Where(s => s.School == teamName)
                                       .Select(x => x.Coach)
                                       .FirstOrDefault();
            context.Database.CloseConnection();
            return coach;
        }

        public async Task UpdateAsync()
        {
            await using var context = new CollegeFootballContext();
            context.Database.OpenConnection();
            foreach (var team in context.Teams)
            {
                var a = GetTeamCoachAsync(team.School).Result;
                if (a != null)
                {

                    team.Coach = a;  
                    team.CoachId = a.Id;

                }
            }
            await context.SaveChangesAsync();
            context.Database.CloseConnection();
        }

        public async Task AddTeamsAsync(ICollection<Team> teams)
        {
            await using var context = new CollegeFootballContext();
            context.Database.OpenConnection();
            await context.Teams.AddRangeAsync(teams);

            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Teams ON");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Teams OFF");
            }
            finally
            {
                await context.Database.CloseConnectionAsync();
            }

        }

        public async Task AddCoachesAsync(ICollection<Coach> coaches)
        {
            await using var context = new CollegeFootballContext();
            context.Database.OpenConnection();
            await context.Coaches.AddRangeAsync(coaches);
            await context.SaveChangesAsync();
            await context.Database.CloseConnectionAsync();

        }
    }
}
