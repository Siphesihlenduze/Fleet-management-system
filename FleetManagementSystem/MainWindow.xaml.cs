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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FleetManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void goRegisterBtn_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();
            Register regW = new Register();
            regW.Show();

        }


        private void gotoLoginBtn_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();
            LogIn loginW = new LogIn();
            loginW.Show();

        }

       
    
    }
}
