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
    /// Education_Page.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Education_Page : Window
    {
        MainWindow mWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
        const int width_id = 50;
        const int width_personID = 150;
        const int width_courseName = 100;
        const int width_courseGrade = 250;
        const int width_comments = 40;
        public int argc = 5;

        public Education_Page(ref List<Person> li_Person, ref List<Education> li_Education)
        {
            InitializeComponent();
            lbl_header.Content = $"{"ID",width_id} {"Person ID",width_personID} {"Course Name",width_courseName} {"Course Grade",width_courseGrade} {"Comments",width_comments}";
            Update();
        }

        public void Update()
        {
            lb_education.Items.Clear();
            foreach (Education education in mWindow.li_Educations)
            {
                StackPanel st = new();
                st.Orientation = Orientation.Horizontal;
                TextBlock tb_id = new TextBlock();
                TextBlock tb_personID = new TextBlock();
                TextBlock tb_courseName = new TextBlock();
                TextBlock tb_courseGrade = new TextBlock();
                TextBlock tb_comments = new TextBlock();

                tb_id.Width = width_id;
                tb_personID.Width = width_personID;
                tb_courseName.Width = width_courseName;
                tb_courseGrade.Width = width_courseGrade;
                tb_comments.Width = width_comments;

                tb_id.Text = education.ID.ToString();
                tb_personID.Text = education.PersonID.ToString();
                tb_courseName.Text = education.Course_Name.ToString();
                tb_courseGrade.Text = education.Course_grade.ToString();
                tb_comments.Text = education.Comments.ToString();

                st.Children.Add(tb_id);
                st.Children.Add(tb_personID);
                st.Children.Add(tb_courseName);
                st.Children.Add(tb_courseGrade);
                st.Children.Add(tb_comments);

                lb_education.Items.Add(st);

            }
        }

        private void Clk_Help(object sender, RoutedEventArgs e)
        {
            Help_Page pg_help = new();
            pg_help.Show();
        }

        private void Clk_Quit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbresult = MessageBox.Show("Do you want to quit the Education Window?", "Confirm", MessageBoxButton.YesNo);
            if (MessageBoxResult.Yes == mbresult) this.Close();
        }

        private void Clk_Insert(object sender, RoutedEventArgs e)
        {
            if (lb_education.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
            }
            else
            {
                int idx = lb_education.SelectedIndex;
                Input_Window input_window = new Input_Window(this, "insert", idx);
                input_window.Show();
            }
        }

        private void Clk_Update(object sender, RoutedEventArgs e)
        {
            if (lb_education.SelectedItem == null)
            {
                MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult mbresult = MessageBox.Show("Do you want to update?", "Confirm", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == mbresult)
                {
                    int idx = lb_education.SelectedIndex;
                    Input_Window input_window = new Input_Window(this, "update", idx);
                    input_window.Show();
                }
            }
        }

        private void Clk_Delete(object sender, RoutedEventArgs e)
        {
            if (lb_education.SelectedItem == null)
            {
                MessageBoxResult mbresult = MessageBox.Show("Please Select ", "Error", MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult mbresult = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == mbresult)
                {
                    int idx = lb_education.SelectedIndex;
                    mWindow.li_Educations.Remove(mWindow.li_Educations[idx]);
                    Update();
                }
            }
        }
    }
}
