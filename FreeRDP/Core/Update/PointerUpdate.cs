/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Pointer Updates
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
	public unsafe struct PointerPositionUpdate
	{
		public UInt32 xPos;
		public UInt32 yPos;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PointerSystemUpdate
	{
		public UInt32 type;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PointerColorUpdate
	{
		public UInt32 cacheIndex;
		public UInt32 xPos;
		public UInt32 yPos;
		public UInt32 width;
		public UInt32 height;
		public UInt32 lengthAndMask;
		public UInt32 lengthXorMask;
		public byte* xorMaskData;
		public byte* andMaskData;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PointerNewUpdate
	{
		public UInt32 xorBpp;
		public PointerColorUpdate colorPtrAttr;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PointerCachedUpdate
	{
		public UInt32 cacheIndex;
	}
	
	public unsafe delegate void pPointerPosition(rdpContext* context, PointerPositionUpdate* pointerPosition);
	public unsafe delegate void pPointerSystem(rdpContext* context, PointerSystemUpdate* pointerSystem);
	public unsafe delegate void pPointerColor(rdpContext* context, PointerColorUpdate* pointerColor);
	public unsafe delegate void pPointerNew(rdpContext* context, PointerNewUpdate* pointerNew);
	public unsafe delegate void pPointerCached(rdpContext* context, PointerCachedUpdate* pointerCached);
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpPointerUpdate
	{
		public rdpContext* context;
		public fixed UInt32 paddingA[16-1];
		
		public IntPtr PointerPosition;
		public IntPtr PointerSystem;
		public IntPtr PointerColor;
		public IntPtr PointerNew;
		public IntPtr PointerCached;
		public fixed UInt32 paddingB[32-21];
	}
}

