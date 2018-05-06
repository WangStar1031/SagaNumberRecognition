using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class GammaForm : Form
    {
        public GammaForm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public double RedComponent
        {
            get 
            {
                if (string.IsNullOrEmpty(txtRedValue.Text))
                    txtRedValue.Text = "0";
                return Convert.ToDouble(txtRedValue.Text); 
            }
            set { txtRedValue.Text = value.ToString(); }
        }

        public double GreenComponent
        {
            get
            {
                if (string.IsNullOrEmpty(txtGreenValue.Text))
                    txtGreenValue.Text = "0";
                return Convert.ToDouble(txtGreenValue.Text);
            }
            set { txtGreenValue.Text = value.ToString(); }
        }

        public double BlueComponent
        {
            get
            {
                if (string.IsNullOrEmpty(txtBlueValue.Text))
                    txtBlueValue.Text = "0";
                return Convert.ToDouble(txtBlueValue.Text);
            }
            set { txtBlueValue.Text = value.ToString(); }
        }
    }
}