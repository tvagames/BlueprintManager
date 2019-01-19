using System.Collections.Generic;
using System.Drawing;

namespace BlueprintManager
{
    public class ColorPalette
    {
        public List<Color> Colors { get; set; } = new List<Color>();

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var c = obj as ColorPalette;
            for (int i = 0; i < c.Colors.Count; i++)
            {
                if (!c.Colors[i].Equals(this.Colors[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}