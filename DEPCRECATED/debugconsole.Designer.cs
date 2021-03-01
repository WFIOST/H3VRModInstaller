
namespace H3VRModInstaller.GUI
{
	partial class debugconsole
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.submit = new System.Windows.Forms.Button();
			this.consolewindow = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox1.Location = new System.Drawing.Point(10, 429);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(836, 20);
			this.textBox1.TabIndex = 0;
			// 
			// submit
			// 
			this.submit.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.submit.Location = new System.Drawing.Point(852, 429);
			this.submit.Name = "submit";
			this.submit.Size = new System.Drawing.Size(123, 20);
			this.submit.TabIndex = 1;
			this.submit.Text = "Submit";
			this.submit.UseVisualStyleBackColor = true;
			this.submit.Click += new System.EventHandler(this.submit_Click);
			// 
			// consolewindow
			// 
			this.consolewindow.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.consolewindow.Location = new System.Drawing.Point(10, 12);
			this.consolewindow.Name = "consolewindow";
			this.consolewindow.ReadOnly = true;
			this.consolewindow.Size = new System.Drawing.Size(965, 411);
			this.consolewindow.TabIndex = 2;
			this.consolewindow.Text = "";
			// 
			// debugconsole
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 461);
			this.Controls.Add(this.consolewindow);
			this.Controls.Add(this.submit);
			this.Controls.Add(this.textBox1);
			this.Name = "debugconsole";
			this.Text = "debugconsole";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.RichTextBox consolewindow;

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button submit;
		private System.ComponentModel.BackgroundWorker Terminator;
	}
}