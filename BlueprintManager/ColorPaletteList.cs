using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;

namespace BlueprintManager
{
    public class ColorPaletteList
    {
        [XmlIgnore]
        public List<ColorPalette> ColorPalettes { get; set; } = new List<ColorPalette>();
        public List<string> ColorPaletteStrings { get; set; } = new List<string>();

        internal static ColorPaletteList Load()
        {
            var path = "colorPalettes.xml";
            if (!System.IO.File.Exists(path))
            {
                return new ColorPaletteList();
            }

            var ser = new System.Xml.Serialization.XmlSerializer(typeof(ColorPaletteList));

            using (var f = new System.IO.StreamReader(path))
            {
                var ret = (ColorPaletteList)ser.Deserialize(f);
                foreach (var item in ret.ColorPaletteStrings)
                {
                    var p = new ColorPalette();
                    var factor = item.Split(',');
                    for (int i = 0; i < factor.Length; i+=4)
                    {
                        var c = Color.FromArgb(int.Parse(factor[i + 0]),
                            int.Parse(factor[i + 1]),
                            int.Parse(factor[i + 2]),
                            int.Parse(factor[i + 3]));
                        p.Colors.Add(c);
                    }

                    ret.ColorPalettes.Add(p);
                }
                return ret;
            }
        }

        internal void Save()
        {
            var path = "colorPalettes.xml";

            var ser = new System.Xml.Serialization.XmlSerializer(typeof(ColorPaletteList));

            this.ColorPaletteStrings.Clear();
            foreach (var item in this.ColorPalettes)
            {
                var s = new List<string>();
                foreach (var c in item.Colors)
                {
                    s.Add(string.Format("{0},{1},{2},{3}", c.A, c.R,c.G,c.B));
                }
                this.ColorPaletteStrings.Add(string.Join(",", s.ToArray()));
            }

            using (var f = new System.IO.StreamWriter(path))
            {
                ser.Serialize(f, this);
            }
        }
    }
}
