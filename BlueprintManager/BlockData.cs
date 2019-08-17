using System.Collections.Generic;

namespace BlueprintManager
{
    internal class BlockData
    {
        public byte[] SortedBytes { get; internal set; }
        public byte[] DataBytes { get; internal set; }
        public uint DataLength { get; internal set; }
        public byte[] HeaderBytes { get; internal set; }
        public uint HeaderLength { get; internal set; }
        public uint Id { get; internal set; }
        public uint SortedLength { get; internal set; }
    }
}