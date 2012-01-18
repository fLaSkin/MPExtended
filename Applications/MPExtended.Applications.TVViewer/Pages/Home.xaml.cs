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
using MPExtended.Services.TVAccessService.Interfaces;
using System.Globalization;
using System.ComponentModel;
using MPExtended.Applications.TVViewer.Code;

namespace MPExtended.Applications.TVViewer.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private bool _isWorking = false;

        Code.Home _home = new Code.Home();
        Settings _settings = new Settings();
        BackgroundWorker epgWorker = new BackgroundWorker();

        public Home()
        {
            InitializeComponent();

            epgWorker.DoWork += new DoWorkEventHandler(epgWorker_DoWork);
            epgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(epgWorker_RunWorkerCompleted);
        

        }

        void BuildDefaultEpg()
        {
            if (MPExtended.Libraries.General.MPEServices.HasTASConnection)
            {
                epgWorker.RunWorkerAsync();
            }
        }
        void epgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _isWorking = false;
            if (e.Result != null)
            {
                lbChannels.ItemsSource = e.Result as List<EpgItem>;
            }
        }
        void epgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _isWorking = true;
                e.Result = _home.GetEpgData(Properties.Settings.Default.DefaultGroup, DateTime.Now, DateTime.Now.AddHours(12));
            

        }

     

    }


    public class MyMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan time = ((DateTime)values[1]).Subtract((DateTime)values[0]);
            int percentage = 24 * time.Hours / 100;
            int windowWidth = 600;
            int width = windowWidth * percentage / 100;
            return width;
        }

        public object[] ConvertBack(object values, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
