/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Bitmap
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
	public unsafe delegate void pBitmap_New(rdpContext* context, rdpBitmap* bitmap);
	public unsafe delegate void pBitmap_Free(rdpContext* context, rdpBitmap* bitmap);
	public unsafe delegate void pBitmap_Paint(rdpContext* context, rdpBitmap* bitmap);
	public unsafe delegate void pBitmap_Decompress(rdpContext* context, rdpBitmap* bitmap);
	public unsafe delegate void pBitmap_SetSurface(rdpContext* context, rdpBitmap* bitmap);
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpBitmap
	{
		public IntPtr size;
		public IntPtr New;
		public IntPtr Free;
		public IntPtr Paint;
		public IntPtr Decompress;
		public IntPtr SetSurface;
		public fixed UInt32 paddingA[16-6];
		
		public UInt32 left;
		public UInt32 top;
		public UInt32 right;
		public UInt32 bottom;
		public UInt32 width;
		public UInt32 height;
		public UInt32 bpp;
		public UInt32 flags;
		public UInt32 length;
		public IntPtr data;
		public fixed UInt32 paddingB[32-26];
		
		public UInt32 compressed;
		public UInt32 ephemeral;
		public fixed UInt32 paddingC[64-34];
	}
}

