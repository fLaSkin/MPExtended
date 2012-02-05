using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MPExtended.Services.TVAccessService.Interfaces;

namespace MPExtended.Applications.TVViewer.Code
{
    public class Schedules
    {
        private bool _isWorking = false;
        private BackgroundWorker _scheduleWorker = new BackgroundWorker();

        public delegate void ReceiveSchedulesEventHandler(List<WebScheduleBasic> schedules);
        public event ReceiveSchedulesEventHandler OnSchedulesReceived;


        DateTime? _start = null;
        DateTime? _end = null;

        public Schedules()
        {
            _scheduleWorker.DoWork += new DoWorkEventHandler(epgWorker_DoWork);
            _scheduleWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(epgWorker_RunWorkerCompleted);
        }

        public bool ReceiveData()
        {
            if (MPExtended.Libraries.General.MPEServices.HasTASConnection)
            {
                if (!_scheduleWorker.IsBusy)
                {
                    _scheduleWorker.RunWorkerAsync();
                }
                return true;
            }
            return false;
        }

        public bool ReceiveData(DateTime start, DateTime end)
        {
            _start = start;
            _end = end;
            if (MPExtended.Libraries.General.MPEServices.HasTASConnection)
            {
                if (!_scheduleWorker.IsBusy)
                {
                    _scheduleWorker.RunWorkerAsync();
                }
                return true;
            }
            return false;
        }
        private List<WebScheduleBasic> _GetSchedules(DateTime? start, DateTime? end)
        {
            var schedules = MPExtended.Libraries.General.MPEServices.TAS.GetSchedules();
            if (start != null && end != null)
            {
                return schedules.Where(p => p.StartTime > start && p.EndTime < end).ToList();
            }
            return schedules.ToList();
        }
        void epgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _isWorking = false;

            if (e.Result != null)
            {

                if (OnSchedulesReceived != null)
                    OnSchedulesReceived(e.Result as List<WebScheduleBasic>);


            }
        }
        void epgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _isWorking = true;
            e.Result = _GetSchedules(_start, _end);


        }
    }
}
