/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Settings
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
	[StructLayout(LayoutKind.Explicit)]
	public unsafe struct rdpSettings
	{
		[FieldOffset(0 * 8)] public freerdp* instance;
		
		/* Core Protocol Parameters */
		[FieldOffset(16 * 8)] public UInt32 width;
		[FieldOffset(17 * 8)] public UInt32 height;
		[FieldOffset(18 * 8)] public UInt32 rdpVersion;
		[FieldOffset(19 * 8)] public UInt32 colorDepth;
		[FieldOffset(20 * 8)] public UInt32 kbdLayout;
		[FieldOffset(21 * 8)] public UInt32 kbdType;
		[FieldOffset(22 * 8)] public UInt32 kbdSubType;
		[FieldOffset(23 * 8)] public UInt32 kbdFnKeys;
		[FieldOffset(24 * 8)] public UInt32 clientBuild;
		[FieldOffset(25 * 8)] public UInt32 requestedProtocols;
		[FieldOffset(26 * 8)] public UInt32 selectedProtocol;
		[FieldOffset(27 * 8)] public UInt32 encryptionMethod;
		[FieldOffset(28 * 8)] public UInt32 encryptionLevel;
		[FieldOffset(29 * 8)] public int authentication;
		[FieldOffset(30 * 8)] public UInt32 negotiationFlags;
		[FieldOffset(31 * 8)] public int negotiateSecurity;
		
		/* Connection Settings */
		[FieldOffset(48 * 8)] public UInt32 port;
		[FieldOffset(49 * 8)] public int ipv6;
		[FieldOffset(50 * 8)] public IntPtr hostname;
		[FieldOffset(51 * 8)] public IntPtr username;
		[FieldOffset(52 * 8)] public IntPtr password;
		[FieldOffset(53 * 8)] public IntPtr domain;
		[FieldOffset(54 * 8)] public IntPtr shell;
		[FieldOffset(55 * 8)] public IntPtr directory;
		[FieldOffset(56 * 8)] public IntPtr ipAddress;
		[FieldOffset(57 * 8)] public IntPtr clientDir;
		[FieldOffset(58 * 8)] public int autologon;
		[FieldOffset(59 * 8)] public int compression;
		[FieldOffset(60 * 8)] public UInt32 performanceFlags;
		[FieldOffset(61 * 8)] public IntPtr passwordCookie;
		[FieldOffset(62 * 8)] public IntPtr kerberosKDC;
		[FieldOffset(63 * 8)] public IntPtr kerberosRealm;
		[FieldOffset(64 * 8)] public int tsGateway;
		[FieldOffset(65 * 8)] public IntPtr tsgHostname;
		[FieldOffset(66 * 8)] public IntPtr tsgUsername;
		[FieldOffset(67 * 8)] public IntPtr tsgPassword;
		[FieldOffset(68 * 8)] public int local;
		[FieldOffset(69 * 8)] public int authenticationOnly;
		[FieldOffset(70 * 8)] public int fromStandardInput;
		[FieldOffset(71 * 8)] public int sendConnectionPdu;
		[FieldOffset(72 * 8)] public UInt32 preconnectionId;
		[FieldOffset(73 * 8)] public IntPtr preconnectionBlob;
		
		/* User Interface Parameters */
		[FieldOffset(80 * 8)] public int softwareGdi;
		[FieldOffset(81 * 8)] public int workarea;
		[FieldOffset(82 * 8)] public int fullscreen;
		[FieldOffset(83 * 8)] public int grabKeyboard;
		[FieldOffset(84 * 8)] public int decorations;
		[FieldOffset(85 * 8)] public UInt32 percentScreen;
		[FieldOffset(86 * 8)] public int mouseMotion;
		[FieldOffset(87 * 8)] public IntPtr windowTitle;
		[FieldOffset(88 * 8)] public UInt64 parentWindowXid;
		
		/* Internal Parameters */
		[FieldOffset(112 * 8)] public IntPtr homePath;
		[FieldOffset(113 * 8)] public UInt32 shareId;
		[FieldOffset(114 * 8)] public UInt32 pduSource;
		[FieldOffset(115 * 8)] public IntPtr uniconv;
		[FieldOffset(116 * 8)] public int serverMode;
		[FieldOffset(117 * 8)] public IntPtr configPath;
		[FieldOffset(118 * 8)] public IntPtr currentPath;
		[FieldOffset(119 * 8)] public IntPtr developmentPath;
		[FieldOffset(120 * 8)] public int developmentMode;
		
		/* Security */
		[FieldOffset(144 * 8)] public int encryption;
		[FieldOffset(145 * 8)] public int tlsSecurity;
		[FieldOffset(146 * 8)] public int nlaSecurity;
		[FieldOffset(147 * 8)] public int rdpSecurity;
		[FieldOffset(148 * 8)] public UInt32 ntlmVersion;
		[FieldOffset(149 * 8)] public int saltedChecksum;
		
		/* Session */
		[FieldOffset(160 * 8)] public int consoleAudio;
		[FieldOffset(161 * 8)] public int consoleSession;
		[FieldOffset(162 * 8)] public UInt32 redirectedSessionId;
		[FieldOffset(163 * 8)] public int audioPlayback;
		[FieldOffset(164 * 8)] public int audioCapture;
	
		/* Output Control */
		[FieldOffset(176 * 8)] public int refreshRect;
		[FieldOffset(177 * 8)] public int suppressOutput;
		[FieldOffset(178 * 8)] public int desktopResize;
	
		/* Reconnection */
		[FieldOffset(192 * 8)] public int autoReconnection;
		[FieldOffset(193 * 8)] public IntPtr clientAutoReconnectCookie;
		[FieldOffset(194 * 8)] public IntPtr serverAutoReconnectCookie;
	
		/* Time Zone */
		[FieldOffset(208 * 8)] public IntPtr clientTimeZone;
	
		/* Capabilities */
		[FieldOffset(216 * 8)] public UInt32 osMajorType;
		[FieldOffset(217 * 8)] public UInt32 osMinorType;
		[FieldOffset(218 * 8)] public UInt32 vcChunkSize;
		[FieldOffset(219 * 8)] public int soundBeeps;
		[FieldOffset(220 * 8)] public int smoothFonts;
		[FieldOffset(221 * 8)] public int frameMarker;
		[FieldOffset(222 * 8)] public int fastpathInput;
		[FieldOffset(223 * 8)] public int fastpathOutput;
		[FieldOffset(224 * 8)] public IntPtr receivedCaps;
		[FieldOffset(225 * 8)] public IntPtr orderSupport;
		[FieldOffset(226 * 8)] public int surfaceCommands;
		[FieldOffset(227 * 8)] public int disableWallpaper;
		[FieldOffset(228 * 8)] public int disableFullWindowDrag;
		[FieldOffset(229 * 8)] public int disableMenuAnimations;
		[FieldOffset(230 * 8)] public int disableTheming;
		[FieldOffset(231 * 8)] public UInt32 connectionType;
		[FieldOffset(232 * 8)] public UInt32 multifragMaxRequestSize;
	
		/* Certificate */
		[FieldOffset(248 * 8)] public IntPtr certFile;
		[FieldOffset(249 * 8)] public IntPtr privateKeyFile;
		[FieldOffset(250 * 8)] public IntPtr clientHostname;
		[FieldOffset(251 * 8)] public IntPtr clientProductId;
		[FieldOffset(252 * 8)] public IntPtr serverRandom;
		[FieldOffset(253 * 8)] public IntPtr serverCertificate;
		[FieldOffset(254 * 8)] public int ignoreCertificate;
		[FieldOffset(255 * 8)] public IntPtr serverCert;
		[FieldOffset(256 * 8)] public IntPtr rdpKeyFile;
		[FieldOffset(257 * 8)] public IntPtr serverKey;
		[FieldOffset(258 * 8)] public IntPtr certificateName;
	
		/* Codecs */
		[FieldOffset(280 * 8)] public int rfxCodec;
		[FieldOffset(281 * 8)] public int nsCodec;
		[FieldOffset(282 * 8)] public UInt32 rfxCodecId;
		[FieldOffset(283 * 8)] public UInt32 nsCodecId;
		[FieldOffset(284 * 8)] public UInt32 rfxCodecMode;
		[FieldOffset(285 * 8)] public int frameAcknowledge;
		[FieldOffset(286 * 8)] public int jpegCodec;
		[FieldOffset(287 * 8)] public UInt32 jpegCodecId;
		[FieldOffset(288 * 8)] public UInt32 jpegQuality;
		[FieldOffset(289 * 8)] public UInt32 v3CodecId;
		[FieldOffset(290 * 8)] public int rfxCodecOnly;
	
		/* Recording */
		[FieldOffset(296 * 8)] public int dumpRfx;
		[FieldOffset(297 * 8)] public int playRfx;
		[FieldOffset(298 * 8)] public IntPtr dumpRfxFile;
		[FieldOffset(299 * 8)] public IntPtr playRfxFile;
	
		/* RemoteApp */
		[FieldOffset(312 * 8)] public int remoteApp;
		[FieldOffset(313 * 8)] public UInt32 numIconCaches;
		[FieldOffset(314 * 8)] public UInt32 numIconCacheEntries;
		[FieldOffset(315 * 8)] public int railLangbarSupported;
	
		/* Pointer */
		[FieldOffset(320 * 8)] public int largePointer;
		[FieldOffset(321 * 8)] public int colorPointer;
		[FieldOffset(322 * 8)] public UInt32 pointerCacheSize;
	
		/* Bitmap Cache */
		[FieldOffset(328 * 8)] public int bitmapCache;
		[FieldOffset(329 * 8)] public int bitmapCacheV3;
		[FieldOffset(330 * 8)] public int persistentBitmapCache;
		[FieldOffset(331 * 8)] public UInt32 bitmapCacheV2NumCells;
		[FieldOffset(332 * 8)] public IntPtr bitmapCacheV2CellInfo;
	
		/* Offscreen Bitmap Cache */
		[FieldOffset(344 * 8)] public int offscreenBitmapCache;
		[FieldOffset(345 * 8)] public UInt32 offscreenBitmapCacheSize;
		[FieldOffset(346 * 8)] public UInt32 offscreenBitmapCacheEntries;
	
		/* Glyph Cache */
		[FieldOffset(352 * 8)] public int glyphCache;
		[FieldOffset(353 * 8)] public UInt32 glyphSupportLevel;
		[FieldOffset(354 * 8)] public IntPtr glyphCacheInfo;
		[FieldOffset(355 * 8)] public IntPtr fragCacheInfo;
	
		/* Draw Nine Grid */
		[FieldOffset(360 * 8)] public int drawNineGrid;
		[FieldOffset(361 * 8)] public UInt32 drawNineGridCacheSize;
		[FieldOffset(362 * 8)] public UInt32 drawNineGridCacheEntries;
	
		/* Draw GDI+ */
		[FieldOffset(368 * 8)] public int drawGdiPlus;
		[FieldOffset(369 * 8)] public int drawGdiPlusCache;
	
		/* Desktop Composition */
		[FieldOffset(376 * 8)] public int desktopComposition;
	};
}

