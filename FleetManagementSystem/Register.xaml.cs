using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Security.Cryptography;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FleetManagementSystem
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-FPT9570R;Initial Catalog=fleetDatabase;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HQCNEQG;Initial Catalog=fleetDatabase;Integrated Security=True");



        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-FPT9570R;Initial Catalog=fleetDatabase;Integrated Security=True");
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HQCNEQG;Initial Catalog=fleetDatabase;Integrated Security=True");

            try
            {
                //con = new SqlConnection(@"Data Source=LAPTOP-FPT9570R;Initial Catalog=fleetDatabase;Integrated Security=True");
                con = new SqlConnection(@"Data Source=DESKTOP-HQCNEQG;Initial Catalog=fleetDatabase;Integrated Security=True");

                con.Open();

                SqlCommand command = new SqlCommand("INSERT INTO registerTbl(Username,FirstName,surname,eMmail,phoneNumber,password) VALUES('" + UsernameBox.Text + "'," +
                    "'" + UsernameBox.Text + "', '" + surnameBox.Text + "', '" + emailBox.Text + "' ," +
                    " '" + phoneNumberBox.Text + "', '" + passWordbox.Password + "');", con);
                command.ExecuteNonQuery();

                MessageBox.Show("you have been registered and can now login");
            }
            catch (Exception ex)
            {
                MessageBox.Show("message" + ex.Message);
            }

            UsernameBox.Clear();
            surnameBox.Clear();
            emailBox.Clear();
            phoneNumberBox.Clear();
            passWordbox.Clear();

            this.Hide();
            LogIn logwin = new LogIn();
            logwin.Show();



        }

        
    }
}
