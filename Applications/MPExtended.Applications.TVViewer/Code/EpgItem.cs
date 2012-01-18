using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPExtended.Services.TVAccessService.Interfaces;

namespace MPExtended.Applications.TVViewer.Code
{
    public class EpgItem
    {
        public WebChannelBasic Channel { get; private set; }

        List<WebProgramBasic> _programs = null;
        public EpgItem(WebChannelBasic channel, List<WebProgramBasic> programs)
        {
            Channel = channel;
            _programs = programs;


        }
        public List<WebProgramBasic> Programs
        {
            get
            {
                return _programs;
            }
            set 
            {
                _programs = value;
            }

        }

    }
}
