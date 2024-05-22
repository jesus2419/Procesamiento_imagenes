using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace procesamiento_de_imagenes
{
    public partial class video : Form
    {
        public video()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterinfocollection;
        //VideoCaptureDevice videoCaptureDevice;
        VideoCaptureDevice videoCaptureDevice = null;

        private void video_Load(object sender, EventArgs e)
        {

            filterinfocollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterinfo in filterinfocollection)
            {
                comboBox2.Items.Add(filterinfo.Name);
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            /*
            pictureBox1.Image = Image.FromFile(@"C:\Users\USER\Pictures\roca.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox2.Image = Image.FromFile(@"C:\Users\USER\Pictures\apoco.gif");
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
            }
            //VideoCaptureDevice_NewFrame
            //videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            //videoCaptureDevice.Start();
            videoCaptureDevice = new VideoCaptureDevice(filterinfocollection[comboBox2.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new MethodInvoker(delegate
                {
                    pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
                }));
            }
            else
            {
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            }
        }

        private void video_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
            {

                videoCaptureDevice.Stop();
                videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame; // Desasociar el evento NewFrame
                videoCaptureDevice = null; // Liberar la instancia de VideoCaptureDevice
                pictureBox1.Image = null; // Limpiar la imagen en el PictureBox
            }
        }
    }
}
