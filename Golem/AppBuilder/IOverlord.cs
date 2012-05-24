using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Golem.AppBuilder
{
    /// <summary>
    /// Watches directories for changes, 
    /// if you can't have fun naming classes in your
    /// personal projects...
    /// </summary>
    public interface IOverlord
    {
        void Watch(string appName, string path, FileSystemEventHandler changeHandler);
        void Unwatch(string appName);
    }
}
