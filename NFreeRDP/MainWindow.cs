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
		int port;
		string hostname;
		string username;
		string domain;
		string password;

		RdpClient rdpClient;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rdpClient = new RdpClient();

			port = 3389;
			hostname = "localhost";
			username = "Administrator";
			domain = "";
			password = "Password123!";

			rdpClient.Connect(hostname, port, username, domain, password);
		}
	}
}
