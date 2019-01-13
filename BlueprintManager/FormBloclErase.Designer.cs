namespace BlueprintManager
{
    partial class FormBlockErase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnErase = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeBlocks = new System.Windows.Forms.TreeView();
            this.chkObjects = new System.Windows.Forms.CheckedListBox();
            this.txtZTo = new System.Windows.Forms.TextBox();
            this.txtYTo = new System.Windows.Forms.TextBox();
            this.txtXTo = new System.Windows.Forms.TextBox();
            this.txtZFrom = new System.Windows.Forms.TextBox();
            this.txtYFrom = new System.Windows.Forms.TextBox();
            this.txtXFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTargetColor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkZinv = new System.Windows.Forms.CheckBox();
            this.chkYinv = new System.Windows.Forms.CheckBox();
            this.chkXinv = new System.Windows.Forms.CheckBox();
            this.chkColor = new System.Windows.Forms.CheckBox();
            this.chkZ = new System.Windows.Forms.CheckBox();
            this.chkY = new System.Windows.Forms.CheckBox();
            this.chkX = new System.Windows.Forms.CheckBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnErase
            // 
            this.btnErase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnErase.Location = new System.Drawing.Point(357, 742);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(87, 28);
            this.btnErase.TabIndex = 0;
            this.btnErase.Text = "erase";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "name";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(65, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(12, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "-";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.treeBlocks);
            this.groupBox2.Controls.Add(this.chkObjects);
            this.groupBox2.Controls.Add(this.txtZTo);
            this.groupBox2.Controls.Add(this.txtYTo);
            this.groupBox2.Controls.Add(this.txtXTo);
            this.groupBox2.Controls.Add(this.txtZFrom);
            this.groupBox2.Controls.Add(this.txtYFrom);
            this.groupBox2.Controls.Add(this.txtXFrom);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblTargetColor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkZinv);
            this.groupBox2.Controls.Add(this.chkYinv);
            this.groupBox2.Controls.Add(this.chkXinv);
            this.groupBox2.Controls.Add(this.chkColor);
            this.groupBox2.Controls.Add(this.chkZ);
            this.groupBox2.Controls.Add(this.chkY);
            this.groupBox2.Controls.Add(this.chkX);
            this.groupBox2.Controls.Add(this.cmbColor);
            this.groupBox2.Location = new System.Drawing.Point(14, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 672);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "target";
            // 
            // treeBlocks
            // 
            this.treeBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeBlocks.CheckBoxes = true;
            this.treeBlocks.Location = new System.Drawing.Point(10, 140);
            this.treeBlocks.Name = "treeBlocks";
            this.treeBlocks.Size = new System.Drawing.Size(412, 406);
            this.treeBlocks.TabIndex = 20;
            this.treeBlocks.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeBlocks_AfterCheck);
            // 
            // chkObjects
            // 
            this.chkObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkObjects.FormattingEnabled = true;
            this.chkObjects.Items.AddRange(new object[] {
            "main object",
            "sub object"});
            this.chkObjects.Location = new System.Drawing.Point(9, 22);
            this.chkObjects.Name = "chkObjects";
            this.chkObjects.Size = new System.Drawing.Size(413, 94);
            this.chkObjects.TabIndex = 7;
            this.chkObjects.SelectedIndexChanged += new System.EventHandler(this.chkObjects_SelectedIndexChanged);
            // 
            // txtZTo
            // 
            this.txtZTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtZTo.Enabled = false;
            this.txtZTo.Location = new System.Drawing.Point(250, 635);
            this.txtZTo.Name = "txtZTo";
            this.txtZTo.Size = new System.Drawing.Size(68, 23);
            this.txtZTo.TabIndex = 18;
            this.txtZTo.TextChanged += new System.EventHandler(this.txtZTo_TextChanged);
            // 
            // txtYTo
            // 
            this.txtYTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYTo.Enabled = false;
            this.txtYTo.Location = new System.Drawing.Point(250, 607);
            this.txtYTo.Name = "txtYTo";
            this.txtYTo.Size = new System.Drawing.Size(68, 23);
            this.txtYTo.TabIndex = 14;
            this.txtYTo.TextChanged += new System.EventHandler(this.txtYTo_TextChanged);
            // 
            // txtXTo
            // 
            this.txtXTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtXTo.Enabled = false;
            this.txtXTo.Location = new System.Drawing.Point(250, 580);
            this.txtXTo.Name = "txtXTo";
            this.txtXTo.Size = new System.Drawing.Size(68, 23);
            this.txtXTo.TabIndex = 10;
            this.txtXTo.TextChanged += new System.EventHandler(this.txtXTo_TextChanged);
            // 
            // txtZFrom
            // 
            this.txtZFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtZFrom.Enabled = false;
            this.txtZFrom.Location = new System.Drawing.Point(154, 635);
            this.txtZFrom.Name = "txtZFrom";
            this.txtZFrom.Size = new System.Drawing.Size(68, 23);
            this.txtZFrom.TabIndex = 17;
            this.txtZFrom.TextChanged += new System.EventHandler(this.txtZFrom_TextChanged);
            // 
            // txtYFrom
            // 
            this.txtYFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYFrom.Enabled = false;
            this.txtYFrom.Location = new System.Drawing.Point(154, 607);
            this.txtYFrom.Name = "txtYFrom";
            this.txtYFrom.Size = new System.Drawing.Size(68, 23);
            this.txtYFrom.TabIndex = 13;
            this.txtYFrom.TextChanged += new System.EventHandler(this.txtYFrom_TextChanged);
            // 
            // txtXFrom
            // 
            this.txtXFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtXFrom.Enabled = false;
            this.txtXFrom.Location = new System.Drawing.Point(154, 580);
            this.txtXFrom.Name = "txtXFrom";
            this.txtXFrom.Size = new System.Drawing.Size(68, 23);
            this.txtXFrom.TabIndex = 9;
            this.txtXFrom.TextChanged += new System.EventHandler(this.txtXFrom_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 638);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "-";
            // 
            // lblTargetColor
            // 
            this.lblTargetColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTargetColor.BackColor = System.Drawing.Color.Red;
            this.lblTargetColor.Location = new System.Drawing.Point(231, 555);
            this.lblTargetColor.Name = "lblTargetColor";
            this.lblTargetColor.Size = new System.Drawing.Size(38, 22);
            this.lblTargetColor.TabIndex = 1;
            this.lblTargetColor.Text = "2";
            this.lblTargetColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 585);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "-";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 612);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "-";
            // 
            // chkZinv
            // 
            this.chkZinv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkZinv.AutoSize = true;
            this.chkZinv.Enabled = false;
            this.chkZinv.Location = new System.Drawing.Point(325, 639);
            this.chkZinv.Name = "chkZinv";
            this.chkZinv.Size = new System.Drawing.Size(74, 19);
            this.chkZinv.TabIndex = 19;
            this.chkZinv.Text = "inverted";
            this.chkZinv.UseVisualStyleBackColor = true;
            this.chkZinv.CheckedChanged += new System.EventHandler(this.chkZinv_CheckedChanged);
            // 
            // chkYinv
            // 
            this.chkYinv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkYinv.AutoSize = true;
            this.chkYinv.Enabled = false;
            this.chkYinv.Location = new System.Drawing.Point(325, 612);
            this.chkYinv.Name = "chkYinv";
            this.chkYinv.Size = new System.Drawing.Size(74, 19);
            this.chkYinv.TabIndex = 15;
            this.chkYinv.Text = "inverted";
            this.chkYinv.UseVisualStyleBackColor = true;
            this.chkYinv.CheckedChanged += new System.EventHandler(this.chkYinv_CheckedChanged);
            // 
            // chkXinv
            // 
            this.chkXinv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXinv.AutoSize = true;
            this.chkXinv.Enabled = false;
            this.chkXinv.Location = new System.Drawing.Point(325, 584);
            this.chkXinv.Name = "chkXinv";
            this.chkXinv.Size = new System.Drawing.Size(74, 19);
            this.chkXinv.TabIndex = 11;
            this.chkXinv.Text = "inverted";
            this.chkXinv.UseVisualStyleBackColor = true;
            this.chkXinv.CheckedChanged += new System.EventHandler(this.chkXinv_CheckedChanged);
            // 
            // chkColor
            // 
            this.chkColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkColor.AutoSize = true;
            this.chkColor.Location = new System.Drawing.Point(31, 557);
            this.chkColor.Name = "chkColor";
            this.chkColor.Size = new System.Drawing.Size(103, 19);
            this.chkColor.TabIndex = 5;
            this.chkColor.Text = "color number";
            this.chkColor.UseVisualStyleBackColor = true;
            this.chkColor.CheckedChanged += new System.EventHandler(this.chkColor_CheckedChanged);
            // 
            // chkZ
            // 
            this.chkZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkZ.AutoSize = true;
            this.chkZ.Location = new System.Drawing.Point(31, 638);
            this.chkZ.Name = "chkZ";
            this.chkZ.Size = new System.Drawing.Size(114, 19);
            this.chkZ.TabIndex = 16;
            this.chkZ.Text = "z (front / back)";
            this.chkZ.UseVisualStyleBackColor = true;
            this.chkZ.CheckedChanged += new System.EventHandler(this.chkZ_CheckedChanged);
            // 
            // chkY
            // 
            this.chkY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkY.AutoSize = true;
            this.chkY.Location = new System.Drawing.Point(31, 612);
            this.chkY.Name = "chkY";
            this.chkY.Size = new System.Drawing.Size(105, 19);
            this.chkY.TabIndex = 12;
            this.chkY.Text = "y (up / down)";
            this.chkY.UseVisualStyleBackColor = true;
            this.chkY.CheckedChanged += new System.EventHandler(this.chkY_CheckedChanged);
            // 
            // chkX
            // 
            this.chkX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkX.AutoSize = true;
            this.chkX.Location = new System.Drawing.Point(31, 584);
            this.chkX.Name = "chkX";
            this.chkX.Size = new System.Drawing.Size(106, 19);
            this.chkX.TabIndex = 8;
            this.chkX.Text = "x (right / left)";
            this.chkX.UseVisualStyleBackColor = true;
            this.chkX.CheckedChanged += new System.EventHandler(this.chkX_CheckedChanged);
            // 
            // cmbColor
            // 
            this.cmbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.Enabled = false;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Items.AddRange(new object[] {
            "(all)"});
            this.cmbColor.Location = new System.Drawing.Point(143, 553);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(79, 23);
            this.cmbColor.TabIndex = 6;
            this.cmbColor.SelectedIndexChanged += new System.EventHandler(this.cmbColor_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(451, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 708);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FormBlockErase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 787);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "FormBlockErase";
            this.Text = "Block Erase";
            this.Load += new System.EventHandler(this.FormBlockErase_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtZTo;
        private System.Windows.Forms.TextBox txtYTo;
        private System.Windows.Forms.TextBox txtXTo;
        private System.Windows.Forms.TextBox txtZFrom;
        private System.Windows.Forms.TextBox txtYFrom;
        private System.Windows.Forms.TextBox txtXFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkZinv;
        private System.Windows.Forms.CheckBox chkYinv;
        private System.Windows.Forms.CheckBox chkXinv;
        private System.Windows.Forms.CheckBox chkColor;
        private System.Windows.Forms.CheckBox chkZ;
        private System.Windows.Forms.CheckBox chkY;
        private System.Windows.Forms.CheckBox chkX;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.CheckedListBox chkObjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTargetColor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView treeBlocks;
    }
}