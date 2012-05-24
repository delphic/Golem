using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Golem
{
    // Arguably should not have a dual purpose dialog
    public partial class AddEditApp : Form
    {
        private JavaScriptApp _selectedApp;
        private Action<string> _updateParentDialog;
        private JavaScriptAppBuilderManager _javaScriptAppBuilder;

        public AddEditApp(JavaScriptAppBuilderManager javaScriptAppBuilder, Action<string> updateParentDialog)
        {
            if (javaScriptAppBuilder == null) { throw new ArgumentNullException("javaScriptAppBuidler"); }
            if (updateParentDialog == null) { throw new ArgumentNullException("updateParentDialog"); }

            this._selectedApp = null;
            this._updateParentDialog = updateParentDialog;
            this._javaScriptAppBuilder = javaScriptAppBuilder;

            InitializeComponent();            
        }

        public AddEditApp(string selectedAppName, JavaScriptAppBuilderManager javaScriptAppBuilder)
        {
            if (javaScriptAppBuilder == null) { throw new ArgumentNullException("javaScriptAppBuilder"); }
            
            this._selectedApp = javaScriptAppBuilder.GetApp(selectedAppName);
            this._javaScriptAppBuilder = javaScriptAppBuilder;
            this._updateParentDialog = null;
            InitializeComponent();
            SetDialogValues(this._selectedApp);
        }

        private void SetDialogValues(JavaScriptApp app)
        {
            this.rootDirectory.Text = app.RootDirectory;
            this.outputDirectory.Text = app.OutputDirectory;
            this.includeLowerCaseCheck.Checked = app.IncludeLowerCase;
            this.appName.Text = app.Name;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) 
            {
                MessageBox.Show(this, "Please ensure you have filled in all the inputs", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; 
            }
            var app = new JavaScriptApp(this.appName.Text, this.rootDirectory.Text, this.outputDirectory.Text, this.includeLowerCaseCheck.Checked);
            
            if (_selectedApp != null)
            {
                this._javaScriptAppBuilder.OverwriteApp(_selectedApp.Name, app);
            }
            else
            {
                this._javaScriptAppBuilder.AddApp(app);
            }

            if (this._updateParentDialog != null)
            {
                this._updateParentDialog(app.Name);
            }

            this.Close();
        }

        private bool ValidateInputs()
        {
            return (!String.IsNullOrEmpty(this.appName.Text) 
                && !String.IsNullOrEmpty(this.rootDirectory.Text) 
                && !String.IsNullOrEmpty(this.outputDirectory.Text));
        }

        private void browseRootButton_Click(object sender, EventArgs e)
        {
            if (rootDirectoryDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.rootDirectory.Text = rootDirectoryDialog.SelectedPath;
                this.outputDirectory.Text = Directory.GetParent(rootDirectoryDialog.SelectedPath) != null 
                    ? Directory.GetParent(rootDirectoryDialog.SelectedPath).ToString() : "";                
                this.appName.Text = Path.GetFileName(this.rootDirectory.Text);
            }
        }

        private void browseOutputButton_Click(object sender, EventArgs e)
        {
            if (outputDirectoryDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.outputDirectory.Text = outputDirectoryDialog.SelectedPath;
            }
        }
    }
}
