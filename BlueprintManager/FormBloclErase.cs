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
    public partial class FormBlockErase : Form
    {
        public FormBlockErase()
        {
            InitializeComponent();
        }

        private BlockCondition TargetCondition { get; set; } = new BlockCondition();
        private BlockAction Action { get; set; } = new BlockAction();
        public Dictionary<string, BlockDefinition> BlockDefinitions { get; set; }
        public BlueprintFile Blueprint { get; set; }
        internal CategoryTreeNode Tree { get; private set; }

        private void FormBlockErase_Load(object sender, EventArgs e)
        {
            try
            {
                this.Tree = CategoryTree.Load(CategoryTree.CATEGORY_TREE_FILE);
                this.Blueprint.LoadBlocks();
                this.BlockDefinitions = this.Blueprint.BlockDefinitions; // BlockDefinitionStore.LoadBlockDefinitions();

                this.treeBlocks.Nodes.Clear();
                this.AddTreeNode(this.Tree, null);

                {
                    var node = new TreeNode("unknown");
                    var list = this.BlockDefinitions.Where(w => string.IsNullOrEmpty(w.Value.Category)).ToList();
                    foreach (var item in list)
                    {
                        var block = this.BlockDefinitions[item.Key];
                        node.Nodes.Add(block.Name).Tag = block;
                    }
                    this.treeBlocks.Nodes.Add(node);
                }

                {
                    var node = new TreeNode("undefined");
                    this.treeBlocks.Nodes.Add(node);
                }

                this.cmbColor.Items.Clear();
                for (int i = 0; i < 32; i++)
                {
                    var index = this.cmbColor.Items.Add(i);
                }
                this.cmbColor.SelectedIndex = 0;

                this.chkObjects.Items.Clear();
                this.chkObjects.Items.Add("main object", true);
                this.chkObjects.Items.Add("sub object", true);


                this.lblName.Text = this.Blueprint.Name;
                this.FillCondition();
                this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddTreeNode(CategoryTreeNode parent, TreeNode parentNode)
        {
            foreach (var category in parent.SubCategories)
            {
                var node = new TreeNode(category.Name);
                if (category.SubCategories != null)
                {
                    AddTreeNode(category, node);
                }
                if (category.Items != null)
                {
                    foreach (var uid in category.Items)
                    {
                        var block = this.BlockDefinitions[uid];
                        block.Category = category.Name;
                        node.Nodes.Add(block.Name).Tag = block;
                    }
                }
                if (parentNode == null)
                {
                    this.treeBlocks.Nodes.Add(node);
                }
                else
                {
                    parentNode.Nodes.Add(node);
                }
            }
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            try
            {
                var map = new Dictionary<string, string>();

                this.FillCondition();
                this.Blueprint.EraseBlocks(this.BlockDefinitions, this.TargetCondition);
                this.Blueprint.LoadBlocks();
                this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

                MessageBox.Show("completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCondition()
        {
            this.TargetCondition.Target = BlockCondition.TargetType.Blocks;

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

            this.TargetCondition.Blocks = this.GetTargetBlocks(this.treeBlocks.Nodes);
        }

        private List<BlockDefinition> GetTargetBlocks(TreeNodeCollection nodes)
        {
            var targetBlocks = new List<BlockDefinition>();
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && node.Tag != null)
                {
                    targetBlocks.Add((BlockDefinition)node.Tag);
                }

                if (node.Nodes.Count > 0)
                {
                    targetBlocks.AddRange(this.GetTargetBlocks(node.Nodes));
                }
            }
            return targetBlocks;
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = this.cmbColor.SelectedIndex;
            this.lblTargetColor.BackColor = this.Blueprint.Colors[i];
            this.lblTargetColor.Text = i.ToString();
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void chkColor_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbColor.Enabled = this.chkColor.Checked;
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void chkX_CheckedChanged(object sender, EventArgs e)
        {
            this.txtXFrom.Enabled = this.chkX.Checked;
            this.txtXTo.Enabled = this.chkX.Checked;
            this.chkXinv.Enabled = this.chkX.Checked;
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void chkY_CheckedChanged(object sender, EventArgs e)
        {
            this.txtYFrom.Enabled = this.chkY.Checked;
            this.txtYTo.Enabled = this.chkY.Checked;
            this.chkYinv.Enabled = this.chkY.Checked;
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);


        }

        private void chkZ_CheckedChanged(object sender, EventArgs e)
        {
            this.txtZFrom.Enabled = this.chkZ.Checked;
            this.txtZTo.Enabled = this.chkZ.Checked;
            this.chkZinv.Enabled = this.chkZ.Checked;
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);


        }

        private void cmbGroupFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void cmbBlockFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void chkObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void txtXFrom_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void txtXTo_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void txtYFrom_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void txtYTo_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void txtZFrom_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void txtZTo_TextChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void chkXinv_CheckedChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void chkYinv_CheckedChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void chkZinv_CheckedChanged(object sender, EventArgs e)
        {
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private CheckState GetChildrenChecked(TreeNodeCollection nodes)
        {
            bool? temp = null;
            foreach (TreeNode child in nodes)
            {
                if (temp.HasValue && temp.Value != child.Checked)
                {
                    return CheckState.Indeterminate;
                }
                else
                {
                    temp = child.Checked;
                }
            }
            if (temp.Value)
            {
                return CheckState.Checked;
            }
            else
            {
                return CheckState.Unchecked;
            }
        }

        private void SetChildrenChecked(TreeNodeCollection nodes, bool isChecked)
        {
            foreach (TreeNode child in nodes)
            {
                child.Checked = isChecked;
                if (child.Nodes.Count > 0)
                {
                    SetChildrenChecked(child.Nodes, isChecked);
                }
            }
        }


        private bool treeCheckLocked = false;

        /// <summary>
        /// ツリーのチェック変更後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeBlocks_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (treeCheckLocked)
            {
                return;
            }
            treeCheckLocked = true;
            if (e.Node.Nodes.Count > 0)
            {
                var childrenState = GetChildrenChecked(e.Node.Nodes);
                // 親
                if (e.Node.Checked && childrenState != CheckState.Checked)
                {
                    // off -> on
                    this.SetChildrenChecked(e.Node.Nodes, true);
                }
                else if (!e.Node.Checked && childrenState == CheckState.Checked)
                {
                    // on -> off
                    this.SetChildrenChecked(e.Node.Nodes, false);
                }
            }
            else if (e.Node.Parent != null)
            {
                var p = e.Node.Parent;
                while (p != null)
                {
                    var childrenState = GetChildrenChecked(p.Nodes);
                    // 子
                    if (e.Node.Checked && !p.Checked && childrenState == CheckState.Checked)
                    {
                        // off -> on
                        p.Checked = true;
                    }
                    else if (!e.Node.Checked && p.Checked)
                    {
                        // on -> off
                        p.Checked = false;
                    }
                    p = p.Parent;
                }

            }
            treeBlocks.ResumeLayout();
            treeCheckLocked = false;
            this.FillCondition();
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);

        }

        private void inputZoom_ValueChanged(object sender, EventArgs e)
        {
            this.pictureBox1.Image = this.Blueprint.GetBmp(this.BlockDefinitions, this.TargetCondition, this.inputZoom.Value);
        }
    }
}


