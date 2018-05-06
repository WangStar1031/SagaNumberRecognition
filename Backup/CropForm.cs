using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class CropForm : Form
    {
        public CropForm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public int CropXPosition
        {
            get 
            {
                if (string.IsNullOrEmpty(txtX.Text))
                    txtX.Text = "0";
                return Convert.ToInt32(txtX.Text); 
            }
            set { txtX.Text = value.ToString(); }
        }

        public int CropYPosition
        {
            get
            {
                if (string.IsNullOrEmpty(txtY.Text))
                    txtY.Text = "0";
                return Convert.ToInt32(txtY.Text);
            }
            set { txtY.Text = value.ToString(); }
        }

        public int CropWidth
        {
            get
            {
                if (string.IsNullOrEmpty(txtWidth.Text))
                    txtWidth.Text = "0";
                return Convert.ToInt32(txtWidth.Text);
            }
            set { txtWidth.Text = value.ToString(); }
        }

        public int CropHeight
        {
            get
            {
                if (string.IsNullOrEmpty(txtHeight.Text))
                    txtHeight.Text = "0";
                return Convert.ToInt32(txtHeight.Text);
            }
            set { txtHeight.Text = value.ToString(); }
        }
    }
}