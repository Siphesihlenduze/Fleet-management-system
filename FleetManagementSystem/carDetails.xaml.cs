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
    /// Interaction logic for carDetails.xaml
    /// </summary>
    public partial class carDetails : Window
    {
        public carDetails()
        {
            InitializeComponent();
            LoadGrid();

        }

        //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-FPT9570R;Initial Catalog=fleetDatabase;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HQCNEQG;Initial Catalog=fleetDatabase;Integrated Security=True");

        public void clearData()
        {
            vehRegBox.Clear();
            vehicleTypeBox.Clear();
            manufacturerBox.Clear();
            engineSizeBox.Clear();
            nextServiceBox.Clear();
            searchBox.Clear();
            oddoRadingBox.Clear();
        }
        
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from carDetails", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            carDetailsGrid.ItemsSource = dt.DefaultView;
        }


        private void clearDataBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        public bool isValid()
        {
            if(vehRegBox.Text == string.Empty)
            {
                MessageBox.Show("vehicle registration required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (vehicleTypeBox.Text == string.Empty)
            {
                MessageBox.Show("vehicle type required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (manufacturerBox.Text == string.Empty)
            {
                MessageBox.Show("manufacturer required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (engineSizeBox.Text == string.Empty)
            {
                MessageBox.Show("engine size required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (nextServiceBox.Text == string.Empty)
            {
                MessageBox.Show("next service ordometer reading requireds", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (oddoRadingBox.Text == string.Empty)
            {
                MessageBox.Show("current ordometer reading requireds", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO carDetails VALUES (@regNumber, @vehicleType, @manufacturer, @engineSize, @nextService, @currentOddoReading)", con);
                    //SqlCommand cmd2 = new SqlCommand("INSERT INTO report1 VALUES (@vehicleNo)", con
                    //cmd2.CommandType = CommandType.Text;
                    //cmd2.Parameters.AddWithValue("@vehicleNo", vehRegBox.Text);


                    cmd.CommandType = CommandType.Text;




                    cmd.Parameters.AddWithValue("@regNumber", vehRegBox.Text);
                    cmd.Parameters.AddWithValue("@vehicleType", vehicleTypeBox.Text);
                    cmd.Parameters.AddWithValue("@manufacturer", manufacturerBox.Text);
                    cmd.Parameters.AddWithValue("@engineSize", engineSizeBox.Text);
                    cmd.Parameters.AddWithValue("@nextService", nextServiceBox.Text);
                    cmd.Parameters.AddWithValue("@currentOddoReading", oddoRadingBox.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("succesfull registered", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from carDetails where recipt = " + searchBox.Text+ "", con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                clearData();
                LoadGrid();
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

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();SqlCommand cmd = new SqlCommand("update carDetails set regNumber ='"+vehRegBox.Text+ "', vehicleType = '"+ vehicleTypeBox+ "', manufacturer ='"+ manufacturerBox .Text+ "' ,engineSize= '" + engineSizeBox .Text+ "', nextService ='"+nextServiceBox.Text+ "' where recipt='" + searchBox.Text +"' ", con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Record has been updated", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch ( SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                clearData();
                LoadGrid();


            }
        }

        private void gotoDashBoard_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainDashboard mainD = new MainDashboard();
            mainD.Show();
        }
    }
}
