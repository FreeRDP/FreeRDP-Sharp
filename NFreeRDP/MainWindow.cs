using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FreeRDP;

namespace NFreeRDP
{
	public partial class MainWindow : Form
	{
		RdpClient rdpClient;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ConnectionDialog dialog = new ConnectionDialog();

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				rdpClient = new RdpClient();
				rdpClient.Connect(dialog.GetConnectionSettings());
			}

			dialog.Dispose();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
