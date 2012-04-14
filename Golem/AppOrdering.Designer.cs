namespace Golem
{
    partial class AppOrdering
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemsList = new System.Windows.Forms.ListBox();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.directoryList = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemsList
            // 
            this.itemsList.FormattingEnabled = true;
            this.itemsList.ItemHeight = 16;
            this.itemsList.Location = new System.Drawing.Point(12, 42);
            this.itemsList.Name = "itemsList";
            this.itemsList.Size = new System.Drawing.Size(217, 164);
            this.itemsList.TabIndex = 0;
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(235, 42);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(68, 50);
            this.upButton.TabIndex = 2;
            this.upButton.Text = "Move Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(235, 156);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(68, 50);
            this.downButton.TabIndex = 3;
            this.downButton.Text = "Move Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // directoryList
            // 
            this.directoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directoryList.FormattingEnabled = true;
            this.directoryList.Location = new System.Drawing.Point(12, 12);
            this.directoryList.Name = "directoryList";
            this.directoryList.Size = new System.Drawing.Size(291, 24);
            this.directoryList.TabIndex = 1;
            this.directoryList.SelectedIndexChanged += new System.EventHandler(this.directoryList_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(13, 216);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 25);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(159, 216);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(142, 25);
            this.okayButton.TabIndex = 5;
            this.okayButton.Text = "Save";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // AppOrdering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 251);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.directoryList);
            this.Controls.Add(this.itemsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AppOrdering";
            this.Text = "Ordering";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox itemsList;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.ComboBox directoryList;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okayButton;

    }
}