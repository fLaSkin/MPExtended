using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MPExtended.Applications.TVViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pages.PageHome home = new Pages.PageHome();
        Pages.PageSchedules schedules = new Pages.PageSchedules();
        public MainWindow()
        {
            InitializeComponent();
            
            contentFrame.Navigate(home);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(schedules);
        }
        private void isServiceConnected()
        {
            if (!MPExtended.Libraries.General.MPEServices.HasTASConnection)
            {
                MessageBox.Show("No connection");
            }
        }
    }
}
