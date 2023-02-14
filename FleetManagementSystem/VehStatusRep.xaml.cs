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
    /// Interaction logic for VehStatusRep.xaml
    /// </summary>
    public partial class VehStatusRep : Window
    {
        public VehStatusRep()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-FPT9570R;Initial Catalog=fleetDatabase;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HQCNEQG;Initial Catalog=fleetDatabase;Integrated Security=True");

        public void LoadGrid()
        {
            //SqlCommand cmd = new SqlCommand("select * from carDetails", con);
            //DataTable dt = new DataTable();
            //con.Open();
            //SqlDataReader sdr = cmd.ExecuteReader();
            //dt.Load(sdr);
            //con.Close();
            //vehStatusGrid.ItemsSource = dt.DefaultView;
        }
        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from carDetails", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            vehStatusGrid.ItemsSource = dt.DefaultView;
        }
    }
}
