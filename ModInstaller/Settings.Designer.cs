
namespace H3VRModInstaller
{
    partial class Settings
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
            this.SettingsPanelTitle = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.Panel();
            this.DatabaseInfoSelector = new System.Windows.Forms.Button();
            this.DatabaseInfoLocationText = new System.Windows.Forms.TextBox();
            this.GameDirectoryText = new System.Windows.Forms.TextBox();
            this.GameDirectorySelector = new System.Windows.Forms.Button();
            this.DatabaseInfoLabel = new System.Windows.Forms.Label();
            this.GameDirectoryLabel = new System.Windows.Forms.Label();
            this.SaveConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SettingsPanelTitle
            // 
            this.SettingsPanelTitle.AutoSize = true;
            this.SettingsPanelTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SettingsPanelTitle.Location = new System.Drawing.Point(93, 9);
            this.SettingsPanelTitle.Name = "SettingsPanelTitle";
            this.SettingsPanelTitle.Size = new System.Drawing.Size(84, 25);
            this.SettingsPanelTitle.TabIndex = 0;
            this.SettingsPanelTitle.Text = "Settings";
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.line.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.line.Location = new System.Drawing.Point(-28, 37);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(372, 1);
            this.line.TabIndex = 1;
            // 
            // DatabaseInfoSelector
            // 
            this.DatabaseInfoSelector.Location = new System.Drawing.Point(239, 59);
            this.DatabaseInfoSelector.Name = "DatabaseInfoSelector";
            this.DatabaseInfoSelector.Size = new System.Drawing.Size(33, 23);
            this.DatabaseInfoSelector.TabIndex = 2;
            this.DatabaseInfoSelector.Text = "...";
            this.DatabaseInfoSelector.UseVisualStyleBackColor = true;
            this.DatabaseInfoSelector.Click += new System.EventHandler(this.DatabaseInfoSelector_Click);
            // 
            // DatabaseInfoLocationText
            // 
            this.DatabaseInfoLocationText.Location = new System.Drawing.Point(12, 59);
            this.DatabaseInfoLocationText.Name = "DatabaseInfoLocationText";
            this.DatabaseInfoLocationText.Size = new System.Drawing.Size(221, 23);
            this.DatabaseInfoLocationText.TabIndex = 3;
            this.DatabaseInfoLocationText.Text = "Database Info Location not specified";
            // 
            // GameDirectoryText
            // 
            this.GameDirectoryText.Location = new System.Drawing.Point(12, 103);
            this.GameDirectoryText.Name = "GameDirectoryText";
            this.GameDirectoryText.Size = new System.Drawing.Size(221, 23);
            this.GameDirectoryText.TabIndex = 5;
            this.GameDirectoryText.Text = "Game Directory not specified";
            // 
            // GameDirectorySelector
            // 
            this.GameDirectorySelector.Location = new System.Drawing.Point(239, 103);
            this.GameDirectorySelector.Name = "GameDirectorySelector";
            this.GameDirectorySelector.Size = new System.Drawing.Size(33, 23);
            this.GameDirectorySelector.TabIndex = 4;
            this.GameDirectorySelector.Text = "...";
            this.GameDirectorySelector.UseVisualStyleBackColor = true;
            this.GameDirectorySelector.Click += new System.EventHandler(this.GameDirectorySelector_Click);
            // 
            // DatabaseInfoLabel
            // 
            this.DatabaseInfoLabel.AutoSize = true;
            this.DatabaseInfoLabel.Location = new System.Drawing.Point(71, 41);
            this.DatabaseInfoLabel.Name = "DatabaseInfoLabel";
            this.DatabaseInfoLabel.Size = new System.Drawing.Size(128, 15);
            this.DatabaseInfoLabel.TabIndex = 6;
            this.DatabaseInfoLabel.Text = "Database Info Location";
            // 
            // GameDirectoryLabel
            // 
            this.GameDirectoryLabel.AutoSize = true;
            this.GameDirectoryLabel.Location = new System.Drawing.Point(71, 85);
            this.GameDirectoryLabel.Name = "GameDirectoryLabel";
            this.GameDirectoryLabel.Size = new System.Drawing.Size(116, 15);
            this.GameDirectoryLabel.TabIndex = 7;
            this.GameDirectoryLabel.Text = "Game Directory Path";
            // 
            // SaveConfig
            // 
            this.SaveConfig.Location = new System.Drawing.Point(93, 132);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(75, 23);
            this.SaveConfig.TabIndex = 8;
            this.SaveConfig.Text = "Save";
            this.SaveConfig.UseVisualStyleBackColor = true;
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.SaveConfig);
            this.Controls.Add(this.GameDirectoryLabel);
            this.Controls.Add(this.DatabaseInfoLabel);
            this.Controls.Add(this.GameDirectoryText);
            this.Controls.Add(this.GameDirectorySelector);
            this.Controls.Add(this.DatabaseInfoLocationText);
            this.Controls.Add(this.DatabaseInfoSelector);
            this.Controls.Add(this.line);
            this.Controls.Add(this.SettingsPanelTitle);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SettingsPanelTitle;
        private System.Windows.Forms.Panel line;
        private System.Windows.Forms.Button DatabaseInfoSelector;
        private System.Windows.Forms.TextBox DatabaseInfoLocationText;
        private System.Windows.Forms.TextBox GameDirectoryText;
        private System.Windows.Forms.Button GameDirectorySelector;
        private System.Windows.Forms.Label DatabaseInfoLabel;
        private System.Windows.Forms.Label GameDirectoryLabel;
        private System.Windows.Forms.Button SaveConfig;
    }
}