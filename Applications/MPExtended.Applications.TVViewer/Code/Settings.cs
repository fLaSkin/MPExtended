using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPExtended.Applications.TVViewer.Code
{
    public class Settings
    {
        public bool UseLocalTAS { get; private set; }
        public string TASAdress { get; private set; }
        public bool UseTranscoding { get; private set; }
        public string TranscodingProfile { get; private set; }

        public delegate void SettingsMissingEventHandler(Settings currentSettings);
        public static event SettingsMissingEventHandler OnSettingsMissing;
        public delegate void SettingsSavedEventHandler(Settings currentSettings);
        public static event SettingsSavedEventHandler OnSettingsSaved;
        public delegate void SettingsLoadedEventHandler(Settings currentSettings);
        public static event SettingsLoadedEventHandler OnSettingsLoaded;

        public Settings()
        {
            if (_loadSettings())
            {
                if (OnSettingsLoaded != null)
                    OnSettingsLoaded(this);
            }
            else
            {
                if (OnSettingsMissing != null)
                    OnSettingsMissing(this);
            
            }
        }

        private bool _loadSettings()
        {
        
            return true;
        }
        public void SaveSettings(bool useLocalTAS, string tasAdress,bool useTranscoding, string transcodingProfile)
        {
            UseLocalTAS = useLocalTAS;
            TASAdress = tasAdress;
            UseTranscoding = useTranscoding;
            TranscodingProfile = transcodingProfile;

            if (_saveSettings())
            {
                if (OnSettingsSaved != null)
                    OnSettingsSaved(this);
            }

        }

        private bool _saveSettings()
        {
            return true;
        }


    }
}
