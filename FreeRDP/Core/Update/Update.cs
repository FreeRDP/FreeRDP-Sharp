/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Updates
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
	public unsafe struct rdpBounds
	{
		public Int32 left;
		public Int32 top;
		public Int32 right;
		public Int32 bottom;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct BitmapData
	{
		public UInt32 destLeft;
		public UInt32 destTop;
		public UInt32 destRight;
		public UInt32 destBottom;
		public UInt32 width;
		public UInt32 height;
		public UInt32 bitsPerPixel;
		public UInt32 flags;
		public UInt32 bitmapLength;
		public fixed byte bitmapComprHdr[8];
		public IntPtr bitmapDataStream;
		public int compressed;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct BitmapUpdate
	{
		public UInt32 count;
		public UInt32 number;
		public BitmapData* rectangles;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PaletteEntry
	{
		public byte red;
		public byte green;
		public byte blue;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PaletteUpdate
	{
		public UInt32 number;
		public PaletteEntry* entries;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpPalette
	{
		public UInt32 count;
		public PaletteEntry* entries;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PlaySoundUpdate
	{
		public UInt32 duration;
		public UInt32 frequency;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SurfaceBits
	{
		public UInt32 cmdType;
		public UInt32 destLeft;
		public UInt32 destTop;
		public UInt32 destRight;
		public UInt32 destBottom;
		public UInt32 bpp;
		public UInt32 codecID;
		public UInt32 width;
		public UInt32 height;
		public UInt32 bitmapDataLength;
		public byte* bitmapData;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SurfaceFrameMarker
	{
		public UInt32 frameAction;
		public UInt32 frameId;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpUpdate
	{
		public IntPtr context;
		public fixed UInt32 paddingA[16-1];
		
		public IntPtr BeginPaint;
		public IntPtr EndPaint;
		public IntPtr SetBounds;
		public IntPtr Synchronize;
		public IntPtr DesktopResize;
		public IntPtr BitmapUpdate;
		public IntPtr Palette;
		public IntPtr PlaySound;
		public fixed UInt32 paddingB[32-24];
		
		public rdpPointerUpdate* pointer;
		public rdpPrimaryUpdate* primary;
		public rdpSecondaryUpdate* secondary;
		public rdpAltSecUpdate* altsec;
		public rdpWindowUpdate* window;
		public fixed UInt32 paddingC[48-37];
		
		public IntPtr RefreshRect;
		public IntPtr SuppressOutput;
		public fixed UInt32 paddingD[64-50];
		
		public IntPtr Surface;
		public IntPtr SurfaceBits;
		public fixed UInt32 paddingE[80-66];
	}
	
	public unsafe interface IUpdate
	{
		void BeginPaint(rdpContext* context);
		void EndPaint(rdpContext* context);
		void SetBounds(rdpContext* context, rdpBounds* bounds);
		void Synchronize(rdpContext* context);
		void DesktopResize(rdpContext* context);
		void BitmapUpdate(rdpContext* context, BitmapUpdate* bitmap);
		void Palette(rdpContext* context, PaletteUpdate* palette);
		void PlaySound(rdpContext* context, PlaySoundUpdate* playSound);
		void SurfaceBits(rdpContext* context, SurfaceBits* surfaceBits);
	}
	
	public unsafe class Update
	{
		private freerdp* instance;
		private rdpContext* context;
		private rdpUpdate* update;
		
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void BeginPaintDelegate(rdpContext* context);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void EndPaintDelegate(rdpContext* context);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void SetBoundsDelegate(rdpContext* context, rdpBounds* bounds);
		delegate void SynchronizeDelegate(rdpContext* context);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void DesktopResizeDelegate(rdpContext* context);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void BitmapUpdateDelegate(rdpContext* context, BitmapUpdate* bitmap);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void PaletteDelegate(rdpContext* context, PaletteUpdate* palette);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void PlaySoundDelegate(rdpContext* context, PlaySoundUpdate* playSound);
		
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void RefreshRectDelegate(rdpContext* context, byte count, IntPtr areas);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void SuppressOutputDelegate(rdpContext* context, byte allow, IntPtr area);
		
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void SurfaceBitsDelegate(rdpContext* context, SurfaceBits* surfaceBits);
		
		private BeginPaintDelegate BeginPaint;
		private EndPaintDelegate EndPaint;
		private SetBoundsDelegate SetBounds;
		private SynchronizeDelegate Synchronize;
		private DesktopResizeDelegate DesktopResize;
		private BitmapUpdateDelegate BitmapUpdate;
		private PaletteDelegate Palette;
		private PlaySoundDelegate PlaySound;
		
		private SurfaceBitsDelegate SurfaceBits;
		
		public Update(rdpContext* context)
		{
			this.context = context;
			this.instance = context->instance;
			this.update = instance->update;
		}
		
		public void RegisterInterface(IUpdate iUpdate)
		{
			BeginPaint = new BeginPaintDelegate(iUpdate.BeginPaint);
			EndPaint = new EndPaintDelegate(iUpdate.EndPaint);
			SetBounds = new SetBoundsDelegate(iUpdate.SetBounds);
			Synchronize = new SynchronizeDelegate(iUpdate.Synchronize);
			DesktopResize = new DesktopResizeDelegate(iUpdate.DesktopResize);
			BitmapUpdate = new BitmapUpdateDelegate(iUpdate.BitmapUpdate);
			Palette = new PaletteDelegate(iUpdate.Palette);
			PlaySound = new PlaySoundDelegate(iUpdate.PlaySound);
			SurfaceBits = new SurfaceBitsDelegate(iUpdate.SurfaceBits);

			update->BeginPaint = Marshal.GetFunctionPointerForDelegate(BeginPaint);
			update->EndPaint = Marshal.GetFunctionPointerForDelegate(EndPaint);
			update->SetBounds = Marshal.GetFunctionPointerForDelegate(SetBounds);
			update->Synchronize = Marshal.GetFunctionPointerForDelegate(Synchronize);
			update->DesktopResize = Marshal.GetFunctionPointerForDelegate(DesktopResize);
			update->BitmapUpdate = Marshal.GetFunctionPointerForDelegate(BitmapUpdate);
			update->Palette = Marshal.GetFunctionPointerForDelegate(Palette);
			update->PlaySound = Marshal.GetFunctionPointerForDelegate(PlaySound);
			update->SurfaceBits = Marshal.GetFunctionPointerForDelegate(SurfaceBits);
		}
	}
}
