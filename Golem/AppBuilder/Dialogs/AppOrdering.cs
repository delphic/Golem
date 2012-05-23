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
    public partial class AppOrdering : Form
    {
        private JavaScriptAppBuilderManager _manager;
        private JavaScriptApp _app;
        private OrderInformation _originalOrdering;
        private IDictionary<string, string> _fullPathDictionary = new Dictionary<string, string>();

        public AppOrdering(JavaScriptApp app, JavaScriptAppBuilderManager manager)
        {
            if (app == null) throw new ArgumentNullException("app");
            if (manager == null) throw new ArgumentNullException("manager");
            this._app = app;
            this._manager = manager;
            this._originalOrdering = app.OrderInformation;

            InitializeComponent();

            foreach (var directory in app.OrderInformation.Keys)
            {
                var description = directory.Replace(app.RootDirectory, app.Name);
                _fullPathDictionary.Add(description, directory); 
                this.directoryList.Items.Add(description);
            }
            
        }

        private void directoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = this.directoryList.SelectedItem;
            this.itemsList.Items.Clear();
            if (selectedItem != null)
            {
                var selectedPath = _fullPathDictionary[selectedItem.ToString()];
                foreach (var item in _app.OrderInformation[selectedPath])
                {
                    this.itemsList.Items.Add(Path.GetFileName(item.Path));
                }
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (this.itemsList.SelectedItem != null)
            {
                var index = this.itemsList.SelectedIndex;
                var item = this.itemsList.Items[index];
                this.itemsList.Items.RemoveAt(index);
                this.itemsList.Items.Insert(index - 1, item);
                this.itemsList.SelectedIndex = index - 1;

                updateOrderInformation();
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (this.itemsList.SelectedItem != null)
            {
                var index = this.itemsList.SelectedIndex;
                var item = this.itemsList.Items[index];
                this.itemsList.Items.RemoveAt(index);
                this.itemsList.Items.Insert(index + 1, item);
                this.itemsList.SelectedIndex = index + 1;

                updateOrderInformation();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _app.OrderInformation = _originalOrdering;
            this.Close();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            updateOrderInformation();
            this.Close();
        }

        private void updateOrderInformation()
        {
            var key = _fullPathDictionary[this.directoryList.SelectedItem.ToString()];
            var newOrder = new List<OrderItem>();
            foreach (var itemDesc in this.itemsList.Items)
            {
                foreach (var item in this._app.OrderInformation[key])
                {
                    if (item.Path.EndsWith(itemDesc.ToString()))
                    {
                        newOrder.Add(item);
                        break;
                    }
                }
            }
            this._app.OrderInformation[key] = newOrder;
            // Save this information using the manager
            this._manager.OverwriteApp(this._app.Name, this._app);
        }
    }
}
