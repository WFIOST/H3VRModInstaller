using System.ComponentModel;

namespace H3VRModInstaller
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.MI_INFOTEXT = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.delConfig = new System.Windows.Forms.CheckBox();
            this.delArchives = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.debugChecked = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.H3InstallSelect = new System.Windows.Forms.Button();
            this.H3VRInstallPathText = new System.Windows.Forms.Label();
            this.OverridePathText = new System.Windows.Forms.Label();
            this.OverrideLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MI_INFOTEXT
            // 
            this.MI_INFOTEXT.Location = new System.Drawing.Point(21, 13);
            this.MI_INFOTEXT.Name = "MI_INFOTEXT";
            this.MI_INFOTEXT.Size = new System.Drawing.Size(422, 72);
            this.MI_INFOTEXT.TabIndex = 0;
            this.MI_INFOTEXT.Text = "MODINSTALLERINFO";
            this.MI_INFOTEXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(465, 425);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(10, 4);
            this.listBox1.TabIndex = 1;
            // 
            // delConfig
            // 
            this.delConfig.Location = new System.Drawing.Point(21, 88);
            this.delConfig.Name = "delConfig";
            this.delConfig.Size = new System.Drawing.Size(422, 28);
            this.delConfig.TabIndex = 2;
            this.delConfig.Text = "Remove configs on deletion";
            this.delConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.delConfig.UseVisualStyleBackColor = true;
            this.delConfig.CheckedChanged += new System.EventHandler(this.delConfig_CheckedChanged);
            // 
            // delArchives
            // 
            this.delArchives.Location = new System.Drawing.Point(21, 122);
            this.delArchives.Name = "delArchives";
            this.delArchives.Size = new System.Drawing.Size(422, 28);
            this.delArchives.TabIndex = 3;
            this.delArchives.Text = "Delete archives on install finish";
            this.delArchives.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.delArchives.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(465, 419);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(10, 10);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Remove configs on deletion";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(465, 453);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(10, 10);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Remove configs on deletion";
            this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // debugChecked
            // 
            this.debugChecked.Location = new System.Drawing.Point(21, 389);
            this.debugChecked.Name = "debugChecked";
            this.debugChecked.Size = new System.Drawing.Size(422, 28);
            this.debugChecked.TabIndex = 6;
            this.debugChecked.Text = "Debug Mode";
            this.debugChecked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.debugChecked.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(452, 408);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 31);
            this.textBox1.TabIndex = 7;
            // 
            // H3InstallSelect
            // 
            this.H3InstallSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.H3InstallSelect.Location = new System.Drawing.Point(21, 156);
            this.H3InstallSelect.Name = "H3InstallSelect";
            this.H3InstallSelect.Size = new System.Drawing.Size(422, 31);
            this.H3InstallSelect.TabIndex = 8;
            this.H3InstallSelect.Text = "H3VR Install Location";
            this.H3InstallSelect.UseVisualStyleBackColor = true;
            // 
            // H3VRInstallPathText
            // 
            this.H3VRInstallPathText.Location = new System.Drawing.Point(21, 189);
            this.H3VRInstallPathText.Name = "H3VRInstallPathText";
            this.H3VRInstallPathText.Size = new System.Drawing.Size(421, 30);
            this.H3VRInstallPathText.TabIndex = 9;
            this.H3VRInstallPathText.Text = "Current path: ";
            // 
            // OverridePathText
            // 
            this.OverridePathText.Location = new System.Drawing.Point(20, 255);
            this.OverridePathText.Name = "OverridePathText";
            this.OverridePathText.Size = new System.Drawing.Size(421, 30);
            this.OverridePathText.TabIndex = 11;
            this.OverridePathText.Text = "Current path: ";
            // 
            // OverrideLocation
            // 
            this.OverrideLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.OverrideLocation.Location = new System.Drawing.Point(20, 222);
            this.OverrideLocation.Name = "OverrideLocation";
            this.OverrideLocation.Size = new System.Drawing.Size(422, 31);
            this.OverrideLocation.TabIndex = 10;
            this.OverrideLocation.Text = "ModInstaller Override Location";
            this.OverrideLocation.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 429);
            this.Controls.Add(this.OverridePathText);
            this.Controls.Add(this.OverrideLocation);
            this.Controls.Add(this.H3VRInstallPathText);
            this.Controls.Add(this.H3InstallSelect);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.debugChecked);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.delArchives);
            this.Controls.Add(this.delConfig);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.MI_INFOTEXT);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button OverrideLocation;
        private System.Windows.Forms.Label OverridePathText;

        private System.Windows.Forms.Label H3VRInstallPathText;

        private System.Windows.Forms.Button H3InstallSelect;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.CheckBox delArchives;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox debugChecked;

        private System.Windows.Forms.CheckBox delConfig;

        private System.Windows.Forms.ListBox listBox1;

        private System.Windows.Forms.Label MI_INFOTEXT;

        #endregion
    }
}