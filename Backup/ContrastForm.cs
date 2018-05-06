using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class ContrastForm : Form
    {
        public ContrastForm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public double ContrastValue
        {
            get
            {
                if (string.IsNullOrEmpty(txtContrastValue.Text))
                    txtContrastValue.Text = "0";
                return Convert.ToDouble(txtContrastValue.Text);
            }
            set { txtContrastValue.Text = value.ToString(); }
        }
    }
}