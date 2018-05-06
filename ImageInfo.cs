using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageProcessing
{
    public partial class ImageInfo : Form
    {
        ImageHandler imageHandler;
        public ImageInfo(ImageHandler imageHandler)
        {
            this.imageHandler = imageHandler;
            InitializeComponent();
        }

        private void ImageInfo_Load(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(imageHandler.BitmapPath);
            lblImageName.Text = fileInfo.Name.Replace(fileInfo.Extension,"");
            lblImageExtension.Text = fileInfo.Extension;
            string loc = fileInfo.DirectoryName;
            if (loc.Length > 50)
                loc = loc.Substring(0, 15) + "..." + loc.Substring(loc.LastIndexOf("\\"));
            lblImageLocation.Text = loc;
            lblImageDimension.Text = imageHandler.CurrentBitmap.Width + " x " + imageHandler.CurrentBitmap.Height;
            lblImageSize.Text = (fileInfo.Length / 1024.0).ToString("0.0") + " KB";
            lblImageCreatedOn.Text = fileInfo.CreationTime.ToString("dddd MMMM dd, yyyy");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}