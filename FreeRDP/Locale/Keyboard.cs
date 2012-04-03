/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Keyboard
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
	public unsafe class Keyboard
	{
		private UInt32 keyboardLayoutId;
		
		[DllImport("libfreerdp-locale")]
		public static extern UInt32 freerdp_keyboard_init(UInt32 keyboardLayoutId);
		
		[DllImport("libfreerdp-locale")]
		public static extern IntPtr freerdp_keyboard_get_layout_name_from_id(UInt32 keyboardLayoutId);
		
		[DllImport("libfreerdp-locale")]
		public static extern UInt32 freerdp_keyboard_get_rdp_scancode_from_x11_keycode(UInt32 keycode, ref int extended);
		
		[DllImport("libfreerdp-locale")]
		public static extern UInt32 freerdp_keyboard_get_x11_keycode_from_rdp_scancode(UInt32 scancode, int extended);
		
		[DllImport("libfreerdp-locale")]
		public static extern UInt32 freerdp_keyboard_get_rdp_scancode_from_virtual_key_code(UInt32 vkcode, ref int extended);
	
		[DllImport("libfreerdp-locale")]
		public static extern IntPtr freerdp_keyboard_get_virtual_key_code_name(UInt32 vkcode);
		
		public Keyboard()
		{
			keyboardLayoutId = freerdp_keyboard_init(0);
		}
		
		public string GetKeyboardLayoutNameFromId(UInt32 keyboardLayoutId)
		{
			string keyboardLayoutName;
			IntPtr cstr = freerdp_keyboard_get_layout_name_from_id(keyboardLayoutId);
			keyboardLayoutName = Marshal.PtrToStringAuto(cstr);
			return keyboardLayoutName;
		}
		
		public UInt32 GetRdpScancodeFromX11Keycode(UInt32 keycode, ref int extended)
		{
			UInt32 scancode;			
			scancode = freerdp_keyboard_get_rdp_scancode_from_x11_keycode(keycode, ref extended);
			return scancode;
		}
		
		public UInt32 GetX11KeycodeFromRdpScancode(UInt32 scancode, int extended)
		{
			UInt32 keycode;
			keycode = freerdp_keyboard_get_x11_keycode_from_rdp_scancode(scancode, extended);
			return keycode;
		}
		
		public UInt32 GetRdpScancodeFromVirtualKeyCode(UInt32 vkcode, ref int extended)
		{
			UInt32 scancode;
			scancode = freerdp_keyboard_get_rdp_scancode_from_virtual_key_code(vkcode, ref extended);
			return scancode;
		}
		
		public string GetVirtualKeyCodeName(UInt32 vkcode)
		{
			string vkcodeName;
			IntPtr cstr = freerdp_keyboard_get_virtual_key_code_name(vkcode);
			vkcodeName = Marshal.PtrToStringAuto(cstr);
			return vkcodeName;
		}
		
		~Keyboard()
		{

		}
	}
}
