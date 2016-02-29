using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace EventHandlerExplorer
{
    /// <summary>
    /// Application settings
    /// </summary>
    public class Settings
    {
#pragma warning disable 1591
        [XmlElement("LoadWebsOnStart")]
        public bool LoadWebsOnStart { get; set; }
        [XmlElement("AutoIisReset")]
        public bool AutoIisReset { get; set; }
        [XmlElement("ScriptGacInstall")]
        public string ScriptGacInstall { get; set; }
        [XmlElement("ScriptGacRemove")]
        public string ScriptGacRemove { get; set; }
        [XmlIgnore]
        public string ScriptIisReset { get; set; }
#pragma warning restore 1591

        private readonly FormMain parent;

        /// <summary>
        /// Default settings
        /// </summary>
        public Settings()
        {
            // Default settings
            LoadWebsOnStart = false;
            AutoIisReset = false;
            ScriptGacInstall= @"[System.Reflection.Assembly]::Load('System.EnterpriseServices, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a');$publish = New-Object System.EnterpriseServices.Internal.Publish;$publish.GacInstall('$fullpath');";
            ScriptGacRemove = @"[System.Reflection.Assembly]::Load('System.EnterpriseServices, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a');$publish = New-Object System.EnterpriseServices.Internal.Publish;$publish.GacRemove('$fullpath');";
            ScriptIisReset = @"iisreset /noforce";
        }

        /// <summary>
        /// Initialize parent to log to listview
        /// </summary>
        public Settings(FormMain form) : this()
        {
            this.parent = form;
        }
        
        /// <summary>
        /// Settings Folder, static property
        /// </summary>
        private static string SettingsFolder
        {
            get
            {
                string folder = string.Empty;

                try
                {
                    folder = Environment.CurrentDirectory;
                }
                catch
                {
                    // Just in case, handle permissions issue. "User\ApplicationData" will have permissions in any case
                    folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                }

                return folder;
            }
        }

        /// <summary>
        /// Settings File, static property
        /// </summary>
        private static string SettingsFile
        {
            get
            {
                return Path.Combine(SettingsFolder, "EventHandlerExplorerSettings.xml");
            }
        }

        /// <summary>
        /// Deserialize settings
        /// </summary>
        public void LoadSettings()
        {
            try
            {
                if (File.Exists(SettingsFile))
                {
                    using (Stream stream = File.OpenRead(SettingsFile))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                        Settings settings = new Settings();
                        settings = (Settings)serializer.Deserialize(stream);

                        this.LoadWebsOnStart = settings.LoadWebsOnStart;
                        this.AutoIisReset = settings.AutoIisReset;
                        this.ScriptGacInstall = settings.ScriptGacInstall;
                        this.ScriptGacRemove = settings.ScriptGacRemove;
                    }
                }
            }
            catch (Exception ex)
            {
                parent.Logger("Exception loading settings, will use standard options.", Color.LightBlue);
                parent.Logger("Exception: " + ex.ToString(), Color.LightBlue);
            }
        }

        /// <summary>
        /// Serialize settings
        /// </summary>
        public void SaveSettings()
        {
            try
            {
                using (Stream stream = File.Create(SettingsFile))
                {
                    XmlSerializer s = new XmlSerializer(this.GetType());
                    s.Serialize(stream, this);
                }
            }
            catch (Exception ex)
            {
                parent.Logger("Exception from Settings, Saving: " + ex.ToString(), Color.LightBlue);
            }
        }
    }
}
