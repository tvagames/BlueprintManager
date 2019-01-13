using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueprintManager
{
    public partial class FormDefineEditor : Form
    {
        internal CategoryTreeNode Tree { get; set; }
        internal Dictionary<string, BlockIdItem> BlockIdList { get; set; }
        internal ClipboardViewer clipboard;
        
        public FormDefineEditor()
        {
            this.clipboard = new ClipboardViewer(this);
            this.clipboard.ClipboardHandler += Clipboard_ClipboardHandler;
            InitializeComponent();
        }

    
        private void FormDefineEditor_Load(object sender, EventArgs e)
        {
            try
            {

                this.BlockIdList = BlockIdStore.LoadIdList();
                this.Tree = CategoryTree.Load(CategoryTree.CATEGORY_TREE_FILE);
                this.AddSubCategories(this.Tree.SubCategories, 0);

                var table = new DataTable();
                table.Columns.Add("UID");
                table.Columns.Add("Name");
                table.Columns.Add("Wdith");
                table.Columns.Add("Height");
                table.Columns.Add("Length");
                table.Columns.Add("Definitions");
                table.Columns.Add("Category");
                table.Columns.Add("Grouped");

                foreach (var item in this.BlockIdList.Values)
                {
                    table.Rows.Add(new object[]{ item.Uid, item.Name, item.Width, item.Height, item.Length, item.Defined, item.Category, item.Grouped });
                }

                this.dataGridView1.DataSource = table;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddSubCategories(List<CategoryTreeNode> categories, int depths)
        {
            foreach (var node in categories)
            {
                var indent = string.Empty.PadLeft(depths * 2);
                this.cmbCategory.Items.Add(indent + node.Name);
                if (node.Items != null)
                {
                    foreach (var item in node.Items)
                    {
                        this.BlockIdList[item].Category = node.Name;
                    }
                }
                if (node.SubCategories != null)
                {
                    this.AddSubCategories(node.SubCategories, depths + 1);
                }
            }
        }

        private void Clipboard_ClipboardHandler(object sender, ClipboardEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Text))
            {
                return;
            }

            if (Regex.IsMatch(e.Text, "[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}"))
            {
                // uid
                this.uidInput.Text = e.Text;
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    var uid = row.Cells[0].Value as string;
                    if (this.uidInput.Text == uid)
                    {
                        this.dataGridView1.CurrentCell = row.Cells[0];
                        this.nameInput.Text = row.Cells[1].Value as string;
                        row.Selected = true;
                        break;
                    }
                }
            }
            else
            {
                this.nameInput.Text = e.Text;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            bool accepted = false;
            int temp;
            DefinitionsStatus defStatus = DefinitionsStatus.Unknown;
            if (!int.TryParse(this.nameInput.Text, out temp))
            {
                defStatus = DefinitionsStatus.Named;
            }

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                var uid = row.Cells[0].Value as string;
                if (this.uidInput.Text == uid)
                {
                    row.Cells[1].Value = this.nameInput.Text;
                    row.Cells[5].Value = defStatus;
                    row.Cells[6].Value = this.cmbCategory.Text.Trim();
                    accepted = true;
                    break;
                }
            }
            if (!accepted)
            {
                DataRow row = ((DataTable)(this.dataGridView1.DataSource)).Rows.Add(new object[] 
                {
                    this.uidInput.Text,
                    this.nameInput.Text,
                    0,
                    0,
                    0,
                    defStatus,
                    "",
                    GroupedStatus.NotGrouped
                });
                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.BlockIdList.Clear();
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    var uid = row.Cells[0].Value as string;
                    var name = row.Cells[1].Value as string;
                    var width = row.Cells[2].Value as string;
                    var height = row.Cells[3].Value as string;
                    var length = row.Cells[4].Value as string;
                    var category = row.Cells[6].Value as string;

                    var item = new BlockIdItem();
                    item.Uid = uid;
                    item.Name = name;
                    item.Category = category;
                    int temp;
                    if (int.TryParse(width, out temp))
                    {
                        item.Width = temp;
                    }
                    if (int.TryParse(height, out temp))
                    {
                        item.Height = temp;
                    }
                    if (int.TryParse(length, out temp))
                    {
                        item.Length = temp;
                    }
                    this.BlockIdList.Add(uid, item);
                }

                this.FillCategoryItems(this.Tree);

                BlockIdStore.SaveIdList(this.BlockIdList);
                CategoryTree.Save(CategoryTree.CATEGORY_TREE_FILE, this.Tree);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCategoryItems(CategoryTreeNode node)
        {
            foreach (var category in node.SubCategories)
            {
                var list = this.BlockIdList.Where(item => item.Value.Category == category.Name);
                category.Items = list.Select(item => item.Value.Uid).ToList();
                if (category.SubCategories != null)
                {
                    this.FillCategoryItems(category);
                }
            }
        }
    }
}

