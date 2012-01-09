using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPExtended.Applications.TVViewer.Code
{
    public class ConnectionManager
    {
        public bool IsConnected { get; private set; }
        public Connection CurrentConnection { get; private set; }
        public delegate void ConnectionEstablishedEventHandler(Connection currentConnection);
        public static event ConnectionEstablishedEventHandler OnConnectionEstablished;

        public void Connect(Settings currentSettings)
        {
            if (true)
            {
                if (OnConnectionEstablished != null)
                    OnConnectionEstablished(CurrentConnection);

            }
        }
        public void Disconnect()
        { 
        
        }
    }
}
