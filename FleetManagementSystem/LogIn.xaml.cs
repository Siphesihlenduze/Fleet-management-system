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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnection sqlcon = new SqlConnection(@"Data source=LAPTOP-FPT9570R; Initial Catalog=loginDB; Intergrated Security=True");
            //SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-FPT9570R;Initial Catalog=fleetDatabase;Integrated Security=True");
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-HQCNEQG;Initial Catalog=fleetDatabase;Integrated Security=True");



            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();

                string query = "SELECT COUNT(1) FROM  registerTbl WHERE Username=@Username AND password=@password";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@Username", usernameLoginBox.Text);
                sqlcmd.Parameters.AddWithValue("@password", passwordLoginBox.Text);
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count == 1)
                {
                    MainDashboard dash = new MainDashboard();
                    dash.Show();
                    this.Close();

                    //calculations works = new calculations();
                    //works.Show();
                }
                else
                {
                    MessageBox.Show("username or password is incorrect");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }
    }
}
