
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
	        this.tabControl1 = new System.Windows.Forms.TabControl();
	        this.TabPageInstalled = new System.Windows.Forms.TabPage();
	        this.InstalledModsList = new System.Windows.Forms.ListView();
	        this.InstalledModName = new System.Windows.Forms.ColumnHeader();
	        this.InstalledModVersion = new System.Windows.Forms.ColumnHeader();
	        this.InstalledModAuthor = new System.Windows.Forms.ColumnHeader();
	        this.TabPageAvailable = new System.Windows.Forms.TabPage();
	        this.DownloadableModsList = new System.Windows.Forms.ListView();
	        this.ModName = new System.Windows.Forms.ColumnHeader();
	        this.ModVersion = new System.Windows.Forms.ColumnHeader();
	        this.ModAuthor = new System.Windows.Forms.ColumnHeader();
	        this.CatagoriesComboBox = new System.Windows.Forms.ComboBox();
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
	        this.CatagoryDropDown = new System.Windows.Forms.ComboBox();
	        this.ModList.SuspendLayout();
	        this.tabControl1.SuspendLayout();
	        this.TabPageInstalled.SuspendLayout();
	        this.TabPageAvailable.SuspendLayout();
	        this.ControlPanel.SuspendLayout();
	        this.InfoPanel.SuspendLayout();
	        this.ProgressPanel.SuspendLayout();
	        this.SuspendLayout();
	        // 
	        // ModList
	        // 
	        this.ModList.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))), ((int) (((byte) (224)))));
	        this.ModList.Controls.Add(this.tabControl1);
	        this.ModList.Controls.Add(this.modlisttext);
	        this.ModList.Location = new System.Drawing.Point(12, 10);
	        this.ModList.Name = "ModList";
	        this.ModList.Size = new System.Drawing.Size(391, 480);
	        this.ModList.TabIndex = 0;
	        this.ModList.Paint += new System.Windows.Forms.PaintEventHandler(this.ModList_Paint);
	        // 
	        // tabControl1
	        // 
	        this.tabControl1.Controls.Add(this.TabPageInstalled);
	        this.tabControl1.Controls.Add(this.TabPageAvailable);
	        this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
	        this.tabControl1.Location = new System.Drawing.Point(0, 65);
	        this.tabControl1.Name = "tabControl1";
	        this.tabControl1.SelectedIndex = 0;
	        this.tabControl1.Size = new System.Drawing.Size(391, 415);
	        this.tabControl1.TabIndex = 11;
	        // 
	        // TabPageInstalled
	        // 
	        this.TabPageInstalled.Controls.Add(this.InstalledModsList);
	        this.TabPageInstalled.Location = new System.Drawing.Point(4, 22);
	        this.TabPageInstalled.Name = "TabPageInstalled";
	        this.TabPageInstalled.Padding = new System.Windows.Forms.Padding(3);
	        this.TabPageInstalled.Size = new System.Drawing.Size(383, 389);
	        this.TabPageInstalled.TabIndex = 0;
	        this.TabPageInstalled.Text = "Installed Mods";
	        this.TabPageInstalled.UseVisualStyleBackColor = true;
	        // 
	        // InstalledModsList
	        // 
	        this.InstalledModsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.InstalledModName, this.InstalledModVersion, this.InstalledModAuthor});
	        this.InstalledModsList.Dock = System.Windows.Forms.DockStyle.Fill;
	        this.InstalledModsList.FullRowSelect = true;
	        this.InstalledModsList.GridLines = true;
	        this.InstalledModsList.HideSelection = false;
	        this.InstalledModsList.Location = new System.Drawing.Point(3, 3);
	        this.InstalledModsList.Name = "InstalledModsList";
	        this.InstalledModsList.Size = new System.Drawing.Size(377, 383);
	        this.InstalledModsList.Sorting = System.Windows.Forms.SortOrder.Ascending;
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
	        // TabPageAvailable
	        // 
	        this.TabPageAvailable.Controls.Add(this.DownloadableModsList);
	        this.TabPageAvailable.Controls.Add(this.CatagoriesComboBox);
	        this.TabPageAvailable.Location = new System.Drawing.Point(4, 22);
	        this.TabPageAvailable.Name = "TabPageAvailable";
	        this.TabPageAvailable.Padding = new System.Windows.Forms.Padding(3);
	        this.TabPageAvailable.Size = new System.Drawing.Size(395, 410);
	        this.TabPageAvailable.TabIndex = 1;
	        this.TabPageAvailable.Text = "Downloadable Mods";
	        this.TabPageAvailable.UseVisualStyleBackColor = true;
	        // 
	        // DownloadableModsList
	        // 
	        this.DownloadableModsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.ModName, this.ModVersion, this.ModAuthor});
	        this.DownloadableModsList.Dock = System.Windows.Forms.DockStyle.Fill;
	        this.DownloadableModsList.FullRowSelect = true;
	        this.DownloadableModsList.GridLines = true;
	        this.DownloadableModsList.HideSelection = false;
	        this.DownloadableModsList.Location = new System.Drawing.Point(3, 24);
	        this.DownloadableModsList.Name = "DownloadableModsList";
	        this.DownloadableModsList.Size = new System.Drawing.Size(389, 383);
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
	        // CatagoriesComboBox
	        // 
	        this.CatagoriesComboBox.Dock = System.Windows.Forms.DockStyle.Top;
	        this.CatagoriesComboBox.FormattingEnabled = true;
	        this.CatagoriesComboBox.Location = new System.Drawing.Point(3, 3);
	        this.CatagoriesComboBox.Name = "CatagoriesComboBox";
	        this.CatagoriesComboBox.Size = new System.Drawing.Size(389, 21);
	        this.CatagoriesComboBox.TabIndex = 10;
	        this.CatagoriesComboBox.SelectedIndexChanged += new System.EventHandler(this.CatagoriesComboBox_SelectedIndexChanged);
	        // 
	        // modlisttext
	        // 
	        this.modlisttext.AutoSize = true;
	        this.modlisttext.Dock = System.Windows.Forms.DockStyle.Top;
	        this.modlisttext.Font = new System.Drawing.Font("Segoe UI", 36F);
	        this.modlisttext.Location = new System.Drawing.Point(0, 0);
	        this.modlisttext.Name = "modlisttext";
	        this.modlisttext.Size = new System.Drawing.Size(147, 65);
	        this.modlisttext.TabIndex = 0;
	        this.modlisttext.Text = "Mods";
	        this.modlisttext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
	        this.modlisttext.Click += new System.EventHandler(this.label1_Click);
	        // 
	        // launch
	        // 
	        this.launch.Location = new System.Drawing.Point(503, 447);
	        this.launch.Name = "launch";
	        this.launch.Size = new System.Drawing.Size(219, 43);
	        this.launch.TabIndex = 1;
	        this.launch.Text = "Launch H3VR";
	        this.launch.UseVisualStyleBackColor = true;
	        this.launch.Click += new System.EventHandler(this.launch_Click);
	        // 
	        // ModsEnabled
	        // 
	        this.ModsEnabled.AutoSize = true;
	        this.ModsEnabled.Font = new System.Drawing.Font("Segoe UI", 8.25F);
	        this.ModsEnabled.Location = new System.Drawing.Point(729, 466);
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
	        this.ControlPanel.Controls.Add(this.CheckButton);
	        this.ControlPanel.Controls.Add(this.ModVer);
	        this.ControlPanel.Controls.Add(this.InfoPanel);
	        this.ControlPanel.Controls.Add(this.Delete);
	        this.ControlPanel.Controls.Add(this.UpdateButton);
	        this.ControlPanel.Controls.Add(this.InstallButton);
	        this.ControlPanel.Controls.Add(this.SelectedModText);
	        this.ControlPanel.Location = new System.Drawing.Point(409, 10);
	        this.ControlPanel.Name = "ControlPanel";
	        this.ControlPanel.Padding = new System.Windows.Forms.Padding(2);
	        this.ControlPanel.Size = new System.Drawing.Size(410, 432);
	        this.ControlPanel.TabIndex = 3;
	        // 
	        // CheckButton
	        // 
	        this.CheckButton.BackColor = System.Drawing.Color.White;
	        this.CheckButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
	        this.CheckButton.Location = new System.Drawing.Point(213, 65);
	        this.CheckButton.Name = "CheckButton";
	        this.CheckButton.Size = new System.Drawing.Size(193, 26);
	        this.CheckButton.TabIndex = 6;
	        this.CheckButton.Text = "Website";
	        this.CheckButton.UseVisualStyleBackColor = false;
	        this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
	        // 
	        // ModVer
	        // 
	        this.ModVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
	        this.ModVer.Location = new System.Drawing.Point(5, 32);
	        this.ModVer.Name = "ModVer";
	        this.ModVer.Size = new System.Drawing.Size(400, 26);
	        this.ModVer.TabIndex = 5;
	        this.ModVer.Text = "Mod Information";
	        this.ModVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
	        // 
	        // InfoPanel
	        // 
	        this.InfoPanel.BackColor = System.Drawing.Color.White;
	        this.InfoPanel.Controls.Add(this.ModInfo);
	        this.InfoPanel.Controls.Add(this.ModInformationLabel);
	        this.InfoPanel.Location = new System.Drawing.Point(5, 127);
	        this.InfoPanel.Name = "InfoPanel";
	        this.InfoPanel.Size = new System.Drawing.Size(400, 292);
	        this.InfoPanel.TabIndex = 4;
	        this.InfoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InfoPanel_Paint);
	        // 
	        // ModInfo
	        // 
	        this.ModInfo.Location = new System.Drawing.Point(0, 19);
	        this.ModInfo.Name = "ModInfo";
	        this.ModInfo.Size = new System.Drawing.Size(400, 273);
	        this.ModInfo.TabIndex = 1;
	        this.ModInfo.Text = "Mod Info Here!";
	        // 
	        // ModInformationLabel
	        // 
	        this.ModInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
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
	        this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
	        this.Delete.Location = new System.Drawing.Point(5, 96);
	        this.Delete.Name = "Delete";
	        this.Delete.Size = new System.Drawing.Size(400, 26);
	        this.Delete.TabIndex = 3;
	        this.Delete.Text = "Delete";
	        this.Delete.UseVisualStyleBackColor = false;
	        this.Delete.Click += new System.EventHandler(this.Delete_Click);
	        // 
	        // UpdateButton
	        // 
	        this.UpdateButton.BackColor = System.Drawing.Color.White;
	        this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
	        this.UpdateButton.Location = new System.Drawing.Point(5, 64);
	        this.UpdateButton.Name = "UpdateButton";
	        this.UpdateButton.Size = new System.Drawing.Size(189, 26);
	        this.UpdateButton.TabIndex = 2;
	        this.UpdateButton.Text = "Update";
	        this.UpdateButton.UseVisualStyleBackColor = false;
	        this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
	        // 
	        // InstallButton
	        // 
	        this.InstallButton.BackColor = System.Drawing.Color.White;
	        this.InstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
	        this.InstallButton.Location = new System.Drawing.Point(5, 32);
	        this.InstallButton.Name = "InstallButton";
	        this.InstallButton.Size = new System.Drawing.Size(400, 26);
	        this.InstallButton.TabIndex = 1;
	        this.InstallButton.Text = "Install";
	        this.InstallButton.UseVisualStyleBackColor = false;
	        this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
	        // 
	        // SelectedModText
	        // 
	        this.SelectedModText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
	        this.SelectedModText.Location = new System.Drawing.Point(5, 0);
	        this.SelectedModText.Name = "SelectedModText";
	        this.SelectedModText.Size = new System.Drawing.Size(400, 32);
	        this.SelectedModText.TabIndex = 0;
	        this.SelectedModText.Text = "Selected Mod: ";
	        this.SelectedModText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
	        // 
	        // ProgressPanel
	        // 
	        this.ProgressPanel.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))), ((int) (((byte) (224)))));
	        this.ProgressPanel.Controls.Add(this.StatusReport);
	        this.ProgressPanel.Location = new System.Drawing.Point(409, 447);
	        this.ProgressPanel.Name = "ProgressPanel";
	        this.ProgressPanel.Size = new System.Drawing.Size(81, 42);
	        this.ProgressPanel.TabIndex = 4;
	        // 
	        // StatusReport
	        // 
	        this.StatusReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	        this.StatusReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
	        this.StatusReport.Location = new System.Drawing.Point(0, 0);
	        this.StatusReport.Name = "StatusReport";
	        this.StatusReport.Size = new System.Drawing.Size(81, 42);
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
	        // CatagoryDropDown
	        // 
	        this.CatagoryDropDown.Location = new System.Drawing.Point(0, 0);
	        this.CatagoryDropDown.Name = "CatagoryDropDown";
	        this.CatagoryDropDown.Size = new System.Drawing.Size(121, 21);
	        this.CatagoryDropDown.TabIndex = 0;
	        // 
	        // mainwindow
	        // 
	        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	        this.ClientSize = new System.Drawing.Size(830, 501);
	        this.Controls.Add(this.ProgressPanel);
	        this.Controls.Add(this.ControlPanel);
	        this.Controls.Add(this.ModsEnabled);
	        this.Controls.Add(this.launch);
	        this.Controls.Add(this.ModList);
	        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	        this.MaximizeBox = false;
	        this.Name = "mainwindow";
	        this.Text = "H3VR Mod Installer";
	        this.Load += new System.EventHandler(this.LoadGUI);
	        this.ModList.ResumeLayout(false);
	        this.ModList.PerformLayout();
	        this.tabControl1.ResumeLayout(false);
	        this.TabPageInstalled.ResumeLayout(false);
	        this.TabPageAvailable.ResumeLayout(false);
	        this.ControlPanel.ResumeLayout(false);
	        this.InfoPanel.ResumeLayout(false);
	        this.ProgressPanel.ResumeLayout(false);
	        this.ResumeLayout(false);
	        this.PerformLayout();
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPageAvailable;
        private System.Windows.Forms.TabPage TabPageInstalled;

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

        //private System.Windows.Forms.ListBox InstallableModsList;
        private System.Windows.Forms.Label SelectedModText;
        private ListView DownloadableModsList;
        private ColumnHeader ModName;
        private ColumnHeader ModVersion;
        private ColumnHeader ModAuthor;
        private System.ComponentModel.BackgroundWorker Terminator;
		private Label ModVer;
		private Button CheckButton;
		private Label StatusReport;
		private ComboBox CatagoriesComboBox;
	}
}

