/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Window Updates 
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
using System.Runtime.InteropServices;

namespace FreeRDP
{
	public unsafe delegate void pWindowCreate(rdpContext* context, IntPtr orderInfo, IntPtr window_state);
	public unsafe delegate void pWindowUpdate(rdpContext* context, IntPtr orderInfo, IntPtr window_state);
	public unsafe delegate void pWindowIcon(rdpContext* context, IntPtr orderInfo, IntPtr window_icon);
	public unsafe delegate void pWindowCachedIcon(rdpContext* context, IntPtr orderInfo, IntPtr window_cached_icon);
	public unsafe delegate void pWindowDelete(rdpContext* context, IntPtr orderInfo);
	public unsafe delegate void pNotifyIconCreate(rdpContext* context, IntPtr orderInfo, IntPtr notify_icon_state);
	public unsafe delegate void pNotifyIconUpdate(rdpContext* context, IntPtr orderInfo, IntPtr notify_icon_state);
	public unsafe delegate void pNotifyIconDelete(rdpContext* context, IntPtr orderInfo);
	public unsafe delegate void pMonitoredDesktop(rdpContext* context, IntPtr orderInfo, IntPtr monitored_desktop);
	public unsafe delegate void pNonMonitoredDesktop(rdpContext* context, IntPtr orderInfo);
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpWindowUpdate
	{
		public rdpContext* context;
		public fixed UInt32 paddingA[16-1];
		
		public IntPtr WindowCreate;
		public IntPtr WindowUpdate;
		public IntPtr WindowIcon;
		public IntPtr WindowCachedIcon;
		public IntPtr WindowDelete;
		public IntPtr NotifyIconCreate;
		public IntPtr NotifyIconUpdate;
		public IntPtr NotifyIconDelete;
		public IntPtr MonitoredDesktop;
		public IntPtr NonMonitoredDesktop;
		public fixed UInt32 paddingB[32-26];
	}
}

