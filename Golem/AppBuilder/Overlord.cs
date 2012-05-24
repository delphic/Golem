using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Golem.AppBuilder
{
    public class Overlord : IOverlord
    {
        private Dictionary<string, FileSystemWatcher> _eyes = new Dictionary<string, FileSystemWatcher>();
        
        public void Watch(string appName, string path, FileSystemEventHandler changeHandler) 
        {
            if (!_eyes.ContainsKey(appName))
            {
                this._eyes.Add(appName, new FileSystemWatcher(path));
            }
            else
            {
                this._eyes[appName].Path = path;
            }
            var eye = this._eyes[appName];
            eye.IncludeSubdirectories = true;
            eye.EnableRaisingEvents = true;
            eye.Changed += changeHandler;
            eye.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.DirectoryName | NotifyFilters.FileName;
        }

        public void Unwatch(string appName) 
        { 
            if(this._eyes.ContainsKey(appName))
            {
                this._eyes[appName].EnableRaisingEvents = false;
                this._eyes.Remove(appName);
            }
        }

    }
}
