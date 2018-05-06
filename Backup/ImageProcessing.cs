using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class ImageProcessing : Form
    {
        OpenFileDialog oDlg;
        SaveFileDialog sDlg;
        double zoomFactor = 1.0;
        private MenuItem cZoom;
        ImageHandler imageHandler = new ImageHandler();

        public ImageProcessing()
        {
            InitializeComponent();
            oDlg = new OpenFileDialog(); // Open Dialog Initialization
            oDlg.RestoreDirectory = true;
            oDlg.InitialDirectory = "C:\\";
            oDlg.FilterIndex = 1;
            oDlg.Filter = "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";
            /*************************/
            sDlg = new SaveFileDialog(); // Save Dialog Initialization
            sDlg.RestoreDirectory = true;
            sDlg.InitialDirectory = "C:\\";
            sDlg.FilterIndex = 1;
            sDlg.Filter = "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";
            /*************************/
            cZoom = menuItemZoom100; // Current Zoom Percentage = 100%
        }

        private void ImageProcessing_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(imageHandler.CurrentBitmap, new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y, Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor)));
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == oDlg.ShowDialog())
            {
                imageHandler.CurrentBitmap = (Bitmap)Bitmap.FromFile(oDlg.FileName);
                imageHandler.BitmapPath = oDlg.FileName;
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                this.Invalidate();
                menuItemImageInfo.Enabled = true;
                ImageInfo imgInfo = new ImageInfo(imageHandler);
                imgInfo.Show();
            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == sDlg.ShowDialog())
            {
                imageHandler.SaveBitmap(sDlg.FileName);
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemUndo_Click(object sender, EventArgs e)
        {
            imageHandler.ResetBitmap();
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();
        }

        private void menuItemClearImage_Click(object sender, EventArgs e)
        {
            imageHandler.RestorePrevious();
            imageHandler.ClearImage();
            this.Invalidate();
        }

        private void menuItemImageInfo_Click(object sender, EventArgs e)
        {
            ImageInfo imgInfo = new ImageInfo(imageHandler);
            imgInfo.Show();
        }

        private void menuItemZoom50_Click(object sender, EventArgs e)
        {
            zoomFactor = 0.5;
            cZoom.Checked = false;
            menuItemZoom50.Checked = true;
            cZoom = menuItemZoom50;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();
        }

        private void menuItemZoom100_Click(object sender, EventArgs e)
        {
            zoomFactor = 1.0;
            cZoom.Checked = false;
            menuItemZoom100.Checked = true;
            cZoom = menuItemZoom100;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();
        }

        private void menuItemZoom150_Click(object sender, EventArgs e)
        {
            zoomFactor = 1.5;
            cZoom.Checked = false;
            menuItemZoom150.Checked = true;
            cZoom = menuItemZoom150;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();
        }

        private void menuItemZoom200_Click(object sender, EventArgs e)
        {
            zoomFactor = 2.0;
            cZoom.Checked = false;
            menuItemZoom200.Checked = true;
            cZoom = menuItemZoom200;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();

        }

        private void menuItemZoom300_Click(object sender, EventArgs e)
        {
            zoomFactor = 3.0;
            cZoom.Checked = false;
            menuItemZoom300.Checked = true;
            cZoom = menuItemZoom300;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();

        }

        private void menuItemZoom400_Click(object sender, EventArgs e)
        {
            zoomFactor = 4.0;
            cZoom.Checked = false;
            menuItemZoom400.Checked = true;
            cZoom = menuItemZoom400;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();
        }

        private void menuItemZoom500_Click(object sender, EventArgs e)
        {
            zoomFactor = 5.0;
            cZoom.Checked = false;
            menuItemZoom500.Checked = true;
            cZoom = menuItemZoom500;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();
        }

        private void menuItemFilterRed_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            imageHandler.SetColorFilter(ImageHandler.ColorFilterTypes.Red);
            this.Invalidate();
            this.Cursor = Cursors.Default;

        }

        private void menuItemFilterGreen_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            imageHandler.SetColorFilter(ImageHandler.ColorFilterTypes.Green);
            this.Invalidate();
            this.Cursor = Cursors.Default;

        }

        private void menuItemFilterBlue_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            imageHandler.SetColorFilter(ImageHandler.ColorFilterTypes.Blue);
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemGamma_Click(object sender, EventArgs e)
        {
            GammaForm gFrm = new GammaForm();
            gFrm.RedComponent = gFrm.GreenComponent = gFrm.BlueComponent = 0;
            if (gFrm.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.SetGamma(gFrm.RedComponent, gFrm.GreenComponent, gFrm.BlueComponent);
                this.Invalidate();
                this.Cursor = Cursors.Default;
            }
        }

        private void menuItemBrightness_Click(object sender, EventArgs e)
        {
            BrightnessForm bFrm = new BrightnessForm();
            bFrm.BrightnessValue = 0;
            if (bFrm.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.SetBrightness(bFrm.BrightnessValue);
                this.Invalidate();
                this.Cursor = Cursors.Default;
            }
        }

        private void menuItemContrast_Click(object sender, EventArgs e)
        {
            ContrastForm cFrm = new ContrastForm();
            cFrm.ContrastValue = 0;
            if (cFrm.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.SetContrast(cFrm.ContrastValue);
                this.Invalidate();
                this.Cursor = Cursors.Default;
            }
        }

        private void menuItemGrayscale_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            imageHandler.SetGrayscale();
            this.Invalidate();
            this.Cursor = Cursors.Default;

        }

        private void menuItemInvert_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            imageHandler.SetInvert();
            this.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void menuItemResize_Click(object sender, EventArgs e)
        {
            InsertTextForm1 rFrm = new InsertTextForm1();
            rFrm.NewWidth = imageHandler.CurrentBitmap.Width;
            rFrm.NewHeight = imageHandler.CurrentBitmap.Height;
            if (rFrm.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.Resize(rFrm.NewWidth, rFrm.NewHeight);
                this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
                this.Invalidate();
                this.Cursor = Cursors.Default;
            }
        }

        private void menuItemRotate90_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();

        }

        private void menuItemRotate180_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.Rotate180FlipNone);
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();

        }

        private void menuItemRotate270_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();

        }

        private void menuItemFlipH_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.RotateNoneFlipX);
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();

        }

        private void menuItemFlipV_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.RotateNoneFlipY);
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor), Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor));
            this.Invalidate();
        }

        private void menuItemCrop_Click(object sender, EventArgs e)
        {
            CropForm cpFrm = new CropForm();
            cpFrm.CropXPosition = 0;
            cpFrm.CropYPosition = 0;
            cpFrm.CropWidth = imageHandler.CurrentBitmap.Width;
            cpFrm.CropHeight = imageHandler.CurrentBitmap.Height;
            if (cpFrm.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.DrawOutCropArea(cpFrm.CropXPosition, cpFrm.CropYPosition, cpFrm.CropWidth, cpFrm.CropHeight);
                this.Invalidate();
                if (MessageBox.Show("Do u want to crop this area?", "ImageProcessing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    imageHandler.Crop(cpFrm.CropXPosition, cpFrm.CropYPosition, cpFrm.CropWidth, cpFrm.CropHeight);
                }
                else
                {
                    imageHandler.RemoveCropAreaDraw();
                }
                this.Invalidate();
                this.Cursor = Cursors.Default;
            }
        }

        private void menuItemInsertText_Click(object sender, EventArgs e)
        {
            InsertTextForm itFrm = new InsertTextForm();
            itFrm.XPosition = itFrm.YPosition = 0;
            if (itFrm.ShowDialog() == DialogResult.OK)
            {
                imageHandler.RestorePrevious();
                imageHandler.InsertText(itFrm.DisplayText, itFrm.XPosition, itFrm.YPosition, itFrm.DisplayTextFont, itFrm.DisplayTextFontSize, itFrm.DisplayTextFontStyle, itFrm.DisplayTextForeColor1, itFrm.DisplayTextForeColor2);
                this.Invalidate();
            }
        }

        private void menuItemInsertImage_Click(object sender, EventArgs e)
        {
            InsertImageForm iiFrm = new InsertImageForm();
            iiFrm.XPosition = iiFrm.YPosition = 0;
            if (iiFrm.ShowDialog() == DialogResult.OK)
            {
                imageHandler.RestorePrevious();
                imageHandler.InsertImage(iiFrm.DisplayImagePath, iiFrm.XPosition, iiFrm.YPosition);
                this.Invalidate();
            }
        }

        private void menuItemInsertShape_Click(object sender, EventArgs e)
        {
            InsertShapeForm isFrm = new InsertShapeForm();
            isFrm.XPosition = isFrm.YPosition = 0;
            if (isFrm.ShowDialog() == DialogResult.OK)
            {
                imageHandler.RestorePrevious();
                imageHandler.InsertShape(isFrm.ShapeType, isFrm.XPosition, isFrm.YPosition, isFrm.ShapeWidth, isFrm.ShapeHeight, isFrm.ShapeColor);
                this.Invalidate();
            }
        }
    }
}