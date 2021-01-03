
using System.Windows.Forms;

namespace H3VRModInstaller.GUI
{
    partial class mainwindow
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ModList = new System.Windows.Forms.Panel();
            this.InstalledModsLabel = new System.Windows.Forms.Label();
            this.InstalledModsList = new System.Windows.Forms.ListBox();
            this.DownloadableModsLabel = new System.Windows.Forms.Label();
            this.Divider = new System.Windows.Forms.Label();
            this.DownloadableMods = new System.Windows.Forms.ListBox();
            this.modlisttext = new System.Windows.Forms.Label();
            this.launch = new System.Windows.Forms.Button();
            this.ModsEnabled = new System.Windows.Forms.CheckBox();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.ModInfo = new System.Windows.Forms.Label();
            this.ModInformationLabel = new System.Windows.Forms.Label();
            this.Delete = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.InstallButton = new System.Windows.Forms.Button();
            this.SelectedModText = new System.Windows.Forms.Label();
            this.ProgressPanel = new System.Windows.Forms.Panel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.PersentageText = new System.Windows.Forms.Label();
            this.ModList.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.ProgressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModList
            // 
            this.ModList.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))), ((int) (((byte) (224)))));
            this.ModList.Controls.Add(this.InstalledModsLabel);
            this.ModList.Controls.Add(this.InstalledModsList);
            this.ModList.Controls.Add(this.DownloadableModsLabel);
            this.ModList.Controls.Add(this.Divider);
            this.ModList.Controls.Add(this.DownloadableMods);
            this.ModList.Controls.Add(this.modlisttext);
            this.ModList.Location = new System.Drawing.Point(7, 9);
            this.ModList.Name = "ModList";
            this.ModList.Size = new System.Drawing.Size(266, 371);
            this.ModList.TabIndex = 0;
            // 
            // InstalledModsLabel
            // 
            this.InstalledModsLabel.AutoSize = true;
            this.InstalledModsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.InstalledModsLabel.Location = new System.Drawing.Point(66, 212);
            this.InstalledModsLabel.Name = "InstalledModsLabel";
            this.InstalledModsLabel.Size = new System.Drawing.Size(135, 25);
            this.InstalledModsLabel.TabIndex = 5;
            this.InstalledModsLabel.Text = "Installed Mods";
            // 
            // InstalledModsList
            // 
            this.InstalledModsList.FormattingEnabled = true;
            this.InstalledModsList.Location = new System.Drawing.Point(15, 237);
            this.InstalledModsList.MultiColumn = true;
            this.InstalledModsList.Name = "InstalledModsList";
            this.InstalledModsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.InstalledModsList.Size = new System.Drawing.Size(237, 121);
            this.InstalledModsList.TabIndex = 4;
            // 
            // DownloadableModsLabel
            // 
            this.DownloadableModsLabel.AutoSize = true;
            this.DownloadableModsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.DownloadableModsLabel.Location = new System.Drawing.Point(50, 60);
            this.DownloadableModsLabel.Name = "DownloadableModsLabel";
            this.DownloadableModsLabel.Size = new System.Drawing.Size(186, 25);
            this.DownloadableModsLabel.TabIndex = 3;
            this.DownloadableModsLabel.Text = "Downloadable Mods";
            this.DownloadableModsLabel.Click += new System.EventHandler(this.DownloadableModsLabel_Click);
            // 
            // Divider
            // 
            this.Divider.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.Divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Divider.Cursor = System.Windows.Forms.Cursors.Default;
            this.Divider.Location = new System.Drawing.Point(0, 57);
            this.Divider.Name = "Divider";
            this.Divider.Size = new System.Drawing.Size(266, 2);
            this.Divider.TabIndex = 2;
            // 
            // DownloadableMods
            // 
            this.DownloadableMods.FormattingEnabled = true;
            this.DownloadableMods.Location = new System.Drawing.Point(15, 88);
            this.DownloadableMods.MultiColumn = true;
            this.DownloadableMods.Name = "DownloadableMods";
            this.DownloadableMods.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DownloadableMods.Size = new System.Drawing.Size(237, 121);
            this.DownloadableMods.TabIndex = 1;
            // 
            // modlisttext
            // 
            this.modlisttext.AutoSize = true;
            this.modlisttext.Font = new System.Drawing.Font("Segoe UI", 36F);
            this.modlisttext.Location = new System.Drawing.Point(66, 0);
            this.modlisttext.Name = "modlisttext";
            this.modlisttext.Size = new System.Drawing.Size(147, 65);
            this.modlisttext.TabIndex = 0;
            this.modlisttext.Text = "Mods";
            this.modlisttext.Click += new System.EventHandler(this.label1_Click);
            // 
            // launch
            // 
            this.launch.Location = new System.Drawing.Point(278, 336);
            this.launch.Name = "launch";
            this.launch.Size = new System.Drawing.Size(314, 43);
            this.launch.TabIndex = 1;
            this.launch.Text = "Launch H3VR";
            this.launch.UseVisualStyleBackColor = true;
            this.launch.Click += new System.EventHandler(this.launch_Click);
            // 
            // ModsEnabled
            // 
            this.ModsEnabled.AutoSize = true;
            this.ModsEnabled.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ModsEnabled.Location = new System.Drawing.Point(597, 352);
            this.ModsEnabled.Name = "ModsEnabled";
            this.ModsEnabled.Size = new System.Drawing.Size(105, 17);
            this.ModsEnabled.TabIndex = 2;
            this.ModsEnabled.Text = "Mods Enabled?";
            this.ModsEnabled.UseVisualStyleBackColor = true;
            this.ModsEnabled.CheckedChanged += new System.EventHandler(this.ModsEnabled_CheckedChanged);
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))), ((int) (((byte) (224)))));
            this.ControlPanel.Controls.Add(this.InfoPanel);
            this.ControlPanel.Controls.Add(this.Delete);
            this.ControlPanel.Controls.Add(this.UpdateButton);
            this.ControlPanel.Controls.Add(this.InstallButton);
            this.ControlPanel.Controls.Add(this.SelectedModText);
            this.ControlPanel.Location = new System.Drawing.Point(279, 9);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Padding = new System.Windows.Forms.Padding(2);
            this.ControlPanel.Size = new System.Drawing.Size(410, 275);
            this.ControlPanel.TabIndex = 3;
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.White;
            this.InfoPanel.Controls.Add(this.ModInfo);
            this.InfoPanel.Controls.Add(this.ModInformationLabel);
            this.InfoPanel.Location = new System.Drawing.Point(5, 128);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(400, 145);
            this.InfoPanel.TabIndex = 4;
            this.InfoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InfoPanel_Paint);
            // 
            // ModInfo
            // 
            this.ModInfo.Location = new System.Drawing.Point(3, 17);
            this.ModInfo.Name = "ModInfo";
            this.ModInfo.Size = new System.Drawing.Size(382, 128);
            this.ModInfo.TabIndex = 1;
            this.ModInfo.Text = "Mod Info Here!";
            // 
            // ModInformationLabel
            // 
            this.ModInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ModInformationLabel.Location = new System.Drawing.Point(125, -3);
            this.ModInformationLabel.Name = "ModInformationLabel";
            this.ModInformationLabel.Size = new System.Drawing.Size(133, 22);
            this.ModInformationLabel.TabIndex = 0;
            this.ModInformationLabel.Text = "Mod Information";
            this.ModInformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.White;
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Delete.Location = new System.Drawing.Point(5, 96);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(400, 26);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = false;
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.White;
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.UpdateButton.Location = new System.Drawing.Point(5, 64);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(400, 26);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            // 
            // InstallButton
            // 
            this.InstallButton.BackColor = System.Drawing.Color.White;
            this.InstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.InstallButton.Location = new System.Drawing.Point(5, 32);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(400, 26);
            this.InstallButton.TabIndex = 1;
            this.InstallButton.Text = "Install";
            this.InstallButton.UseVisualStyleBackColor = false;
            // 
            // SelectedModText
            // 
            this.SelectedModText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.SelectedModText.Location = new System.Drawing.Point(5, 2);
            this.SelectedModText.Name = "SelectedModText";
            this.SelectedModText.Size = new System.Drawing.Size(388, 20);
            this.SelectedModText.TabIndex = 0;
            this.SelectedModText.Text = "Selected Mod: ";
            this.SelectedModText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressPanel
            // 
            this.ProgressPanel.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))), ((int) (((byte) (224)))));
            this.ProgressPanel.Controls.Add(this.ProgressBar);
            this.ProgressPanel.Controls.Add(this.PersentageText);
            this.ProgressPanel.Location = new System.Drawing.Point(278, 291);
            this.ProgressPanel.Name = "ProgressPanel";
            this.ProgressPanel.Size = new System.Drawing.Size(410, 42);
            this.ProgressPanel.TabIndex = 4;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(4, 11);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(370, 19);
            this.ProgressBar.TabIndex = 1;
            // 
            // PersentageText
            // 
            this.PersentageText.AutoSize = true;
            this.PersentageText.Location = new System.Drawing.Point(378, 15);
            this.PersentageText.Name = "PersentageText";
            this.PersentageText.Size = new System.Drawing.Size(21, 13);
            this.PersentageText.TabIndex = 0;
            this.PersentageText.Text = "0%";
            // 
            // mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 390);
            this.Controls.Add(this.ProgressPanel);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.ModsEnabled);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.ModList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainwindow";
            this.Text = "H3VR Mod Installer";
            this.ModList.ResumeLayout(false);
            this.ModList.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.ProgressPanel.ResumeLayout(false);
            this.ProgressPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label ModInfo;

        private System.Windows.Forms.Label ModInformationLabel;

        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Button UpdateButton;

        private System.Windows.Forms.Button InstallButton;

        #endregion

        private System.Windows.Forms.Panel ModList;
        private System.Windows.Forms.Button launch;
        private System.Windows.Forms.CheckBox ModsEnabled;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Label modlisttext;
        private System.Windows.Forms.Panel ProgressPanel;
        private System.Windows.Forms.Label PersentageText;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.ListBox DownloadableMods;
        private System.Windows.Forms.Label Divider;
        private System.Windows.Forms.Label DownloadableModsLabel;
        private System.Windows.Forms.Label InstalledModsLabel;
        private System.Windows.Forms.ListBox InstalledMods;
        private System.Windows.Forms.ListBox InstallableModsList;
        private System.Windows.Forms.ListBox InstalledModsList;
        private System.Windows.Forms.Label SelectedModText;


        
    }
}

