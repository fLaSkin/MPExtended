using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPExtended.Services.TVAccessService.Interfaces;

namespace MPExtended.Applications.TVViewer.Code
{

    public class EpgItem
    {

        public WebChannelBasic Phannel { get; private set; }
        public List<WebProgramBasic> Program { get; private set; }
    
    }
}
