using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Assignment_Jewoo_Ham
{
    public class Personality
    {
        public Personality(int ID, int personID, int Shoe_size, string Favourite_movie, string Favourite_actor)
        {
            this.ID = ID;
            this.PersonID = personID;
            this.Shoe_size = Shoe_size;
            this.Favourite_movie = Favourite_movie;
            this.Favourite_actor = Favourite_actor;
        }

        public int ID { get; set; }
        
        public int PersonID { get; set; }

        public int Shoe_size { get; set; }

        public string Favourite_movie { get; set; }

        public string Favourite_actor { get; set; }


    }
}
