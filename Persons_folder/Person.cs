using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Assignment_Jewoo_Ham
{
    public class Person
    {
        
        public Person(int ID, string Name, string Address, string Email, int Age, string Birthday)
        {
            this.ID = ID;
            this.Name = Name;
            this.Address = Address;
            this.Email = Email;
            this.Age = Age;
            this.Birthday = Birthday;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }

    }
}
