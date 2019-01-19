using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueprintManager
{
    public partial class ColorPaletteControl : UserControl
    {
        public ColorPaletteControl()
        {
            _colors = new Color[32];
            _labels = new List<Label>();
            InitializeComponent();

            _labels.Add(this.label0);
            _labels.Add(this.label1);
            _labels.Add(this.label2);
            _labels.Add(this.label3);
            _labels.Add(this.label4);
            _labels.Add(this.label5);
            _labels.Add(this.label6);
            _labels.Add(this.label7);
            _labels.Add(this.label8);
            _labels.Add(this.label9);
            _labels.Add(this.label10);
            _labels.Add(this.label11);
            _labels.Add(this.label12);
            _labels.Add(this.label13);
            _labels.Add(this.label14);
            _labels.Add(this.label15);
            _labels.Add(this.label16);
            _labels.Add(this.label17);
            _labels.Add(this.label18);
            _labels.Add(this.label19);
            _labels.Add(this.label20);
            _labels.Add(this.label21);
            _labels.Add(this.label22);
            _labels.Add(this.label23);
            _labels.Add(this.label24);
            _labels.Add(this.label25);
            _labels.Add(this.label26);
            _labels.Add(this.label27);
            _labels.Add(this.label28);
            _labels.Add(this.label29);
            _labels.Add(this.label30);
            _labels.Add(this.label31);
        }

        private List<Label> _labels;
        private Color[] _colors;
        public Color[] Colors
        {
            get
            {
                return _colors;
                }
            set
            {
                _colors = value;
                for (int i = 0; i < 32; i++)
                {
                    _labels[i].BackColor = _colors[i];
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
