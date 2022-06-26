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
    /// Persons_Page.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Persons_Page : Window
    {
        const int width_id = 50;
        const int width_name = 150;
        const int width_addr = 100;
        const int width_email = 250;
        const int width_age = 40;
        const int width_birthday = 80;
        public int argc = 6;

        MainWindow mWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
        public Persons_Page()
        {
            InitializeComponent();
            lbl_header.Content = $"{"ID",width_id} {"Name",width_name} {"Address",width_addr} {"Email",width_email} {"Age",width_age} {"Birthday",width_birthday}";
            Update();
            
        }

        public void Update()
        {
            lb_person.Items.Clear();
            foreach (Person person in mWindow.li_Person)
            {
                StackPanel st = new();
                st.Orientation = Orientation.Horizontal;
                TextBlock tb_id = new TextBlock();
                TextBlock tb_name = new TextBlock();
                TextBlock tb_address = new TextBlock();
                TextBlock tb_email = new TextBlock();
                TextBlock tb_age = new TextBlock();
                TextBlock tb_birthday = new TextBlock();

                tb_id.Width = width_id;
                tb_name.Width = width_name;
                tb_address.Width = width_addr;
                tb_email.Width = width_email;
                tb_age.Width = width_age;
                tb_birthday.Width = width_birthday;


                tb_id.Text = person.ID.ToString();
                tb_name.Text = person.Name.ToString();
                tb_address.Text = person.Address.ToString();
                tb_email.Text = person.Email.ToString();
                tb_age.Text = person.Age.ToString();
                tb_birthday.Text = person.Birthday.ToString();

                st.Children.Add(tb_id);
                st.Children.Add(tb_name);
                st.Children.Add(tb_address);
                st.Children.Add(tb_email);
                st.Children.Add(tb_age);
                st.Children.Add(tb_birthday);

                lb_person.Items.Add(st);

            }
        }
        private void Clk_Quit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbresult = MessageBox.Show("Do you want to quit the Persons Window?", "Confirm", MessageBoxButton.YesNo);
            if (MessageBoxResult.Yes == mbresult) this.Close();
        }

        private void Clk_Help(object sender, RoutedEventArgs e)
        {
            Help_Page pg_help = new();
            pg_help.Show();
        }

        private void Clk_Insert(object sender, RoutedEventArgs e)
        {
            if (lb_person.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
            }
            else
            {
                int idx = lb_person.SelectedIndex;
                Input_Window input_window = new Input_Window(this, "insert", idx);
                input_window.Show();
            }
        }

        private void Clk_Update(object sender, RoutedEventArgs e)
        {
            if (lb_person.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult mbresult = MessageBox.Show("Do you want to update?", "Confirm", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == mbresult)
                {
                    int idx = lb_person.SelectedIndex;
                    Input_Window input_window = new Input_Window(this, "update", idx);
                    input_window.Show();
                }
            }
        }

        private void Clk_Delete(object sender, RoutedEventArgs e)
        {
            if (lb_person.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult mbresult = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == mbresult)
                {
                    int idx = lb_person.SelectedIndex;
                    mWindow.li_Person.Remove(mWindow.li_Person[idx]);
                    Update();
                }
            }
        }

    }
}