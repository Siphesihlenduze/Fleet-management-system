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
using System.Data.SqlClient;
using System.Data;

namespace FleetManagementSystem
{
    /// <summary>
    /// Interaction logic for EmployeeDetails.xaml
    /// </summary>
    public partial class EmployeeDetails : Window
    {
        public EmployeeDetails()
        {
            InitializeComponent();
        }

        //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-FPT9570R;Initial Catalog=fleetDatabase;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HQCNEQG;Initial Catalog=fleetDatabase;Integrated Security=True");


        public void clearData()
        {
            employeeIDbox.Clear();
            
            employeeNameBox.Clear();
            positionComboBox.Items.Clear();
            noOfHoursBox.Clear();

        }

        public void LoadEmployeeDetailsGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from employeeDetails", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            employeeDetailsGrid.ItemsSource = dt.DefaultView;
        }

        private void clearDataBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        public bool isValid()
        {
            if (employeeIDbox.Text == string.Empty)
            {
                MessageBox.Show("Employee ID required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (employeeNameBox.Text == string.Empty) // change to text box problems occure
            {
                MessageBox.Show("Employee name required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (positionComboBox.Text == string.Empty)
            {
                MessageBox.Show("Employee position required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (noOfHoursBox.Text == string.Empty)
            {
                MessageBox.Show("Number of hours required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            
            return true;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO employeeDetails VALUES (@EmployeeID, @EmployeeName, @EmployeePosition, @numberOfHours)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeIDbox.Text);
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeNameBox.Text);
                    cmd.Parameters.AddWithValue("@EmployeePosition", positionComboBox.Text);
                    cmd.Parameters.AddWithValue("@numberOfHours", noOfHoursBox.Text);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadEmployeeDetailsGrid();
                    MessageBox.Show("succesfull registered", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open(); SqlCommand cmd = new SqlCommand("update employeeDetails set EmployeeID ='" + employeeIDbox.Text + "', EmployeeName = '" + employeeNameBox.Text+ "', EmployeePosition ='" + positionComboBox.Text + "' ,numberOfHours= '" + noOfHoursBox.Text +  "' where receipt='" + searchBox.Text + "' ", con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Record has been updated", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                clearData();
                LoadEmployeeDetailsGrid();

            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from employeeDetails where receipt = " + searchBox.Text + "", con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                clearData();
                LoadEmployeeDetailsGrid();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(" Not deleted" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void gotoDashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainDashboard mainD = new MainDashboard();
            mainD.Show();
        }
    }
}
