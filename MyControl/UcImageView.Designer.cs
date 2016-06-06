namespace MyControl
{
    partial class UcImageView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcImageView));
            this.PnlMain = new System.Windows.Forms.Panel();
            this.hScrollBarImageView = new System.Windows.Forms.HScrollBar();
            this.mnuPrint = new System.Windows.Forms.CheckBox();
            this.mnuMy = new System.Windows.Forms.CheckBox();
            this.picView = new System.Windows.Forms.PictureBox();
            this.vScrollBarImageView = new System.Windows.Forms.VScrollBar();
            this.printDocImageView = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialogImage = new System.Windows.Forms.PrintPreviewDialog();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PnlMain.Controls.Add(this.hScrollBarImageView);
            this.PnlMain.Controls.Add(this.mnuPrint);
            this.PnlMain.Controls.Add(this.mnuMy);
            this.PnlMain.Controls.Add(this.picView);
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(660, 344);
            this.PnlMain.TabIndex = 0;
            this.PnlMain.Resize += new System.EventHandler(this.PnlMain_Resize);
            // 
            // hScrollBarImageView
            // 
            this.hScrollBarImageView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBarImageView.Location = new System.Drawing.Point(2, 325);
            this.hScrollBarImageView.Name = "hScrollBarImageView";
            this.hScrollBarImageView.Size = new System.Drawing.Size(634, 17);
            this.hScrollBarImageView.TabIndex = 3;
            this.hScrollBarImageView.Visible = false;
            this.hScrollBarImageView.ValueChanged += new System.EventHandler(this.hScrollBarImageView_ValueChanged);
            // 
            // mnuPrint
            // 
            this.mnuPrint.AutoSize = true;
            this.mnuPrint.Location = new System.Drawing.Point(570, 303);
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(15, 14);
            this.mnuPrint.TabIndex = 2;
            this.mnuPrint.UseVisualStyleBackColor = true;
            this.mnuPrint.Visible = false;
            // 
            // mnuMy
            // 
            this.mnuMy.AutoSize = true;
            this.mnuMy.Location = new System.Drawing.Point(463, 305);
            this.mnuMy.Name = "mnuMy";
            this.mnuMy.Size = new System.Drawing.Size(78, 16);
            this.mnuMy.TabIndex = 1;
            this.mnuMy.Text = "checkBox1";
            this.mnuMy.UseVisualStyleBackColor = true;
            this.mnuMy.Visible = false;
            this.mnuMy.CheckedChanged += new System.EventHandler(this.mnuMy_CheckedChanged);
            // 
            // picView
            // 
            this.picView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picView.Location = new System.Drawing.Point(0, 0);
            this.picView.Margin = new System.Windows.Forms.Padding(0);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(639, 323);
            this.picView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picView.TabIndex = 0;
            this.picView.TabStop = false;
            this.picView.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.picView_LoadCompleted);
            this.picView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picView_MouseDown);
            this.picView.MouseEnter += new System.EventHandler(this.picView_MouseEnter);
            this.picView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picView_MouseMove);
            this.picView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picView_MouseUp);
            // 
            // vScrollBarImageView
            // 
            this.vScrollBarImageView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBarImageView.Location = new System.Drawing.Point(640, 4);
            this.vScrollBarImageView.Name = "vScrollBarImageView";
            this.vScrollBarImageView.Size = new System.Drawing.Size(17, 319);
            this.vScrollBarImageView.TabIndex = 4;
            this.vScrollBarImageView.Visible = false;
            this.vScrollBarImageView.ValueChanged += new System.EventHandler(this.vScrollBarImageView_ValueChanged);
            this.vScrollBarImageView.SizeChanged += new System.EventHandler(this.vScrollBarImageView_ValueChanged);
            // 
            // printDocImageView
            // 
            this.printDocImageView.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocImageView_PrintPage);
            // 
            // printPreviewDialogImage
            // 
            this.printPreviewDialogImage.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialogImage.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialogImage.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialogImage.Enabled = true;
            this.printPreviewDialogImage.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialogImage.Icon")));
            this.printPreviewDialogImage.Name = "printPreviewDialogImage";
            this.printPreviewDialogImage.Visible = false;
            // 
            // UcImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.vScrollBarImageView);
            this.Controls.Add(this.PnlMain);
            this.Name = "UcImageView";
            this.Size = new System.Drawing.Size(660, 343);
            this.Load += new System.EventHandler(this.UcImageView_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.PictureBox picView;
        private System.Drawing.Printing.PrintDocument printDocImageView;
        private System.Windows.Forms.CheckBox mnuPrint;
        private System.Windows.Forms.CheckBox mnuMy;
        private System.Windows.Forms.VScrollBar vScrollBarImageView;
        private System.Windows.Forms.HScrollBar hScrollBarImageView;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogImage;
    }
}
