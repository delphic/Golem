using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Golem.AppBuilder.Config;

namespace Golem
{
    static class Golem
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // For now just launch the JavaScript App Builder Dialog
            // in future we hope for several tools
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new JavaScriptAppBuilder());
        }
    }
}
