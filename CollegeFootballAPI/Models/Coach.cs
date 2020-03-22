using System.Collections.Generic;

namespace CollegeFootballAPI
{
   
    public class Coach
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
        public virtual Team? Team { get; set; }


        public override string ToString()
        {
            return $"{First_Name} {Last_Name}";
        }

    }
}