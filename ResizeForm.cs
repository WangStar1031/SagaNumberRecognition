using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class InsertTextForm1 : Form
    {
        public InsertTextForm1()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public int NewWidth
        {
            get
            {
                if (string.IsNullOrEmpty(txtWidth.Text))
                    txtWidth.Text = "0";
                return Convert.ToInt32(txtWidth.Text);
            }
            set { txtWidth.Text = value.ToString(); }
        }

        public int NewHeight
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