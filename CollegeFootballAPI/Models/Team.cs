

namespace CollegeFootballAPI
{
    public class Team
    {
        public int Id { get; set; }
        public string School { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string? Division { get; set; }
        public virtual Coach? Coach { get; set; }
        public int? CoachId { get; set; }



    }
}
