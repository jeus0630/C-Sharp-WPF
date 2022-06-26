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
    /// Personality_Page.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Personality_Page : Window
    {
        const int width_id = 50;
        const int width_personID = 150;
        const int width_shoeSize = 100;
        const int width_favouriteMovie = 250;
        const int width_favouriteActor = 40;
        public int argc = 5;
        MainWindow mWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        public Personality_Page(ref List<Person> li_Person, ref List< Personality> li_Personality)
        {
            InitializeComponent();
            lbl_header.Content = $"{"ID",width_id} {"Person ID",width_personID} {"Shoe Size",width_shoeSize} {"Favourite Movie",width_favouriteMovie} {"Favourite Actor",width_favouriteActor}";
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
            this.Close();
        }

        private void Clk_help(object sender, RoutedEventArgs e)
        {
            Help_Page pg_help = new();
            pg_help.Show();
        }

        private void Clk_insert(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(lb_personality.SelectedItem.ToString());
            if (lb_personality.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
                if (MessageBoxResult.OK == mbresult) this.Close();
            }
            else
            {
                int idx = lb_personality.SelectedIndex;
                Input_Window input_window = new Input_Window(this, "insert", idx);
                input_window.Show();
            }
        }

        private void Clk_update(object sender, RoutedEventArgs e)
        {
            if (lb_personality.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
                if (MessageBoxResult.OK == mbresult) this.Close();
            }
            else
            {
                int idx = lb_personality.SelectedIndex;
                Input_Window input_window = new Input_Window(this, "update", idx);
                input_window.Show();
            }
        }

    }

}
