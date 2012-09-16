/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Windows Server Interface
 *
 * Copyright 2011-2012 Marc-Andre Moreau <marcandre.moreau@gmail.com>
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
using System.Text;
using System.Runtime.InteropServices;

namespace FreeRDP.Server
{
	public class Windows : Server
	{
		private IntPtr instance;

		[DllImport("libwfreerdp-server", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr wfreerdp_server_new();

		[DllImport("libwfreerdp-server", CallingConvention = CallingConvention.Cdecl)]
		public static extern void wfreerdp_server_start(IntPtr instance);

		[DllImport("libwfreerdp-server", CallingConvention = CallingConvention.Cdecl)]
		public static extern void wfreerdp_server_stop(IntPtr instance);

		[DllImport("libwfreerdp-server", CallingConvention = CallingConvention.Cdecl)]
		public static extern void wfreerdp_server_free(IntPtr instance);

		public Windows()
		{
			instance = wfreerdp_server_new();
		}

		~Windows()
		{
			wfreerdp_server_free(instance);
		}

		public override void Start()
		{
			wfreerdp_server_start(instance);
		}

		public override void Stop()
		{
			wfreerdp_server_stop(instance);
		}
	}
}
