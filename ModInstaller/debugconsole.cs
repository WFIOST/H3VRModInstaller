using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using H3VRModInstaller;

namespace H3VRModInstaller.GUI
{
	/// <summary>
	/// this shit janky af
	/// </summary>
	public partial class debugconsole : Form
	{
		public mainwindow mainform;
		public debugconsole()
		{
			Terminator = new BackgroundWorker();
			InitializeComponent();
		}

		private void submit_Click(object sender, EventArgs e)
		{
			StartTerminator(textBox1.Text);
		}
		
		public void StartTerminator(string strngcommand)
		{
			if (!Terminator.IsBusy)
			{
				command = strngcommand.Split(' ');
				Terminator.RunWorkerAsync();
			}
		}

		public string[] command;

		private void Terminator_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				
				
				MainClass.doCommand(command);
			}
			catch (Exception exception)
			{

			}
		}
	}
}
