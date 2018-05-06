namespace ImageProcessing
{
    partial class ImageProcessing
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
            this.components = new System.ComponentModel.Container();
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItemSep1 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemUndo = new System.Windows.Forms.MenuItem();
            this.menuItemClearImage = new System.Windows.Forms.MenuItem();
            this.menuItemView = new System.Windows.Forms.MenuItem();
            this.menuItemImageInfo = new System.Windows.Forms.MenuItem();
            this.menuItemSep2 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom = new System.Windows.Forms.MenuItem();
            this.menuItemZoom50 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom100 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom150 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom200 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom300 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom400 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom500 = new System.Windows.Forms.MenuItem();
            this.menuItemColor = new System.Windows.Forms.MenuItem();
            this.menuItemFilter = new System.Windows.Forms.MenuItem();
            this.menuItemFilterRed = new System.Windows.Forms.MenuItem();
            this.menuItemFilterGreen = new System.Windows.Forms.MenuItem();
            this.menuItemFilterBlue = new System.Windows.Forms.MenuItem();
            this.menuItemGamma = new System.Windows.Forms.MenuItem();
            this.menuItemBrightness = new System.Windows.Forms.MenuItem();
            this.menuItemContrast = new System.Windows.Forms.MenuItem();
            this.menuItemGrayscale = new System.Windows.Forms.MenuItem();
            this.menuItemInvert = new System.Windows.Forms.MenuItem();
            this.menuItemImage = new System.Windows.Forms.MenuItem();
            this.menuItemResize = new System.Windows.Forms.MenuItem();
            this.menuItemRotateFlip = new System.Windows.Forms.MenuItem();
            this.menuItemRotate90 = new System.Windows.Forms.MenuItem();
            this.menuItemRotate180 = new System.Windows.Forms.MenuItem();
            this.menuItemRotate270 = new System.Windows.Forms.MenuItem();
            this.menuItemSep3 = new System.Windows.Forms.MenuItem();
            this.menuItemFlipH = new System.Windows.Forms.MenuItem();
            this.menuItemFlipV = new System.Windows.Forms.MenuItem();
            this.menuItemCrop = new System.Windows.Forms.MenuItem();
            this.menuItemInsert = new System.Windows.Forms.MenuItem();
            this.menuItemInsertText = new System.Windows.Forms.MenuItem();
            this.menuItemInsertImage = new System.Windows.Forms.MenuItem();
            this.menuItemInsertShape = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemView,
            this.menuItemColor,
            this.menuItemImage,
            this.menuItemInsert});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpen,
            this.menuItemSave,
            this.menuItemSep1,
            this.menuItemExit});
            this.menuItemFile.Text = "&File";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Index = 0;
            this.menuItemOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItemOpen.Text = "&Open";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Index = 1;
            this.menuItemSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemSep1
            // 
            this.menuItemSep1.Index = 2;
            this.menuItemSep1.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 3;
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemUndo,
            this.menuItemClearImage});
            this.menuItemEdit.Text = "&Edit";
            // 
            // menuItemUndo
            // 
            this.menuItemUndo.Index = 0;
            this.menuItemUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuItemUndo.Text = "&Undo";
            this.menuItemUndo.Click += new System.EventHandler(this.menuItemUndo_Click);
            // 
            // menuItemClearImage
            // 
            this.menuItemClearImage.Index = 1;
            this.menuItemClearImage.Text = "C&lear Image";
            this.menuItemClearImage.Click += new System.EventHandler(this.menuItemClearImage_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.Index = 2;
            this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemImageInfo,
            this.menuItemSep2,
            this.menuItemZoom});
            this.menuItemView.Text = "&View";
            // 
            // menuItemImageInfo
            // 
            this.menuItemImageInfo.Enabled = false;
            this.menuItemImageInfo.Index = 0;
            this.menuItemImageInfo.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
            this.menuItemImageInfo.Text = "I&mage Info.";
            this.menuItemImageInfo.Click += new System.EventHandler(this.menuItemImageInfo_Click);
            // 
            // menuItemSep2
            // 
            this.menuItemSep2.Index = 1;
            this.menuItemSep2.Text = "-";
            // 
            // menuItemZoom
            // 
            this.menuItemZoom.Index = 2;
            this.menuItemZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemZoom50,
            this.menuItemZoom100,
            this.menuItemZoom150,
            this.menuItemZoom200,
            this.menuItemZoom300,
            this.menuItemZoom400,
            this.menuItemZoom500});
            this.menuItemZoom.Text = "&Zoom";
            // 
            // menuItemZoom50
            // 
            this.menuItemZoom50.Index = 0;
            this.menuItemZoom50.Text = "50%";
            this.menuItemZoom50.Click += new System.EventHandler(this.menuItemZoom50_Click);
            // 
            // menuItemZoom100
            // 
            this.menuItemZoom100.Checked = true;
            this.menuItemZoom100.Index = 1;
            this.menuItemZoom100.Text = "100%";
            this.menuItemZoom100.Click += new System.EventHandler(this.menuItemZoom100_Click);
            // 
            // menuItemZoom150
            // 
            this.menuItemZoom150.Index = 2;
            this.menuItemZoom150.Text = "150%";
            this.menuItemZoom150.Click += new System.EventHandler(this.menuItemZoom150_Click);
            // 
            // menuItemZoom200
            // 
            this.menuItemZoom200.Index = 3;
            this.menuItemZoom200.Text = "200%";
            this.menuItemZoom200.Click += new System.EventHandler(this.menuItemZoom200_Click);
            // 
            // menuItemZoom300
            // 
            this.menuItemZoom300.Index = 4;
            this.menuItemZoom300.Text = "300%";
            this.menuItemZoom300.Click += new System.EventHandler(this.menuItemZoom300_Click);
            // 
            // menuItemZoom400
            // 
            this.menuItemZoom400.Index = 5;
            this.menuItemZoom400.Text = "400%";
            this.menuItemZoom400.Click += new System.EventHandler(this.menuItemZoom400_Click);
            // 
            // menuItemZoom500
            // 
            this.menuItemZoom500.Index = 6;
            this.menuItemZoom500.Text = "500%";
            this.menuItemZoom500.Click += new System.EventHandler(this.menuItemZoom500_Click);
            // 
            // menuItemColor
            // 
            this.menuItemColor.Index = 3;
            this.menuItemColor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFilter,
            this.menuItemGamma,
            this.menuItemBrightness,
            this.menuItemContrast,
            this.menuItemGrayscale,
            this.menuItemInvert});
            this.menuItemColor.Text = "&Color";
            // 
            // menuItemFilter
            // 
            this.menuItemFilter.Index = 0;
            this.menuItemFilter.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFilterRed,
            this.menuItemFilterGreen,
            this.menuItemFilterBlue});
            this.menuItemFilter.Text = "&Filter";
            // 
            // menuItemFilterRed
            // 
            this.menuItemFilterRed.Index = 0;
            this.menuItemFilterRed.Text = "&Red Filter";
            this.menuItemFilterRed.Click += new System.EventHandler(this.menuItemFilterRed_Click);
            // 
            // menuItemFilterGreen
            // 
            this.menuItemFilterGreen.Index = 1;
            this.menuItemFilterGreen.Text = "&Green Filter";
            this.menuItemFilterGreen.Click += new System.EventHandler(this.menuItemFilterGreen_Click);
            // 
            // menuItemFilterBlue
            // 
            this.menuItemFilterBlue.Index = 2;
            this.menuItemFilterBlue.Text = "&Blue Filter";
            this.menuItemFilterBlue.Click += new System.EventHandler(this.menuItemFilterBlue_Click);
            // 
            // menuItemGamma
            // 
            this.menuItemGamma.Index = 1;
            this.menuItemGamma.Text = "&Gamma";
            this.menuItemGamma.Click += new System.EventHandler(this.menuItemGamma_Click);
            // 
            // menuItemBrightness
            // 
            this.menuItemBrightness.Index = 2;
            this.menuItemBrightness.Text = "&Brightness";
            this.menuItemBrightness.Click += new System.EventHandler(this.menuItemBrightness_Click);
            // 
            // menuItemContrast
            // 
            this.menuItemContrast.Index = 3;
            this.menuItemContrast.Text = "Con&trast";
            this.menuItemContrast.Click += new System.EventHandler(this.menuItemContrast_Click);
            // 
            // menuItemGrayscale
            // 
            this.menuItemGrayscale.Index = 4;
            this.menuItemGrayscale.Text = "&Grayscale";
            this.menuItemGrayscale.Click += new System.EventHandler(this.menuItemGrayscale_Click);
            // 
            // menuItemInvert
            // 
            this.menuItemInvert.Index = 5;
            this.menuItemInvert.Text = "&Invert";
            this.menuItemInvert.Click += new System.EventHandler(this.menuItemInvert_Click);
            // 
            // menuItemImage
            // 
            this.menuItemImage.Index = 4;
            this.menuItemImage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemResize,
            this.menuItemRotateFlip,
            this.menuItemCrop});
            this.menuItemImage.Text = "&Image";
            // 
            // menuItemResize
            // 
            this.menuItemResize.Index = 0;
            this.menuItemResize.Text = "&Resize";
            this.menuItemResize.Click += new System.EventHandler(this.menuItemResize_Click);
            // 
            // menuItemRotateFlip
            // 
            this.menuItemRotateFlip.Index = 1;
            this.menuItemRotateFlip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemRotate90,
            this.menuItemRotate180,
            this.menuItemRotate270,
            this.menuItemSep3,
            this.menuItemFlipH,
            this.menuItemFlipV});
            this.menuItemRotateFlip.Text = "Ro&tate && Flip";
            // 
            // menuItemRotate90
            // 
            this.menuItemRotate90.Index = 0;
            this.menuItemRotate90.Text = "Rotate &90";
            this.menuItemRotate90.Click += new System.EventHandler(this.menuItemRotate90_Click);
            // 
            // menuItemRotate180
            // 
            this.menuItemRotate180.Index = 1;
            this.menuItemRotate180.Text = "Rotate &180";
            this.menuItemRotate180.Click += new System.EventHandler(this.menuItemRotate180_Click);
            // 
            // menuItemRotate270
            // 
            this.menuItemRotate270.Index = 2;
            this.menuItemRotate270.Text = "Rotate &270";
            this.menuItemRotate270.Click += new System.EventHandler(this.menuItemRotate270_Click);
            // 
            // menuItemSep3
            // 
            this.menuItemSep3.Index = 3;
            this.menuItemSep3.Text = "-";
            // 
            // menuItemFlipH
            // 
            this.menuItemFlipH.Index = 4;
            this.menuItemFlipH.Text = "Flip &Horizontal";
            this.menuItemFlipH.Click += new System.EventHandler(this.menuItemFlipH_Click);
            // 
            // menuItemFlipV
            // 
            this.menuItemFlipV.Index = 5;
            this.menuItemFlipV.Text = "Flip &Vertical";
            this.menuItemFlipV.Click += new System.EventHandler(this.menuItemFlipV_Click);
            // 
            // menuItemCrop
            // 
            this.menuItemCrop.Index = 2;
            this.menuItemCrop.Text = "Cro&p";
            this.menuItemCrop.Click += new System.EventHandler(this.menuItemCrop_Click);
            // 
            // menuItemInsert
            // 
            this.menuItemInsert.Index = 5;
            this.menuItemInsert.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemInsertText,
            this.menuItemInsertImage,
            this.menuItemInsertShape});
            this.menuItemInsert.Text = "In&sert";
            // 
            // menuItemInsertText
            // 
            this.menuItemInsertText.Index = 0;
            this.menuItemInsertText.Text = "&Text";
            this.menuItemInsertText.Click += new System.EventHandler(this.menuItemInsertText_Click);
            // 
            // menuItemInsertImage
            // 
            this.menuItemInsertImage.Index = 1;
            this.menuItemInsertImage.Text = "&Image";
            this.menuItemInsertImage.Click += new System.EventHandler(this.menuItemInsertImage_Click);
            // 
            // menuItemInsertShape
            // 
            this.menuItemInsertShape.Index = 2;
            this.menuItemInsertShape.Text = "&Shape";
            this.menuItemInsertShape.Click += new System.EventHandler(this.menuItemInsertShape_Click);
            // 
            // ImageProcessing
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(764, 509);
            this.Menu = this.MainMenu1;
            this.Name = "ImageProcessing";
            this.Text = "Image Processing";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageProcessing_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu MainMenu1;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemOpen;
        private System.Windows.Forms.MenuItem menuItemSave;
        private System.Windows.Forms.MenuItem menuItemSep1;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemEdit;
        private System.Windows.Forms.MenuItem menuItemUndo;
        private System.Windows.Forms.MenuItem menuItemClearImage;
        private System.Windows.Forms.MenuItem menuItemView;
        private System.Windows.Forms.MenuItem menuItemImageInfo;
        private System.Windows.Forms.MenuItem menuItemSep2;
        private System.Windows.Forms.MenuItem menuItemZoom;
        private System.Windows.Forms.MenuItem menuItemZoom50;
        private System.Windows.Forms.MenuItem menuItemZoom100;
        private System.Windows.Forms.MenuItem menuItemZoom150;
        private System.Windows.Forms.MenuItem menuItemZoom200;
        private System.Windows.Forms.MenuItem menuItemZoom300;
        private System.Windows.Forms.MenuItem menuItemZoom400;
        private System.Windows.Forms.MenuItem menuItemZoom500;
        private System.Windows.Forms.MenuItem menuItemColor;
        private System.Windows.Forms.MenuItem menuItemFilter;
        private System.Windows.Forms.MenuItem menuItemFilterRed;
        private System.Windows.Forms.MenuItem menuItemFilterGreen;
        private System.Windows.Forms.MenuItem menuItemFilterBlue;
        private System.Windows.Forms.MenuItem menuItemGamma;
        private System.Windows.Forms.MenuItem menuItemBrightness;
        private System.Windows.Forms.MenuItem menuItemContrast;
        private System.Windows.Forms.MenuItem menuItemGrayscale;
        private System.Windows.Forms.MenuItem menuItemInvert;
        private System.Windows.Forms.MenuItem menuItemImage;
        private System.Windows.Forms.MenuItem menuItemResize;
        private System.Windows.Forms.MenuItem menuItemRotateFlip;
        private System.Windows.Forms.MenuItem menuItemRotate90;
        private System.Windows.Forms.MenuItem menuItemRotate180;
        private System.Windows.Forms.MenuItem menuItemRotate270;
        private System.Windows.Forms.MenuItem menuItemSep3;
        private System.Windows.Forms.MenuItem menuItemFlipH;
        private System.Windows.Forms.MenuItem menuItemFlipV;
        private System.Windows.Forms.MenuItem menuItemCrop;
        private System.Windows.Forms.MenuItem menuItemInsert;
        private System.Windows.Forms.MenuItem menuItemInsertText;
        private System.Windows.Forms.MenuItem menuItemInsertImage;
        private System.Windows.Forms.MenuItem menuItemInsertShape;
    }
}

