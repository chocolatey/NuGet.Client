// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.IO;

namespace NuGet.Protocol
{
    public delegate void StreamUpdate(Stream sender, long progress, long totalProgress);

    // Based on https://www.thomasbogholm.net/2021/07/15/extend-streams-with-progress-reporting-progressreportingstream/
    public class ChocolateyProgressStream : Stream
    {
        public ChocolateyProgressStream(Stream s)
        {
            InnerStream = s;
        }

        public event StreamUpdate WriteProgress;
        public event StreamUpdate ReadProgress;

        Stream InnerStream { get; }

        private long _totalBytesRead;
        private long _totalBytesWritten;

        private void UpdateRead(long read)
        {
            _totalBytesRead += read;
            ReadProgress?.Invoke(this, read, _totalBytesRead);
        }

        private void UpdateWritten(long written)
        {
            _totalBytesWritten += written;
            WriteProgress?.Invoke(this, written, _totalBytesWritten);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var result = InnerStream.Read(buffer, offset, count);
            UpdateRead(result);
            return result;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            InnerStream.Write(buffer, offset, count);
            UpdateWritten(count);
        }

        public override bool CanRead => InnerStream.CanRead;
        public override bool CanSeek => InnerStream.CanSeek;
        public override bool CanWrite => InnerStream.CanWrite;
        public override long Length => InnerStream.Length;
        public override long Position { get => InnerStream.Position; set => InnerStream.Position = value; }

        public override void Flush() => InnerStream.Flush();
        public override long Seek(long offset, SeekOrigin origin) => InnerStream.Seek(offset, origin);
        public override void SetLength(long value) => InnerStream.SetLength(value);
    }
}
