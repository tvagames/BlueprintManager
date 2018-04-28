using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        private ListViewItemComparer list1Sort = new ListViewItemComparer();
        private ListViewItemComparer list2Sort = new ListViewItemComparer();

        private BackupManager backupMgr = new BackupManager();
        private Config config = new Config();

        public Form1()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this.targetInput.Text;
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.targetInput.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this.backupInput.Text;
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.backupInput.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                var targetDir = new DirectoryInfo(this.targetInput.Text);
                if (!targetDir.Exists)
                {
                    MessageBox.Show("targetのフォルダがありません。", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var backupDir = new DirectoryInfo(this.backupInput.Text);
                if (!backupDir.Exists)
                {
                    MessageBox.Show("backupのフォルダがありません。", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                this.groupBox1.Enabled = false;
                this.startButton.Enabled = false;
                this.stopButton.Enabled = true;
                this.startToolStripMenuItem.Enabled = false;
                this.stopToolStripMenuItem.Enabled = true;

                this.config.TargetFolder = this.targetInput.Text;
                this.config.BackupFolder = this.backupInput.Text;
                this.config.Startup = this.checkBox1.Checked;
                this.config.Save();

                this.backupMgr.Start(this.targetInput.Text, this.backupInput.Text);

                this.CreateTree(this.targetInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateTree(string root)
        {
            this.treeView1.Nodes.Clear();
            var dir = new DirectoryInfo(root);
            var parentNode = this.treeView1.Nodes.Add(dir.Name);
            parentNode.Tag = dir.FullName;
            this.AddChildNode(dir, parentNode);
        }

        private void AddChildNode(DirectoryInfo dir, TreeNode parentNode)
        {
            foreach (var d in dir.GetDirectories())
            {
                var child = parentNode.Nodes.Add(d.Name);
                child.Tag = d.FullName;
                AddChildNode(d, child);
            }
        }


        private void stopButton_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            this.startButton.Enabled = true;
            this.stopButton.Enabled = false;
            this.startToolStripMenuItem.Enabled = true;
            this.stopToolStripMenuItem.Enabled = false;
            this.backupMgr.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.config = Config.Load();
            this.targetInput.Text = this.config.TargetFolder;
            this.backupInput.Text = this.config.BackupFolder;
            this.checkBox1.Checked = this.config.Startup;
            if (this.config.Startup)
            {
                this.startButton.PerformClick();
            }
            else
            {
                this.stopButton.PerformClick();
            }
            this.listView1.ListViewItemSorter = this.list1Sort;
            this.listView2.ListViewItemSorter = this.list2Sort;

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var path = (string)e.Node.Tag;
            this.ViewList(path);
        }

        private void ViewList(string path)
        {
            this.listView1.BeginUpdate();
            this.listView1.Clear();
            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("Name").Width = 200;
            this.listView1.Columns.Add("Version");
            this.listView1.Columns.Add("Game Version");
            this.listView1.Columns.Add("Last Update Date").Width = 150;

            var dir = new DirectoryInfo(path);
            foreach (var f in dir.GetFiles("*.blueprint"))
            {
                var bp = BlueprintFile.Load(f.FullName);
                var item = new ListViewItem(f.Name);
                item.SubItems.Add("v" + bp.Version.ToString());
                item.SubItems.Add(bp.Blueprint.GameVersion);
                item.SubItems.Add(f.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"));


                item.Tag = new BlueprintItem()
                {
                    Path = f.FullName,
                };
                this.listView1.Items.Add(item);
                
            }
            this.listView1.EndUpdate();
        }

        class BlueprintItem
        {
            public string Path { get; internal set; }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.startButton.PerformClick();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.stopButton.PerformClick();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices.Count == 0)
            {
                return;
            }

            var bpi = (BlueprintItem)this.listView1.SelectedItems[0].Tag;
            var related = bpi.Path.Substring(this.backupMgr.TargetPath.Length);
            var dirPath = related.Substring(0, related.Length - ".blueprint".Length);
            var bkDirPath = this.backupMgr.BackupPath + dirPath;
            var bkDir = new DirectoryInfo(bkDirPath);
            if (!bkDir.Exists)
            {
                return;
            }
            this.listView2.BeginUpdate();
            this.listView2.Clear();
            this.listView2.Columns.Clear();
            this.listView2.Columns.Add("Name").Width = 200;
            this.listView2.Columns.Add("Version");
            this.listView2.Columns.Add("Game Version");
            this.listView2.Columns.Add("Last Update Date").Width = 150;

            foreach (var f in bkDir.GetFiles())
            {
                var bp = BlueprintFile.Load(f.FullName);
                if (bp == null)
                {
                    continue;
                }
                var item = new ListViewItem(f.Name);
                item.SubItems.Add("v" + bp.Version.ToString());
                item.SubItems.Add(bp.Blueprint.GameVersion);
                item.SubItems.Add(f.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"));

                item.Tag = new BlueprintItem()
                {
                    Path = f.FullName,
                };
                this.listView2.Items.Add(item);
            }
            this.listView2.EndUpdate();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode == null)
            {
                return;
            }

            var path = (string)this.treeView1.SelectedNode.Tag;
            var dir = new DirectoryInfo(path);
            this.BackupFolder(dir);
            MessageBox.Show("Backup completed.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackupFolder(DirectoryInfo dir)
        {
            foreach (var f in dir.GetFiles("*.blueprint"))
            {
                this.backupMgr.BackupFile(f.FullName);
            }
            foreach (var d in dir.GetDirectories())
            {
                this.BackupFolder(d);
            }
        }

        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices.Count == 0)
            {
                return;
            }

            var bpi = (BlueprintItem)this.listView1.SelectedItems[0].Tag;
            this.backupMgr.BackupFile(bpi.Path);
            MessageBox.Show("Backup completed.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            list1Sort.Column = e.Column;
            this.listView1.Sort();
        }

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            list1Sort.Column = e.Column;
            this.listView2.Sort();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            var bpi = (BlueprintItem)this.listView1.SelectedItems[0].Tag;
            var bp = BlueprintFile.Load(bpi.Path);
            var f = new Form2();
            f.Blueprint = bp;
            f.Show();
        }
    }

    public class ListViewItemComparer : IComparer
    {
        private int _column;

        /// <summary>
        /// ListViewItemComparerクラスのコンストラクタ
        /// </summary>
        /// <param name="col">並び替える列番号</param>
        public ListViewItemComparer()
        {
        }

        public int Column
        {
            set
            {
                //現在と同じ列の時は、昇順降順を切り替える
                if (_column == value)
                {
                    if (Order == SortOrder.Ascending)
                    {
                        Order = SortOrder.Descending;
                    }
                    else if (Order == SortOrder.Descending)
                    {
                        Order = SortOrder.Ascending;
                    }
                    else
                    {
                        Order = SortOrder.Ascending;
                    }
                }
                _column = value;
            }
            get
            {
                return _column;
            }
        }
        public SortOrder Order { get; set; }

        //xがyより小さいときはマイナスの数、大きいときはプラスの数、
        //同じときは0を返す
        public int Compare(object x, object y)
        {
            //ListViewItemの取得
            ListViewItem itemx = (ListViewItem)x;
            ListViewItem itemy = (ListViewItem)y;

            //xとyを文字列として比較する
            var ret = string.Compare(itemx.SubItems[Column].Text,
                itemy.SubItems[Column].Text);
            if (this.Order == SortOrder.Descending)
            {
                ret = -ret;
            }
            return ret;
        }
    }
}

