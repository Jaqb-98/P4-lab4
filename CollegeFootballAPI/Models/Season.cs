

namespace CollegeFootballAPI
{
    public class Season
    {
        public int SeasonId { get; set; }
        public string School { get; set; }
        public int Year { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int? Preseason_Rank { get; set; }
        public int? Postseason_Rank { get; set; }
        public virtual Coach Coach { get; set; }

    }
}
