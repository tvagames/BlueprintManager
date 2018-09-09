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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbGroupFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGroupTo = new System.Windows.Forms.ComboBox();
            this.btnGroupDo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGroupDo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbGroupTo);
            this.groupBox1.Controls.Add(this.cmbGroupFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "replace by group";
            // 
            // cmbGroupFrom
            // 
            this.cmbGroupFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupFrom.FormattingEnabled = true;
            this.cmbGroupFrom.Location = new System.Drawing.Point(51, 29);
            this.cmbGroupFrom.Name = "cmbGroupFrom";
            this.cmbGroupFrom.Size = new System.Drawing.Size(204, 20);
            this.cmbGroupFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "from";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "to";
            // 
            // cmbGroupTo
            // 
            this.cmbGroupTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupTo.FormattingEnabled = true;
            this.cmbGroupTo.Location = new System.Drawing.Point(321, 29);
            this.cmbGroupTo.Name = "cmbGroupTo";
            this.cmbGroupTo.Size = new System.Drawing.Size(204, 20);
            this.cmbGroupTo.TabIndex = 0;
            // 
            // btnGroupDo
            // 
            this.btnGroupDo.Location = new System.Drawing.Point(532, 25);
            this.btnGroupDo.Name = "btnGroupDo";
            this.btnGroupDo.Size = new System.Drawing.Size(75, 23);
            this.btnGroupDo.TabIndex = 2;
            this.btnGroupDo.Text = "replace";
            this.btnGroupDo.UseVisualStyleBackColor = true;
            this.btnGroupDo.Click += new System.EventHandler(this.btnGroupDo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "name";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(61, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(23, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "xxx";
            // 
            // FormBlockReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 136);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormBlockReplace";
            this.Text = "Block Replace";
            this.Load += new System.EventHandler(this.FormBlockReplace_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGroupDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGroupTo;
        private System.Windows.Forms.ComboBox cmbGroupFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblName;
    }
}