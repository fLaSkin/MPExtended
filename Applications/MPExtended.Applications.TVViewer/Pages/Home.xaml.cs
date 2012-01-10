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

namespace MPExtended.Applications.TVViewer.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private bool _isWorking = false;

        public Home()
        {
            InitializeComponent();
            getListBoxData();
        }

        public void getListBoxData()
        {

            List<WebChannelExtended> channelList = new List<WebChannelExtended>();
            List<WebProgramBasic> list = new List<WebProgramBasic>();
            list.Add(new WebProgramBasic
            {
                Title = "GZSZ",
                StartTime = DateTime.Now.AddHours(5),
                EndTime = DateTime.Now.AddHours(10)
            });
            list.Add(new WebProgramBasic
{
    Title = "Blabla",
    StartTime = DateTime.Now.AddHours(10),
    EndTime = DateTime.Now.AddHours(15)
});
            list.Add(new WebProgramBasic
{
    Title = "GZSZ",
    StartTime = DateTime.Now.AddHours(15),
    EndTime = DateTime.Now.AddHours(20)
});
            channelList.Add(new WebChannelExtended
            {
                Name = "ZDF",
                Programs = list



            });

            lbChannels.ItemsSource = channelList;
        }

    }
    public class WebChannelExtended
    {
        public string Name { get; set; }
        public List<WebProgramBasic> Programs { get; set; }


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
