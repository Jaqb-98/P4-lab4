using RestSharp;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace CollegeFootballAPI
{
    class Program
    {
        static RestClient client = new RestClient("https://api.collegefootballdata.com");
        static async Task Main(string[] args)
        {

            //druzyny wpisane do bazy ef code first 
            //na podstawie nazwy druzyn znaleść aktualnego trenera
            // dopisanie trenera do druzyny
            // dla drużyn pobieramy trenera
            using var context = new CollegeFootballContext();
            var data = new Data();

            int option=0;
            while (option != 3)
            {

                Console.WriteLine("---1---    Import Data and create tables\n" +
                                  "---2---    Display Teams and coaches\n" +
                                  "---3---    Exit");
                if (int.TryParse(Console.ReadLine(), out option)) { }
                switch (option)
                {
                    case 1:
                        var client = new Client("https://api.collegefootballdata.com");

                        var teamsJSON = await client.GetResponseAsync("/teams/fbs?year=2019");
                        var coachesJSON = await client.GetResponseAsync("/coaches?year=2019");


                        var teams = JsonConvert.DeserializeObject<List<Team>>(teamsJSON);
                        var coaches = JsonConvert.DeserializeObject<List<Coach>>(coachesJSON);


                        context.Database.EnsureCreated();

                        await data.AddTeamsAsync(teams);
                        await data.AddCoachesAsync(coaches);


                        //przypisanie trenera do druzyny
                        await data.UpdateAsync();
                        break;
                    case 2:
                        var teamsList = context.Teams.ToList();

                        foreach (var team in teamsList)
                        {
                            Console.WriteLine($"Team: {team.School}\n\tCoach: {NullToString(team.Coach)}\n");
                        }
                        break;

                }
            }


        }

        static string NullToString(Coach? value)
        {
            return value == null ? "---" : value.ToString();
        }


    }
}
