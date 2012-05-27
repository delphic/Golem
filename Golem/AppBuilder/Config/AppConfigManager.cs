using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Golem.AppBuilder.Config
{
    public class AppConfigManager : IAppConfigManager
    {
        private string _saveDirectory;

        #region Constructor

        public AppConfigManager()
        {
            this._saveDirectory = Directory.GetCurrentDirectory() + @"\SavedApps\";
        }

        #endregion

        #region IAppConfigManager Members

        public IList<JavaScriptApp> LoadAppsFromDirectory() 
        {
            var apps = new List<JavaScriptApp>();
            if (Directory.Exists(_saveDirectory))
            {
                var filePaths = Directory.EnumerateFiles(_saveDirectory);
                foreach (var filePath in filePaths)
                {
                    var app = new JavaScriptApp();
                    if (TryLoadApp(filePath, ref app))
                    {
                        apps.Add(app);
                    }
                }
            }
            return apps;
        }

        public bool TryLoadApp(string path, ref JavaScriptApp app)
        {
            var result = false;
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                try
                {
                    var serialiser = new XmlSerializer(typeof(AppConfig));
                    if (Path.GetExtension(path) == ".xml")
                    {
                        AssignAppInformation((AppConfig)serialiser.Deserialize(fileStream), ref app);
                        result = true;
                    }
                }
                catch (Exception)
                {
                    // Pokemon
                }
            }
            return result;
        }        

        public void SaveApp(JavaScriptApp app, string previousName)
        {
            
            if (previousName != null)
            {
                File.Delete(_saveDirectory + previousName + ".xml");
            }
            if (!Directory.Exists(_saveDirectory)) 
            {
                Directory.CreateDirectory(_saveDirectory);
            }
            var targetPath = _saveDirectory + app.Name + ".xml";

            using (var fileStream = new FileStream(targetPath, FileMode.Create))
            {
                var xmlSerialiser = new XmlSerializer(typeof(AppConfig));
                var xml = new AppConfig(app.Name, app.RootDirectory, app.OutputDirectory, app.OrderInformation, app.IncludeLowerCase);
                xmlSerialiser.Serialize(fileStream, xml);
            }
        }

        public void DeleteApp(string appName)
        {
            File.Delete(_saveDirectory + appName + ".xml");
        }

        #endregion

        #region Private Functions

        private void AssignAppInformation(AppConfig config, ref JavaScriptApp app)
        {
            app.Name = config.Name;
            app.RootDirectory = config.RootDirectory;
            app.OutputDirectory = config.OutputDirectory;
            app.IncludeLowerCase = config.IncludeLowercase;
            app.OrderInformation = config.GetOrderInformation();
        }

        #endregion
    }
}
