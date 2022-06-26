using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Assignment_Jewoo_Ham
{
    public class Education
    {
        public Education(int ID, int personID, string Course_Name, double Course_grade, string Comments)
        {
            this.ID = ID;
            this.PersonID = personID;
            this.Course_Name = Course_Name;
            this.Course_grade = Course_grade;
            this.Comments = Comments;
        }

        public int ID { get; set; }
        public int PersonID { get; set; }
        public string Course_Name { get; set; }
        public double Course_grade { get; set; }
        public string Comments { get; set; }
    }
}
