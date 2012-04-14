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
        private JavaScriptApp app;
        private OrderInformation originalOrdering;
        private IDictionary<string, string> fullPathDictionary = new Dictionary<string, string>();

        public AppOrdering(JavaScriptApp app)
        {
            if (app == null) throw new ArgumentNullException("app");
            this.app = app;
            this.originalOrdering = app.OrderInformation;

            InitializeComponent();

            foreach (var directory in app.OrderInformation.Keys)
            {
                var description = directory.Replace(app.RootDirectory, app.Name);
                fullPathDictionary.Add(description, directory); 
                this.directoryList.Items.Add(description);
            }
            
        }

        private void directoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = this.directoryList.SelectedItem;
            this.itemsList.Items.Clear();
            if (selectedItem != null)
            {
                var selectedPath = fullPathDictionary[selectedItem.ToString()];
                foreach (var item in app.OrderInformation[selectedPath])
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
            app.OrderInformation = originalOrdering;
            this.Close();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            updateOrderInformation();
            this.Close();
        }

        private void updateOrderInformation()
        {
            var key = fullPathDictionary[this.directoryList.SelectedItem.ToString()];
            var newOrder = new List<OrderItem>();
            foreach (var itemDesc in this.itemsList.Items)
            {
                foreach (var item in this.app.OrderInformation[key])
                {
                    if (item.Path.EndsWith(itemDesc.ToString()))
                    {
                        newOrder.Add(item);
                        break;
                    }
                }
            }
            this.app.OrderInformation[key] = newOrder;
        }
    }
}
