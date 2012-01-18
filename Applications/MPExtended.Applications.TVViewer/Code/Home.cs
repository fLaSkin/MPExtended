using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPExtended.Applications.TVViewer.Code
{
    public class Home
    {
        public Home()
        {

        }

        public List<EpgItem> GetEpgData(int group, DateTime start, DateTime end)
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
       
    }
}
