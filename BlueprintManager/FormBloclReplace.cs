using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueprintManager
{
    public partial class FormBlockReplace : Form
    {
        public FormBlockReplace()
        {
            InitializeComponent();
        }

        private BlockCondition TargetCondition { get; set; } = new BlockCondition();
        private BlockAction Action { get; set; } = new BlockAction();
        public Dictionary<string, BlockDefinition> BlockIdList { get; set; }
        public Dictionary<string, List<string>> GroupMap { get; set; }
        public BlueprintFile Blueprint { get; set; }


        private void FormBlockReplace_Load(object sender, EventArgs e)
        {
            try
            {
                this.Blueprint.LoadBlocks();
                this.BlockIdList = this.Blueprint.BlockDefinitions;// BlockDefinitionStore.LoadBlockDefinitions();
                this.GroupMap = BlockDefinitionStore.LoadGroupMap();

                this.cmbGroupFrom.Items.Clear();
                foreach (var key in this.GroupMap.Keys)
                {
                    this.cmbGroupFrom.Items.Add(key);
                }

                this.cmbGroupTo.Items.Clear();
                foreach (var key in this.GroupMap.Keys)
                {
                    this.cmbGroupTo.Items.Add(key);
                }
                this.cmbGroupFrom.SelectedIndex = 0;
                this.cmbGroupTo.SelectedIndex = 0;

                this.cmbBlockFrom.DataSource = this.BlockIdList.Select(s => s.Value).ToList();
                this.cmbBlockTo.DataSource = this.BlockIdList.Select(s => s.Value).ToList();

                this.cmbColor.Items.Clear();
                for (int i = 0; i < 32; i++)
                {
                    var index = this.cmbColor.Items.Add(i);
                }
                this.cmbColor.SelectedIndex = 0;


                this.cmbActionColorNumbers.Items.Clear();
                for (int i = 0; i < 32; i++)
                {
                    var index = this.cmbActionColorNumbers.Items.Add(i);
                }
                this.cmbActionColorNumbers.SelectedIndex = 0;

                this.chkObjects.Items.Clear();
                this.chkObjects.Items.Add("main object", true);
                this.chkObjects.Items.Add("sub object", true);


                this.lblName.Text = this.Blueprint.Name;
                this.FillCondition();
                this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGroupDo_Click(object sender, EventArgs e)
        {
            try
            {
                var fromKey = this.cmbGroupFrom.Items[this.cmbGroupFrom.SelectedIndex] as string;
                var toKey = this.cmbGroupTo.Items[this.cmbGroupTo.SelectedIndex] as string;

                var fromList = this.GroupMap[fromKey];
                var toList = this.GroupMap[toKey];
                var map = new Dictionary<string, string>();
                for (int i = 0; i < fromList.Count; i++)
                {
                    map.Add(fromList[i], toList[i]);
                }

                this.FillAction();
                this.FillCondition();
                //this.Blueprint.ReplaceGroup(map);
                this.Blueprint.ReplaceGroup(this.TargetCondition, this.Action);
                this.Blueprint.LoadBlocks();
                this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

                MessageBox.Show("completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCondition()
        {
            if (this.radAll.Checked)
            {
                this.TargetCondition.Target = BlockCondition.TargetType.All;
            }
            else if (this.radGroup.Checked)
            {
                this.TargetCondition.Target = BlockCondition.TargetType.Group;
            }
            if (this.radBlock.Checked)
            {
                this.TargetCondition.Target = BlockCondition.TargetType.Block;
            }

            this.TargetCondition.Block = this.cmbBlockFrom.SelectedItem as BlockDefinition;
            var fromKey = this.cmbGroupFrom.Items[this.cmbGroupFrom.SelectedIndex] as string;
            this.TargetCondition.Group = this.GroupMap[fromKey];

            this.TargetCondition.IsColor = this.chkColor.Checked;
            this.TargetCondition.ColorNumber = this.cmbColor.SelectedIndex;
            int buf = 0;

            this.TargetCondition.IsX = this.chkX.Checked;
            this.TargetCondition.IsXInverted = this.chkXinv.Checked;
            if (int.TryParse(this.txtXFrom.Text, out buf))
            {
                this.TargetCondition.XFrom = buf;
            }
            else
            {
                this.TargetCondition.XFrom = null;
            }
            if (int.TryParse(this.txtXTo.Text, out buf))
            {
                this.TargetCondition.XTo = buf;
            }
            else
            {
                this.TargetCondition.XTo = null;
            }

            this.TargetCondition.IsY = this.chkY.Checked;
            this.TargetCondition.IsYInverted = this.chkYinv.Checked;
            if (int.TryParse(this.txtYFrom.Text, out buf))
            {
                this.TargetCondition.YFrom = buf;
            }
            else
            {
                this.TargetCondition.YFrom = null;
            }
            if (int.TryParse(this.txtYTo.Text, out buf))
            {
                this.TargetCondition.YTo = buf;
            }
            else
            {
                this.TargetCondition.YTo = null;
            }

            this.TargetCondition.IsZ = this.chkZ.Checked;
            this.TargetCondition.IsZInverted = this.chkZinv.Checked;
            if (int.TryParse(this.txtZFrom.Text, out buf))
            {
                this.TargetCondition.ZFrom = buf;
            }
            else
            {
                this.TargetCondition.ZFrom = null;
            }
            if (int.TryParse(this.txtZTo.Text, out buf))
            {
                this.TargetCondition.ZTo = buf;
            }
            else
            {
                this.TargetCondition.ZTo = null;
            }

            this.TargetCondition.IsMain = this.chkObjects.CheckedIndices.Contains(0);
            this.TargetCondition.IsSub = this.chkObjects.CheckedIndices.Contains(1);

        }

        private void FillAction()
        {
            if (this.radActionNone.Checked)
            {
                this.Action.Action = BlockAction.ActionType.None;
            }
            else if (this.radActionGroup.Checked)
            {
                this.Action.Action = BlockAction.ActionType.Group;
            }
            if (this.radActionBlok.Checked)
            {
                this.Action.Action = BlockAction.ActionType.Block;
            }

            this.Action.Block = this.cmbBlockTo.SelectedItem as BlockDefinition;
            var key = this.cmbGroupTo.Items[this.cmbGroupTo.SelectedIndex] as string;
            this.Action.Group = this.GroupMap[key];

            this.Action.IsColorPalette = this.chkActionColorPalette.Checked;
            this.Action.ColorPalette = this.cmbActionColorPalette.SelectedItem as ColorPalette;

            this.Action.IsColor = this.chkActionColorNumber.Checked;
            this.Action.ColorNumber = this.cmbActionColorNumbers.SelectedIndex;


        }


        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = this.cmbColor.SelectedIndex;
            this.lblTargetColor.BackColor = this.Blueprint.Colors[i];
            this.lblTargetColor.Text = i.ToString();
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void cmbActionColorNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = this.cmbActionColorNumbers.SelectedIndex;
            this.lblActionColor.BackColor = this.Blueprint.Colors[i];
            this.lblActionColor.Text = i.ToString();

        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radAll.Checked)
            {
                this.radActionNone.Enabled = true;
                this.radActionGroup.Enabled = false;
                this.radActionBlok.Enabled = false;
            }
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void radGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radGroup.Checked)
            {
                this.radActionNone.Enabled = true;
                this.radActionGroup.Enabled = true;
                this.radActionBlok.Enabled = false;
                this.radActionGroup.Checked = true;
            }
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void radBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radBlock.Checked)
            {
                this.radActionNone.Enabled = true;
                this.radActionGroup.Enabled = false;
                this.radActionBlok.Enabled = true;
                this.radActionBlok.Checked = true;
            }
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void chkActionColorPalette_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbActionColorPalette.Enabled = this.chkActionColorPalette.Checked;
        }

        private void chkActionColorNumber_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbActionColorNumbers.Enabled = this.chkActionColorNumber.Checked;
        }

        private void chkColor_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbColor.Enabled = this.chkColor.Checked;
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void chkX_CheckedChanged(object sender, EventArgs e)
        {
            this.txtXFrom.Enabled = this.chkX.Checked;
            this.txtXTo.Enabled = this.chkX.Checked;
            this.chkXinv.Enabled = this.chkX.Checked;
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void chkY_CheckedChanged(object sender, EventArgs e)
        {
            this.txtYFrom.Enabled = this.chkY.Checked;
            this.txtYTo.Enabled = this.chkY.Checked;
            this.chkYinv.Enabled = this.chkY.Checked;
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);


        }

        private void chkZ_CheckedChanged(object sender, EventArgs e)
        {
            this.txtZFrom.Enabled = this.chkZ.Checked;
            this.txtZTo.Enabled = this.chkZ.Checked;
            this.chkZinv.Enabled = this.chkZ.Checked;
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);


        }

        private void cmbGroupFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void cmbBlockFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void chkObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void txtXFrom_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void txtXTo_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void txtYFrom_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void txtYTo_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void txtZFrom_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void txtZTo_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void chkXinv_CheckedChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void chkYinv_CheckedChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void chkZinv_CheckedChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockIdList, this.TargetCondition);

        }

        private void radActionGroup_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbBlockTo.Enabled = false;
            this.cmbGroupTo.Enabled = true;
        }

        private void radActionBlok_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbBlockTo.Enabled = true;
            this.cmbGroupTo.Enabled = false;
        }

        private void radActionNone_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbBlockTo.Enabled = false;
            this.cmbGroupTo.Enabled = false;
        }
    }
}


