namespace BlueprintManager
{
    partial class FormBlueprintEditor
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
            this.panel1 = new DoubleBufferedPanel();
            this.panel2 = new ColorPalettePanel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 450);
            this.panel1.TabIndex = 0;
            this.panel1.PaddingChanged += new System.EventHandler(this.panel1_PaddingChanged);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(19, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 91);
            this.panel2.TabIndex = 1;
            // 
            // FormBlueprintEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 605);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormBlueprintEditor";
            this.Text = "FormBlueprintEditor";
            this.Load += new System.EventHandler(this.FormBlueprintEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferedPanel panel1;
        private ColorPalettePanel panel2;
    }
}