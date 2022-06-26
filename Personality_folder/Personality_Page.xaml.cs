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
    public partial class Personality_Page : Window
    {
        const int width_id = 80;
        const int width_personID = 100;
        const int width_shoeSize = 80;
        const int width_favouriteMovie = 125;
        const int width_favouriteActor = 130;
        public int argc = 5;
        MainWindow mWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        public Personality_Page(ref List<Person> li_Person, ref List< Personality> li_Personality)
        {
            InitializeComponent();
            lbl_header.Content = $"{"ID"} {"Person ID",20} {"Shoe Size",20} {"Favourite Movie",20} {"Favourite Actor",20}";
            Update();
        }

        public void Update()
        {
            lb_personality.Items.Clear();
            foreach (Personality personality in mWindow.li_Personalities)
            {
                StackPanel st = new();
                st.Orientation = Orientation.Horizontal;
                TextBlock tb_id = new TextBlock();
                TextBlock tb_personID = new TextBlock();
                TextBlock tb_shoeSize = new TextBlock();
                TextBlock tb_favouriteMovie = new TextBlock();
                TextBlock tb_favouriteActor = new TextBlock();

                tb_id.Width = width_id;
                tb_personID.Width = width_personID;
                tb_shoeSize.Width = width_shoeSize;
                tb_favouriteMovie.Width = width_favouriteMovie;
                tb_favouriteActor.Width = width_favouriteActor;

                tb_id.Text = personality.ID.ToString();
                tb_personID.Text = personality.PersonID.ToString();
                tb_shoeSize.Text = personality.Shoe_size.ToString();
                tb_favouriteMovie.Text = personality.Favourite_movie.ToString();
                tb_favouriteActor.Text = personality.Favourite_actor.ToString();

                st.Children.Add(tb_id);
                st.Children.Add(tb_personID);
                st.Children.Add(tb_shoeSize);
                st.Children.Add(tb_favouriteMovie);
                st.Children.Add(tb_favouriteActor);
                lb_personality.Items.Add(st);

            }
        }

        private void Clk_Quit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbresult = MessageBox.Show("Do you want to quit the Personality Window?", "Confirm", MessageBoxButton.YesNo);
            if (MessageBoxResult.Yes == mbresult) this.Close();
        }

        private void Clk_Help(object sender, RoutedEventArgs e)
        {
            Help_Page pg_help = new();
            pg_help.Show();
        }

        private void Clk_Insert(object sender, RoutedEventArgs e)
        {
            if (lb_personality.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select Item from the list where you want to insert", "Error", MessageBoxButton.OK);
            }
            else
            {
                int idx = lb_personality.SelectedIndex;
                Input_Window input_window = new Input_Window(this, "insert", idx);
                input_window.Show();
            }
        }

        private void Clk_Update(object sender, RoutedEventArgs e)
        {
            if (lb_personality.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select Item from the list", "Error", MessageBoxButton.OK);
            }
            else
            {            
                int idx = lb_personality.SelectedIndex;

                Input_Window input_window = new Input_Window(this, "update", idx);
                input_window.Show();   
            }
        }

        private void Clk_Delete(object sender, RoutedEventArgs e)
        {
            if (lb_personality.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select Item from the list", "Error", MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult mbresult = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == mbresult)
                {
                    int idx = lb_personality.SelectedIndex;
                    mWindow.li_Personalities.Remove(mWindow.li_Personalities[idx]);
                    Update();
                }
            }
        }
    }

}
