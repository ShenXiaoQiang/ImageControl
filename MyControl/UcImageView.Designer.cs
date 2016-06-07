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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcImageView));
            this.PnlMain = new System.Windows.Forms.Panel();
            this.hScrollBarImageView = new System.Windows.Forms.HScrollBar();
            this.picView = new System.Windows.Forms.PictureBox();
            this.vScrollBarImageView = new System.Windows.Forms.VScrollBar();
            this.printDocImageView = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialogImage = new System.Windows.Forms.PrintPreviewDialog();
            this.lblScale = new System.Windows.Forms.Label();
            this.tmrScaleShowTime = new System.Windows.Forms.Timer(this.components);
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
            this.PnlMain.Controls.Add(this.lblScale);
            this.PnlMain.Controls.Add(this.hScrollBarImageView);
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
            // picView
            // 
            this.picView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // lblScale
            // 
            this.lblScale.BackColor = System.Drawing.Color.Transparent;
            this.lblScale.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScale.ForeColor = System.Drawing.Color.White;
            this.lblScale.Location = new System.Drawing.Point(197, 137);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(250, 37);
            this.lblScale.TabIndex = 5;
            this.lblScale.Text = "100%";
            this.lblScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScale.Visible = false;
            // 
            // tmrScaleShowTime
            // 
            this.tmrScaleShowTime.Tick += new System.EventHandler(this.tmrScaleShowTime_Tick);
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
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.PictureBox picView;
        private System.Drawing.Printing.PrintDocument printDocImageView;
        private System.Windows.Forms.VScrollBar vScrollBarImageView;
        private System.Windows.Forms.HScrollBar hScrollBarImageView;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogImage;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.Timer tmrScaleShowTime;
    }
}
