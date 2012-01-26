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
using MPExtended.Applications.TVViewer.Controls;
using MPExtended.Libraries.General;

namespace MPExtended.Applications.TVViewer.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class PageHome : Page
    {


        Home _home = new Home();
        PageSettings _settings = new PageSettings();


        public PageHome()
        {
            InitializeComponent();
            _home.OnEpgDataReceived += new Home.ReceiveEpgDataEventHandler(Home_OnEpgDataReceived);
            BuildDefaultEpg();

        }

        void BuildDefaultEpg()
        {
            _home.ReceiveData();
        }

        void Home_OnEpgDataReceived(List<EpgItem> epg)
        {
            lbChannels.Items.Clear();
            lbChannels.ItemsSource = epg;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            BuildDefaultEpg();
        }


        private void lbChannels_Selected(object sender, RoutedEventArgs e)
        {

            if (e.OriginalSource is ListBoxItem)
            {
                if (((ListBoxItem)e.OriginalSource).Content is EpgItem)
                {
                    EpgItem item = ((ListBoxItem)e.OriginalSource).Content as EpgItem;
                    MessageBox.Show(item.GetType().ToString());
                    WebChannelBasic channel = item.Channel;
                    if (channel != null)
                    {
                        try
                        {
                            MediaPlayerControl player = new MediaPlayerControl();
                            string url = MPEServices.TAS.SwitchTVServerToChannelAndGetStreamingUrl("TVViewer", channel.Id);
                            if (!String.IsNullOrEmpty(url))
                            {
                                player.PlayStream(url);
                                Window window = new Window
                             {
                                 Title = "My User Control Dialog",
                                 Content = player
                             };

                                window.ShowDialog();
                            }

                        }
                        catch (Exception ex)
                        {
                            tbException.Text = ex.ToString();
                        }

                    }

                }
            }
        }


    }


    public class MyMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan time = ((DateTime)values[1]).Subtract((DateTime)values[0]);
            int percentage = 12 * time.Hours / 99;
            double windowWidth = (double)values[2];
            double width = windowWidth / 12 * percentage;
            return width;
        }

        public object[] ConvertBack(object values, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
