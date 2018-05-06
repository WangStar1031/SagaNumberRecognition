using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class InsertTextForm : Form
    {
        public InsertTextForm()
        {
            InitializeComponent();
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

        public string DisplayText
        {
            get { return txtText.Text; }
            set { txtText.Text = value.ToString(); }
        }

        public string DisplayTextFont
        {
            get { return cmbFonts.Text; }
            set { cmbFonts.Text = value.ToString(); }
        }

        public float DisplayTextFontSize
        {
            get
            {
                float fs = 10.0F;
                if (!string.IsNullOrEmpty(cmbFontSize.Text))
                    fs = Convert.ToSingle(cmbFontSize.Text.Replace("pt", ""));
                return fs;
            }
            set { cmbFonts.Text = value.ToString() + "pt"; }
        }

        public string DisplayTextFontStyle
        {
            get { return cmbFontStyles.Text; }
            set { cmbFontStyles.Text = value.ToString(); }
        }

        public string DisplayTextForeColor1
        {
            get { return cmbColors1.Text; }
            set { cmbColors1.Text = value.ToString(); }
        }

        public string DisplayTextForeColor2
        {
            get { return cmbColors2.Text; }
            set { cmbColors2.Text = value.ToString(); }
        }

        private void InsertTextForm_Load(object sender, EventArgs e)
        {
            // Load Fonts.
            foreach (FontFamily ff in FontFamily.Families)
            {
                cmbFonts.Items.Add(ff.Name);
            }
            // Load Font Size.
            for (int i = 5; i <= 75; i += 5)
            {
                cmbFontSize.Items.Add(i.ToString() + "pt");
            }
            // Load Font Styles.
            cmbFontStyles.Items.Add("Bold");
            cmbFontStyles.Items.Add("Italic");
            cmbFontStyles.Items.Add("Regular");
            cmbFontStyles.Items.Add("Strikeout");
            cmbFontStyles.Items.Add("Underline");
            // Load Colors.
            Type type = typeof(System.Drawing.Color);
            System.Reflection.PropertyInfo[] propertyInfo = type.GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                if (propertyInfo[i].Name != "Transparent"
                    && propertyInfo[i].Name != "R"
                    && propertyInfo[i].Name != "G"
                    && propertyInfo[i].Name != "B"
                    && propertyInfo[i].Name != "A"
                    && propertyInfo[i].Name != "IsKnownColor"
                    && propertyInfo[i].Name != "IsEmpty"
                    && propertyInfo[i].Name != "IsNamedColor"
                    && propertyInfo[i].Name != "IsSystemColor"
                    && propertyInfo[i].Name != "Name")
                {
                    cmbColors1.Items.Add(propertyInfo[i].Name);
                    cmbColors2.Items.Add(propertyInfo[i].Name);
                }
            }
        }

        private void GradientCheck_CheckedChanged(object sender, EventArgs e)
        {
            cmbColors2.Enabled = GradientCheck.Checked;
        }
    }
}