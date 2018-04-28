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



    public struct BlockInfo
    {
        public float x;
        public float y;
        public float z;
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
    }
}