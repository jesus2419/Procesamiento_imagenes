using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace procesamiento_de_imagenes
{
    public partial class cargarvideo : Form
    {
        public cargarvideo()
        {
            InitializeComponent();
        }

        private void cargarvideo_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"C:\Users\USER\Pictures\apoco.gif");
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
