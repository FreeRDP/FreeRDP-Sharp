/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * FreeRDP
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
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void pContextNew(freerdp* instance, rdpContext* context);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void pContextFree(freerdp* instance, rdpContext* context);
	
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool pPreConnect(freerdp* instance);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool pPostConnect(freerdp* instance);
	
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool pAuthenticate(freerdp* instance, IntPtr username, IntPtr password, IntPtr domain);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool pVerifyCertificate(freerdp* instance, IntPtr subject, IntPtr issuer, IntPtr fingerprint);
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct freerdp
	{
		public rdpContext* context;
		public fixed UInt32 paddingA[16-1];
		
		public IntPtr input;
		public rdpUpdate* update;
		public rdpSettings* settings;
		public fixed UInt32 paddingB[32-19];
		
		public UIntPtr ContextSize;
		public IntPtr ContextNew;
		public IntPtr ContextFree;
		public fixed UInt32 paddingC[48-35];
		
		public IntPtr PreConnect;
		public IntPtr PostConnect;
		public IntPtr Authenticate;
		public IntPtr VerifyCertificate;
		public fixed UInt32 paddingD[64-52];
		
		public IntPtr SendChannelData;
		public IntPtr RecvChannelData;
		public fixed UInt32 paddingF[80-66];
	};
}

