using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FrmUcImageView_Shown(object sender, EventArgs e)
        {
            try
            {
                ucImageViewTest.AddImage(Image.FromFile(Application.StartupPath + "\\windows7.jpg"));
            }
            catch (Exception ex)
            {
                //DialogHelper.ShowErrorMsg(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openImgDlg.Filter = "Image Files(*.jpg;*.jpeg;*.tiff;*.gif)|*.jpg;*.gpeg;*.tiff;*.gif|All files (*.*)|*.*";//图片文件的类型
            if (openImgDlg.ShowDialog() == DialogResult.OK)
            {
                string FileName, pathName;
                pathName = openImgDlg.FileName;
                FileName = pathName.Substring(pathName.LastIndexOf('\\'));
                ucImageViewTest.AddImage(Image.FromFile(pathName));
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            ucImageViewTest.ZoomInImage();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            ucImageViewTest.ZoomOutImage();
        }

        private void btnMy_Click(object sender, EventArgs e)
        {
            btnMy.Checked = ucImageViewTest.MnuMoveImageChecked = !btnMy.Checked;
            ucImageViewTest.MoveImage();
        }

        private void btnFitSize_Click(object sender, EventArgs e)
        {
            ucImageViewTest.FitImageSize();
        }

        private void btnLeftRotate_Click(object sender, EventArgs e)
        {
            ucImageViewTest.LeftRotateImage();
        }

        private void btnRightRotate_Click(object sender, EventArgs e)
        {
            ucImageViewTest.RightRotateImage();
        }

        private void ucImageViewTest_OnMnuMoveImageCheckedChanged(object sender, EventArgs e)
        {
            //使ucImageViewDj中的快捷菜单中的漫游的选中状态与当前窗口漫游按钮的选中状态保持一至
            btnMy.Checked = ucImageViewTest.MnuMoveImageChecked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ucImageViewTest.PrintImagePreview();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ucImageViewTest.PrintImage();
        }
    }
}
