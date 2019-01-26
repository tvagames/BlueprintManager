using System;
using System.Collections.Generic;

namespace BlueprintManager
{

    public enum Rotation
    {
        ForwardUp,
        RightUp,
        BackUp,
        LeftUp,
        DownForward,
        DownRight,
        DownBack,
        DownLeft,
        UpForward,
        UpRight,
        UpBack,
        UpLeft,
        ForwardDown,
        RightDown,
        BackDown,
        LeftDown,
        ForwardRight,
        BackRight,
        ForwardLeft,
        BackLeft,
        RightForward,
        LeftForward,
        RightBack,
        LeftBack,
    }

    public class Construction
    {
        public List<BlockInfo> Blocks { get; set; } = new List<BlockInfo>();
        public Vector3 LocalPosition { get; internal set; }
        public Construction Parent { get; internal set; }
        public Vector3 Position { get; internal set; }
        public List<Construction> Subconstructions { get; set; } = new List<Construction>();

        public List<BlockInfo> GetAllBlocks()
        {
            var ret = new List<BlockInfo>();
            ret.AddRange(this.Blocks);
            foreach (var sc in this.Subconstructions)
            {
                ret.AddRange(this.GetSubBlocks(sc));
            }
            return ret;
        }

        private List<BlockInfo> GetSubBlocks(Construction parent)
        {
            var ret = new List<BlockInfo>();
            ret.AddRange(parent.Blocks);
            foreach (var sc in parent.Subconstructions)
            {
//                ret.AddRange(sc.Blocks);
                ret.AddRange(sc.GetSubBlocks(sc));
            }
            return ret;
        }
    }

    public class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }

    public class BlockInfo
    {
        public Vector3 localPosition;
        public Vector3 position;
        public List<Vector3> Vertecis { get; set; } = new List<Vector3>();
        //public float x;
        //public float y;
        //public float z;
        public int id;
        public int colorIndex;
        public Rotation rotation;

        public bool IsForward()
        {
            return this.rotation == Rotation.ForwardDown
                || this.rotation == Rotation.ForwardLeft
                || this.rotation == Rotation.ForwardRight
                || this.rotation == Rotation.ForwardUp;
        }

        public bool IsBack()
        {
            return this.rotation == Rotation.BackDown
                || this.rotation == Rotation.BackLeft
                || this.rotation == Rotation.BackRight
                || this.rotation == Rotation.BackUp;
        }
        public bool IsRight()
        {
            return this.rotation == Rotation.RightBack
                || this.rotation == Rotation.RightDown
                || this.rotation == Rotation.RightForward
                || this.rotation == Rotation.RightUp;
        }
        public bool IsLeft()
        {
            return this.rotation == Rotation.LeftBack
                || this.rotation == Rotation.LeftDown
                || this.rotation == Rotation.LeftForward
                || this.rotation == Rotation.LeftUp;
        }
        public bool IsUp()
        {
            return this.rotation == Rotation.UpBack
                || this.rotation == Rotation.UpForward
                || this.rotation == Rotation.UpLeft
                || this.rotation == Rotation.UpRight;
        }
        public bool IsDown()
        {
            return this.rotation == Rotation.DownBack
                || this.rotation == Rotation.DownForward
                || this.rotation == Rotation.DownLeft
                || this.rotation == Rotation.DownRight;
        }

        internal void FillVertecies(Vector3 pos)
        {
            float size = 1;
            float s1 = size / 2;
            float s2 = s1;
            var vertecis = new Vector3[]
            {
                new Vector3() { X = pos.X + s1 * -1, Y = pos.Y + s1 * -1, Z = pos.Z + s1 * -1 },
                new Vector3() { X = pos.X + s1 * +1, Y = pos.Y + s1 * -1, Z = pos.Z + s1 * -1 },
                new Vector3() { X = pos.X + s1 * +1, Y = pos.Y + s1 * +1, Z = pos.Z + s1 * -1 },
                new Vector3() { X = pos.X + s1 * -1, Y = pos.Y + s1 * +1, Z = pos.Z + s1 * -1 },
                new Vector3() { X = pos.X + s1 * -1, Y = pos.Y + s1 * -1, Z = pos.Z + s1 * +1 },
                new Vector3() { X = pos.X + s1 * +1, Y = pos.Y + s1 * -1, Z = pos.Z + s1 * +1 },
                new Vector3() { X = pos.X + s1 * +1, Y = pos.Y + s1 * +1, Z = pos.Z + s1 * +1 },
                new Vector3() { X = pos.X + s1 * -1, Y = pos.Y + s1 * +1, Z = pos.Z + s1 * +1 },
            };
            this.Vertecis.AddRange(vertecis);
        }
    }
}