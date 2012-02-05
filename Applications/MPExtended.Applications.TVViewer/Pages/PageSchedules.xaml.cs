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
using MPExtended.Applications.TVViewer.Code;
using MPExtended.Services.TVAccessService.Interfaces;

namespace MPExtended.Applications.TVViewer.Pages
{
    /// <summary>
    /// Interaction logic for Schedules.xaml
    /// </summary>
    public partial class PageSchedules : Page
    {
        Schedules _schedules = new Schedules();

        public PageSchedules()
        {
            InitializeComponent();
            _schedules.OnSchedulesReceived += new Schedules.ReceiveSchedulesEventHandler(_schedules_OnSchedulesReceived);
            BuildDefaultScheduleList();
        
        }

        void _schedules_OnSchedulesReceived(List<Services.TVAccessService.Interfaces.WebScheduleBasic> schedules)
        {
            lbSchedules.Items.Clear();
            lbSchedules.ItemsSource = schedules;
        }

        private void BuildDefaultScheduleList()
        {
            _schedules.ReceiveData();
        }

        private void lbSchedules_Selected(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is ListBoxItem)
            {

                ListBoxItem item = (ListBoxItem)e.OriginalSource;


                if (item.Content is WebScheduleBasic)
                {
           
                    WebScheduleBasic schedule = (WebScheduleBasic)item.Content;
                    try
                    {
                        var programs = MPExtended.Libraries.General.MPEServices.TAS.GetProgramsDetailedForChannel(schedule.IdChannel,schedule.StartTime,schedule.EndTime);
                        

                        tbProgramName.Text = schedule.ProgramName;
                        tbProgramDescription.Text = programs.FirstOrDefault().Description;
         
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error");
                    }




                }

            }
        }

    }
    [ValueConversion(typeof(object), typeof(object))]
    public class DateTimeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType,
                 object parameter, System.Globalization.CultureInfo culture)
        {
            if (culture == null)
            {
                culture = new System.Globalization.CultureInfo("de-DE");
                return ((DateTime)value).ToString("d.M HH:mm", culture);
            }
            else
            {
                return ((DateTime)value).ToString("d.M HH:mm", culture);
            }
        }
        public object ConvertBack(object value, Type targetType,
                 object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
