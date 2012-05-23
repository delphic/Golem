using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Golem.AppBuilder.Config;

namespace Golem
{
    public partial class JavaScriptAppBuilder : Form
    {
        // Why u no use interface?
        private JavaScriptAppBuilderManager _javaScriptAppBuilderManager;
        
        public JavaScriptAppBuilder()
        {
            this._javaScriptAppBuilderManager = new JavaScriptAppBuilderManager(new AppConfigManager());
            InitializeComponent();
            this.appsList.Items.AddRange(this._javaScriptAppBuilderManager.GetAllAppNames().ToArray());
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditApp(this._javaScriptAppBuilderManager, x => this.appsList.Items.Add(x));
            addForm.ShowDialog(this);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            this._javaScriptAppBuilderManager.RemoveApp(this.appsList.SelectedItem.ToString());
            this.appsList.Items.Remove(this.appsList.SelectedItem.ToString());
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.appsList.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select an app to edit", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var editForm = new AddEditApp(this.appsList.SelectedItem.ToString(), this._javaScriptAppBuilderManager);
                editForm.Text = "Edit JavaScript Application";
                editForm.ShowDialog(this);
            }
        }

        private void orderingButton_Click(object sender, EventArgs e)
        {
            if (this.appsList.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select an app to edit", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var orderingForm = new AppOrdering(
                    this._javaScriptAppBuilderManager.GetApp(this.appsList.SelectedItem.ToString()), 
                    this._javaScriptAppBuilderManager); 
                orderingForm.ShowDialog(this);
            }
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            if (this.appsList.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select an app to build", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var appName = this.appsList.SelectedItem.ToString();
                try
                {
                    this._javaScriptAppBuilderManager.BuildApp(appName); // TODO: Add Spinner
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, String.Format("Something went wrong. '{0}'", ex.Message), "Oh Noes!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show(this, String.Format("Successfully built '{0}'", appName), "Huzzah!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
