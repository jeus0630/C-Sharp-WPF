using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Assignment_Jewoo_Ham
{
    public class SportsTeam
    {
        public SportsTeam(int ID, int personID, string Sports_Team, string City)
        {
            this.ID = ID;
            this.PersonId = personID;
            this.Sports_Team = Sports_Team;
            this.City = City;
        }
            
        public int ID { get; set; }
        public int PersonId { get; set; }
        public string Sports_Team { get; set; }
        public string City { get; set; }
    }
}
