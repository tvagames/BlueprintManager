using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintManager
{
    public class BlockCondition
    {
        public enum TargetType
        {
            All,
            Group,
            Block,
            Blocks
        }
        public TargetType Target { get; set; }
        public List<string> Group { get; set; }
        public BlockIdItem Block { get; set; }
        public List<BlockIdItem> Blocks { get; set; } = new List<BlockIdItem>();

        public bool IsColor { get; set; }
        public int ColorNumber { get; set; }
        public bool IsX { get; set; }
        public bool IsY { get; set; }
        public bool IsZ { get; set; }
        public bool IsXInverted { get; set; }
        public bool IsYInverted { get; set; }
        public bool IsZInverted { get; set; }
        public Nullable<int> XFrom { get; set; }
        public Nullable<int> XTo { get; set; }
        public Nullable<int> YFrom { get; set; }
        public Nullable<int> YTo { get; set; }
        public Nullable<int> ZFrom { get; set; }
        public Nullable<int> ZTo { get; set; }

        public bool IsMain { get; set; }
        public bool IsSub { get; set; }
    }
}
