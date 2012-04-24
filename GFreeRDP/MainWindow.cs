/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 *
 * Copyright 2012 Marc-Andre Moreau <marcandre.moreau@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using FreeRDP;
using Gtk;

namespace GFreeRDP
{
	public partial class MainWindow: Gtk.Window, IUserAction
	{
		RdpClient rdpClient;
		
		public MainWindow(): base (Gtk.WindowType.Toplevel)
		{
			Build();
		}
		
		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}
	
		protected void OnConnectActionActivated(object sender, System.EventArgs e)
		{
			ConnectionDialog connectionDialog = new ConnectionDialog(this);
		}
		
		public void OnNewConnection(string hostname, string username, string password)
		{
			rdpClient = new RdpClient();
	
			rdpClient.Connect(hostname, 3389, username, "", password);
		}
	}
}
