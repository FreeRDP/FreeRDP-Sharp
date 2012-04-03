/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Secondary Updates
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
	public unsafe struct CacheBitmapOrder
	{
		public UInt32 cacheId;
		public UInt32 bitmapBpp;
		public UInt32 bitmapWidth;
		public UInt32 bitmapHeight;
		public UInt32 bitmapLength;
		public UInt32 cacheIndex;
		public fixed byte bitmapComprHdr[8];
		public byte* bitmapDataStream;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CacheBitmapV2Order
	{
		public UInt32 cacheId;
		public UInt32 flags;
		public UInt32 key1;
		public UInt32 key2;
		public UInt32 bitmapBpp;
		public UInt32 bitmapWidth;
		public UInt32 bitmapHeight;
		public UInt32 bitmapLength;
		public UInt32 cacheIndex;
		public int compressed;
		public fixed byte bitmapComprHdr[8];
		public byte* bitmapDataStream;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct BitmapDataEx
	{
		public UInt32 bpp;
		public UInt32 codecID;
		public UInt32 width;
		public UInt32 height;
		public UInt32 length;
		public byte* data;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CacheBitmapV3Order
	{
		public UInt32 cacheId;
		public UInt32 bpp;
		public UInt32 flags;
		public UInt32 cacheIndex;
		public UInt32 key1;
		public UInt32 key2;
		public BitmapDataEx* bitmapData;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CacheColorTableOrder
	{
		public UInt32 cacheIndex;
		public UInt32 numberColors;
		public UInt32* colorTable;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct GlyphData
	{
		public UInt32 cacheIndex;
		public Int32 x;
		public Int32 y;
		public UInt32 cx;
		public UInt32 cy;
		public UInt32 cb;
		public byte* aj;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CacheGlyphOrder
	{
		public UInt32 cacheId;
		public UInt32 cGlyphs;
		//public GlyphData glyphData[255];
		public byte* unicodeCharacters;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct GlyphDataV2
	{
		public UInt32 cacheIndex;
		public Int32 x;
		public Int32 y;
		public UInt32 cx;
		public UInt32 cy;
		public UInt32 cb;
		public byte* aj;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CacheGlyphV2Order
	{
		public UInt32 cacheId;
		public UInt32 flags;
		public UInt32 cGlyphs;
		//public GlyphDataV2 glyphData[255];
		public byte* unicodeCharacters;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CacheBrushOrder
	{
		public UInt32 index;
		public UInt32 bpp;
		public UInt32 cx;
		public UInt32 cy;
		public UInt32 style;
		public UInt32 length;
		public byte* data;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpSecondaryUpdate
	{
		public rdpContext* context;
		public fixed UInt32 paddingA[16-1];
		
		public IntPtr CacheBitmap;
		public IntPtr CacheBitmapV2;
		public IntPtr CacheBitmapV3;
		public IntPtr CacheColorTable;
		public IntPtr CacheGlyph;
		public IntPtr CacheGlyphV2;
		public IntPtr CacheBrush;
		public fixed UInt32 paddingB[32-23];
	}
	
	public unsafe interface ISecondaryUpdate
	{
		void CacheBitmap(rdpContext* context, CacheBitmapOrder* cacheBitmapOrder);
		void CacheBitmapV2(rdpContext* context, CacheBitmapV2Order* cacheBitmapV2Order);
		void CacheBitmapV3(rdpContext* context, CacheBitmapV3Order* cacheBitmapV3Order);
		void CacheColorTable(rdpContext* context, CacheColorTableOrder* cacheColorTableOrder);
		void CacheGlyph(rdpContext* context, CacheGlyphOrder* cacheGlyphOrder);
		void CacheGlyphV2(rdpContext* context, CacheGlyphV2Order* cacheGlyphV2Order);
		void CacheBrush(rdpContext* context, CacheBrushOrder* cacheBrushOrder);
	}
	
	public unsafe class SecondaryUpdate
	{
		private freerdp* instance;
		private rdpContext* context;
		private rdpUpdate* update;
		private rdpSecondaryUpdate* secondary;
		
		delegate void CacheBitmapDelegate(rdpContext* context, CacheBitmapOrder* cacheBitmapOrder);
		delegate void CacheBitmapV2Delegate(rdpContext* context, CacheBitmapV2Order* cacheBitmapV2Order);
		delegate void CacheBitmapV3Delegate(rdpContext* context, CacheBitmapV3Order* cacheBitmapV3Order);
		delegate void CacheColorTableDelegate(rdpContext* context, CacheColorTableOrder* cacheColorTableOrder);
		delegate void CacheGlyphDelegate(rdpContext* context, CacheGlyphOrder* cacheGlyphOrder);
		delegate void CacheGlyphV2Delegate(rdpContext* context, CacheGlyphV2Order* cacheGlyphV2Order);
		delegate void CacheBrushDelegate(rdpContext* context, CacheBrushOrder* cacheBrushOrder);
		
		private CacheBitmapDelegate CacheBitmap;
		private CacheBitmapV2Delegate CacheBitmapV2;
		private CacheBitmapV3Delegate CacheBitmapV3;
		private CacheColorTableDelegate CacheColorTable;
		private CacheGlyphDelegate CacheGlyph;
		private CacheGlyphV2Delegate CacheGlyphV2;
		private CacheBrushDelegate CacheBrush;
		
		public SecondaryUpdate(rdpContext* context)
		{
			this.context = context;
			this.instance = context->instance;
			this.update = instance->update;
			this.secondary = update->secondary;
		}
		
		public void RegisterInterface(ISecondaryUpdate iSecondary)
		{
			CacheBitmap = new CacheBitmapDelegate(iSecondary.CacheBitmap);
			CacheBitmapV2 = new CacheBitmapV2Delegate(iSecondary.CacheBitmapV2);
			CacheBitmapV3 = new CacheBitmapV3Delegate(iSecondary.CacheBitmapV3);
			CacheColorTable = new CacheColorTableDelegate(iSecondary.CacheColorTable);
			CacheGlyph = new CacheGlyphDelegate(iSecondary.CacheGlyph);
			CacheGlyphV2 = new CacheGlyphV2Delegate(iSecondary.CacheGlyphV2);
			CacheBrush = new CacheBrushDelegate(iSecondary.CacheBrush);

			secondary->CacheBitmap = Marshal.GetFunctionPointerForDelegate(CacheBitmap);
			secondary->CacheBitmapV2 = Marshal.GetFunctionPointerForDelegate(CacheBitmapV2);
			secondary->CacheBitmapV3 = Marshal.GetFunctionPointerForDelegate(CacheBitmapV3);
			secondary->CacheColorTable = Marshal.GetFunctionPointerForDelegate(CacheColorTable);
			secondary->CacheGlyph = Marshal.GetFunctionPointerForDelegate(CacheGlyph);
			secondary->CacheGlyphV2 = Marshal.GetFunctionPointerForDelegate(CacheGlyphV2);
			secondary->CacheBrush = Marshal.GetFunctionPointerForDelegate(CacheBrush);			
		}
	}
}

