/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Surface Command
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

namespace FreeRDP
{	
	public abstract class SurfaceCommand
	{
		public UInt16 CmdType = 0;
		
		protected const UInt16 CMDTYPE_SET_SURFACE_BITS = 1;
		protected const UInt16 CMDTYPE_STREAM_SURFACE_BITS = 6;
		protected const UInt16 CMDTYPE_FRAME_MARKER = 4;
		
		protected const byte CODEC_ID_NONE = 0x00;
		protected const byte CODEC_ID_NSCODEC = 0x01;
		protected const byte CODEC_ID_REMOTEFX = 0x03;
		
		public SurfaceCommand()
		{
		}
		
		public virtual void Read(BinaryReader fp) {}
		public abstract byte[] Write();
		
		public abstract UInt16 GetCmdType();
		
		public static SurfaceCommand Parse(BinaryReader fp)
		{
			UInt16 cmdType;
			SurfaceCommand cmd = null;
			
			cmdType = fp.ReadUInt16();
			
			switch (cmdType)
			{
				case CMDTYPE_SET_SURFACE_BITS:
					cmd = new SetSurfaceBitsCommand();
					cmd.Read(fp);
					break;
				
				case CMDTYPE_STREAM_SURFACE_BITS:
					cmd = new StreamSurfaceBitsCommand();
					cmd.Read(fp);
					break;
				
				case CMDTYPE_FRAME_MARKER:
					cmd = new FrameMarkerCommand();
					cmd.Read(fp);
					break;
				
				default:
					Console.WriteLine("Unknown Surface Command: {0}", cmdType);
					break;
			}
			
			return cmd;
		}
	}
}

