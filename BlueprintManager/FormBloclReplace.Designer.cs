﻿namespace BlueprintManager
{
    partial class FormBlockReplace
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
            this.btnGroupDo = new System.Windows.Forms.Button();
            this.cmbGroupTo = new System.Windows.Forms.ComboBox();
            this.cmbGroupFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.radBlock = new System.Windows.Forms.RadioButton();
            this.radGroup = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbBlockFrom = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkActionColorNumber = new System.Windows.Forms.CheckBox();
            this.chkActionColorPalette = new System.Windows.Forms.CheckBox();
            this.radActionBlok = new System.Windows.Forms.RadioButton();
            this.radActionNone = new System.Windows.Forms.RadioButton();
            this.radActionGroup = new System.Windows.Forms.RadioButton();
            this.cmbActionColorNumbers = new System.Windows.Forms.ComboBox();
            this.cmbActionColorPalette = new System.Windows.Forms.ComboBox();
            this.cmbBlockTo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblActionColor = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputZoom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGroupDo
            // 
            this.btnGroupDo.Location = new System.Drawing.Point(357, 689);
            this.btnGroupDo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGroupDo.Name = "btnGroupDo";
            this.btnGroupDo.Size = new System.Drawing.Size(87, 29);
            this.btnGroupDo.TabIndex = 0;
            this.btnGroupDo.Text = "replace";
            this.btnGroupDo.UseVisualStyleBackColor = true;
            this.btnGroupDo.Click += new System.EventHandler(this.btnGroupDo_Click);
            // 
            // cmbGroupTo
            // 
            this.cmbGroupTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupTo.Enabled = false;
            this.cmbGroupTo.FormattingEnabled = true;
            this.cmbGroupTo.Location = new System.Drawing.Point(174, 64);
            this.cmbGroupTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGroupTo.Name = "cmbGroupTo";
            this.cmbGroupTo.Size = new System.Drawing.Size(140, 23);
            this.cmbGroupTo.TabIndex = 2;
            // 
            // cmbGroupFrom
            // 
            this.cmbGroupFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupFrom.FormattingEnabled = true;
            this.cmbGroupFrom.Location = new System.Drawing.Point(112, 54);
            this.cmbGroupFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGroupFrom.Name = "cmbGroupFrom";
            this.cmbGroupFrom.Size = new System.Drawing.Size(143, 23);
            this.cmbGroupFrom.TabIndex = 2;
            this.cmbGroupFrom.SelectedIndexChanged += new System.EventHandler(this.cmbGroupFrom_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "name";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(65, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(12, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "-";
            // 
            // groupBox2
            // 
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
            this.groupBox2.Controls.Add(this.radBlock);
            this.groupBox2.Controls.Add(this.radGroup);
            this.groupBox2.Controls.Add(this.radAll);
            this.groupBox2.Controls.Add(this.cmbColor);
            this.groupBox2.Controls.Add(this.cmbBlockFrom);
            this.groupBox2.Controls.Add(this.cmbGroupFrom);
            this.groupBox2.Location = new System.Drawing.Point(14, 62);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(430, 278);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "target";
            // 
            // chkObjects
            // 
            this.chkObjects.FormattingEnabled = true;
            this.chkObjects.Items.AddRange(new object[] {
            "main object",
            "sub object"});
            this.chkObjects.Location = new System.Drawing.Point(276, 22);
            this.chkObjects.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkObjects.Name = "chkObjects";
            this.chkObjects.Size = new System.Drawing.Size(139, 112);
            this.chkObjects.TabIndex = 7;
            this.chkObjects.SelectedIndexChanged += new System.EventHandler(this.chkObjects_SelectedIndexChanged);
            // 
            // txtZTo
            // 
            this.txtZTo.Enabled = false;
            this.txtZTo.Location = new System.Drawing.Point(237, 239);
            this.txtZTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtZTo.Name = "txtZTo";
            this.txtZTo.Size = new System.Drawing.Size(68, 23);
            this.txtZTo.TabIndex = 18;
            this.txtZTo.TextChanged += new System.EventHandler(this.txtZTo_TextChanged);
            // 
            // txtYTo
            // 
            this.txtYTo.Enabled = false;
            this.txtYTo.Location = new System.Drawing.Point(237, 211);
            this.txtYTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYTo.Name = "txtYTo";
            this.txtYTo.Size = new System.Drawing.Size(68, 23);
            this.txtYTo.TabIndex = 14;
            this.txtYTo.TextChanged += new System.EventHandler(this.txtYTo_TextChanged);
            // 
            // txtXTo
            // 
            this.txtXTo.Enabled = false;
            this.txtXTo.Location = new System.Drawing.Point(237, 184);
            this.txtXTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtXTo.Name = "txtXTo";
            this.txtXTo.Size = new System.Drawing.Size(68, 23);
            this.txtXTo.TabIndex = 10;
            this.txtXTo.TextChanged += new System.EventHandler(this.txtXTo_TextChanged);
            // 
            // txtZFrom
            // 
            this.txtZFrom.Enabled = false;
            this.txtZFrom.Location = new System.Drawing.Point(141, 239);
            this.txtZFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtZFrom.Name = "txtZFrom";
            this.txtZFrom.Size = new System.Drawing.Size(68, 23);
            this.txtZFrom.TabIndex = 17;
            this.txtZFrom.TextChanged += new System.EventHandler(this.txtZFrom_TextChanged);
            // 
            // txtYFrom
            // 
            this.txtYFrom.Enabled = false;
            this.txtYFrom.Location = new System.Drawing.Point(141, 211);
            this.txtYFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYFrom.Name = "txtYFrom";
            this.txtYFrom.Size = new System.Drawing.Size(68, 23);
            this.txtYFrom.TabIndex = 13;
            this.txtYFrom.TextChanged += new System.EventHandler(this.txtYFrom_TextChanged);
            // 
            // txtXFrom
            // 
            this.txtXFrom.Enabled = false;
            this.txtXFrom.Location = new System.Drawing.Point(141, 184);
            this.txtXFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtXFrom.Name = "txtXFrom";
            this.txtXFrom.Size = new System.Drawing.Size(68, 23);
            this.txtXFrom.TabIndex = 9;
            this.txtXFrom.TextChanged += new System.EventHandler(this.txtXFrom_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "-";
            // 
            // lblTargetColor
            // 
            this.lblTargetColor.BackColor = System.Drawing.Color.Red;
            this.lblTargetColor.Location = new System.Drawing.Point(217, 118);
            this.lblTargetColor.Name = "lblTargetColor";
            this.lblTargetColor.Size = new System.Drawing.Size(38, 21);
            this.lblTargetColor.TabIndex = 1;
            this.lblTargetColor.Text = "2";
            this.lblTargetColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "-";
            // 
            // chkZinv
            // 
            this.chkZinv.AutoSize = true;
            this.chkZinv.Enabled = false;
            this.chkZinv.Location = new System.Drawing.Point(313, 242);
            this.chkZinv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkZinv.Name = "chkZinv";
            this.chkZinv.Size = new System.Drawing.Size(74, 19);
            this.chkZinv.TabIndex = 19;
            this.chkZinv.Text = "inverted";
            this.chkZinv.UseVisualStyleBackColor = true;
            this.chkZinv.CheckedChanged += new System.EventHandler(this.chkZinv_CheckedChanged);
            // 
            // chkYinv
            // 
            this.chkYinv.AutoSize = true;
            this.chkYinv.Enabled = false;
            this.chkYinv.Location = new System.Drawing.Point(313, 215);
            this.chkYinv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkYinv.Name = "chkYinv";
            this.chkYinv.Size = new System.Drawing.Size(74, 19);
            this.chkYinv.TabIndex = 15;
            this.chkYinv.Text = "inverted";
            this.chkYinv.UseVisualStyleBackColor = true;
            this.chkYinv.CheckedChanged += new System.EventHandler(this.chkYinv_CheckedChanged);
            // 
            // chkXinv
            // 
            this.chkXinv.AutoSize = true;
            this.chkXinv.Enabled = false;
            this.chkXinv.Location = new System.Drawing.Point(313, 188);
            this.chkXinv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkXinv.Name = "chkXinv";
            this.chkXinv.Size = new System.Drawing.Size(74, 19);
            this.chkXinv.TabIndex = 11;
            this.chkXinv.Text = "inverted";
            this.chkXinv.UseVisualStyleBackColor = true;
            this.chkXinv.CheckedChanged += new System.EventHandler(this.chkXinv_CheckedChanged);
            // 
            // chkColor
            // 
            this.chkColor.AutoSize = true;
            this.chkColor.Location = new System.Drawing.Point(17, 119);
            this.chkColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkColor.Name = "chkColor";
            this.chkColor.Size = new System.Drawing.Size(103, 19);
            this.chkColor.TabIndex = 5;
            this.chkColor.Text = "color number";
            this.chkColor.UseVisualStyleBackColor = true;
            this.chkColor.CheckedChanged += new System.EventHandler(this.chkColor_CheckedChanged);
            // 
            // chkZ
            // 
            this.chkZ.AutoSize = true;
            this.chkZ.Location = new System.Drawing.Point(19, 241);
            this.chkZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkZ.Name = "chkZ";
            this.chkZ.Size = new System.Drawing.Size(114, 19);
            this.chkZ.TabIndex = 16;
            this.chkZ.Text = "z (front / back)";
            this.chkZ.UseVisualStyleBackColor = true;
            this.chkZ.CheckedChanged += new System.EventHandler(this.chkZ_CheckedChanged);
            // 
            // chkY
            // 
            this.chkY.AutoSize = true;
            this.chkY.Location = new System.Drawing.Point(19, 215);
            this.chkY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkY.Name = "chkY";
            this.chkY.Size = new System.Drawing.Size(105, 19);
            this.chkY.TabIndex = 12;
            this.chkY.Text = "y (up / down)";
            this.chkY.UseVisualStyleBackColor = true;
            this.chkY.CheckedChanged += new System.EventHandler(this.chkY_CheckedChanged);
            // 
            // chkX
            // 
            this.chkX.AutoSize = true;
            this.chkX.Location = new System.Drawing.Point(19, 188);
            this.chkX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkX.Name = "chkX";
            this.chkX.Size = new System.Drawing.Size(106, 19);
            this.chkX.TabIndex = 8;
            this.chkX.Text = "x (right / left)";
            this.chkX.UseVisualStyleBackColor = true;
            this.chkX.CheckedChanged += new System.EventHandler(this.chkX_CheckedChanged);
            // 
            // radBlock
            // 
            this.radBlock.AutoSize = true;
            this.radBlock.Location = new System.Drawing.Point(19, 88);
            this.radBlock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radBlock.Name = "radBlock";
            this.radBlock.Size = new System.Drawing.Size(55, 19);
            this.radBlock.TabIndex = 3;
            this.radBlock.Text = "block";
            this.radBlock.UseVisualStyleBackColor = true;
            this.radBlock.CheckedChanged += new System.EventHandler(this.radBlock_CheckedChanged);
            // 
            // radGroup
            // 
            this.radGroup.AutoSize = true;
            this.radGroup.Location = new System.Drawing.Point(19, 55);
            this.radGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radGroup.Name = "radGroup";
            this.radGroup.Size = new System.Drawing.Size(58, 19);
            this.radGroup.TabIndex = 1;
            this.radGroup.Text = "group";
            this.radGroup.UseVisualStyleBackColor = true;
            this.radGroup.CheckedChanged += new System.EventHandler(this.radGroup_CheckedChanged);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Location = new System.Drawing.Point(19, 22);
            this.radAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(78, 19);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "all blocks";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            // 
            // cmbColor
            // 
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.Enabled = false;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Items.AddRange(new object[] {
            "(all)"});
            this.cmbColor.Location = new System.Drawing.Point(129, 116);
            this.cmbColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(79, 23);
            this.cmbColor.TabIndex = 6;
            this.cmbColor.SelectedIndexChanged += new System.EventHandler(this.cmbColor_SelectedIndexChanged);
            // 
            // cmbBlockFrom
            // 
            this.cmbBlockFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlockFrom.FormattingEnabled = true;
            this.cmbBlockFrom.Location = new System.Drawing.Point(112, 86);
            this.cmbBlockFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBlockFrom.Name = "cmbBlockFrom";
            this.cmbBlockFrom.Size = new System.Drawing.Size(143, 23);
            this.cmbBlockFrom.TabIndex = 4;
            this.cmbBlockFrom.SelectedIndexChanged += new System.EventHandler(this.cmbBlockFrom_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbGroupTo);
            this.groupBox3.Controls.Add(this.chkActionColorNumber);
            this.groupBox3.Controls.Add(this.chkActionColorPalette);
            this.groupBox3.Controls.Add(this.radActionBlok);
            this.groupBox3.Controls.Add(this.radActionNone);
            this.groupBox3.Controls.Add(this.radActionGroup);
            this.groupBox3.Controls.Add(this.cmbActionColorNumbers);
            this.groupBox3.Controls.Add(this.cmbActionColorPalette);
            this.groupBox3.Controls.Add(this.cmbBlockTo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblActionColor);
            this.groupBox3.Location = new System.Drawing.Point(14, 348);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(430, 334);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "action";
            // 
            // chkActionColorNumber
            // 
            this.chkActionColorNumber.AutoSize = true;
            this.chkActionColorNumber.Location = new System.Drawing.Point(16, 289);
            this.chkActionColorNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkActionColorNumber.Name = "chkActionColorNumber";
            this.chkActionColorNumber.Size = new System.Drawing.Size(148, 19);
            this.chkActionColorNumber.TabIndex = 7;
            this.chkActionColorNumber.Text = "change color number";
            this.chkActionColorNumber.UseVisualStyleBackColor = true;
            this.chkActionColorNumber.CheckedChanged += new System.EventHandler(this.chkActionColorNumber_CheckedChanged);
            // 
            // chkActionColorPalette
            // 
            this.chkActionColorPalette.AutoSize = true;
            this.chkActionColorPalette.Location = new System.Drawing.Point(19, 131);
            this.chkActionColorPalette.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkActionColorPalette.Name = "chkActionColorPalette";
            this.chkActionColorPalette.Size = new System.Drawing.Size(144, 19);
            this.chkActionColorPalette.TabIndex = 5;
            this.chkActionColorPalette.Text = "change color palette";
            this.chkActionColorPalette.UseVisualStyleBackColor = true;
            this.chkActionColorPalette.CheckedChanged += new System.EventHandler(this.chkActionColorPalette_CheckedChanged);
            // 
            // radActionBlok
            // 
            this.radActionBlok.AutoSize = true;
            this.radActionBlok.Enabled = false;
            this.radActionBlok.Location = new System.Drawing.Point(19, 98);
            this.radActionBlok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radActionBlok.Name = "radActionBlok";
            this.radActionBlok.Size = new System.Drawing.Size(101, 19);
            this.radActionBlok.TabIndex = 3;
            this.radActionBlok.Text = "replace block";
            this.radActionBlok.UseVisualStyleBackColor = true;
            this.radActionBlok.CheckedChanged += new System.EventHandler(this.radActionBlok_CheckedChanged);
            // 
            // radActionNone
            // 
            this.radActionNone.AutoSize = true;
            this.radActionNone.Checked = true;
            this.radActionNone.Location = new System.Drawing.Point(19, 38);
            this.radActionNone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radActionNone.Name = "radActionNone";
            this.radActionNone.Size = new System.Drawing.Size(85, 19);
            this.radActionNone.TabIndex = 0;
            this.radActionNone.TabStop = true;
            this.radActionNone.Text = "no replace";
            this.radActionNone.UseVisualStyleBackColor = true;
            this.radActionNone.CheckedChanged += new System.EventHandler(this.radActionNone_CheckedChanged);
            // 
            // radActionGroup
            // 
            this.radActionGroup.AutoSize = true;
            this.radActionGroup.Enabled = false;
            this.radActionGroup.Location = new System.Drawing.Point(19, 65);
            this.radActionGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radActionGroup.Name = "radActionGroup";
            this.radActionGroup.Size = new System.Drawing.Size(104, 19);
            this.radActionGroup.TabIndex = 1;
            this.radActionGroup.Text = "replace group";
            this.radActionGroup.UseVisualStyleBackColor = true;
            this.radActionGroup.CheckedChanged += new System.EventHandler(this.radActionGroup_CheckedChanged);
            // 
            // cmbActionColorNumbers
            // 
            this.cmbActionColorNumbers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionColorNumbers.Enabled = false;
            this.cmbActionColorNumbers.FormattingEnabled = true;
            this.cmbActionColorNumbers.Location = new System.Drawing.Point(171, 286);
            this.cmbActionColorNumbers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbActionColorNumbers.Name = "cmbActionColorNumbers";
            this.cmbActionColorNumbers.Size = new System.Drawing.Size(143, 23);
            this.cmbActionColorNumbers.TabIndex = 8;
            this.cmbActionColorNumbers.SelectedIndexChanged += new System.EventHandler(this.cmbActionColorNumbers_SelectedIndexChanged);
            // 
            // cmbActionColorPalette
            // 
            this.cmbActionColorPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionColorPalette.Enabled = false;
            this.cmbActionColorPalette.FormattingEnabled = true;
            this.cmbActionColorPalette.Location = new System.Drawing.Point(174, 129);
            this.cmbActionColorPalette.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbActionColorPalette.Name = "cmbActionColorPalette";
            this.cmbActionColorPalette.Size = new System.Drawing.Size(143, 23);
            this.cmbActionColorPalette.TabIndex = 6;
            // 
            // cmbBlockTo
            // 
            this.cmbBlockTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlockTo.Enabled = false;
            this.cmbBlockTo.FormattingEnabled = true;
            this.cmbBlockTo.Location = new System.Drawing.Point(174, 96);
            this.cmbBlockTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBlockTo.Name = "cmbBlockTo";
            this.cmbBlockTo.Size = new System.Drawing.Size(143, 23);
            this.cmbBlockTo.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(110, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "2";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(64, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "1";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(19, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "0";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActionColor
            // 
            this.lblActionColor.BackColor = System.Drawing.Color.Red;
            this.lblActionColor.Location = new System.Drawing.Point(322, 288);
            this.lblActionColor.Name = "lblActionColor";
            this.lblActionColor.Size = new System.Drawing.Size(38, 21);
            this.lblActionColor.TabIndex = 1;
            this.lblActionColor.Text = "2";
            this.lblActionColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(470, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 620);
            this.panel1.TabIndex = 4;
            // 
            // inputZoom
            // 
            this.inputZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputZoom.Location = new System.Drawing.Point(552, 695);
            this.inputZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputZoom.Name = "inputZoom";
            this.inputZoom.Size = new System.Drawing.Size(72, 23);
            this.inputZoom.TabIndex = 6;
            this.inputZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputZoom.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.inputZoom.ValueChanged += new System.EventHandler(this.inputZoom_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(507, 697);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "zoom";
            // 
            // FormBlockReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 751);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputZoom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGroupDo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormBlockReplace";
            this.Text = "Block Replace";
            this.Load += new System.EventHandler(this.FormBlockReplace_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGroupDo;
        private System.Windows.Forms.ComboBox cmbGroupTo;
        private System.Windows.Forms.ComboBox cmbGroupFrom;
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
        private System.Windows.Forms.RadioButton radBlock;
        private System.Windows.Forms.RadioButton radGroup;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.ComboBox cmbBlockFrom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkActionColorNumber;
        private System.Windows.Forms.CheckBox chkActionColorPalette;
        private System.Windows.Forms.RadioButton radActionBlok;
        private System.Windows.Forms.RadioButton radActionGroup;
        private System.Windows.Forms.ComboBox cmbActionColorPalette;
        private System.Windows.Forms.ComboBox cmbBlockTo;
        private System.Windows.Forms.CheckedListBox chkObjects;
        private System.Windows.Forms.ComboBox cmbActionColorNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTargetColor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblActionColor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radActionNone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown inputZoom;
        private System.Windows.Forms.Label label1;
    }
}