using System.Collections.Generic;
using System.Drawing;

namespace BlueprintManager
{
    internal class BlockAction
    {
        public BlockIdItem Block { get; internal set; }

        public bool IsColorPalette { get; set; }
        public ColorPalette ColorPalette { get; internal set; }

        public bool IsColor { get; set; }
        public int ColorNumber { get; internal set; }

        public List<string> Group { get; internal set; }
        public ActionType Action { get; internal set; }

        public enum ActionType
        {
            None,
            Group,
            Block
        }
    }
}