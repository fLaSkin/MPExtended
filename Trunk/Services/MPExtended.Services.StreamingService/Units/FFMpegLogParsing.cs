﻿#region Copyright
/* 
 *  Copyright (C) 2011 Oxan
 *
 *  This Program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2, or (at your option)
 *  any later version.
 *   
 *  This Program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *   
 *  You should have received a copy of the GNU General Public License
 *  along with GNU Make; see the file COPYING.  If not, write to
 *  the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA. 
 *  http://www.gnu.org/copyleft/gpl.html
 *
 */
#endregion

using System.IO;
using System.Threading;
using MPExtended.Services.StreamingService.Util;

namespace MPExtended.Services.StreamingService.Units {
    internal class FFMpegLogParsing : ILogProcessingUnit {
        public Stream InputStream { get; set; }
        public bool LogMessages { get; set; }
        public bool LogProgress { get; set; }
        private Reference<EncodingInfo> data;
        private Thread processThread;

        public FFMpegLogParsing(Reference<EncodingInfo> save) {
            data = save;
        }

        public bool Setup() {
            // this might be better placed in the Start() method, but EncoderUnit.Start() depends on this
            processThread = new Thread(new ThreadStart(delegate()
            {
                OutputParsing.ParseOutputStream(InputStream, data, LogMessages, LogProgress);
            }));
            processThread.Start();
            return true;
        }

        public bool Start() {
            return true;
        }

        public bool Stop() {
            processThread.Abort();
            return true;
        }
    }
}