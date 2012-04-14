namespace Golem
{
    partial class AddEditApp
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
            this.rootDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseRootButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rootDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.browseOutputButton = new System.Windows.Forms.Button();
            this.outputDirectory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.appName = new System.Windows.Forms.TextBox();
            this.includeLowerCaseCheck = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okayButton = new System.Windows.Forms.Button();
            this.outputDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // rootDirectory
            // 
            this.rootDirectory.Location = new System.Drawing.Point(12, 29);
            this.rootDirectory.Name = "rootDirectory";
            this.rootDirectory.Size = new System.Drawing.Size(300, 22);
            this.rootDirectory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Root Directory";
            // 
            // browseRootButton
            // 
            this.browseRootButton.Location = new System.Drawing.Point(318, 25);
            this.browseRootButton.Name = "browseRootButton";
            this.browseRootButton.Size = new System.Drawing.Size(87, 26);
            this.browseRootButton.TabIndex = 2;
            this.browseRootButton.Text = "Browse...";
            this.browseRootButton.UseVisualStyleBackColor = true;
            this.browseRootButton.Click += new System.EventHandler(this.browseRootButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Directory";
            // 
            // browseOutputButton
            // 
            this.browseOutputButton.Location = new System.Drawing.Point(318, 70);
            this.browseOutputButton.Name = "browseOutputButton";
            this.browseOutputButton.Size = new System.Drawing.Size(87, 26);
            this.browseOutputButton.TabIndex = 5;
            this.browseOutputButton.Text = "Browse...";
            this.browseOutputButton.UseVisualStyleBackColor = true;
            this.browseOutputButton.Click += new System.EventHandler(this.browseOutputButton_Click);
            // 
            // outputDirectory
            // 
            this.outputDirectory.Location = new System.Drawing.Point(12, 74);
            this.outputDirectory.Name = "outputDirectory";
            this.outputDirectory.Size = new System.Drawing.Size(300, 22);
            this.outputDirectory.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "App Name";
            // 
            // appName
            // 
            this.appName.Location = new System.Drawing.Point(12, 119);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(300, 22);
            this.appName.TabIndex = 7;
            // 
            // includeLowerCaseCheck
            // 
            this.includeLowerCaseCheck.AutoSize = true;
            this.includeLowerCaseCheck.Location = new System.Drawing.Point(12, 147);
            this.includeLowerCaseCheck.Name = "includeLowerCaseCheck";
            this.includeLowerCaseCheck.Size = new System.Drawing.Size(294, 21);
            this.includeLowerCaseCheck.TabIndex = 8;
            this.includeLowerCaseCheck.Text = "Include lowercase files in return statement";
            this.includeLowerCaseCheck.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(215, 172);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(190, 26);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(12, 174);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(190, 26);
            this.okayButton.TabIndex = 10;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // AddEditApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 210);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.includeLowerCaseCheck);
            this.Controls.Add(this.appName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.browseOutputButton);
            this.Controls.Add(this.outputDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseRootButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rootDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddEditApp";
            this.Text = "Add JavaScript Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rootDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseRootButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog rootDirectoryDialog;
        private System.Windows.Forms.Button browseOutputButton;
        private System.Windows.Forms.TextBox outputDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox appName;
        private System.Windows.Forms.CheckBox includeLowerCaseCheck;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.FolderBrowserDialog outputDirectoryDialog;
    }
}