/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Graphics Device Interface (GDI)
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
	public unsafe class GDI
	{
		[DllImport("libfreerdp-gdi")]
		public static extern int gdi_init(freerdp* instance, UInt32 flags, IntPtr buffer);
		
		[DllImport("libfreerdp-gdi")]
		public static extern void gdi_free(freerdp* instance);
	
		private UInt32 flags;
		private freerdp* instance;
		
		public GDI(freerdp* instance)
		{
			this.flags = 0;
			this.instance = instance;
		}
		
		public bool Init()
		{
			return ((gdi_init(instance, flags, IntPtr.Zero) == 0) ? false : true);
		}
		
		~GDI()
		{
				gdi_free(instance);
		}
	}
}

