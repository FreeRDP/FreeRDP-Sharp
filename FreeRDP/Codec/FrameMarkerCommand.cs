/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Frame Marker Command
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
	public class FrameMarkerCommand : SurfaceCommand
	{
		private UInt16 frameAction;
		private UInt32 frameId;
		
		public FrameMarkerCommand()
		{
		}
		
		public override void Read(BinaryReader fp)
		{
			frameAction = fp.ReadUInt16(); /* frameAction */
			frameId = fp.ReadUInt32(); /* frameId */
		}
		
		public override byte[] Write()
		{
			byte[] buffer = new byte[2 + 6];
			BinaryWriter s = new BinaryWriter(new MemoryStream(buffer));
			
			s.Write(CmdType);
			
			s.Write(frameAction);
			s.Write(frameId);
			
			return buffer;
		}
		
		public override UInt16 GetCmdType()
		{
			return CMDTYPE_FRAME_MARKER;
		}
	}
}

