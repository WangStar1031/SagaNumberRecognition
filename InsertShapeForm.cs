using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class InsertShapeForm : Form
    {
        public InsertShapeForm()
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

        public int ShapeWidth
        {
            get
            {
                if (string.IsNullOrEmpty(txtWidth.Text))
                    txtWidth.Text = "0";
                return Convert.ToInt32(txtWidth.Text);
            }
            set { txtWidth.Text = value.ToString(); }
        }

        public int ShapeHeight
        {
            get
            {
                if (string.IsNullOrEmpty(txtHeight.Text))
                    txtHeight.Text = "0";
                return Convert.ToInt32(txtHeight.Text);
            }
            set { txtHeight.Text = value.ToString(); }
        }

        public string ShapeType
        {
            get { return cmbShapes.Text; }
            set { cmbShapes.Text = value.ToString(); }
        }

        public string ShapeColor
        {
            get { return cmbColors.Text; }
            set { cmbColors.Text = value.ToString(); }
        }

        private void InsertShapeForm_Load(object sender, EventArgs e)
        {
            // Load Shapes.
            cmbShapes.Items.Add("FilledEllipse");
            cmbShapes.Items.Add("FilledRectangle");
            cmbShapes.Items.Add("Ellipse");
            cmbShapes.Items.Add("Rectangle");
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
                    cmbColors.Items.Add(propertyInfo[i].Name);
                }
            }
        }
    }
}