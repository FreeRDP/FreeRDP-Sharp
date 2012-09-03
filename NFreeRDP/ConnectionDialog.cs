using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NFreeRDP
{
	public partial class ConnectionDialog : Form
	{
		public ConnectionDialog()
		{
			InitializeComponent();
		}

		public ConnectionSettings GetConnectionSettings()
		{
			ConnectionSettings settings = new ConnectionSettings();

			settings.port = 3389;
			settings.hostname = txtHostname.Text;
			settings.username = txtUsername.Text;
			settings.domain = "";
			settings.password = txtPassword.Text;

			return settings;
		}
	}
}
