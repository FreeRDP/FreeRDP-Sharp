/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Memory Utils
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
	public unsafe static class Memory
	{
		[DllImport("libfreerdp", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr xmalloc(UIntPtr size);

		[DllImport("libfreerdp", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr xzalloc(UIntPtr size);

		[DllImport("libfreerdp", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr xrealloc(IntPtr ptr, UIntPtr size);

		[DllImport("libfreerdp", CallingConvention = CallingConvention.Cdecl)]
		public static extern void xfree(IntPtr ptr);

		public static IntPtr Malloc(int size)
		{		
			UIntPtr size_t = new UIntPtr((ulong) size);
			return xmalloc(size_t);
		}
		
		public static IntPtr Zalloc(int size)
		{
			UIntPtr size_t = new UIntPtr((ulong) size);
			return xzalloc(size_t);
		}
		
		public static IntPtr Realloc(IntPtr ptr, int size)
		{
			UIntPtr size_t = new UIntPtr((ulong) size);
			return xrealloc(ptr, size_t);
		}
		
		public static void Free(IntPtr ptr)
		{
			xfree(ptr);
		}
	}
}

