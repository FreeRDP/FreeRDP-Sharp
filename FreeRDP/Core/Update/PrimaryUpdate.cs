/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Primary Updates
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
	public unsafe struct rdpBrush
	{
		public UInt32 x;
		public UInt32 y;
		public UInt32 bpp;
		public UInt32 style;
		public UInt32 hatch;
		public UInt32 index;
		public UInt32 data;
		public fixed byte p8x8[8];
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct OrderInfo
	{
		public UInt32 orderType;
		public UInt32 fieldFlags;
		public rdpBounds* bounds;
		public Int32 deltaBoundLeft;
		public Int32 deltaBoundTop;
		public Int32 deltaBoundRight;
		public Int32 deltaBoundBottom;
		public int deltaCoordinates;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DstBltOrder
	{
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nWidth;
		public Int32 nHeight;
		public UInt32 bRop;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PatBltOrder
	{
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nWidth;
		public Int32 nHeight;
		public UInt32 bRop;
		public UInt32 backColor;
		public UInt32 foreColor;
		public rdpBrush* brush;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ScrBltOrder
	{
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nWidth;
		public Int32 nHeight;
		public UInt32 bRop;
		public Int32 nXSrc;
		public Int32 nYSrc;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct OpaqueRectOrder
	{
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nWidth;
		public Int32 nHeight;
		public UInt32 color;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DrawNineGridOrder
	{
		public Int32 srcLeft;
		public Int32 srcTop;
		public Int32 srcRight;
		public Int32 srcBottom;
		public UInt32 bitmapId;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DeltaRect
	{
		public Int32 left;
		public Int32 top;
		public Int32 width;
		public Int32 height;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct MultiDstBltOrder
	{
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nWidth;
		public Int32 nHeight;
		public UInt32 bRop;
		public UInt32 numRectangles;
		public UInt32 cbData;
		//public fixed DeltaRect rectangles[45];
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct MultiPatBltOrder
	{
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nWidth;
		public Int32 nHeight;
		public UInt32 bRop;
		public UInt32 backColor;
		public UInt32 foreColor;
		public rdpBrush brush;
		public UInt32 numRectangles;
		public UInt32 cbData;
		//public fixed DeltaRect rectangles[45];
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct MultiScrBltOrder
	{
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nWidth;
		public Int32 nHeight;
		public UInt32 bRop;
		public Int32 nXSrc;
		public Int32 nYSrc;
		public UInt32 numRectangles;
		public UInt32 cbData;
		//public fixed DeltaRect rectangles[45];
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct MultiOpaqueRectOrder
	{
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nWidth;
		public Int32 nHeight;
		public UInt32 color;
		public UInt32 numRectangles;
		public UInt32 cbData;
		//public fixed DeltaRect rectangles[45];
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct MultiDrawNineGridOrder
	{
		public Int32 srcLeft;
		public Int32 srcTop;
		public Int32 srcRight;
		public Int32 srcBottom;
		public UInt32 bitmapId;
		public UInt32 nDeltaEntries;
		public UInt32 cbData;
		public byte* codeDeltaList;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct LineToOrder
	{
		public UInt32 backMode;
		public Int32 nXStart;
		public Int32 nYStart;
		public Int32 nXEnd;
		public Int32 nYEnd;
		public UInt32 backColor;
		public UInt32 bRop2;
		public UInt32 penStyle;
		public UInt32 penWidth;
		public UInt32 penColor;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DeltaPoint
	{
		public Int32 x;
		public Int32 y;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PolylineOrder
	{
		public Int32 xStart;
		public Int32 yStart;
		public UInt32 bRop2;
		public UInt32 penColor;
		public UInt32 numPoints;
		public UInt32 cbData;
		public DeltaPoint* points;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct MemBltOrder
	{
		public UInt32 cacheId;
		public UInt32 colorIndex;
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nWidth;
		public Int32 nHeight;
		public UInt32 bRop;
		public Int32 nXSrc;
		public Int32 nYSrc;
		public UInt32 cacheIndex;
		public rdpBitmap* bitmap;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct Mem3BltOrder
	{
		public UInt32 cacheId;
		public UInt32 colorIndex;
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nWidth;
		public Int32 nHeight;
		public UInt32 bRop;
		public Int32 nXSrc;
		public Int32 nYSrc;
		public UInt32 backColor;
		public UInt32 foreColor;
		public rdpBrush brush;
		public UInt32 cacheIndex;
		public rdpBitmap* bitmap;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SaveBitmapOrder
	{
		public UInt32 savedBitmapPosition;
		public Int32 nLeftRect;
		public Int32 nTopRect;
		public Int32 nRightRect;
		public Int32 nBottomRect;
		public UInt32 operation;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct GlyphFragmentIndex
	{
		public UInt32 index;
		public UInt32 delta;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct GlyphFragment
	{
		public UInt32 operation;
		public UInt32 index;
		public UInt32 size;
		public UInt32 nindices;
		public GlyphFragmentIndex* indices;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct GlyphIndexOrder
	{
		public UInt32 cacheId;
		public UInt32 flAccel;
		public UInt32 ulCharInc;
		public UInt32 fOpRedundant;
		public UInt32 backColor;
		public UInt32 foreColor;
		public Int32 bkLeft;
		public Int32 bkTop;
		public Int32 bkRight;
		public Int32 bkBottom;
		public Int32 opLeft;
		public Int32 opTop;
		public Int32 opRight;
		public Int32 opBottom;
		public rdpBrush brush;
		public Int32 x;
		public Int32 y;
		public UInt32 cbData;
		public fixed byte data[256];
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct FastIndexOrder
	{
		public UInt32 cacheId;
		public UInt32 flAccel;
		public UInt32 ulCharInc;
		public UInt32 backColor;
		public UInt32 foreColor;
		public Int32 bkLeft;
		public Int32 bkTop;
		public Int32 bkRight;
		public Int32 bkBottom;
		public Int32 opLeft;
		public Int32 opTop;
		public Int32 opRight;
		public Int32 opBottom;
		public int opaqueRect;
		public Int32 x;
		public Int32 y;
		public UInt32 cbData;
		public fixed byte data[256];
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct FastGlyphOrder
	{
		public UInt32 cacheId;
		public UInt32 flAccel;
		public UInt32 ulCharInc;
		public UInt32 backColor;
		public UInt32 foreColor;
		public Int32 bkLeft;
		public Int32 bkTop;
		public Int32 bkRight;
		public Int32 bkBottom;
		public Int32 opLeft;
		public Int32 opTop;
		public Int32 opRight;
		public Int32 opBottom;
		public Int32 x;
		public Int32 y;
		public UInt32 cbData;
		public fixed byte data[256];
		public void* glyphData;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PolygonSCOrder
	{
		public Int32 xStart;
		public Int32 yStart;
		public UInt32 bRop2;
		public UInt32 fillMode;
		public UInt32 brushColor;
		public UInt32 nDeltaEntries;
		public UInt32 cbData;
		public byte* codeDeltaList;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PolygonCBOrder
	{
		public Int32 xStart;
		public Int32 yStart;
		public UInt32 bRop2;
		public UInt32 fillMode;
		public UInt32 backColor;
		public UInt32 foreColor;
		public rdpBrush brush;
		public UInt32 nDeltaEntries;
		public UInt32 cbData;
		public byte* codeDeltaList;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct EllipseSCOrder
	{
		public Int32 leftRect;
		public Int32 topRect;
		public Int32 rightRect;
		public Int32 bottomRect;
		public UInt32 bRop2;
		public UInt32 fillMode;
		public UInt32 color;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct EllipseCBOrder
	{
		public Int32 leftRect;
		public Int32 topRect;
		public Int32 rightRect;
		public Int32 bottomRect;
		public UInt32 bRop2;
		public UInt32 fillMode;
		public UInt32 backColor;
		public UInt32 foreColor;
		public rdpBrush brush;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpPrimaryUpdate
	{
		public rdpContext* context;
		public fixed UInt32 paddingA[16-1];
		
		public IntPtr DstBlt;
		public IntPtr PatBlt;
		public IntPtr ScrBlt;
		public IntPtr OpaqueRect;
		public IntPtr DrawNineGrid;
		public IntPtr MultiDstBlt;
		public IntPtr MultiPatBlt;
		public IntPtr MultiScrBlt;
		public IntPtr MultiOpaqueRect;
		public IntPtr MultiDrawNineGrid;
		public IntPtr LineTo;
		public IntPtr Polyline;
		public IntPtr MemBlt;
		public IntPtr Mem3Blt;
		public IntPtr SaveBitmap;
		public IntPtr GlyphIndex;
		public IntPtr FastIndex;
		public IntPtr FastGlyph;
		public IntPtr PolygonSC;
		public IntPtr PolygonCB;
		public IntPtr EllipseSC;
		public IntPtr EllipseCB;
		public fixed UInt32 paddingB[48-38];
	}
	
	public unsafe interface IPrimaryUpdate
	{		
		void DstBlt(rdpContext* context, DstBltOrder* dstblt);
		void PatBlt(rdpContext* context, PatBltOrder* patblt);
		void ScrBlt(rdpContext* context, ScrBltOrder* scrblt);
		void OpaqueRect(rdpContext* context, OpaqueRectOrder* opaqueRect);
		void DrawNineGrid(rdpContext* context, DrawNineGridOrder* drawNineGrid);
		void MultiDstBlt(rdpContext* context, MultiDstBltOrder* multi_dstblt);
		void MultiPatBlt(rdpContext* context, MultiPatBltOrder* multi_patblt);
		void MultiScrBlt(rdpContext* context, MultiScrBltOrder* multi_scrblt);
		void MultiOpaqueRect(rdpContext* context, MultiOpaqueRectOrder* multi_opaque_rect);
		void MultiDrawNineGrid(rdpContext* context, MultiDrawNineGridOrder* multi_draw_nine_grid);
		void LineTo(rdpContext* context, LineToOrder* line_to);
		void Polyline(rdpContext* context, PolylineOrder* polyline);
		void MemBlt(rdpContext* context, MemBltOrder* memblt);
		void Mem3Blt(rdpContext* context, Mem3BltOrder* mem3blt);
		void SaveBitmap(rdpContext* context, SaveBitmapOrder* save_bitmap);
		void GlyphIndex(rdpContext* context, GlyphIndexOrder* glyph_index);
		void FastIndex(rdpContext* context, FastIndexOrder* fast_index);
		void FastGlyph(rdpContext* context, FastGlyphOrder* fast_glyph);
		void PolygonSC(rdpContext* context, PolygonSCOrder* polygon_sc);
		void PolygonCB(rdpContext* context, PolygonCBOrder* polygon_cb);
		void EllipseSC(rdpContext* context, EllipseSCOrder* ellipse_sc);
		void EllipseCB(rdpContext* context, EllipseCBOrder* ellipse_cb);
	}
	
	public unsafe class PrimaryUpdate
	{
		private freerdp* instance;
		private rdpContext* context;
		private rdpUpdate* update;
		private rdpPrimaryUpdate* primary;
		
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void DstBltDelegate(rdpContext* context, DstBltOrder* dstBlt);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void PatBltDelegate(rdpContext* context, PatBltOrder* patBlt);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void ScrBltDelegate(rdpContext* context, ScrBltOrder* scrBlt);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void OpaqueRectDelegate(rdpContext* context, OpaqueRectOrder* opaqueRect);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void DrawNineGridDelegate(rdpContext* context, DrawNineGridOrder* drawNineGrid);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void MultiDstBltDelegate(rdpContext* context, MultiDstBltOrder* multiDstBlt);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void MultiPatBltDelegate(rdpContext* context, MultiPatBltOrder* multiPatBlt);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void MultiScrBltDelegate(rdpContext* context, MultiScrBltOrder* multiScrBlt);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void MultiOpaqueRectDelegate(rdpContext* context, MultiOpaqueRectOrder* multiOpaqueRect);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void MultiDrawNineGridDelegate(rdpContext* context, MultiDrawNineGridOrder* multiDrawNineGrid);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void LineToDelegate(rdpContext* context, LineToOrder* lineTo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void PolylineDelegate(rdpContext* context, PolylineOrder* polyline);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void MemBltDelegate(rdpContext* context, MemBltOrder* memBlt);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void Mem3BltDelegate(rdpContext* context, Mem3BltOrder* mem3Blt);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void SaveBitmapDelegate(rdpContext* context, SaveBitmapOrder* saveBitmap);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void GlyphIndexDelegate(rdpContext* context, GlyphIndexOrder* glyphIndex);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void FastIndexDelegate(rdpContext* context, FastIndexOrder* fastIndex);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void FastGlyphDelegate(rdpContext* context, FastGlyphOrder* fastGlyph);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void PolygonSCDelegate(rdpContext* context, PolygonSCOrder* polygonSC);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void PolygonCBDelegate(rdpContext* context, PolygonCBOrder* polygonCB);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void EllipseSCDelegate(rdpContext* context, EllipseSCOrder* ellipseSC);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void EllipseCBDelegate(rdpContext* context, EllipseCBOrder* ellipseCB);
		
		private DstBltDelegate DstBlt;
		private PatBltDelegate PatBlt;
		private ScrBltDelegate ScrBlt;
		private OpaqueRectDelegate OpaqueRect;
		private DrawNineGridDelegate DrawNineGrid;
		private MultiDstBltDelegate MultiDstBlt;
		private MultiPatBltDelegate MultiPatBlt;
		private MultiScrBltDelegate MultiScrBlt;
		private MultiOpaqueRectDelegate MultiOpaqueRect;
		private MultiDrawNineGridDelegate MultiDrawNineGrid;
		private LineToDelegate LineTo;
		private PolylineDelegate Polyline;
		private MemBltDelegate MemBlt;
		private Mem3BltDelegate Mem3Blt;
		private SaveBitmapDelegate SaveBitmap;
		private GlyphIndexDelegate GlyphIndex;
		private FastIndexDelegate FastIndex;
		private FastGlyphDelegate FastGlyph;
		private PolygonSCDelegate PolygonSC;
		private PolygonCBDelegate PolygonCB;
		private EllipseSCDelegate EllipseSC;
		private EllipseCBDelegate EllipseCB;
		
		public PrimaryUpdate(rdpContext* context)
		{
			this.context = context;
			this.instance = context->instance;
			this.update = instance->update;
			this.primary = update->primary;
		}
		
		public void RegisterInterface(IPrimaryUpdate iPrimary)
		{
			DstBlt = new DstBltDelegate(iPrimary.DstBlt);
			PatBlt = new PatBltDelegate(iPrimary.PatBlt);
			ScrBlt = new ScrBltDelegate(iPrimary.ScrBlt);
			OpaqueRect = new OpaqueRectDelegate(iPrimary.OpaqueRect);
			DrawNineGrid = new DrawNineGridDelegate(iPrimary.DrawNineGrid);
			MultiDstBlt = new MultiDstBltDelegate(iPrimary.MultiDstBlt);
			MultiPatBlt = new MultiPatBltDelegate(iPrimary.MultiPatBlt);
			MultiScrBlt = new MultiScrBltDelegate(iPrimary.MultiScrBlt);
			MultiOpaqueRect = new MultiOpaqueRectDelegate(iPrimary.MultiOpaqueRect);
			MultiDrawNineGrid = new MultiDrawNineGridDelegate(iPrimary.MultiDrawNineGrid);
			LineTo = new LineToDelegate(iPrimary.LineTo);
			Polyline = new PolylineDelegate(iPrimary.Polyline);
			MemBlt = new MemBltDelegate(iPrimary.MemBlt);
			Mem3Blt = new Mem3BltDelegate(iPrimary.Mem3Blt);
			SaveBitmap = new SaveBitmapDelegate(iPrimary.SaveBitmap);
			GlyphIndex = new GlyphIndexDelegate(iPrimary.GlyphIndex);
			FastIndex = new FastIndexDelegate(iPrimary.FastIndex);
			FastGlyph = new FastGlyphDelegate(iPrimary.FastGlyph);
			PolygonSC = new PolygonSCDelegate(iPrimary.PolygonSC);
			PolygonCB = new PolygonCBDelegate(iPrimary.PolygonCB);
			EllipseSC = new EllipseSCDelegate(iPrimary.EllipseSC);
			EllipseCB = new EllipseCBDelegate(iPrimary.EllipseCB);
			
			primary->DstBlt = Marshal.GetFunctionPointerForDelegate(DstBlt);
			primary->PatBlt = Marshal.GetFunctionPointerForDelegate(PatBlt);
			primary->ScrBlt = Marshal.GetFunctionPointerForDelegate(ScrBlt);
			primary->OpaqueRect = Marshal.GetFunctionPointerForDelegate(OpaqueRect);
			primary->DrawNineGrid = Marshal.GetFunctionPointerForDelegate(DrawNineGrid);
			primary->MultiDstBlt = Marshal.GetFunctionPointerForDelegate(MultiDstBlt);
			primary->MultiPatBlt = Marshal.GetFunctionPointerForDelegate(MultiPatBlt);
			primary->MultiScrBlt = Marshal.GetFunctionPointerForDelegate(MultiScrBlt);
			primary->MultiOpaqueRect = Marshal.GetFunctionPointerForDelegate(MultiOpaqueRect);
			primary->MultiDrawNineGrid = Marshal.GetFunctionPointerForDelegate(MultiDrawNineGrid);
			primary->LineTo = Marshal.GetFunctionPointerForDelegate(LineTo);
			primary->Polyline = Marshal.GetFunctionPointerForDelegate(Polyline);
			primary->MemBlt = Marshal.GetFunctionPointerForDelegate(MemBlt);
			primary->Mem3Blt = Marshal.GetFunctionPointerForDelegate(Mem3Blt);
			primary->SaveBitmap = Marshal.GetFunctionPointerForDelegate(SaveBitmap);
			primary->GlyphIndex = Marshal.GetFunctionPointerForDelegate(GlyphIndex);
			primary->FastIndex = Marshal.GetFunctionPointerForDelegate(FastIndex);
			primary->FastGlyph = Marshal.GetFunctionPointerForDelegate(FastGlyph);
			primary->PolygonSC = Marshal.GetFunctionPointerForDelegate(PolygonSC);
			primary->PolygonCB = Marshal.GetFunctionPointerForDelegate(PolygonCB);
			primary->EllipseSC = Marshal.GetFunctionPointerForDelegate(EllipseSC);
			primary->EllipseCB = Marshal.GetFunctionPointerForDelegate(EllipseCB);
		}
	}
}

