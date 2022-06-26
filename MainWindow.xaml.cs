using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Midterm_Assignment_Jewoo_Ham
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Person> li_Person;
        public List<SportsTeam> li_SportsTeams;
        public List<Personality> li_Personalities;
        public List<Education> li_Educations;
        
        public MainWindow()
        {
            InitializeComponent();
            li_Person = new List<Person>
            {
                new Person(1, "Jewoo", "L5W 7SZ","jewoo@google.com", 23, "6.30.1994" ),
                new Person(2, "Hoseung", "K4C 9ZE","hoseung@google.com", 21, "8.17.1995"),
                new Person(3, "James", "N2V 8BP", "james@google.com", 31, "3.4.1992"),
                new Person(4, "Yasmin", "P8P 1L2", "yasmin@google.com", 35, "12.1.1988"),
                new Person(5, "Muna", "A4Z 8PJ", "muna@google.com", 20, "1.1.2003"),
            };
            li_SportsTeams = new List<SportsTeam>
            {
                new SportsTeam(1, 1, "LA Lakers", "LA"),
                new SportsTeam(2, 2, "Raptors", "TORONTO"),
                new SportsTeam(3, 3, "Houston Rockets", "HUSTON"),
                new SportsTeam(4, 4, "New York Knicks", "NEW YORK"),
                new SportsTeam(5, 5, "Boston Celtics", "BOSTON")
            };
            li_Personalities = new List<Personality>
            {
                new Personality(1, 1, 7, "LALA LAND", "Ryan Gosling"),
                new Personality(2, 2, 6, "The Notebook", "Rachel Anne McAdams "),
                new Personality(3, 3, 4, "Ant-Man", "Paul Rudd"),
                new Personality(4, 4, 8, "Top Gun - Maverick", "Tom Cruise"),
                new Personality(5, 5, 9, "Joker", "Joaquin Phoenix"),
            };
            li_Educations = new List<Education>
            {
                new Education(1, 1, ".Net Technology C#", 4.0, "C# is amazing"),
                new Education(2, 2, "Project Management using PMP", 3.9, "PMP is amazing"),
                new Education(3, 3, "Mobile Development", 3.8, "Angular is amazing"),
                new Education(4, 4, "Data Structure & Algorithm with C", 3.7, "C is amazing"),
                new Education(5, 5, "Database", 3.6, "Oracle is amazing"),
            };
        }

        private void Clk_Quit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbresult = MessageBox.Show("Do you wnat to quit the application?", "Confirm", MessageBoxButton.YesNoCancel);
            if(MessageBoxResult.Yes == mbresult) this.Close();
        }

        private void Clk_open_Person(object sender, RoutedEventArgs e)
        {
            Persons_Page pg_Persons = new();
            pg_Persons.Show();

        }
        private void Clk_open_Sports_Team(object sender, RoutedEventArgs e)
        {
            Sports_Team_Page pg_Sports = new(ref li_Person, ref li_SportsTeams);
            pg_Sports.Show();
        }


        private void Clk_open_Personality(object sender, RoutedEventArgs e)
        {
            Personality_Page pg_Personality = new(ref li_Person, ref li_Personalities);
            pg_Personality.Show();
        }

        private void Clk_open_Education(object sender, RoutedEventArgs e)
        {
            Education_Page pg_Education = new(ref li_Person, ref li_Educations);
            pg_Education.Show();
        }

        private void Clk_help(object sender, RoutedEventArgs e)
        {
            Help_Page pg_help = new();
            pg_help.Show();
        }
    }
}
