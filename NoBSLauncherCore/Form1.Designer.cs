namespace NoBSLauncherCore
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.modLabel = new System.Windows.Forms.Label();
            this.dlcLabel = new System.Windows.Forms.Label();
            this.launchButton = new System.Windows.Forms.Button();
            this.debugLaunchButton = new System.Windows.Forms.Button();
            this.disableAllModsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // modLabel
            // 
            this.modLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.modLabel.AutoSize = true;
            this.modLabel.BackColor = System.Drawing.Color.Transparent;
            this.modLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modLabel.Location = new System.Drawing.Point(182, 5);
            this.modLabel.Name = "modLabel";
            this.modLabel.Size = new System.Drawing.Size(46, 20);
            this.modLabel.TabIndex = 0;
            this.modLabel.Text = "Mods";
            this.modLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dlcLabel
            // 
            this.dlcLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dlcLabel.AutoSize = true;
            this.dlcLabel.BackColor = System.Drawing.Color.Transparent;
            this.dlcLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dlcLabel.Location = new System.Drawing.Point(582, 5);
            this.dlcLabel.Name = "dlcLabel";
            this.dlcLabel.Size = new System.Drawing.Size(35, 20);
            this.dlcLabel.TabIndex = 1;
            this.dlcLabel.Text = "DLC";
            this.dlcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // launchButton
            // 
            this.launchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.launchButton.Location = new System.Drawing.Point(713, 415);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(75, 23);
            this.launchButton.TabIndex = 2;
            this.launchButton.Text = "Launch";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // debugLaunchButton
            // 
            this.debugLaunchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.debugLaunchButton.AutoSize = true;
            this.debugLaunchButton.Location = new System.Drawing.Point(614, 415);
            this.debugLaunchButton.Name = "debugLaunchButton";
            this.debugLaunchButton.Size = new System.Drawing.Size(94, 25);
            this.debugLaunchButton.TabIndex = 3;
            this.debugLaunchButton.Text = "Launch Debug";
            this.debugLaunchButton.UseVisualStyleBackColor = true;
            this.debugLaunchButton.Click += new System.EventHandler(this.debugLaunchButton_Click);
            // 
            // disableAllModsButton
            // 
            this.disableAllModsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.disableAllModsButton.AutoSize = true;
            this.disableAllModsButton.Location = new System.Drawing.Point(12, 415);
            this.disableAllModsButton.Name = "disableAllModsButton";
            this.disableAllModsButton.Size = new System.Drawing.Size(105, 25);
            this.disableAllModsButton.TabIndex = 4;
            this.disableAllModsButton.Text = "Disable All Mods";
            this.disableAllModsButton.UseVisualStyleBackColor = true;
            this.disableAllModsButton.Click += new System.EventHandler(this.disableAllModsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.disableAllModsButton);
            this.Controls.Add(this.debugLaunchButton);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.dlcLabel);
            this.Controls.Add(this.modLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "No BS Launcher";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label modLabel;
        private Label dlcLabel;
        private Button launchButton;
        private Button debugLaunchButton;
        private Button disableAllModsButton;
    }
}