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
    /// Interaction logic for Maintainance.xaml
    /// </summary>
    public partial class Maintainance : Window
    {
        public Maintainance()
        {
            InitializeComponent();
        }

        //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-FPT9570R;Initial Catalog=fleetDatabase;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HQCNEQG;Initial Catalog=fleetDatabase;Integrated Security=True");


        public void clearData()
        {
            vehicleBox.Clear();
            //service_datePicker.ClearValue();
            typeOfServiceBox.Clear();
            procedureCodeBox.Clear();
            procedureDescriptionBox.Clear();

        }

        public void LoadMaintenanceGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from maintenance_Details", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            maintenanceGrid.ItemsSource = dt.DefaultView;
        }




        private void maintenance_clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        public bool isValid()
        {
            if (vehicleBox.Text == string.Empty)
            {
                MessageBox.Show("vehicle ID required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (service_datePicker.Text == string.Empty) // change to text box problems occure
            {
                MessageBox.Show("service date required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (typeOfServiceBox.Text == string.Empty)
            {
                MessageBox.Show("types of service required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (procedureCodeBox.Text == string.Empty)
            {
                MessageBox.Show("procedure code required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (procedureDescriptionBox.Text == string.Empty)
            {
                MessageBox.Show("procedure description required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void maintenance_insertBtn_Click(object sender, RoutedEventArgs e)
        {

            if (isValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO maintenance_Details VALUES (@Vehicle_ID, @Service_Date, @Type_of_service, @Procedure_code, @Procedure_Description)", con);
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO report1 VALUES (@appointmentTimes,@servicePerformed, @proCode, @descrptin,)", con);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue("@appointmentTimes", service_datePicker.SelectedDate);
                    cmd2.Parameters.AddWithValue("@servicePerformed", typeOfServiceBox.Text);
                    cmd2.Parameters.AddWithValue("@proCode", procedureCodeBox.Text);
                    cmd2.Parameters.AddWithValue("@descrptin", procedureDescriptionBox.Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Vehicle_ID", vehicleBox.Text);
                    cmd.Parameters.AddWithValue("@Service_Date", service_datePicker.SelectedDate);
                    cmd.Parameters.AddWithValue("@Type_of_service", typeOfServiceBox.Text);
                    cmd.Parameters.AddWithValue("@Procedure_code", procedureCodeBox.Text);
                    cmd.Parameters.AddWithValue("@Procedure_Description", procedureDescriptionBox.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadMaintenanceGrid();
                    MessageBox.Show("succesfull registered", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        
        private void maintenance_updateBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open(); SqlCommand cmd = new SqlCommand("update maintenance_Details set Vehicle_ID ='" + vehicleBox.Text + "', Service_Date = '" + service_datePicker.SelectedDate + "', Type_of_service ='" + typeOfServiceBox.Text + "' ,Procedure_code= '" + procedureCodeBox.Text + "', Procedure_Description ='" + procedureDescriptionBox.Text + "' where receipt='" + maintenanceSearchBox.Text + "' ", con);

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
                LoadMaintenanceGrid();

            }
        }

        private void maintenance_deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from maintenance_Details where receipt = " + maintenanceSearchBox.Text + "", con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                clearData();
                LoadMaintenanceGrid();
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

        private void gotoMainWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainDashboard mainD = new MainDashboard();
            mainD.Show();
        }
    }
}


