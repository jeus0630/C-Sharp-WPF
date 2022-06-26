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
    public partial class Input_Window : Window
    {
        MainWindow mWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
        Window pg;
        string cmd;
        int idx;
        StackPanel sp_lbl = new StackPanel();
        StackPanel sp_tb = new StackPanel();
        Label[] lbl = new Label[6];
        TextBox[] tb = new TextBox[6];
        Button btn_Ok = new Button();
        int n_btn = 0;
        const double tb_width = 60;

        public Input_Window(Window pg, string cmd, int idx)
        {
            InitializeComponent();
            this.pg = pg;
            this.cmd = cmd;
            this.idx = idx;
            
            sp_lbl.Orientation = Orientation.Horizontal;
            sp_tb.Orientation = Orientation.Horizontal;
            for (int i = 0; i < 6; i++)
            {
                tb[i] = new();
                tb[i].Width = tb_width;
                lbl[i] = new();
            }

            btn_Ok.Width = 40;
            btn_Ok.Height = 40;
            btn_Ok.HorizontalAlignment = HorizontalAlignment.Right;
            btn_Ok.Content = "OK";
            btn_Ok.Click += Clk_Ok;
            
            if (this.pg is Persons_Page)
            {
                n_btn = ((Persons_Page)pg).argc;
                lbl[0].Content = "ID";
                lbl[1].Content = "Name";
                lbl[2].Content = "Address";
                lbl[3].Content = "Email";
                lbl[4].Content = "Age";
                lbl[5].Content = "Brithday";
            }
            else if (this.pg is Sports_Team_Page)
            {
                n_btn = ((Sports_Team_Page)pg).argc;
                lbl[0].Content = "ID";
                lbl[1].Content = "PersonID";
                lbl[2].Content = "Sports Team";
                lbl[3].Content = "City";
            }
            else if (this.pg is Personality_Page)
            {
                n_btn = ((Personality_Page)pg).argc;
                lbl[0].Content = "ID";
                lbl[1].Content = "PersonID";
                lbl[2].Content = "Shoe Size";
                lbl[3].Content = "Favourite Movie";
                lbl[4].Content = "Favourite Actor";
            }
            else if (this.pg is Education_Page)
            {
                n_btn = ((Education_Page)pg).argc;
                lbl[0].Content = "ID";
                lbl[1].Content = "PersonID";
                lbl[2].Content = "Course Name";
                lbl[3].Content = "Course Grade";
                lbl[4].Content = "Comments";
            }
            for (int i = 0; i < n_btn; i++)
            {
                sp_lbl.Children.Add(lbl[i]);
                sp_tb.Children.Add(tb[i]);
            }
            root.Children.Add(sp_lbl);
            root.Children.Add(sp_tb);
            root.Children.Add(btn_Ok);
        }

        public void Clk_Ok(object sender, RoutedEventArgs e)
        {
            if (this.cmd == "insert")
            {
                if (this.pg is Persons_Page)
                {
                    bool ret = int.TryParse(tb[0].Text, out int id);
                    ret &= int.TryParse(tb[4].Text, out int age);
                    if (!ret)
                    {
                        MessageBox.Show("Please Input correct format", "Error");
                    }
                    else
                    {
                        var ids = from person in mWindow.li_Person
                                    where person.ID == id
                                        select person;
                        
                        if (ids.Count() > 0)
                        {
                            MessageBox.Show("There is already same ID", "Fail");
                        }
                        else
                        {
                            Person temp = new Person(id, tb[1].Text, tb[2].Text, tb[3].Text, age, tb[5].Text);
                            mWindow.li_Person.Insert(this.idx, temp);
                            ((Persons_Page)this.pg).Update();
                            MessageBox.Show("Insert success", "Success");
                            this.Close();
                        }
                    }
                }
                else if (this.pg is Sports_Team_Page)
                {
                    int id, personID;
                    bool ret = int.TryParse(tb[0].Text, out id);
                    ret &= int.TryParse(tb[1].Text, out personID);

                    if (!ret)
                    {
                        MessageBox.Show("Please Input correct format", "Error");
                    }

                    bool is_ID_True = false;
                    foreach (var person in mWindow.li_Person)
                    {
                        if (person.ID == personID) is_ID_True = true;
                    }

                    if (!is_ID_True)
                    {
                        MessageBox.Show("There is not matched person ID", "Error");
                    }

                    var ids = from person in mWindow.li_Person
                              where person.ID == id
                              select person;

                    if (ids.Count() > 0)
                    {
                        MessageBox.Show("There is already same ID", "Fail");
                    }

                    if (ret && is_ID_True && ids.Count() == 0)
                    {
                        SportsTeam temp = new SportsTeam(id, personID, tb[2].Text, tb[3].Text);
                        mWindow.li_SportsTeams.Insert(this.idx, temp);
                        ((Sports_Team_Page)this.pg).Update();
                        MessageBox.Show("Insert success", "Success");
                        this.Close();
                    }
                }
                else if (this.pg is Personality_Page)
                {
                    int id, personID, ssize;
                    bool ret = int.TryParse(tb[0].Text, out id);
                    ret &= int.TryParse(tb[1].Text, out personID);
                    ret &= int.TryParse(tb[2].Text, out ssize);
                    if (!ret)
                    {
                        MessageBox.Show("Please Input correct format", "Error");
                    }

                    bool is_ID_True = false;
                    foreach (var person in mWindow.li_Person)
                    {
                        if (person.ID == personID) is_ID_True = true;
                    }

                    if (!is_ID_True)
                    {
                        MessageBox.Show("There is not matched person ID", "Error");
                    }

                    var ids = from person in mWindow.li_Person
                              where person.ID == id
                              select person;

                    if (ids.Count() > 0)
                    {
                        MessageBox.Show("There is already same ID", "Fail");
                    }

                    if (ret && is_ID_True)
                    {
                        Personality temp = new Personality(id, personID, ssize, tb[3].Text, tb[4].Text);
                        mWindow.li_Personalities.Insert(this.idx, temp);
                        ((Personality_Page)this.pg).Update();
                        MessageBox.Show("Insert success", "Success");
                        this.Close();
                    }
                }
                else if (this.pg is Education_Page)
                {
                    int id, personID;
                    double grade;
                    bool ret = int.TryParse(tb[0].Text, out id);
                    ret &= int.TryParse(tb[1].Text, out personID);
                    ret &= double.TryParse(tb[3].Text, out grade);
                    if (!ret)
                    {
                        MessageBox.Show("Please Input correct format", "Error");
                    }

                    bool is_ID_True = false;
                    foreach (var person in mWindow.li_Person)
                    {
                        if (person.ID == personID) is_ID_True = true;
                    }

                    if (!is_ID_True)
                    {
                        MessageBox.Show("There is not matched person ID", "Error");
                    }

                    var ids = from person in mWindow.li_Person
                              where person.ID == id
                              select person;

                    if (ids.Count() > 0)
                    {
                        MessageBox.Show("There is already same ID", "Fail");
                    }

                    if (ret && is_ID_True)
                    {

                        Education temp = new Education(id, personID, tb[2].Text, grade, tb[4].Text);
                        mWindow.li_Educations.Insert(this.idx, temp);
                        ((Education_Page)pg).Update();
                        MessageBox.Show("Insert success", "Success");
                        this.Close();
                    }
                }

            }
            if (this.cmd == "update")
            {
                if (this.pg is Persons_Page)
                {
                    MessageBoxResult mbResult = MessageBox.Show("Do you want to update?", "Confirm", MessageBoxButton.YesNo);
                    if (MessageBoxResult.Yes == mbResult)
                    {
                        int id, age;
                        bool ret = int.TryParse(tb[0].Text, out id);
                        ret &= int.TryParse(tb[4].Text, out age);
                        if (!ret)
                        {
                            MessageBoxResult mbresult = MessageBox.Show("Please Input correct format", "Error");
                        }
                        else
                        {
                            var ids = from person in mWindow.li_Person
                                      where person.ID == id
                                      select person;

                            if (ids.Count() > 0)
                            {
                                MessageBox.Show("There is already same ID", "Fail");
                            }else
                            {
                                Person temp = new Person(id, tb[1].Text, tb[2].Text, tb[3].Text, age, tb[5].Text);
                                mWindow.li_Person[this.idx] = temp;
                                ((Persons_Page)this.pg).Update();
                                MessageBox.Show("Update success", "Success");
                                this.Close();
                            }
                        }

                    }
                }
                else if (this.pg is Sports_Team_Page)
                {
                    MessageBoxResult mbResult = MessageBox.Show("Do you want to update?", "Confirm", MessageBoxButton.YesNo);
                    if (MessageBoxResult.Yes == mbResult)
                    {
                        int id, personID;
                        bool ret = int.TryParse(tb[0].Text, out id);
                        ret &= int.TryParse(tb[1].Text, out personID);
                        if (!ret)
                        {
                            MessageBox.Show("Please Input correct format", "Error");
                        }

                        bool is_ID_True = false;
                        foreach (var person in mWindow.li_Person)
                        {
                            if (person.ID == personID) is_ID_True = true;
                        }

                        if (!is_ID_True)
                        {
                            MessageBox.Show("There is not matched person ID", "Error");
                        }

                        var ids = from person in mWindow.li_Person
                                  where person.ID == id
                                  select person;

                        if (ids.Count() > 0)
                        {
                            MessageBox.Show("There is already same ID", "Fail");
                        }

                        if (ret && is_ID_True && ids.Count() == 0)
                        {
                            SportsTeam temp = new SportsTeam(id, personID, tb[2].Text, tb[3].Text);
                            mWindow.li_SportsTeams[this.idx] = temp;
                            ((Sports_Team_Page)this.pg).Update();
                            MessageBox.Show("Update success", "Success");
                            this.Close();
                        }
                    }
                }
                else if (this.pg is Personality_Page)
                {
                    MessageBoxResult mbResult = MessageBox.Show("Do you want to update?", "Confirm", MessageBoxButton.YesNo);
                    if (MessageBoxResult.Yes == mbResult)
                    {
                        int id, personID, ssize;
                        bool ret = int.TryParse(tb[0].Text, out id);
                        ret &= int.TryParse(tb[1].Text, out personID);
                        ret &= int.TryParse(tb[2].Text, out ssize);
                        if (!ret)
                        {
                            MessageBoxResult mbresult = MessageBox.Show("Please Input correct format", "Error");
                        }

                        bool is_ID_True = false;
                        foreach (var person in mWindow.li_Person)
                        {
                            if (person.ID == personID) is_ID_True = true;
                        }

                        if (!is_ID_True)
                        {
                            MessageBox.Show("There is not matched person ID", "Error");
                        }

                        var ids = from person in mWindow.li_Person
                                  where person.ID == id
                                  select person;

                        if (ids.Count() > 0)
                        {
                            MessageBox.Show("There is already same ID", "Fail");
                        }

                        if (ret && is_ID_True && ids.Count() == 0)
                        {
                            Personality temp = new Personality(id, personID, ssize, tb[3].Text, tb[4].Text);
                            mWindow.li_Personalities[this.idx] = temp;
                            ((Personality_Page)this.pg).Update();
                            MessageBox.Show("Update success", "Success");
                            this.Close();
                        }
                    }
                }
                else if (this.pg is Education_Page)
                {
                    MessageBoxResult mbResult = MessageBox.Show("Do you want to update?", "Confirm", MessageBoxButton.YesNo);
                    if (MessageBoxResult.Yes == mbResult)
                    {
                        int id, personID;
                        double grade;
                        bool ret = int.TryParse(tb[0].Text, out id);
                        ret &= int.TryParse(tb[1].Text, out personID);
                        ret &= double.TryParse(tb[3].Text, out grade);
                        if (!ret)
                        {
                            MessageBoxResult mbresult = MessageBox.Show("Please Input correct format", "Error");
                        }

                        bool is_ID_True = false;
                        foreach (var person in mWindow.li_Person)
                        {
                            if (person.ID == personID) is_ID_True = true;
                        }

                        if (!is_ID_True)
                        {
                            MessageBox.Show("There is not matched person ID", "Error");
                        }

                        var ids = from person in mWindow.li_Person
                                  where person.ID == id
                                  select person;

                        if (ids.Count() > 0)
                        {
                            MessageBox.Show("There is already same ID", "Fail");
                        }

                        if (ret && is_ID_True && ids.Count() == 0)
                        {
                            Education temp = new Education(id, personID, tb[2].Text, grade, tb[4].Text);
                            mWindow.li_Educations[this.idx] = temp;
                            ((Education_Page)pg).Update();
                            MessageBox.Show("Update success", "Success");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
