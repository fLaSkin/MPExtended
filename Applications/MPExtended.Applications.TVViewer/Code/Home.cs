using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MPExtended.Applications.TVViewer.Code
{
    public class Home
    {
        private bool _isWorking = false;
        private BackgroundWorker _epgWorker = new BackgroundWorker();

        public delegate void ReceiveEpgDataEventHandler(List<EpgItem> epg);
        public event ReceiveEpgDataEventHandler OnEpgDataReceived;

        int _groupId = 2;
        DateTime _start = DateTime.Now;
        DateTime _end = DateTime.Now.AddHours(12);
        public Home()
        {
            _epgWorker.DoWork += new DoWorkEventHandler(epgWorker_DoWork);
            _epgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(epgWorker_RunWorkerCompleted);
        }

        public bool ReceiveData()
        {
            if (MPExtended.Libraries.General.MPEServices.HasTASConnection)
            {
                _epgWorker.RunWorkerAsync();
                return true;
            }
            return false;
        }
        public void ReceiveData(int groupId)
        {
            _groupId = groupId;
            _epgWorker.RunWorkerAsync();
        }
        public void ReceiveData(int groupId, DateTime start, DateTime end)
        {
            _start = start;
            _end = end;
            _groupId = groupId;
            _epgWorker.RunWorkerAsync();
        }
        private List<EpgItem> _GetEpgData(int group, DateTime start, DateTime end)
        {
            List<EpgItem> list = new List<EpgItem>();


            var channels = MPExtended.Libraries.General.MPEServices.TAS.GetChannelsBasic(group);
            foreach (var channel in channels)
            {
                var program = MPExtended.Libraries.General.MPEServices.TAS.GetProgramsBasicForChannel(channel.Id, start, end);
                list.Add(new EpgItem(channel, program.ToList()));
            }

            return list;

        }
        void epgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _isWorking = false;

            if (e.Result != null)
            {

                if (OnEpgDataReceived != null)
                    OnEpgDataReceived(e.Result as List<EpgItem>);


            }
        }
        void epgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _isWorking = true;
            e.Result = _GetEpgData(_groupId, _start, _end);


        }


    }
}
