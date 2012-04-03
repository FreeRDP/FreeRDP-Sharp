/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Context
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
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpContext
	{
		public freerdp* instance;
		public IntPtr peer;
		public fixed UInt32 paddingA[16-2];
		
		public int argc;
		public IntPtr argv;
		public fixed UInt32 paddingB[32-18];
		
		public IntPtr rdp;
		public IntPtr gdi;
		public IntPtr rail;
		public IntPtr cache;
		public IntPtr channels;
		public IntPtr graphics;
		public fixed UInt32 paddingC[64-38];
	};
}

