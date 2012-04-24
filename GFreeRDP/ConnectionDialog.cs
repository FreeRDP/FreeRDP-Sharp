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

namespace GFreeRDP
{
	public partial class ConnectionDialog : Gtk.Dialog
	{
		private IUserAction iUserAction;
		
		public ConnectionDialog(IUserAction iUserAction)
		{
			this.Build();
			this.iUserAction = iUserAction;
		}

		protected void OnButtonConnectClicked(object sender, System.EventArgs e)
		{
			string hostname;
			string username;
			string password;
			
			hostname = entryHostname.Text;
			username = entryUsername.Text;
			password = entryPassword.Text;
			
			Console.WriteLine("OnButtonConnectActivated");
			
			iUserAction.OnNewConnection(hostname, username, password);
			
			Console.WriteLine("OnButtonConnectActivated Destroy");
			
			this.Destroy();
		}

		protected void OnButtonCancelClicked(object sender, System.EventArgs e)
		{
			this.Destroy();
		}
	}
}

