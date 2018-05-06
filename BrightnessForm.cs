using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class BrightnessForm : Form
    {
        public BrightnessForm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public int BrightnessValue
        {
            get 
            {
                if (string.IsNullOrEmpty(txtBrightnessValue.Text))
                    txtBrightnessValue.Text = "0";
                return Convert.ToInt32(txtBrightnessValue.Text); 
            }
            set { txtBrightnessValue.Text = value.ToString(); }
        }
    }
}