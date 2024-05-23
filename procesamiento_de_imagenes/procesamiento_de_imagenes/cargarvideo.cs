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
using Accord.Video.FFMPEG;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;

namespace procesamiento_de_imagenes
{
    public partial class cargarvideo : Form
    {
        VideoCapture capture = null;
        Image<Bgr, Byte> currentFrame;
        double duracion;
        double FPS;
        bool IsVideoLoad = false;
        string filtro = "";
        Timer timer;
        public cargarvideo()
        {
            InitializeComponent();
        }

        private void cargarvideo_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 1000 / 30; // Aproximadamente 30 FPS
            timer.Tick += new EventHandler(Reproducir);
        }

        private void Btnvideo_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            string formats = "Video Files | *.mp4; ";
            openFileDialog.Filter = formats;
            openFileDialog.Title = "Selecciona un video.";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    capture = new VideoCapture(openFileDialog.FileName);
                    capture.QueryFrame();
                    Mat m = new Mat();
                    capture.Read(m);
                    if (!m.IsEmpty)
                    {
                        currentFrame = m.ToImage<Bgr, byte>();
                        pictureBox1.Image = currentFrame.ToBitmap();
                        duracion = capture.GetCaptureProperty(CapProp.FrameCount);
                        FPS = capture.GetCaptureProperty(CapProp.Fps);
                        IsVideoLoad = true;
                        pictureBox1.BackgroundImage = null;
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar el video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir el video: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_reproducir_Click(object sender, EventArgs e)
        {
            if (IsVideoLoad)
            {
                timer.Start();
                /*DialogResult result = MessageBox.Show("El video se reproducirá indefinidamente.", "Aviso", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    timer.Start();
                } */
            }
            else
            {
                MessageBox.Show("No se ha cargado ningún video.", "Error");
            }
        }


        private void Reproducir(object sender, EventArgs e)
        {
            if (capture != null && capture.Ptr != IntPtr.Zero)
            {
                if (capture.GetCaptureProperty(CapProp.PosFrames) < duracion - 2)
                {
                    Mat m = new Mat();
                    capture.Read(m);

                    if (!m.IsEmpty)
                    {
                        currentFrame = m.ToImage<Bgr, byte>();
                        pictureBox1.Image = currentFrame.ToBitmap();
                    }
                    else
                    {
                        // Si m está vacío y no hay más frames, reiniciar la reproducción
                        capture.SetCaptureProperty(CapProp.PosFrames, 0);
                        timer.Stop();
                        timer.Start();
                    }
                }
                else
                {
                    capture.SetCaptureProperty(CapProp.PosFrames, 0);
                }
            }
        }




        private void invertirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aberracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void colorizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void brilloToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contrasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sobbelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ruidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pixelacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void invertirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (IsVideoLoad)
            {
                // Detener la reproducción actual si está en curso
                if (timer != null && timer.Enabled)
                {
                    timer.Stop();
                }

                Mat m = new Mat();
                int frameCount = (int)duracion; // Número total de frames en el video

                for (int i = 0; i < frameCount; i++)
                {
                    capture.SetCaptureProperty(CapProp.PosFrames, i);

                    capture.Read(m);

                    if (!m.IsEmpty)
                    {
                        Image<Bgr, byte> currentFrame = m.ToImage<Bgr, byte>();

                        // Aplicar filtro de inversión de colores a cada píxel
                        for (int y = 0; y < currentFrame.Height; y++)
                        {
                            for (int x = 0; x < currentFrame.Width; x++)
                            {
                                Bgr originalColor = currentFrame[y, x];
                                Bgr invertedColor = new Bgr(255 - originalColor.Blue,
                                                            255 - originalColor.Green,
                                                            255 - originalColor.Red);
                                currentFrame[y, x] = invertedColor;
                            }
                        }

                        // Mostrar la imagen con el filtro aplicado en pictureBox1
                        pictureBox1.Image = currentFrame.ToBitmap();
                        pictureBox1.Refresh(); // Asegurar que se actualice la imagen en el PictureBox

                        // Pausa para simular la velocidad de reproducción del video
                        System.Threading.Thread.Sleep((int)(1000 / FPS));
                    }
                }

                // Reiniciar la reproducción del video si estaba en curso
                if (timer != null && !timer.Enabled)
                {
                    timer.Start();
                }
            }
            else
            {
                MessageBox.Show("No se ha cargado ningún video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_parar_Click(object sender, EventArgs e)
        {

            if (timer != null && timer.Enabled)
            {
                timer.Stop();
            }
        }

        private void cargarvideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Asegurarse de liberar los recursos al cerrar el formulario
            capture?.Dispose();
            timer?.Stop();
            timer?.Dispose();
        }
    }
}
