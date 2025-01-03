namespace Labeling
{
    partial class UClabel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_imagePath = new System.Windows.Forms.Label();
            this.chk_select = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(35, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(436, 25);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(580, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // lbl_imagePath
            // 
            this.lbl_imagePath.AutoSize = true;
            this.lbl_imagePath.Location = new System.Drawing.Point(451, 7);
            this.lbl_imagePath.Name = "lbl_imagePath";
            this.lbl_imagePath.Size = new System.Drawing.Size(35, 13);
            this.lbl_imagePath.TabIndex = 2;
            this.lbl_imagePath.Text = "label1";
            // 
            // chk_select
            // 
            this.chk_select.AutoSize = true;
            this.chk_select.Dock = System.Windows.Forms.DockStyle.Left;
            this.chk_select.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_select.Location = new System.Drawing.Point(0, 0);
            this.chk_select.Margin = new System.Windows.Forms.Padding(10);
            this.chk_select.Name = "chk_select";
            this.chk_select.Padding = new System.Windows.Forms.Padding(10);
            this.chk_select.Size = new System.Drawing.Size(35, 50);
            this.chk_select.TabIndex = 3;
            this.chk_select.UseVisualStyleBackColor = true;
            this.chk_select.CheckedChanged += new System.EventHandler(this.chk_select_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyPath,
            this.btnCopyImage,
            this.btnOpenImage});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // btnCopyPath
            // 
            this.btnCopyPath.Name = "btnCopyPath";
            this.btnCopyPath.Size = new System.Drawing.Size(139, 22);
            this.btnCopyPath.Text = "Copy path";
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(139, 22);
            this.btnCopyImage.Text = "Copy image";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(139, 22);
            this.btnOpenImage.Text = "Open image";
            // 
            // UClabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lbl_imagePath);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chk_select);
            this.Name = "UClabel";
            this.Size = new System.Drawing.Size(1016, 50);
            this.Enter += new System.EventHandler(this.UClabel_Enter);
            this.Leave += new System.EventHandler(this.UClabel_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_imagePath;
        public System.Windows.Forms.CheckBox chk_select;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCopyPath;
        private System.Windows.Forms.ToolStripMenuItem btnCopyImage;
        private System.Windows.Forms.ToolStripMenuItem btnOpenImage;
    }
}
