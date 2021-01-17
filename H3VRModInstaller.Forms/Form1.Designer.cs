
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
			this.InstalledModsList = new System.Windows.Forms.ListView();
			this.InstalledModName = new System.Windows.Forms.ColumnHeader();
			this.InstalledModVersion = new System.Windows.Forms.ColumnHeader();
			this.InstalledModAuthor = new System.Windows.Forms.ColumnHeader();
			this.DownloadableModsButton = new System.Windows.Forms.Button();
			this.InstalledMods = new System.Windows.Forms.Button();
			this.DownloadableModsList = new System.Windows.Forms.ListView();
			this.ModName = new System.Windows.Forms.ColumnHeader();
			this.ModVersion = new System.Windows.Forms.ColumnHeader();
			this.ModAuthor = new System.Windows.Forms.ColumnHeader();
			this.Divider = new System.Windows.Forms.Label();
			this.modlisttext = new System.Windows.Forms.Label();
			this.launch = new System.Windows.Forms.Button();
			this.ModsEnabled = new System.Windows.Forms.CheckBox();
			this.ControlPanel = new System.Windows.Forms.Panel();
			this.CheckButton = new System.Windows.Forms.Button();
			this.ModVer = new System.Windows.Forms.Label();
			this.InfoPanel = new System.Windows.Forms.Panel();
			this.ModInfo = new System.Windows.Forms.Label();
			this.ModInformationLabel = new System.Windows.Forms.Label();
			this.Delete = new System.Windows.Forms.Button();
			this.UpdateButton = new System.Windows.Forms.Button();
			this.InstallButton = new System.Windows.Forms.Button();
			this.SelectedModText = new System.Windows.Forms.Label();
			this.ProgressPanel = new System.Windows.Forms.Panel();
			this.StatusReport = new System.Windows.Forms.Label();
			this.Terminator = new System.ComponentModel.BackgroundWorker();
			this.CatagoriesList = new System.Windows.Forms.ListView();
			this.CatagoryName = new System.Windows.Forms.ColumnHeader();
			this.CatagoryDropDown = new System.Windows.Forms.ComboBox();
			this.CatagoriesComboBox = new System.Windows.Forms.ComboBox();
			this.ModList.SuspendLayout();
			this.ControlPanel.SuspendLayout();
			this.InfoPanel.SuspendLayout();
			this.ProgressPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ModList
			// 
			this.ModList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ModList.Controls.Add(this.CatagoriesComboBox);
			this.ModList.Controls.Add(this.InstalledModsList);
			this.ModList.Controls.Add(this.DownloadableModsButton);
			this.ModList.Controls.Add(this.InstalledMods);
			this.ModList.Controls.Add(this.DownloadableModsList);
			this.ModList.Controls.Add(this.Divider);
			this.ModList.Controls.Add(this.modlisttext);
			this.ModList.Location = new System.Drawing.Point(13, 12);
			this.ModList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.ModList.Name = "ModList";
			this.ModList.Size = new System.Drawing.Size(424, 555);
			this.ModList.TabIndex = 0;
			this.ModList.Paint += new System.Windows.Forms.PaintEventHandler(this.ModList_Paint);
			// 
			// InstalledModsList
			// 
			this.InstalledModsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InstalledModName,
            this.InstalledModVersion,
            this.InstalledModAuthor});
			this.InstalledModsList.FullRowSelect = true;
			this.InstalledModsList.GridLines = true;
			this.InstalledModsList.HideSelection = false;
			this.InstalledModsList.Location = new System.Drawing.Point(18, 127);
			this.InstalledModsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.InstalledModsList.Name = "InstalledModsList";
			this.InstalledModsList.Size = new System.Drawing.Size(390, 416);
			this.InstalledModsList.TabIndex = 7;
			this.InstalledModsList.UseCompatibleStateImageBehavior = false;
			this.InstalledModsList.View = System.Windows.Forms.View.Details;
			this.InstalledModsList.SelectedIndexChanged += new System.EventHandler(this.InstalledModsList_SelectedIndexChanged);
			// 
			// InstalledModName
			// 
			this.InstalledModName.Name = "InstalledModName";
			this.InstalledModName.Text = "Name";
			this.InstalledModName.Width = 200;
			// 
			// InstalledModVersion
			// 
			this.InstalledModVersion.Name = "InstalledModVersion";
			this.InstalledModVersion.Text = "Version";
			this.InstalledModVersion.Width = 75;
			// 
			// InstalledModAuthor
			// 
			this.InstalledModAuthor.Name = "InstalledModAuthor";
			this.InstalledModAuthor.Text = "Author";
			this.InstalledModAuthor.Width = 100;
			// 
			// DownloadableModsButton
			// 
			this.DownloadableModsButton.BackColor = System.Drawing.Color.White;
			this.DownloadableModsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.DownloadableModsButton.Location = new System.Drawing.Point(18, 103);
			this.DownloadableModsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.DownloadableModsButton.Name = "DownloadableModsButton";
			this.DownloadableModsButton.Size = new System.Drawing.Size(193, 27);
			this.DownloadableModsButton.TabIndex = 6;
			this.DownloadableModsButton.Text = "Downloadable Mods";
			this.DownloadableModsButton.UseVisualStyleBackColor = false;
			this.DownloadableModsButton.Click += new System.EventHandler(this.DownloadableModsButton_Click);
			// 
			// InstalledMods
			// 
			this.InstalledMods.BackColor = System.Drawing.Color.White;
			this.InstalledMods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InstalledMods.Location = new System.Drawing.Point(208, 103);
			this.InstalledMods.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.InstalledMods.Name = "InstalledMods";
			this.InstalledMods.Size = new System.Drawing.Size(200, 27);
			this.InstalledMods.TabIndex = 5;
			this.InstalledMods.Text = "Installed Mods";
			this.InstalledMods.UseVisualStyleBackColor = false;
			this.InstalledMods.Click += new System.EventHandler(this.InstalledMods_Click);
			// 
			// DownloadableModsList
			// 
			this.DownloadableModsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ModName,
            this.ModVersion,
            this.ModAuthor});
			this.DownloadableModsList.FullRowSelect = true;
			this.DownloadableModsList.GridLines = true;
			this.DownloadableModsList.HideSelection = false;
			this.DownloadableModsList.Location = new System.Drawing.Point(18, 127);
			this.DownloadableModsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.DownloadableModsList.Name = "DownloadableModsList";
			this.DownloadableModsList.Size = new System.Drawing.Size(390, 416);
			this.DownloadableModsList.TabIndex = 6;
			this.DownloadableModsList.UseCompatibleStateImageBehavior = false;
			this.DownloadableModsList.View = System.Windows.Forms.View.Details;
			this.DownloadableModsList.SelectedIndexChanged += new System.EventHandler(this.DownloadableModsList_SelectedIndexChanged);
			// 
			// ModName
			// 
			this.ModName.Name = "ModName";
			this.ModName.Text = "Name";
			this.ModName.Width = 200;
			// 
			// ModVersion
			// 
			this.ModVersion.Name = "ModVersion";
			this.ModVersion.Text = "Version";
			this.ModVersion.Width = 75;
			// 
			// ModAuthor
			// 
			this.ModAuthor.Name = "ModAuthor";
			this.ModAuthor.Text = "Author";
			this.ModAuthor.Width = 100;
			// 
			// Divider
			// 
			this.Divider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.Divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Divider.Cursor = System.Windows.Forms.Cursors.Default;
			this.Divider.Location = new System.Drawing.Point(0, 66);
			this.Divider.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Divider.Name = "Divider";
			this.Divider.Size = new System.Drawing.Size(500, 2);
			this.Divider.TabIndex = 2;
			// 
			// modlisttext
			// 
			this.modlisttext.AutoSize = true;
			this.modlisttext.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.modlisttext.Location = new System.Drawing.Point(133, 3);
			this.modlisttext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.modlisttext.Name = "modlisttext";
			this.modlisttext.Size = new System.Drawing.Size(147, 65);
			this.modlisttext.TabIndex = 0;
			this.modlisttext.Text = "Mods";
			this.modlisttext.Click += new System.EventHandler(this.label1_Click);
			// 
			// launch
			// 
			this.launch.Location = new System.Drawing.Point(476, 516);
			this.launch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.launch.Name = "launch";
			this.launch.Size = new System.Drawing.Size(366, 50);
			this.launch.TabIndex = 1;
			this.launch.Text = "Launch H3VR";
			this.launch.UseVisualStyleBackColor = true;
			this.launch.Click += new System.EventHandler(this.launch_Click);
			// 
			// ModsEnabled
			// 
			this.ModsEnabled.AutoSize = true;
			this.ModsEnabled.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ModsEnabled.Location = new System.Drawing.Point(850, 538);
			this.ModsEnabled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.ModsEnabled.Name = "ModsEnabled";
			this.ModsEnabled.Size = new System.Drawing.Size(105, 17);
			this.ModsEnabled.TabIndex = 2;
			this.ModsEnabled.Text = "Mods Enabled?";
			this.ModsEnabled.UseVisualStyleBackColor = true;
			this.ModsEnabled.CheckedChanged += new System.EventHandler(this.ModsEnabled_CheckedChanged);
			// 
			// ControlPanel
			// 
			this.ControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ControlPanel.Controls.Add(this.CheckButton);
			this.ControlPanel.Controls.Add(this.ModVer);
			this.ControlPanel.Controls.Add(this.InfoPanel);
			this.ControlPanel.Controls.Add(this.Delete);
			this.ControlPanel.Controls.Add(this.UpdateButton);
			this.ControlPanel.Controls.Add(this.InstallButton);
			this.ControlPanel.Controls.Add(this.SelectedModText);
			this.ControlPanel.Location = new System.Drawing.Point(477, 139);
			this.ControlPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.ControlPanel.Name = "ControlPanel";
			this.ControlPanel.Padding = new System.Windows.Forms.Padding(2);
			this.ControlPanel.Size = new System.Drawing.Size(478, 317);
			this.ControlPanel.TabIndex = 3;
			// 
			// CheckButton
			// 
			this.CheckButton.BackColor = System.Drawing.Color.White;
			this.CheckButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.CheckButton.Location = new System.Drawing.Point(248, 75);
			this.CheckButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.CheckButton.Name = "CheckButton";
			this.CheckButton.Size = new System.Drawing.Size(225, 30);
			this.CheckButton.TabIndex = 6;
			this.CheckButton.Text = "Check Website\r\n";
			this.CheckButton.UseVisualStyleBackColor = false;
			this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
			// 
			// ModVer
			// 
			this.ModVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.ModVer.Location = new System.Drawing.Point(6, 37);
			this.ModVer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ModVer.Name = "ModVer";
			this.ModVer.Size = new System.Drawing.Size(467, 30);
			this.ModVer.TabIndex = 5;
			this.ModVer.Text = "Mod Information";
			this.ModVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// InfoPanel
			// 
			this.InfoPanel.BackColor = System.Drawing.Color.White;
			this.InfoPanel.Controls.Add(this.ModInfo);
			this.InfoPanel.Controls.Add(this.ModInformationLabel);
			this.InfoPanel.Location = new System.Drawing.Point(6, 147);
			this.InfoPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.InfoPanel.Name = "InfoPanel";
			this.InfoPanel.Size = new System.Drawing.Size(467, 168);
			this.InfoPanel.TabIndex = 4;
			this.InfoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InfoPanel_Paint);
			// 
			// ModInfo
			// 
			this.ModInfo.Location = new System.Drawing.Point(0, 20);
			this.ModInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ModInfo.Name = "ModInfo";
			this.ModInfo.Size = new System.Drawing.Size(467, 148);
			this.ModInfo.TabIndex = 1;
			this.ModInfo.Text = "Mod Info Here!";
			// 
			// ModInformationLabel
			// 
			this.ModInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.ModInformationLabel.Location = new System.Drawing.Point(146, -3);
			this.ModInformationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ModInformationLabel.Name = "ModInformationLabel";
			this.ModInformationLabel.Size = new System.Drawing.Size(155, 25);
			this.ModInformationLabel.TabIndex = 0;
			this.ModInformationLabel.Text = "Mod Information";
			this.ModInformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Delete
			// 
			this.Delete.BackColor = System.Drawing.Color.White;
			this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Delete.Location = new System.Drawing.Point(6, 111);
			this.Delete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(467, 30);
			this.Delete.TabIndex = 3;
			this.Delete.Text = "Delete";
			this.Delete.UseVisualStyleBackColor = false;
			this.Delete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// UpdateButton
			// 
			this.UpdateButton.BackColor = System.Drawing.Color.White;
			this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.UpdateButton.Location = new System.Drawing.Point(6, 74);
			this.UpdateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.UpdateButton.Name = "UpdateButton";
			this.UpdateButton.Size = new System.Drawing.Size(220, 30);
			this.UpdateButton.TabIndex = 2;
			this.UpdateButton.Text = "Update";
			this.UpdateButton.UseVisualStyleBackColor = false;
			this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
			// 
			// InstallButton
			// 
			this.InstallButton.BackColor = System.Drawing.Color.White;
			this.InstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InstallButton.Location = new System.Drawing.Point(6, 37);
			this.InstallButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.InstallButton.Name = "InstallButton";
			this.InstallButton.Size = new System.Drawing.Size(467, 30);
			this.InstallButton.TabIndex = 1;
			this.InstallButton.Text = "Install";
			this.InstallButton.UseVisualStyleBackColor = false;
			this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
			// 
			// SelectedModText
			// 
			this.SelectedModText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.SelectedModText.Location = new System.Drawing.Point(6, 0);
			this.SelectedModText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.SelectedModText.Name = "SelectedModText";
			this.SelectedModText.Size = new System.Drawing.Size(467, 37);
			this.SelectedModText.TabIndex = 0;
			this.SelectedModText.Text = "Selected Mod: ";
			this.SelectedModText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ProgressPanel
			// 
			this.ProgressPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ProgressPanel.Controls.Add(this.StatusReport);
			this.ProgressPanel.Location = new System.Drawing.Point(476, 462);
			this.ProgressPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.ProgressPanel.Name = "ProgressPanel";
			this.ProgressPanel.Size = new System.Drawing.Size(478, 48);
			this.ProgressPanel.TabIndex = 4;
			// 
			// StatusReport
			// 
			this.StatusReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.StatusReport.Location = new System.Drawing.Point(7, 0);
			this.StatusReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.StatusReport.Name = "StatusReport";
			this.StatusReport.Size = new System.Drawing.Size(467, 48);
			this.StatusReport.TabIndex = 7;
			this.StatusReport.Text = "Idle";
			this.StatusReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Terminator
			// 
			this.Terminator.WorkerReportsProgress = true;
			this.Terminator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Terminator_DoWork);
			this.Terminator.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Terminator_ProgressChanged);
			this.Terminator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Terminator_RunWorkerCompleted);
			// 
			// CatagoriesList
			// 
			this.CatagoriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CatagoryName});
			this.CatagoriesList.FullRowSelect = true;
			this.CatagoriesList.GridLines = true;
			this.CatagoriesList.HideSelection = false;
			this.CatagoriesList.Location = new System.Drawing.Point(483, 12);
			this.CatagoriesList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.CatagoriesList.Name = "CatagoriesList";
			this.CatagoriesList.Size = new System.Drawing.Size(244, 121);
			this.CatagoriesList.TabIndex = 8;
			this.CatagoriesList.UseCompatibleStateImageBehavior = false;
			this.CatagoriesList.View = System.Windows.Forms.View.Details;
			// 
			// CatagoryName
			// 
			this.CatagoryName.Name = "CatagoryName";
			this.CatagoryName.Text = "Catagory";
			this.CatagoryName.Width = 200;
			// 
			// CatagoryDropDown
			// 
			this.CatagoryDropDown.Location = new System.Drawing.Point(0, 0);
			this.CatagoryDropDown.Name = "CatagoryDropDown";
			this.CatagoryDropDown.Size = new System.Drawing.Size(121, 23);
			this.CatagoryDropDown.TabIndex = 0;
			// 
			// CatagoriesComboBox
			// 
			this.CatagoriesComboBox.FormattingEnabled = true;
			this.CatagoriesComboBox.Location = new System.Drawing.Point(18, 74);
			this.CatagoriesComboBox.Name = "CatagoriesComboBox";
			this.CatagoriesComboBox.Size = new System.Drawing.Size(193, 23);
			this.CatagoriesComboBox.TabIndex = 10;
			this.CatagoriesComboBox.SelectedIndexChanged += new System.EventHandler(this.CatagoriesComboBox_SelectedIndexChanged);
			// 
			// mainwindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(968, 578);
			this.Controls.Add(this.CatagoriesList);
			this.Controls.Add(this.ProgressPanel);
			this.Controls.Add(this.ControlPanel);
			this.Controls.Add(this.ModsEnabled);
			this.Controls.Add(this.launch);
			this.Controls.Add(this.ModList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.Name = "mainwindow";
			this.Text = "H3VR Mod Installer";
			this.Load += new System.EventHandler(this.LoadGUI);
			this.ModList.ResumeLayout(false);
			this.ModList.PerformLayout();
			this.ControlPanel.ResumeLayout(false);
			this.InfoPanel.ResumeLayout(false);
			this.ProgressPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        private System.Windows.Forms.ColumnHeader InstalledModAuthor;

        private System.Windows.Forms.ColumnHeader InstalledModName;
        private System.Windows.Forms.ColumnHeader InstalledModVersion;
        private System.Windows.Forms.ColumnHeader InstalledModSize;
        private System.Windows.Forms.ListView InstalledModsList;

		private System.Windows.Forms.ComboBox CatagoryDropDown;

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
        private System.Windows.Forms.Label Divider;
        //private System.Windows.Forms.ListBox InstallableModsList;
        private System.Windows.Forms.Label SelectedModText;
        private ListView DownloadableModsList;
        private ColumnHeader ModName;
        private ColumnHeader ModVersion;
        private ColumnHeader ModAuthor;
        private System.ComponentModel.BackgroundWorker Terminator;
		private Label ModVer;
		private Button CheckButton;
		private Button DownloadableModsButton;
		private Button InstalledMods;
		private ListView CatagoriesList;
		private ColumnHeader CatagoryName;
		private Label StatusReport;
		private ComboBox CatagoriesComboBox;
	}
}

