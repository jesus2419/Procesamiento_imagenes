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
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace procesamiento_de_imagenes
{
    public partial class foto : Form
    {
        public foto()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterinfocollection;
        VideoCaptureDevice videoCaptureDevice = null;
        CascadeClassifier faceCascade;
        private bool detectFaces = false; // Añadir una bandera para la detección de rostros

        private void foto_Load(object sender, EventArgs e)
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

            // Cargar el clasificador de cascada para la detección de rostros
            string cascadePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascade_frontalface_default.xml");
            if (!System.IO.File.Exists(cascadePath))
            {
                MessageBox.Show("El archivo haarcascade_frontalface_default.xml no se encuentra en el directorio de la aplicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            faceCascade = new CascadeClassifier(cascadePath); // Asegúrate de tener este archivo en tu proyecto
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
            }
            videoCaptureDevice = new VideoCaptureDevice(filterinfocollection[comboBox2.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            if (detectFaces) // Solo detectar rostros si la bandera está activada
            {
                frame = DetectFaces(frame);
            }

            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new MethodInvoker(delegate
                {
                    pictureBox1.Image = frame;
                }));
            }
            else
            {
                pictureBox1.Image = frame;
            }
        }

        private Bitmap DetectFaces(Bitmap frame)
        {
            using (Image<Bgr, byte> imageFrame = new Image<Bgr, byte>(frame))
            {
                try
                {
                    using (Image<Gray, byte> grayFrame = imageFrame.Convert<Gray, byte>())
                    {
                        Rectangle[] faces = faceCascade.DetectMultiScale(grayFrame, 1.1, 10, new Size(20, 20), Size.Empty);
                        Random random = new Random();

                        for (int i = 0; i < faces.Length; i++)
                        {
                            // Generate a random color for each face
                            Bgr color = new Bgr(random.Next(255), random.Next(255), random.Next(255));
                            CvInvoke.Rectangle(imageFrame, faces[i], color.MCvScalar, 2);

                            // Draw the label above the rectangle
                            string label = $"Persona {i + 1}";
                            Point labelPosition = new Point(faces[i].X, faces[i].Y - 10);

                            // Ensure the text is within the image boundaries
                            if (labelPosition.Y < 0)
                            {
                                labelPosition.Y = faces[i].Y + faces[i].Height + 20; // Move text below the face if it's too high
                            }

                            CvInvoke.PutText(imageFrame, label, labelPosition, FontFace.HersheySimplex, 1.0, new MCvScalar(0, 255, 0), 2); // Increased font scale to 1.0
                        }

                        Console.WriteLine($"{faces.Length} rostro(s) detectado(s).");
                    }

                    return imageFrame.ToBitmap();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al detectar rostros: " + ex.Message);
                    return frame;
                }
            }
        }
        private void foto_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void foto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
                videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame; // Desasociar el evento NewFrame
                videoCaptureDevice = null; // Liberar la instancia de VideoCaptureDevice
                pictureBox1.Image = null; // Limpiar la imagen en el PictureBox
            }
        }

        private void BtnFoto_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap capturedImage = new Bitmap(pictureBox1.Image);
                pictureBox2.Image = capturedImage;
            }
        }

        private void btn_detectarRostro_Click(object sender, EventArgs e)
        {
            
            detectFaces = true; // Activar la detección de rostros al hacer clic en el botón
        }

        //Guardar Foto
        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
                saveFileDialog.Title = "Guardar imagen";
                saveFileDialog.FileName = "captura.jpg"; // Nombre por defecto

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Guardar la imagen
                    pictureBox2.Image.Save(saveFileDialog.FileName);
                    MessageBox.Show("Imagen guardada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay imagen para guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
    }
}
