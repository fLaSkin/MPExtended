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
    }
}
