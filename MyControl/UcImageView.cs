using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace MyControl
{
    public partial class UcImageView : UserControl
    {
        #region 公共属性
        private bool _mnuMoveImageChecked;
        ///<summary>
        /// 确定漫游菜单项是否处于选中状态(用于是否可以移动或漫游图片)
        ///</summary>
        [Category("图片浏览"), Description("确定漫游菜单项是否处于选中状态(用于是否可以移动或漫游图片)"), Browsable(false)]
        public bool MnuMoveImageChecked
        {
            get
            {
                return _mnuMoveImageChecked;
            }
            set
            {
                _mnuMoveImageChecked = value;
                this.mnuMy.Checked = _mnuMoveImageChecked;
            }
        }

        private bool _mnuPrintVisible = false; //默认可见
                                              ///<summary>
                                              /// 确定打印菜单项是可见还是隐藏
                                              ///</summary>
        [Category("图片浏览"), Description("确定打印菜单项是可见还是隐藏"), Browsable(true)]
        public bool MnuPrintVisible
        {
            get
            {
                return _mnuPrintVisible;
            }
            set
            {
                _mnuPrintVisible = value;
                this.mnuPrint.Visible = _mnuPrintVisible;
            }
        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        #endregion
        public UcImageView()
        {
            InitializeComponent();
            //记录PnlMain的size
            panelOldSize.X = PnlMain.Width;
            panelOldSize.Y = PnlMain.Height;

            this.m_VBarWidth = SystemInformation.VerticalScrollBarWidth;

            this.m_HBarHeight = SystemInformation.HorizontalScrollBarHeight;
            this.mnuPrint.Visible = false;
        }
        #region 公共变量
        private Point StartP = new Point(0, 0);
        private bool isMouseDown = false;
        private Point panelOldSize = new Point(0, 0);
        private int imgIndexBy1000 = 0;
        private int keyAction = 0;
        private int w, h;
        private int imgScale = 0;
        #endregion

        #region 公共事件

        [Category("图片浏览"), Description("移动或漫游图片的Checked事件Changed时发生。"), Browsable(true)]
        public event EventHandler OnMnuMoveImageCheckedChanged;

        #endregion

        #region 公共方法

        #region 增加图片到PictureBox:void AddImage(string fileName, bool isAsync)
        public void DisPlay()
        {
            AddImage(_fileName, false);
        }
        ///<summary>
        /// 增加要显示的图片
        ///</summary>
        ///<param name="fileName">图片路径全名</param>
        ///<param name="isAsync">true:异步方式加载图片</param>
        public void AddImage(string fileName, bool isAsync)
        {
            if (isAsync)//异步加载图片
            {
                //图片异步加载完成后的处理事件
                picView.LoadCompleted += new AsyncCompletedEventHandler(picView_LoadCompleted);
                //图片加裁时，显示等待光标
                picView.UseWaitCursor = true;
                //采用异步加裁方式
                picView.WaitOnLoad = false;
                //开始异步加裁图片
                picView.LoadAsync(fileName);
            }
            else
            {
                picView.Image = Image.FromFile(fileName);//载入图片
            }

            InitialImage();

        }

        ///<summary>
        /// 增加要显示的图片
        ///</summary>
        ///<param name="img">Image</param>
        public void AddImage(Image img)
        {
            if (img != null)
            {
                picView.Image = img;
                InitialImage();
            }
            else
            {
                picView = null;
            }
        }
        #endregion

        #region 得到ImageView中的图片:Image GetImageInImageView()
        ///<summary>
        /// 得到ImageView中的图片
        ///</summary>
        ///<returns>Image</returns>
        public Image GetImageInImageView()
        {
            if (picView.Image != null)
            {
                return picView.Image;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 放大、缩小、适应图片大小、移动图片、左旋转图片与右旋转图片
        ///<summary>
        /// 放大图片
        ///</summary>
        public void ZoomInImage()
        {
            if (picView.Image != null)
            {
                if (picView.Width < 5000)
                {
                    zoom(picView.Location, 1100);
                    CenterImage();
                }
                else
                {
                    MessageBox.Show("对不起，不能再进行放大!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        ///<summary>
        /// 缩小图片
        ///</summary>
        public void ZoomOutImage()
        {
            if (picView.Image != null)
            {
                if (picView.Image.Width / picView.Width < 5 && -7 < 0)
                {
                    zoom(picView.Location, 900);
                    CenterImage();
                }
                else
                {
                    MessageBox.Show("对不起，不能再进行缩小!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        ///<summary>
        /// 适应图片大小
        ///</summary>
        public void FitImageSize()
        {
            if (picView.Image != null)
            {
                float r1 = (float)this.w / this.picView.Width;
                float r2 = (float)this.h / this.picView.Height;
                //this.picView.Scale(r1, r2);
                SizeF sizeF = new SizeF(r1, r2);
                this.picView.Scale(sizeF);
                this.picView.Left = (this.PnlMain.Width - this.picView.Width) / 2;
                this.picView.Top = (this.PnlMain.Height - this.picView.Height) / 2;
                this.picView.Cursor = Cursors.Default;
                CenterImage();
                setScrllBars();
            }
        }

        ///<summary>
        /// 移动图片
        ///</summary>
        public void MoveImage()
        {
            mnuMy.Checked = MnuMoveImageChecked;
        }

        ///<summary>
        /// 左旋转图片
        ///</summary>
        public void LeftRotateImage()
        {
            if (picView.Image != null)
            {
                picView.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                picView.Refresh();
                CenterImage();
            }
        }

        ///<summary>
        /// 右旋转图片
        ///</summary>
        public void RightRotateImage()
        {
            if (picView.Image != null)
            {
                picView.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                picView.Refresh();
                CenterImage();
            }
        }

        public void PrintImagePreview()
        {
            if (picView.Image!=null)
            {
                //预览
                this.printPreviewDialogImage.Document = printDocImageView;
                this.printPreviewDialogImage.ShowDialog();
            }
        }

        public void PrintImage()
        {
            mnuPrint_Click(null,null);
        }
        #endregion

        #endregion

       

        #region 私有方法

        private void picView_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //图片加载完成后，将光标恢复
            picView.UseWaitCursor = false;
        }

        #region 图片缩放
        ///<summary>
        /// 图片缩放
        ///</summary>
        ///<param name="center">缩放中心点</param>
        ///<param name="zoomIndexBy1000">缩放倍率的1000倍</param>
        private void zoom(Point center, int zoomIndexBy1000)
        {
            //记录原始的picView的Size
            Point oldSize = new Point(picView.Width, picView.Height);
            //实施放大（以x方向为基准计算得出y方向大小，防止多次运算误差积累使Image和picView的尺寸不匹配）
            picView.Width = picView.Width * zoomIndexBy1000 / 1000;
            picView.Height = picView.Width * imgIndexBy1000 / 1000;
            //重新定位标定后的picView位置
            picView.Left -= ((picView.Width - oldSize.X) * (center.X * 1000 / oldSize.X)) / 1000;
            picView.Top -= ((picView.Height - oldSize.Y) * (center.Y * 1000 / oldSize.Y)) / 1000;
            //重新设定横向滚动条最大值和位置
            //if (picView.Width - PnlMain.Width > 0)
            //{
            //    hScrollBarImageView.Visible = true;
            //    hScrollBarImageView.Maximum = picView.Width - PnlMain.Width + vScrollBarImageView.Width + 2;
            //    hScrollBarImageView.Value = (picView.Left >= 0 ? 0 : (-picView.Left > hScrollBarImageView.Maximum ? hScrollBarImageView.Maximum : -picView.Left));
            //}
            //else
            //{
            //    hScrollBarImageView.Visible = false;
            //}
            ////重新设定纵向滚动条最大值和位置
            //if (picView.Height - PnlMain.Height > 0)
            //{
            //    vScrollBarImageView.Visible = true;
            //    vScrollBarImageView.Maximum = picView.Height - PnlMain.Height + hScrollBarImageView.Height + 2;
            //    vScrollBarImageView.Value = (picView.Top >= 0 ? 0 : (-picView.Top > vScrollBarImageView.Maximum ? vScrollBarImageView.Maximum : -picView.Top));
            //}
            //else
            //{
            //    vScrollBarImageView.Visible = false;
            //}
            setScrllBars();
        }
        #endregion

        #region 图片加裁到PictureBox中后，对其进行初始化操作
        ///<summary>
        /// 图片加裁到PictureBox中后，对其进行初始化操作
        ///</summary>
        private void InitialImage()
        {
            ImageChange();//得到最适合显示的图片尺寸
            this.w = this.picView.Width;
            this.h = this.picView.Height;

            //设定图片位置
            picView.Location = new Point(0, 0);
            //设定图片初始尺寸
            picView.Size = picView.Image.Size;
            //设定图片纵横比
            imgIndexBy1000 = (picView.Image.Height * 1000) / picView.Image.Width;
            //设定滚动条
            //if (picView.Width - PnlMain.Width > 0)
            //{
            //    hScrollBarImageView.Maximum = picView.Width - PnlMain.Width + vScrollBarImageView.Width + 2;//+ hScrollBarImageView.LargeChange
            //    hScrollBarImageView.Visible = true;
            //}
            //if (picView.Height - PnlMain.Height > 0)
            //{
            //    vScrollBarImageView.Maximum = picView.Height - PnlMain.Height + hScrollBarImageView.Height + 2;//+ vScrollBarImageView.LargeChange
            //    vScrollBarImageView.Visible = true;
            //}
            setScrllBars();
            CenterImage();
        }
        #endregion

        #region 居中与全屏显示图片

        ///<summary>
        /// 使图片全屏显示
        ///</summary>
        private void FullImage()
        {
            if (picView.Image.Width < picView.Width && picView.Image.Height < picView.Height)
            {
                picView.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            CalculateAspectRatioAndSetDimensions();
        }


        ///<summary>
        /// 保持图片居中显示
        ///</summary>
        private void CenterImage()
        {
            picView.Left = PnlMain.Width / 2 - picView.Width / 2;
            picView.Top = PnlMain.Height / 2 - picView.Height / 2;
            //picView.Left = 0;
            //picView.Top = 0;
        }

        #endregion

        #region CalculateAspectRatioAndSetDimensions
        ///<summary>
        /// CalculateAspectRatioAndSetDimensions
        ///</summary>
        ///<returns>double</returns>
        private double CalculateAspectRatioAndSetDimensions()
        {
            double ratio;
            if (picView.Image.Width > picView.Image.Height)
            {
                ratio = picView.Image.Width / picView.Image.Height;
                picView.Height = Convert.ToInt16(double.Parse(picView.Width.ToString()) / ratio);
            }
            else
            {
                ratio = picView.Image.Height / picView.Image.Width;
                picView.Width = Convert.ToInt16(double.Parse(picView.Height.ToString()) / ratio);
            }
            return ratio;
        }
        #endregion

        #region 用于适应图片大小
        ///<summary>
        /// 用于适应图片大小
        ///</summary>
        private void ImageChange()
        {
            this.picView.Height = this.picView.Image.Height;
            this.picView.Width = this.picView.Image.Width;
            float cx = 1;
            if (this.picView.Image.Height > this.PnlMain.Height)
                cx =(float)(this.PnlMain.Height - 10) / (float)this.picView.Image.Height;
            SizeF curSize = new SizeF(cx, cx);
            this.picView.Scale(curSize);

            this.picView.Left = (this.PnlMain.Width - this.picView.Width) / 2;
            this.picView.Top = (this.PnlMain.Height - this.picView.Height) / 2;
        }
        #endregion

        #endregion

        #region 窗口（PnlMain）尺寸改变时图像的显示位置控制
        /************************************************************
        * 窗口（PnlMain）尺寸改变时图像的显示位置控制
        ************************************************************/
        private void PnlMain_Resize(object sender, EventArgs e)
        {
            //对左右的方向操作（左右）
            if (picView.Width <= PnlMain.Width) //图片左右居中
            {
                picView.Left = (PnlMain.Width - picView.Width) / 2;
                hScrollBarImageView.Visible = false;
            }
            else if (picView.Left < 0 && picView.Width + picView.Left < PnlMain.Width)//图片靠右
            {
                picView.Left = PnlMain.Width - picView.Width;
                hScrollBarImageView.Visible = true;
            }
            else if (picView.Left > 0 && picView.Width + picView.Left > PnlMain.Width)//图片靠左
            {
                picView.Left = 0;
                hScrollBarImageView.Visible = true;
            }
            else//保证显示的中心图样不变（左右）
            {
                picView.Left += (PnlMain.Width - panelOldSize.X) / 2;
                hScrollBarImageView.Visible = true;
            }
            //设定横向滚动条最大值
            hScrollBarImageView.Maximum = (picView.Width - PnlMain.Width > 0 ? picView.Width - PnlMain.Width + hScrollBarImageView.Maximum + 2 : 0);
            //设定横向滚动条Value
            hScrollBarImageView.Value = (picView.Left >= 0 ? 0 : -picView.Left);
            //重置旧的pannel1的Width
            panelOldSize.X = PnlMain.Width;

            //对上下的方向操作（上下）
            if (picView.Height <= PnlMain.Height)//图片上下居中
            {
                picView.Top = (PnlMain.Height - picView.Height) / 2;
                vScrollBarImageView.Visible = false;
            }
            else if (picView.Top < 0 && picView.Height + picView.Top < PnlMain.Height)//图片靠下
            {
                picView.Top = PnlMain.Height - picView.Height;
                vScrollBarImageView.Visible = true;
            }
            else if (picView.Top > 0 && picView.Height + picView.Top > PnlMain.Height)//图片靠上
            {
                picView.Top = 0;
                vScrollBarImageView.Visible = true;
            }
            else//保证显示的中心图样不变（上下）
            {
                picView.Top += (PnlMain.Height - panelOldSize.Y) / 2;
                vScrollBarImageView.Visible = true;
            }
            //设定纵向滚动条最大值
            vScrollBarImageView.Maximum = (picView.Height - PnlMain.Height > 0 ? picView.Height - PnlMain.Height + vScrollBarImageView.Maximum + 2 : 0);
            //设定纵向滚动条Value
            vScrollBarImageView.Value = (picView.Top >= 0 ? 0 : -picView.Top);
            //重置旧的pannel1的Height
            panelOldSize.Y = PnlMain.Height;
        }
        #endregion

        #region 滚动条滚动时，图片移动
        /************************************************************
                 * 滚动条滚动时，图片移动
                 ************************************************************/
        private void vScrollBarImageView_ValueChanged(object sender, EventArgs e)
        {
            picView.Top = -vScrollBarImageView.Value;
        }

        private void hScrollBarImageView_ValueChanged(object sender, EventArgs e)
        {
            picView.Left = -hScrollBarImageView.Value;
        }
        #endregion

        #region PictureBox 鼠标按下、鼠标进入、松开与移动事件
        private void picView_MouseDown(object sender, MouseEventArgs e)
        {
            StartP = e.Location;
            isMouseDown = true;
        }

        private void picView_MouseEnter(object sender, EventArgs e)
        {
            picView.Focus();
        }

        private void picView_MouseMove(object sender, MouseEventArgs e)
        {
            if (mnuMy.Checked && isMouseDown)
            {
                this.picView.Cursor = Cursors.SizeAll;
                //计算出移动后两个滚动条应该的Value
                int x = -picView.Left + StartP.X - e.X;
                int y = -picView.Top + StartP.Y - e.Y;

                //如果滚动条的value有效则执行操作；
                if (x >= -PnlMain.Width + 10 && x <= picView.Width - 10)
                {
                    if (hScrollBarImageView.Visible)
                    {
                        if (x > 0)
                            hScrollBarImageView.Value = x > hScrollBarImageView.Maximum ? hScrollBarImageView.Maximum : x;
                        picView.Left = -x - (vScrollBarImageView.Visible && x < 0 ? vScrollBarImageView.Width : 0);
                    }
                    else
                        picView.Left = -x;
                }

                if (y >= -PnlMain.Height + 10 && y <= picView.Height - 10)
                {
                    if (vScrollBarImageView.Visible)
                    {
                        if (y > 0)
                            vScrollBarImageView.Value = y > vScrollBarImageView.Maximum ? vScrollBarImageView.Maximum : y;
                        picView.Top = -y - (hScrollBarImageView.Visible && y < 0 ? hScrollBarImageView.Height : 0);
                    }
                    else
                        picView.Top = -y;
                }


                /*****************************************************
                                 * 给予调整滚动条调整图片位置
                                 *****************************************************
                                计算出移动后两个滚动条应该的Value*/
                /*int w = hScrollBarImageView.Value + StartP.X -e.X;
                                int z = vScrollBarImageView.Value + StartP.Y -e.Y;
                                如果滚动条的value有效则执行操作；
                                否则将滚动条按不同情况拉到两头
                                if (w >= 0 && w <= hScrollBarImageView.Maximum)
                                {
                                    hScrollBarImageView.Value = w;
                                }
                                else
                                {
                                    hScrollBarImageView.Value = (w < 0 ? 0 : hScrollBarImageView.Maximum);
                                }
                                if (z >= 0 && z <= vScrollBarImageView.Maximum)
                                {
                                    vScrollBarImageView.Value = z;
                                }
                                else
                                {
                                    vScrollBarImageView.Value = (z < 0 ? 0 : vScrollBarImageView.Maximum);
                                }*/
            }
            else
            {
                this.picView.Cursor = Cursors.Default;
            }
        }

        private void picView_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        #endregion

        #region 滚动鼠标滚轮实现鼠标缩放
        /************************************************************
                 * 滚动鼠标滚轮实现鼠标缩放
                 ************************************************************/
        private void picView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (picView.Image != null)
            {
                if (e.Delta > 0)
                    ZoomInImage();
                else
                    ZoomOutImage();
            }
        }
        #endregion

        #region 窗体按键事件处理

        private void UcImageView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                keyAction = 1;
            else if (e.Shift)
                keyAction = 2;
        }

        private void UcImageView_KeyUp(object sender, KeyEventArgs e)
        {
            keyAction = 0;
        }

        private void picView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                keyAction = 1;
            else if (e.Shift)
                keyAction = 2;
            else
                keyAction = 3;
        }
        private void picView_KeyUp(object sender, KeyEventArgs e)
        {
            keyAction = 0;
        }
        #endregion

        #region 快捷菜单事件代码
        //放大图片
        private void mnuZoomIn_Click(object sender, EventArgs e)
        {
            this.ZoomInImage();
        }

        //缩小图片
        private void mnuZoomOut_Click(object sender, EventArgs e)
        {
            this.ZoomOutImage();
        }

        //适应图片大小
        private void mnuFitSize_Click(object sender, EventArgs e)
        {
            this.FitImageSize();
        }

        //漫游图片
        private void mnuMy_Click(object sender, EventArgs e)
        {
            MnuMoveImageChecked = !mnuMy.Checked;
            this.MoveImage();
        }

        //左旋转图片
        private void mnuLeftRotate_Click(object sender, EventArgs e)
        {
            this.LeftRotateImage();
        }

        //右旋转图片
        private void mnuRightRotate_Click(object sender, EventArgs e)
        {
            this.RightRotateImage();
        }

        #region 打印图片
        //打印图片
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            if (picView.Image != null)
            {
                PrintDialog printDgImageView = new PrintDialog();

                /*设置纸张类型
                                PaperSize pg = new PaperSize("A3",297,420);
                                printDocImageView.DefaultPageSettings.PaperSize = pg;*/
                PaperSize pg = null;
                foreach (PaperSize ps in printDocImageView.PrinterSettings.PaperSizes)
                {
                    if (ps.PaperName.Equals("A4"))
                        pg = ps;
                }
                printDocImageView.DefaultPageSettings.PaperSize = pg;
                printDgImageView.Document = printDocImageView;
                if (printDgImageView.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        printDocImageView.Print();
                    }
                    catch
                    {
                        //停止打印
                        printDocImageView.PrintController.OnEndPrint(printDocImageView, new System.Drawing.Printing.PrintEventArgs());
                    }
                }
            }
            else
            {
                //DialogHelper.ShowWarningMsg("对不起，没有要打印的数据!");
            }
        }

        private void printDocImageView_PrintPage(object sender, PrintPageEventArgs e)
        {
            //this.FitImageSize();//实际尺寸
            if (picView.Image != null)
            {
                Graphics grfx = e.Graphics;

                #region 这里改变图像大小 这是A4纸大小
                //RectangleF rectf = new RectangleF(ppea.MarginBounds.Left, ppea.MarginBounds.Top, ppea.MarginBounds.Width, ppea.MarginBounds.Height);
                //A4
                RectangleF rectf = new RectangleF(0, 0, e.MarginBounds.Width + 200, e.MarginBounds.Height + 200);
                //RectangleF rectf = new RectangleF(0, 0, ppea.MarginBounds.Width + 200, 500);
                #endregion
                grfx.DrawImage(picView.Image, rectf);
                //e.Graphics.DrawImage(picView.Image, picView.Location.X, picView.Location.Y, picView.Width, picView.Height);
            }
        }
        #endregion

        #endregion

        #region 窗体事件
        private void mnuMy_CheckedChanged(object sender, EventArgs e)
        {
            if (OnMnuMoveImageCheckedChanged != null)
            {
                MnuMoveImageChecked = this.mnuMy.Checked;
                OnMnuMoveImageCheckedChanged(sender, EventArgs.Empty);
            }
        }
        #endregion


        #region 滚动条设置
        private int m_VBarWidth;

        private int m_HBarHeight;

        private int m_BorderWidth=0;

        private void UcImageView_Load(object sender, EventArgs e)
        {
            picView.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.picView_MouseWheel);
        }

        private void setScrllBars()
        {
            //设置垂直最大滚动值
            int vLarge = PnlMain.Height;
            //设置水平最大滚动值
            int hLarge = PnlMain.Width;

            //显示区域的高
            int vValue = picView.Height;
            //显示区域的宽
            int hValue = picView.Width;

            //滚动条的最大值
            int vMaxValue = 0;
            int hMaxValue = 0;

            //垂直滚动条的可见标志
            bool vVisible = false;
            //水平滚动条的可见标志
            bool hVisible = false;

            if (vValue > PnlMain.Height - 2 * this.m_BorderWidth)
            {
                //垂直方向上显示区域高大于窗口高时，垂直滚动条直接可见
                vVisible = true;

                //垂直滚动条宽影响水平滚动条可见性
                hVisible = hValue >
                 (PnlMain.Width - this.m_VBarWidth - 2 * this.m_BorderWidth);
                //水平滚动条的最大值因垂直滚动的显示而受影响

                hMaxValue =
                  hValue - (PnlMain.Width - this.m_VBarWidth - 2 * this.m_BorderWidth);

                //水平滚动条可见性又会反向影响到垂直滚动条的最大值
                if (!hVisible)
                {
                    vMaxValue =
                      vValue - (PnlMain.Height - 2 * this.m_BorderWidth);
                }
                else
                {
                    vMaxValue =
                      vValue - (PnlMain.Height - this.m_HBarHeight - 2 * this.m_BorderWidth);
                }
            }
            else if (hValue > PnlMain.Width - 2 * this.m_BorderWidth)
            {
                //水平方向上显示区域宽大于窗口宽时，水平滚动条直接可见
                hVisible = true;

                //水平方向滚动条高影响垂直滚动条可见性
                vVisible =
                   vValue > (PnlMain.Height - this.m_HBarHeight - 2 * this.m_BorderWidth);

                //垂直滚动条的最大值因水平滚动条的显示而受影响
                vMaxValue =
                   vValue - (PnlMain.Height - this.m_HBarHeight - 2 * this.m_BorderWidth);

                //垂直滚动条的可见性又反向影响到了水平滚动条的最大值
                if (!vVisible)
                {
                    hMaxValue =
                      hValue - (PnlMain.Width - 2 * this.m_BorderWidth);
                }
                else
                {
                    hMaxValue =
                      hValue - (PnlMain.Width - this.m_VBarWidth - 2 * this.m_BorderWidth);
                }
            }

            int vOffset = this.m_VBarWidth;//垂直滚动条高的差值
            int hOffset = this.m_HBarHeight;//水平滚动条宽的差值
            if (vVisible != hVisible)
            {
                //当垂直滚动条和水平滚动条可见性不同时，要显示的滚动条占满位置
                if (vVisible)
                {
                    vOffset = 0;
                }
                if (hVisible)
                {
                    hOffset = 0;
                }
            }

            //计算垂直滚动条靠近右边所需的矩形区域
            Rectangle vRect = new Rectangle(
                PnlMain.Width - this.m_BorderWidth - this.m_VBarWidth,
                this.m_BorderWidth,
                this.m_VBarWidth,
                PnlMain.Height - 2 * this.m_BorderWidth - vOffset);

            //计算水平滚动条靠近下边所需的矩形区域
            Rectangle hRect = new Rectangle(
               this.m_BorderWidth,
               PnlMain.Height - this.m_HBarHeight - this.m_BorderWidth,
               PnlMain.Width - 2 * this.m_BorderWidth - hOffset,
               this.m_HBarHeight);


            //当窗口的宽不足容纳垂直滚动条时，需隐藏垂直滚动条
            bool tmpVHide =
              PnlMain.Width < (this.m_VBarWidth + 2 * this.m_BorderWidth);

            //当窗口的高不足容纳水平滚动条时，需隐藏水平滚动条
            bool tmpHHide =
               PnlMain.Height < (this.m_HBarHeight + 2 * this.m_BorderWidth);

            //在需要显示每个滚动条的时候先设置其各个值
            this.vScrollBarImageView.Bounds = vRect;
            this.vScrollBarImageView.LargeChange = vLarge;
            this.vScrollBarImageView.Maximum = vMaxValue + vLarge - 1;
            this.vScrollBarImageView.Minimum = 0;

            this.hScrollBarImageView.Bounds = hRect;
            this.hScrollBarImageView.LargeChange = hLarge;
            this.hScrollBarImageView.Maximum = hMaxValue + hLarge - 1;
            this.hScrollBarImageView.Minimum = 0;

            //如果窗口高不够，则直接不显示垂直滚动条
            if (tmpVHide)
            {
                vVisible = false;
            }

            //如果窗口宽不够，则直接不显示水平滚动条
            if (tmpHHide)
            {
                hVisible = false;
            }

            //显示标志决定滚动条的可见性
            this.vScrollBarImageView.Visible = vVisible;
            this.hScrollBarImageView.Visible = hVisible;

        }
        #endregion

    }
}
