/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Surface Bits Command
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
using System.IO;
using System.Runtime.InteropServices;

namespace FreeRDP
{
	public unsafe class SurfaceBitsCommand : SurfaceCommand
	{		
		protected byte[] buffer;
		
		protected UInt16 destLeft;
		protected UInt16 destTop;
		protected UInt16 destRight;
		protected UInt16 destBottom;
		protected Byte bpp;
		protected Byte reserved1;
		protected Byte reserved2;
		protected Byte codecID;
		protected UInt16 width;
		protected UInt16 height;
		protected UInt32 bitmapDataLength;
		protected byte[] bitmapData;
		
		public SurfaceBitsCommand()
		{
			reserved1 = 0;
			reserved2 = 0;
			buffer = new byte[4096 * 4];
		}
		
		public override void Read(BinaryReader fp)
		{
			destLeft = fp.ReadUInt16(); /* destLeft */
			destTop = fp.ReadUInt16(); /* destTop */
			destRight = fp.ReadUInt16(); /* destRight */
			destBottom = fp.ReadUInt16(); /* destBottom */
			bpp = fp.ReadByte(); /* bpp */
			reserved1 = fp.ReadByte(); /* Reserved1 */
			reserved2 = fp.ReadByte(); /* Reserved2 */
			codecID = fp.ReadByte(); /* codecID */
			width = fp.ReadUInt16(); /* width */
			height = fp.ReadUInt16(); /* height */
			bitmapDataLength = fp.ReadUInt32(); /* bitmapDataLength */
			bitmapData = fp.ReadBytes((int) bitmapDataLength); /* bitmapData */
		}
		
		public void Read(SurfaceBits* surfaceBits)
		{
			destLeft = (UInt16) surfaceBits->destLeft; /* destLeft */
			destTop = (UInt16) surfaceBits->destTop; /* destTop */
			destRight = (UInt16) surfaceBits->destRight; /* destRight */
			destBottom = (UInt16) surfaceBits->destBottom; /* destBottom */
			bpp = (Byte) surfaceBits->bpp; /* bpp */
			codecID = (Byte) surfaceBits->codecID; /* codecID */
			width = (UInt16) surfaceBits->width; /* width */
			height = (UInt16) surfaceBits->height; /* height */
			
			bitmapDataLength = (UInt32) surfaceBits->bitmapDataLength; /* bitmapDataLength */
			
			bitmapData = new byte[bitmapDataLength];
			
			Marshal.Copy(new IntPtr(surfaceBits->bitmapData),
				bitmapData, 0, (int) bitmapDataLength); /* bitmapData */
		}
		
		public override byte[] Write()
		{
			byte[] buffer = new byte[2 + 20 + bitmapDataLength];
			BinaryWriter s = new BinaryWriter(new MemoryStream(buffer));
			
			s.Write(GetCmdType());
			
			s.Write(destLeft);
			s.Write(destTop);
			s.Write(destRight);
			s.Write(destBottom);
			s.Write(bpp);
			s.Write(reserved1);
			s.Write(reserved2);
			s.Write(codecID);
			s.Write(width);
			s.Write(height);
			s.Write(bitmapDataLength);
			s.Write(bitmapData);
			
			return buffer;
		}
		
		public override UInt16 GetCmdType()
		{
			return CMDTYPE_STREAM_SURFACE_BITS;
		}
	}
}

