using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPExtended.Applications.TVViewer.Code
{
    public class TVViewer
    {
        private Settings _settings = new Settings();
        private ConnectionManager _connectionManager = new ConnectionManager();

        public TVViewer()
        {
            Settings.OnSettingsMissing += new Settings.SettingsMissingEventHandler(Settings_OnSettingsMissing);
            Settings.OnSettingsLoaded += new Settings.SettingsLoadedEventHandler(Settings_OnSettingsLoaded);
            Settings.OnSettingsSaved += new Settings.SettingsSavedEventHandler(Settings_OnSettingsSaved);
            ConnectionManager.OnConnectionEstablished += new ConnectionManager.ConnectionEstablishedEventHandler(ConnectionManager_OnConnectionEstablished);
        }

        void ConnectionManager_OnConnectionEstablished(Connection currentConnection)
        {
            throw new NotImplementedException();
        }

        void Settings_OnSettingsSaved(Settings currentSettings)
        {
            _connectionManager.Connect(currentSettings);
        }

        void Settings_OnSettingsLoaded(Settings currentSettings)
        {
            _connectionManager.Connect(currentSettings);
        }

        void Settings_OnSettingsMissing(Settings currentSettings)
        {
            throw new NotImplementedException();
        }

       
    }
}
