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
    /// Sports_Team_Page.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Sports_Team_Page : Window
    {
        const int width_id = 50;
        const int width_personID = 150;
        const int width_sportsTeam = 100;
        const int width_city = 250;
        public int argc = 4;

        MainWindow mWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
        public Sports_Team_Page(ref List<Person> li_Person, ref List<SportsTeam> li_SportsTeam)
        {
            InitializeComponent();
            lbl_header.Content = $"{"ID",width_id} {"Person ID",width_personID} {"Sports Team",width_sportsTeam} {"City",width_city}";
            Update();
        }

        public void Update()
        {
            lb_sports_team.Items.Clear();
            foreach (SportsTeam sportsTeam in mWindow.li_SportsTeams)
            {
                StackPanel st = new();
                st.Orientation = Orientation.Horizontal;
                TextBlock tb_id = new TextBlock();
                TextBlock tb_personID = new TextBlock();
                TextBlock tb_sportsTeam = new TextBlock();
                TextBlock tb_city = new TextBlock();

                tb_id.Width = width_id;
                tb_personID.Width = width_personID;
                tb_sportsTeam.Width = width_sportsTeam;
                tb_city.Width = width_city;

                tb_id.Text = sportsTeam.ID.ToString();
                tb_personID.Text = sportsTeam.PersonId.ToString();
                tb_sportsTeam.Text = sportsTeam.Sports_Team.ToString();
                tb_city.Text = sportsTeam.City.ToString();

                st.Children.Add(tb_id);
                st.Children.Add(tb_personID);
                st.Children.Add(tb_sportsTeam);
                st.Children.Add(tb_city);

                lb_sports_team.Items.Add(st);
            }
        }

        private void Clk_Quit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbresult = MessageBox.Show("Do you want to quit the Sports Team Window?", "Confirm", MessageBoxButton.YesNo);
            if (MessageBoxResult.Yes == mbresult) this.Close();
        }

        private void Clk_Help(object sender, RoutedEventArgs e)
        {
            Help_Page pg_help = new();
            pg_help.Show();
        }

        private void Clk_Insert(object sender, RoutedEventArgs e)
        {
            if (lb_sports_team.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
            }
            else
            {
                int idx = lb_sports_team.SelectedIndex;
                Input_Window input_window = new Input_Window(this, "insert", idx);
                input_window.Show();
            }
        }

        private void Clk_Update(object sender, RoutedEventArgs e)
        {
            if (lb_sports_team.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
            }
            else
            {
                int idx = lb_sports_team.SelectedIndex;
                Input_Window input_window = new Input_Window(this, "update", idx);
                input_window.Show();
            }
        }

        private void Clk_Delete(object sender, RoutedEventArgs e)
        {
            if (lb_sports_team.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
            }else
            {
                MessageBoxResult mbresult = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == mbresult)
                {
                    int idx = lb_sports_team.SelectedIndex;
                    mWindow.li_SportsTeams.Remove(mWindow.li_SportsTeams[idx]);
                }
                Update();
            }
        }
    }
}
