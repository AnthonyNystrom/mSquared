using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SURFFeature
{
    public partial class frmShowKeyPoints : Form
    {
        public frmShowKeyPoints(Bitmap b)
        {
            InitializeComponent();

            pictureBox1.Image = b;
        }
    }
}
