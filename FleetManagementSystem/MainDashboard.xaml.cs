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

namespace FleetManagementSystem
{
    /// <summary>
    /// Interaction logic for MainDashboard.xaml
    /// </summary>
    public partial class MainDashboard : Window
    {
        public MainDashboard()
        {
            InitializeComponent();
        }



        private void DashLogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void carDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            carDetails carDetWin = new carDetails();
            carDetWin.Show();
        }

        private void gotoMaintenance_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Maintainance mainTwin = new Maintainance();
            mainTwin.Show();
        }

        private void gotoEmployeeDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EmployeeDetails emploW = new EmployeeDetails();
            emploW.Show();

        }

        private void gotoTripDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TripDetails tripD = new TripDetails();
            tripD.Show();

        }
    }
}
