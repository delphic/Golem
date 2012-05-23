namespace Golem
{
    partial class JavaScriptAppBuilder
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
            this.appsList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.buildButton = new System.Windows.Forms.Button();
            this.orderingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // appsList
            // 
            this.appsList.FormattingEnabled = true;
            this.appsList.ItemHeight = 16;
            this.appsList.Location = new System.Drawing.Point(12, 12);
            this.appsList.Name = "appsList";
            this.appsList.Size = new System.Drawing.Size(199, 196);
            this.appsList.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(217, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(78, 28);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(217, 46);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(78, 28);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(217, 115);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(78, 28);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(217, 180);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(78, 28);
            this.buildButton.TabIndex = 5;
            this.buildButton.Text = "Build";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // orderingButton
            // 
            this.orderingButton.Location = new System.Drawing.Point(217, 80);
            this.orderingButton.Name = "orderingButton";
            this.orderingButton.Size = new System.Drawing.Size(78, 29);
            this.orderingButton.TabIndex = 6;
            this.orderingButton.Text = "Ordering";
            this.orderingButton.UseVisualStyleBackColor = true;
            this.orderingButton.Click += new System.EventHandler(this.orderingButton_Click);
            // 
            // JavaScriptAppBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 220);
            this.Controls.Add(this.orderingButton);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.appsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "JavaScriptAppBuilder";
            this.Text = "Golem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox appsList;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.Button orderingButton;
    }
}