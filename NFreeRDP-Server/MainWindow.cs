using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NFreeRDP_Server
{
	public partial class MainWindow : Form
	{
		FreeRDP.Server.Windows server;

		public MainWindow()
		{
			InitializeComponent();
			server = new FreeRDP.Server.Windows();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void startServerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			server.Start();
			startServerToolStripMenuItem.Enabled = false;
			stopServerToolStripMenuItem.Enabled = true;
		}

		private void stopServerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			server.Start();
			startServerToolStripMenuItem.Enabled = true;
			stopServerToolStripMenuItem.Enabled = false;
		}
	}
}
