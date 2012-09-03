/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * RemoteFX
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
	public unsafe class Rfx
	{
		protected IntPtr handle;
		
		public enum RFX_PIXEL_FORMAT
		{
			BGRA = 0,
			RGBA = 1,
			BGR = 2,
			RGB = 3,
			BGR565_LE = 4,
			RGB565_LE = 5,
			PALETTE4_PLANER = 6,
			PALETTE8 = 7
		}

		[DllImport("libfreerdp", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr rfx_context_new();

		[DllImport("libfreerdp", CallingConvention = CallingConvention.Cdecl)]
		public static extern void rfx_context_free(IntPtr handle);

		[DllImport("libfreerdp", CallingConvention = CallingConvention.Cdecl)]
		public static extern void rfx_context_set_pixel_format(IntPtr handle, RFX_PIXEL_FORMAT format);
		
		public Rfx()
		{
			handle = rfx_context_new();
			rfx_context_set_pixel_format(handle, RFX_PIXEL_FORMAT.RGBA);
		}
		
		public RfxMessage ParseMessage(byte[] data, UInt32 length)
		{
			return RfxMessage.Parse(handle, data, length);
		}
		
		~Rfx()
		{
			rfx_context_free(handle);
		}
	}
}

