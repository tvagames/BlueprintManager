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

        public Dictionary<string, BlockIdItem> BlockIdList { get; set; }
        public Dictionary<string, List<string>> GroupMap { get; set; }
        public BlueprintFile Blueprint { get; set; }


        private void FormBlockReplace_Load(object sender, EventArgs e)
        {
            this.BlockIdList = BlockIdStore.LoadIdList();
            this.GroupMap = BlockIdStore.LoadGroupMap();

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

            this.lblName.Text = this.Blueprint.Name;
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

                this.Blueprint.ReplaceGroup(map);

                MessageBox.Show("completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

