/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Alternate Secondary Updates
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
	public unsafe struct OffscreenDeleteList
	{
		public UInt32 cIndices;
		public UInt16* indices;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CreateOffscreenBitmapOrder
	{
		public UInt32 id;
		public UInt32 cx;
		public UInt32 cy;
		public OffscreenDeleteList deleteList;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SwitchSurfaceOrder
	{
		public UInt32 bitmapId;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct NineGridBitmapInfo
	{
		public UInt32 flFlags;
		public UInt32 ulLeftWidth;
		public UInt32 ulRightWidth;
		public UInt32 ulTopHeight;
		public UInt32 ulBottomHeight;
		public UInt32 crTransparent;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CreateNineGridBitmapOrder
	{
		public UInt32 bitmapBpp;
		public UInt32 bitmapId;
		public UInt32 cx;
		public UInt32 cy;
		public NineGridBitmapInfo* nineGridInfo;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct FrameMarkerOrder
	{
		public UInt32 action;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct StreamBitmapFirstOrder
	{
		public UInt32 bitmapFlags;
		public UInt32 bitmapBpp;
		public UInt32 bitmapType;
		public UInt32 bitmapWidth;
		public UInt32 bitmapHeight;
		public UInt32 bitmapSize;
		public UInt32 bitmapBlockSize;
		public byte* bitmapBlock;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct StreamBitmapNextOrder
	{
		public UInt32 bitmapFlags;
		public UInt32 bitmapType;
		public UInt32 bitmapBlockSize;
		public byte* bitmapBlock;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DrawGdiPlusFirstOrder
	{
		public UInt32 cbSize;
		public UInt32 cbTotalSize;
		public UInt32 cbTotalEmfSize;
		public byte* emfRecords;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DrawGdiPlusNextOrder
	{
		public UInt32 cbSize;
		public byte* emfRecords;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DrawGdiPlusEndOrder
	{
		public UInt32 cbSize;
		public UInt32 cbTotalSize;
		public UInt32 cbTotalEmfSize;
		public byte* emfRecords;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DrawGdiPlusCacheFirstOrder
	{
		public UInt32 flags;
		public UInt32 cacheType;
		public UInt32 cacheIndex;
		public UInt32 cbSize;
		public UInt32 cbTotalSize;
		public byte* emfRecords;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DrawGdiPlusCacheNextOrder
	{
		public UInt32 flags;
		public UInt32 cacheType;
		public UInt32 cacheIndex;
		public UInt32 cbSize;
		public byte* emfRecords;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DrawGdiPlusCacheEndOrder
	{
		public UInt32 flags;
		public UInt32 cacheType;
		public UInt32 cacheIndex;
		public UInt32 cbSize;
		public UInt32 cbTotalSize;
		public byte* emfRecords;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpAltSecUpdate
	{
		public rdpContext* context;
		public fixed UInt32 paddingA[16-1];
		
		public IntPtr CreateOffscreenBitmap;
		public IntPtr SwitchSurface;
		public IntPtr CreateNineGridBitmap;
		public IntPtr FrameMarker;
		public IntPtr StreamBitmapFirst;
		public IntPtr StreamBitmapNext;
		public IntPtr DrawGdiPlusFirst;
		public IntPtr DrawGdiPlusNext;
		public IntPtr DrawGdiPlusEnd;
		public IntPtr DrawGdiPlusCacheFirst;
		public IntPtr DrawGdiPlusCacheNext;
		public IntPtr DrawGdiPlusCacheEnd;
		public fixed UInt32 paddingB[32-28];
	}
	
	public unsafe interface IAltSecUpdate
	{
		void CreateOffscreenBitmap(rdpContext* context, CreateOffscreenBitmapOrder* createOffscreenBitmap);
		void SwitchSurface(rdpContext* context, SwitchSurfaceOrder* switchSurface);
		void CreateNineGridBitmap(rdpContext* context, CreateNineGridBitmapOrder* createNineGridBitmap);
		void FrameMarker(rdpContext* context, FrameMarkerOrder* frameMarker);
		void StreamBitmapFirst(rdpContext* context, StreamBitmapFirstOrder* streamBitmapFirst);
		void StreamBitmapNext(rdpContext* context, StreamBitmapNextOrder* streamBitmapNext);
		void DrawGdiPlusFirst(rdpContext* context, DrawGdiPlusFirstOrder* drawGdiPlusFirst);
		void DrawGdiPlusNext(rdpContext* context, DrawGdiPlusNextOrder* drawGdiPlusNext);
		void DrawGdiPlusEnd(rdpContext* context, DrawGdiPlusEndOrder* drawGdiPlusEnd);
		void DrawGdiPlusCacheFirst(rdpContext* context, DrawGdiPlusCacheFirstOrder* drawGdiPlusCacheFirst);
		void DrawGdiPlusCacheNext(rdpContext* context, DrawGdiPlusCacheNextOrder* drawGdiPlusCacheNext);
		void DrawGdiPlusCacheEnd(rdpContext* context, DrawGdiPlusCacheEndOrder* drawGdiPlusCacheEnd);
	}
	
	public unsafe class AltSecUpdate
	{
		private freerdp* instance;
		private rdpContext* context;
		private rdpUpdate* update;
		private rdpAltSecUpdate* altsec;
		
		delegate void CreateOffscreenBitmapDelegate(rdpContext* context, CreateOffscreenBitmapOrder* createOffscreenBitmap);
		delegate void SwitchSurfaceDelegate(rdpContext* context, SwitchSurfaceOrder* switchSurface);
		delegate void CreateNineGridBitmapDelegate(rdpContext* context, CreateNineGridBitmapOrder* createNineGridBitmap);
		delegate void FrameMarkerDelegate(rdpContext* context, FrameMarkerOrder* frameMarker);
		delegate void StreamBitmapFirstDelegate(rdpContext* context, StreamBitmapFirstOrder* streamBitmapFirst);
		delegate void StreamBitmapNextDelegate(rdpContext* context, StreamBitmapNextOrder* streamBitmapNext);
		delegate void DrawGdiPlusFirstDelegate(rdpContext* context, DrawGdiPlusFirstOrder* drawGdiPlusFirst);
		delegate void DrawGdiPlusNextDelegate(rdpContext* context, DrawGdiPlusNextOrder* drawGdiPlusNext);
		delegate void DrawGdiPlusEndDelegate(rdpContext* context, DrawGdiPlusEndOrder* drawGdiPlusEnd);
		delegate void DrawGdiPlusCacheFirstDelegate(rdpContext* context, DrawGdiPlusCacheFirstOrder* drawGdiPlusCacheFirst);
		delegate void DrawGdiPlusCacheNextDelegate(rdpContext* context, DrawGdiPlusCacheNextOrder* drawGdiPlusCacheNext);
		delegate void DrawGdiPlusCacheEndDelegate(rdpContext* context, DrawGdiPlusCacheEndOrder* drawGdiPlusCacheEnd);
		
		private CreateOffscreenBitmapDelegate CreateOffscreenBitmap;
		private SwitchSurfaceDelegate SwitchSurface;
		private CreateNineGridBitmapDelegate CreateNineGridBitmap;
		private FrameMarkerDelegate FrameMarker;
		private StreamBitmapFirstDelegate StreamBitmapFirst;
		private StreamBitmapNextDelegate StreamBitmapNext;
		private DrawGdiPlusFirstDelegate DrawGdiPlusFirst;
		private DrawGdiPlusNextDelegate DrawGdiPlusNext;
		private DrawGdiPlusEndDelegate DrawGdiPlusEnd;
		private DrawGdiPlusCacheFirstDelegate DrawGdiPlusCacheFirst;
		private DrawGdiPlusCacheNextDelegate DrawGdiPlusCacheNext;
		private DrawGdiPlusCacheEndDelegate DrawGdiPlusCacheEnd;
		
		public AltSecUpdate(rdpContext* context)
		{
			this.context = context;
			this.instance = context->instance;
			this.update = instance->update;
			this.altsec = update->altsec;
		}
		
		public void RegisterInterface(IAltSecUpdate iAltSec)
		{
			CreateOffscreenBitmap = new CreateOffscreenBitmapDelegate(iAltSec.CreateOffscreenBitmap);
			SwitchSurface = new SwitchSurfaceDelegate(iAltSec.SwitchSurface);
			CreateNineGridBitmap = new CreateNineGridBitmapDelegate(iAltSec.CreateNineGridBitmap);
			FrameMarker = new FrameMarkerDelegate(iAltSec.FrameMarker);
			StreamBitmapFirst = new StreamBitmapFirstDelegate(iAltSec.StreamBitmapFirst);
			StreamBitmapNext = new StreamBitmapNextDelegate(iAltSec.StreamBitmapNext);
			DrawGdiPlusFirst = new DrawGdiPlusFirstDelegate(iAltSec.DrawGdiPlusFirst);
			DrawGdiPlusNext = new DrawGdiPlusNextDelegate(iAltSec.DrawGdiPlusNext);
			DrawGdiPlusEnd = new DrawGdiPlusEndDelegate(iAltSec.DrawGdiPlusEnd);
			DrawGdiPlusCacheFirst = new DrawGdiPlusCacheFirstDelegate(iAltSec.DrawGdiPlusCacheFirst);
			DrawGdiPlusCacheNext = new DrawGdiPlusCacheNextDelegate(iAltSec.DrawGdiPlusCacheNext);
			DrawGdiPlusCacheEnd = new DrawGdiPlusCacheEndDelegate(iAltSec.DrawGdiPlusCacheEnd);
			
			altsec->CreateOffscreenBitmap = Marshal.GetFunctionPointerForDelegate(CreateOffscreenBitmap);
			altsec->SwitchSurface = Marshal.GetFunctionPointerForDelegate(SwitchSurface);
			altsec->CreateNineGridBitmap = Marshal.GetFunctionPointerForDelegate(CreateNineGridBitmap);
			altsec->FrameMarker = Marshal.GetFunctionPointerForDelegate(FrameMarker);
			altsec->StreamBitmapFirst = Marshal.GetFunctionPointerForDelegate(StreamBitmapFirst);
			altsec->StreamBitmapNext = Marshal.GetFunctionPointerForDelegate(StreamBitmapNext);
			altsec->DrawGdiPlusFirst = Marshal.GetFunctionPointerForDelegate(DrawGdiPlusFirst);
			altsec->DrawGdiPlusNext = Marshal.GetFunctionPointerForDelegate(DrawGdiPlusNext);
			altsec->DrawGdiPlusEnd = Marshal.GetFunctionPointerForDelegate(DrawGdiPlusEnd);
			altsec->DrawGdiPlusCacheFirst = Marshal.GetFunctionPointerForDelegate(DrawGdiPlusCacheFirst);
			altsec->DrawGdiPlusCacheNext = Marshal.GetFunctionPointerForDelegate(DrawGdiPlusCacheNext);
			altsec->DrawGdiPlusCacheEnd = Marshal.GetFunctionPointerForDelegate(DrawGdiPlusCacheEnd);
		}
	}
}

