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
using System.Windows.Shapes;

namespace Midterm_Assignment_Jewoo_Ham
{
    /// <summary>
    /// Persons_Insert_Window.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Persons_Insert_Window : Window
    {
        public Persons_Insert_Window()
        {
            InitializeComponent();
        }
        public List<Person> li_Person { get; set; }

        private void Clk_btn_person_insert_true(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(input_id.Text);
            string name = input_name.Text;
            string address = input_address.Text;
            string email = input_email.Text;
            int age = int.Parse(input_age.Text);
            string birthday = input_birthday.Text;

            this.li_Person.Add(new Person(id,name,address,email,age,birthday));
        }
    }
}
