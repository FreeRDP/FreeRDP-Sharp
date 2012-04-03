/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * RemoteFX Message
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
	public unsafe class RfxMessage
	{
		IntPtr handle;
		IntPtr rfxHandle;
		
		protected int itiles;
		protected int irects;
		protected UInt16 nrects;
		protected UInt16 ntiles;
		
		public int RectCount
		{
			get { return (int) nrects; }
		}
		
		public int TileCount
		{
			get { return (int) ntiles; }
		}
		
		[StructLayout(LayoutKind.Sequential)]
		public struct RFX_RECT
		{
			public UInt16 x;
			public UInt16 y;
			public UInt16 width;
			public UInt16 height;
		}
		
		[StructLayout(LayoutKind.Sequential)]
		public struct RFX_TILE
		{
			public UInt16 x;
			public UInt16 y;
			public byte* data;
		}
		
		[DllImport("libfreerdp-codec")]
		public static extern IntPtr rfx_process_message(IntPtr rfxHandle, byte[] data, UInt32 length);
		
		[DllImport("libfreerdp-codec")]
		public static extern UInt16 rfx_message_get_tile_count(IntPtr handle);
		
		[DllImport("libfreerdp-codec")]
		public static extern RFX_TILE* rfx_message_get_tile(IntPtr handle, int index);
		
		[DllImport("libfreerdp-codec")]
		public static extern UInt16 rfx_message_get_rect_count(IntPtr handle);
		
		[DllImport("libfreerdp-codec")]
		public static extern RFX_RECT* rfx_message_get_rect(IntPtr handle, int index);
		
		[DllImport("libfreerdp-codec")]
		public static extern void rfx_message_free(IntPtr rfxHandle, IntPtr handle);
		
		private RfxMessage(IntPtr rfxHandle, IntPtr handle)
		{
			this.handle = handle;
			this.rfxHandle = rfxHandle;
			
			itiles = irects = 0;
			ntiles = nrects = 0;
		}
		
		public static RfxMessage Parse(IntPtr rfxHandle, byte[] data, UInt32 length)
		{
			IntPtr msgHandle;
			
			msgHandle = rfx_process_message(rfxHandle, data, length);
			RfxMessage message = new RfxMessage(rfxHandle, msgHandle);
			
			message.ntiles = rfx_message_get_tile_count(msgHandle);
			message.nrects = rfx_message_get_rect_count(msgHandle);
			
			return message;
		}
		
		public bool HasNextTile()
		{
			return (itiles < ntiles);
		}
		
		public void GetNextTile(byte[] buffer, ref int x, ref int y)
		{			
			RFX_TILE* tile = rfx_message_get_tile(handle, itiles++);
			
			x = tile->x;
			y = tile->y;
			
			Marshal.Copy(new IntPtr(tile->data), buffer, 0, 4096 * 4);
		}
		
		public bool HasNextRect()
		{	
			return (irects < nrects);
		}
		
		public void GetNextRect(ref int x, ref int y, ref int width, ref int height)
		{			
			RFX_RECT* rect = rfx_message_get_rect(handle, irects++);
		
			x = rect->x;
			y = rect->y;
			width = rect->width;
			height = rect->height;
		}
		
		~RfxMessage()
		{
			rfx_message_free(rfxHandle, handle);
		}
	}
}

