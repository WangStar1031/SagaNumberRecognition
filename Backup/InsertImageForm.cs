using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class InsertImageForm : Form
    {
        OpenFileDialog oDlg;
        public InsertImageForm()
        {
            InitializeComponent();
            oDlg = new OpenFileDialog(); // Open Dialog Initialization
            oDlg.RestoreDirectory = true;
            oDlg.InitialDirectory = "C:\\";
            oDlg.FilterIndex = 1;
            oDlg.Filter = "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public int XPosition
        {
            get 
            {
                if (string.IsNullOrEmpty(txtX.Text))
                    txtX.Text = "0";
                return Convert.ToInt32(txtX.Text); 
            }
            set { txtX.Text = value.ToString(); }
        }

        public int YPosition
        {
            get
            {
                if (string.IsNullOrEmpty(txtY.Text))
                    txtY.Text = "0";
                return Convert.ToInt32(txtY.Text);
            }
            set { txtY.Text = value.ToString(); }
        }

        public string DisplayImagePath
        {
            get { return txtImage.Text; }
            set { txtImage.Text = value.ToString(); }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == oDlg.ShowDialog())
            {
                txtImage.Text = oDlg.FileName;
            }
        }
    }
}