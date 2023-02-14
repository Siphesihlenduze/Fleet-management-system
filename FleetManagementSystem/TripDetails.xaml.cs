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
    /// Interaction logic for TripDetails.xaml
    /// </summary>
    public partial class TripDetails : Window
    {
        public TripDetails()
        {
            InitializeComponent();
        }

       //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-FPT9570R;Initial Catalog=fleetDatabase;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HQCNEQG;Initial Catalog=fleetDatabase;Integrated Security=True");

        public void clearData()
        {
           
            trip_destinationBox.Clear();
            Trip_Distance.Clear();

        }

        public void loadtripDetailsGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from tripDetails", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            tripDetailsGrid.ItemsSource = dt.DefaultView;
        }

        private void clearDataBtn_Click_1(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        public bool isValid()
        {
            

            if (trip_destinationBox.Text == string.Empty) // change to text box problems occure
            {
                MessageBox.Show("Destination required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (Trip_Distance.Text == string.Empty)
            {
                MessageBox.Show("Distance required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO tripDetails VALUES (@Trip_destination, @Trip_distance)", con);
                    cmd.CommandType = CommandType.Text;
                   
                    cmd.Parameters.AddWithValue("@Trip_destination", trip_destinationBox.Text);
                    cmd.Parameters.AddWithValue("@Trip_distance", Trip_Distance.Text);
                    

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadtripDetailsGrid();
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
            con.Open(); SqlCommand cmd = new SqlCommand("update tripDetails set Trip_destination = '" + trip_destinationBox.Text + "', Trip_distance ='" + Trip_Distance.Text + "' where receipt='" + searchBox.Text + "' ", con);
            //if error occurs its most likely here
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
                loadtripDetailsGrid();

            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from tripDetails where receipt = " + searchBox.Text + "", con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                clearData();
                loadtripDetailsGrid();
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


                             // completed trip section


        private void CompTripclearDataBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            Completetrip_destinationBox.Clear();
            Completed_Trip_Distance.Clear();
        }



        public void loadComptripDetailsGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from completedTrip", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            CompTripDetailsGrid.ItemsSource = dt.DefaultView;
        }

        public bool CompTripisValid()
        {


            if (Completetrip_destinationBox.Text == string.Empty) // change to text box problems occure
            {
                MessageBox.Show("Destination required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (Completed_Trip_Distance.Text == string.Empty)
            {
                MessageBox.Show("Distance required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }




            return true;
        }

        private void CompTrip_insertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CompTripisValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO completedTrip VALUES (@tripDestination, @actualDistance)", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@tripDestination", Completetrip_destinationBox.Text);
                    cmd.Parameters.AddWithValue("@actualDistance", Completed_Trip_Distance.Text);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadComptripDetailsGrid();
                    MessageBox.Show("succesfull registered", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void CompTripdeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from completedTrip where receipt = " + CompTripsearchBox.Text + "", con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                clearData();
                loadComptripDetailsGrid();
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

        private void CompTripupdateBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open(); SqlCommand cmd = new SqlCommand("update completedTrip set tripDestination = '" + Completetrip_destinationBox.Text + "', actualDistance ='" + Completed_Trip_Distance.Text + "', where reciept='" + CompTripsearchBox.Text + "' ", con);
            //if error occurs its most likely here
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
                loadComptripDetailsGrid();

            }
        }
    }
}
