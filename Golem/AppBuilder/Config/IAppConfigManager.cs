using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golem.AppBuilder.Config
{
    public interface IAppConfigManager
    {
        IList<JavaScriptApp> LoadAppsFromDirectory();
        bool TryLoadApp(string path, ref JavaScriptApp app);
        void SaveApp(JavaScriptApp app, string previousName);
        void DeleteApp(string appName);
    }
}
