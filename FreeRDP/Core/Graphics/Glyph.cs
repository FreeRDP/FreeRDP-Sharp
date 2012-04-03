/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Glyph
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
	public unsafe delegate void pGlyph_New(rdpContext* context, rdpGlyph* glyph);
	public unsafe delegate void pGlyph_Free(rdpContext* context, rdpGlyph* glyph);
	public unsafe delegate void pGlyph_Draw(rdpContext* context, rdpGlyph* glyph, int x, int y);
	
	public unsafe delegate void pGlyph_BeginDraw(rdpContext* context, rdpGlyph* glyph,
		int x, int y, UInt32 bgcolor, UInt32 fgcolor);
	
	public unsafe delegate void pGlyph_EndDraw(rdpContext* context, rdpGlyph* glyph,
		int x, int y, UInt32 bgcolor, UInt32 fgcolor);
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpGlyph
	{
		public IntPtr size;
		public IntPtr New;
		public IntPtr Free;
		public IntPtr Draw;
		public IntPtr BeginDraw;
		public IntPtr EndDraw;
		public fixed UInt32 paddingA[16-6];
		
		public UInt32 x;
		public UInt32 y;
		public UInt32 cx;
		public UInt32 cy;
		public UInt32 cb;
		public IntPtr aj;
		public fixed UInt32 paddingB[32-22];
	}
}
