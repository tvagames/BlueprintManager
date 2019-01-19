using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueprintManager
{
    public partial class FormColorPalette : Form
    {
        public BlueprintFile Blueprint { get; set; }
        public string TargetPath { get; set; }
        public ColorPaletteList ColorPalettes { get; set; } = new ColorPaletteList();

        public FormColorPalette()
        {
            InitializeComponent();
        }

        private void FormColorPalette_Load(object sender, EventArgs e)
        {
            this.Blueprint.LoadBlocks();
            this.ColorPalettes = ColorPaletteList.Load();
            if (this.ColorPalettes == null)
            {
                this.ColorPalettes = new ColorPaletteList();
            }

            this.ViewColorPalettes(this.ColorPalettes);
        }

        private void ViewColorPalettes(ColorPaletteList colorPalettes)
        {
            this.listPanel.Controls.Clear();
            var isExists = false;
            foreach (var item in colorPalettes.ColorPalettes)
            {
                var addedPanel = this.AddColorPalettePanel(item.Colors, true);

                if (item.Equals(new ColorPalette() { Colors = this.Blueprint.Colors.ToList() }))
                {
                    SelectPalette(addedPanel);
                    isExists = true;
                }
            }

            {
                var addedPanel = this.AddColorPalettePanel(this.Blueprint.Colors,false);
                SelectPalette(addedPanel);
            }
        }

        private ColorPalettePanel AddColorPalettePanel(List<Color> colors, bool canRemove)
        {

            var item = new Panel();
            item.Dock = DockStyle.Top;
            item.Height = 68;
            item.Padding = new Padding(10);

            var palette = new ColorPalettePanel();
            palette.Dock = DockStyle.Fill;
            palette.Colors = colors.ToArray();
            palette.Click += Palette_Click;
            palette.CanRemove = canRemove;


            item.Controls.Add(palette);
            item.Controls.SetChildIndex(palette, 0);
            this.listPanel.Controls.Add(item);

            return palette;
        }

        private void RemoveColorPalettePanel(ColorPalettePanel target)
        {
            var index = -1;
            for (int i = 0; i < this.listPanel.Controls.Count; i++)
            {
                var p = this.listPanel.Controls[i] as Panel;
                var c = p.Controls[0] as ColorPalettePanel;
                if (c == target)
                {
                    c.Click -= Palette_Click;
                    index = i;
                }
            }
            if (index  >= 0)
            {
                this.listPanel.Controls.RemoveAt(index);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.dlgFile.InitialDirectory = this.TargetPath;
                this.dlgFile.DefaultExt = "blueprint";
                if (this.dlgFile.ShowDialog() == DialogResult.OK)
                {
                    var s = this.dlgFile.FileName;
                    var bp = BlueprintFile.Load(s);
                    bp.LoadBlocks();

                    this.AddColorPalettePanel(bp.Colors, true);

                    var fi = new FileInfo(this.dlgFile.FileName);
                    this.TargetPath = fi.DirectoryName;
                    this.ColorPalettes.ColorPalettes.Add(new ColorPalette() {Colors = bp.Colors });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void SelectPalette(ColorPalettePanel panel)
        {
            for (int i = 0; i < this.listPanel.Controls.Count; i++)
            {
                var p = this.listPanel.Controls[i] as Panel;
                var c = p.Controls[0] as ColorPalettePanel;
                if (c == panel)
                {
                    c.Selected = true;
                }
                else
                {
                    c.Selected = false;
                }
                c.Refresh();
            }

        }

        private void Palette_Click(object sender, EventArgs e)
        {
            var p = sender as ColorPalettePanel;
            if (p.CanRemove && p.IsHitDelelteButton)
            {
                this.RemoveColorPalettePanel(p);
            }
            else
            {
                SelectPalette(sender as ColorPalettePanel);
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            this.ColorPalettes.Save();

            for (int i = 0; i < this.listPanel.Controls.Count; i++)
            {
                var p = this.listPanel.Controls[i] as Panel;
                var c = p.Controls[0] as ColorPalettePanel;
                if (c.Selected)
                {
                    this.Blueprint.Colors = c.Colors.ToList();
                    this.Blueprint.SaveColors(c.Colors);
                    break;
                }
            }
        }
    }
}
