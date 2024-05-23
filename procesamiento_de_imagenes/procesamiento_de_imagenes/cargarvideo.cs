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
using Emgu.CV.UI;
using System.Diagnostics;
using AForge.Controls;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms.DataVisualization.Charting;

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

                        UpdateHistogram(currentFrame.Bitmap);
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

        private void aberracionToolStripMenuItem_Click_1(object sender, EventArgs e)
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

                        // Aplicar filtro de aberración de color a cada píxel
                        Image<Bgr, byte> aberrationFrame = currentFrame.Clone();
                        int shiftAmount = 10; // Cantidad de desplazamiento para los canales de color

                        for (int y = 0; y < currentFrame.Height; y++)
                        {
                            for (int x = 0; x < currentFrame.Width; x++)
                            {
                                Bgr originalColor = currentFrame[y, x];

                                int redX = x + shiftAmount < currentFrame.Width ? x + shiftAmount : x;
                                int greenY = y + shiftAmount < currentFrame.Height ? y + shiftAmount : y;
                                int blueX = x - shiftAmount >= 0 ? x - shiftAmount : x;

                                Bgr redColor = currentFrame[y, redX];
                                Bgr greenColor = currentFrame[greenY, x];
                                Bgr blueColor = currentFrame[y, blueX];

                                Bgr aberrationColor = new Bgr(redColor.Blue, greenColor.Green, blueColor.Red);
                                aberrationFrame[y, x] = aberrationColor;
                            }
                        }

                        // Mostrar la imagen con el filtro aplicado en pictureBox1
                        pictureBox1.Image = aberrationFrame.ToBitmap();
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

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (IsVideoLoad)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Video Files (*.mp4)|*.mp4|All files (*.*)|*.*";
                saveFileDialog.Title = "Guardar video";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    VideoWriter writer = new VideoWriter(saveFileDialog.FileName, VideoWriter.Fourcc('H', '2', '6', '4'), (int)FPS, new System.Drawing.Size(pictureBox1.Width, pictureBox1.Height), true);

                    Mat m = new Mat();
                    int frameCount = (int)duracion; // Número total de frames en el video

                    for (int i = 0; i < frameCount; i++)
                    {
                        capture.SetCaptureProperty(CapProp.PosFrames, i);

                        capture.Read(m);

                        if (!m.IsEmpty)
                        {
                            Image<Bgr, byte> currentFrame = m.ToImage<Bgr, byte>();

                            // Aplicar filtro u operaciones de procesamiento de video si es necesario
                            // En este ejemplo, guardamos el frame tal como está sin modificar
                            writer.Write(currentFrame.Mat);
                        }
                    }

                    writer.Dispose();
                    MessageBox.Show("Video guardado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cargar y reproducir automáticamente el video guardado
                    try
                    {
                        Process.Start(saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al intentar reproducir el video guardado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha cargado ningún video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void colorizarToolStripMenuItem_Click(object sender, EventArgs e)
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

                        // Aplicar filtro de colorización a cada píxel
                        Image<Bgr, byte> colorizedFrame = currentFrame.Clone();

                        for (int y = 0; y < currentFrame.Height; y++)
                        {
                            for (int x = 0; x < currentFrame.Width; x++)
                            {
                                Bgr originalColor = currentFrame[y, x];

                                // Convertir a escala de grises
                                int gray = (int)(originalColor.Red * 0.299 + originalColor.Green * 0.587 + originalColor.Blue * 0.114);

                                // Aplicar el color amarillo
                                int red = (int)(gray * 1.0);     // Amarillo: R = G = 255, B = 0
                                int green = (int)(gray * 1.0);
                                int blue = 0;

                                // Asegurarse de que los valores estén en el rango válido (0-255)
                                red = Math.Max(0, Math.Min(255, red));
                                green = Math.Max(0, Math.Min(255, green));
                                blue = Math.Max(0, Math.Min(255, blue));

                                Bgr colorizedBgr = new Bgr(blue, green, red); // Se invierten los canales para color amarillo
                                colorizedFrame[y, x] = colorizedBgr;
                            }
                        }

                        // Mostrar la imagen colorizada en pictureBox1
                        pictureBox1.Image = colorizedFrame.ToBitmap();
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

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Ingrese el valor de gamma";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;

                var numericUpDown = new NumericUpDown();
                numericUpDown.Minimum = 0.1M;   // Valor mínimo permitido
                numericUpDown.Maximum = 5.0M;   // Valor máximo permitido
                numericUpDown.DecimalPlaces = 2;
                numericUpDown.Value = 1.0M;     // Valor inicial
                numericUpDown.Width = 120;
                numericUpDown.TextAlign = HorizontalAlignment.Center;

                var okButton = new Button();
                okButton.Text = "Aceptar";
                okButton.DialogResult = DialogResult.OK;
                okButton.Width = 80;

                var cancelButton = new Button();
                cancelButton.Text = "Cancelar";
                cancelButton.DialogResult = DialogResult.Cancel;
                cancelButton.Width = 80;

                form.Controls.AddRange(new Control[] { numericUpDown, okButton, cancelButton });

                // Posicionar controles
                numericUpDown.Location = new Point((form.Width - numericUpDown.Width) / 2, 20);
                okButton.Location = new Point((form.Width - 200) / 2, 60);
                cancelButton.Location = new Point((form.Width + 40), 60);

                // Mostrar el cuadro de diálogo
                var result = form.ShowDialog();

                // Procesar el valor de gamma si el usuario hizo clic en Aceptar
                if (result == DialogResult.OK)
                {
                    ApplyGammaFilter((double)numericUpDown.Value);
                }
            }

        }

        private void ApplyGammaFilter(double gammaValue)
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

                        // Aplicar filtro gamma a cada píxel del frame
                        Image<Bgr, byte> gammaFrame = currentFrame.Clone();

                        for (int y = 0; y < currentFrame.Height; y++)
                        {
                            for (int x = 0; x < currentFrame.Width; x++)
                            {
                                Bgr originalColor = currentFrame[y, x];

                                double red = 255.0 * Math.Pow(originalColor.Red / 255.0, gammaValue);
                                double green = 255.0 * Math.Pow(originalColor.Green / 255.0, gammaValue);
                                double blue = 255.0 * Math.Pow(originalColor.Blue / 255.0, gammaValue);

                                // Asegurarse de que los valores estén en el rango válido (0-255)
                                int redInt = Math.Max(0, Math.Min(255, (int)red));
                                int greenInt = Math.Max(0, Math.Min(255, (int)green));
                                int blueInt = Math.Max(0, Math.Min(255, (int)blue));

                                Bgr gammaColor = new Bgr(blueInt, greenInt, redInt); // Invertir los canales para gamma
                                gammaFrame[y, x] = gammaColor;
                            }
                        }

                        // Mostrar la imagen gamma en pictureBox1
                        pictureBox1.Image = gammaFrame.ToBitmap();
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

        private void brilloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear un formulario para ajustar el brillo
            using (var form = new Form())
            {
                form.Text = "Ajustar Brillo";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;

                var numericUpDown = new NumericUpDown();
                numericUpDown.Minimum = -255;   // Valor mínimo permitido (brillo mínimo)
                numericUpDown.Maximum = 255;    // Valor máximo permitido (brillo máximo)
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Value = 0;        // Valor inicial
                numericUpDown.Width = 120;
                numericUpDown.TextAlign = HorizontalAlignment.Center;

                var okButton = new Button();
                okButton.Text = "Aceptar";
                okButton.DialogResult = DialogResult.OK;
                okButton.Width = 80;

                var cancelButton = new Button();
                cancelButton.Text = "Cancelar";
                cancelButton.DialogResult = DialogResult.Cancel;
                cancelButton.Width = 80;

                form.Controls.AddRange(new Control[] { numericUpDown, okButton, cancelButton });

                // Posicionar controles
                numericUpDown.Location = new Point((form.Width - numericUpDown.Width) / 2, 20);
                okButton.Location = new Point((form.Width - 200) / 2, 60);
                cancelButton.Location = new Point((form.Width + 40), 60);

                // Mostrar el cuadro de diálogo
                var result = form.ShowDialog();

                // Procesar el valor de brillo si el usuario hizo clic en Aceptar
                if (result == DialogResult.OK)
                {
                    ApplyBrightnessAdjustment((int)numericUpDown.Value);
                }
            }
        }

        private void ApplyBrightnessAdjustment(int brightnessValue)
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

                        // Aplicar ajuste de brillo a cada píxel del frame
                        Image<Bgr, byte> brightnessFrame = currentFrame.Clone();

                        for (int y = 0; y < currentFrame.Height; y++)
                        {
                            for (int x = 0; x < currentFrame.Width; x++)
                            {
                                Bgr originalColor = currentFrame[y, x];

                                int red = (int)(originalColor.Red + brightnessValue);
                                int green = (int)(originalColor.Green + brightnessValue);
                                int blue = (int)(originalColor.Blue + brightnessValue);

                                // Asegurarse de que los valores estén en el rango válido (0-255)
                                red = Math.Max(0, Math.Min(255, red));
                                green = Math.Max(0, Math.Min(255, green));
                                blue = Math.Max(0, Math.Min(255, blue));

                                Bgr adjustedColor = new Bgr(blue, green, red); // Invertir los canales para ajuste de brillo
                                brightnessFrame[y, x] = adjustedColor;
                            }
                        }

                        // Mostrar la imagen con ajuste de brillo en pictureBox1
                        pictureBox1.Image = brightnessFrame.ToBitmap();
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

        private void contrasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear un formulario para ajustar el contraste
            using (var form = new Form())
            {
                form.Text = "Ajustar Contraste";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;

                var numericUpDown = new NumericUpDown();
                numericUpDown.Minimum = -100;   // Valor mínimo permitido (contraste mínimo)
                numericUpDown.Maximum = 100;    // Valor máximo permitido (contraste máximo)
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Value = 0;        // Valor inicial
                numericUpDown.Width = 120;
                numericUpDown.TextAlign = HorizontalAlignment.Center;

                var okButton = new Button();
                okButton.Text = "Aceptar";
                okButton.DialogResult = DialogResult.OK;
                okButton.Width = 80;

                var cancelButton = new Button();
                cancelButton.Text = "Cancelar";
                cancelButton.DialogResult = DialogResult.Cancel;
                cancelButton.Width = 80;

                form.Controls.AddRange(new Control[] { numericUpDown, okButton, cancelButton });

                // Posicionar controles
                numericUpDown.Location = new Point((form.Width - numericUpDown.Width) / 2, 20);
                okButton.Location = new Point((form.Width - 200) / 2, 60);
                cancelButton.Location = new Point((form.Width + 40), 60);

                // Mostrar el cuadro de diálogo
                var result = form.ShowDialog();

                // Procesar el valor de contraste si el usuario hizo clic en Aceptar
                if (result == DialogResult.OK)
                {
                    ApplyContrastAdjustment((int)numericUpDown.Value);
                }
            }
        }

        private void ApplyContrastAdjustment(int contrastValue)
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

                        // Aplicar ajuste de contraste a cada píxel del frame
                        Image<Bgr, byte> contrastFrame = currentFrame.Clone();

                        double contrastLevel = Math.Pow((100.0 + contrastValue) / 100.0, 2);

                        for (int y = 0; y < currentFrame.Height; y++)
                        {
                            for (int x = 0; x < currentFrame.Width; x++)
                            {
                                Bgr originalColor = currentFrame[y, x];

                                double red = (((originalColor.Red / 255.0 - 0.5) * contrastLevel + 0.5) * 255.0);
                                double green = (((originalColor.Green / 255.0 - 0.5) * contrastLevel + 0.5) * 255.0);
                                double blue = (((originalColor.Blue / 255.0 - 0.5) * contrastLevel + 0.5) * 255.0);

                                // Asegurarse de que los valores estén en el rango válido (0-255)
                                red = Math.Max(0, Math.Min(255, red));
                                green = Math.Max(0, Math.Min(255, green));
                                blue = Math.Max(0, Math.Min(255, blue));

                                Bgr adjustedColor = new Bgr((byte)blue, (byte)green, (byte)red); // Invertir los canales para ajuste de contraste
                                contrastFrame[y, x] = adjustedColor;
                            }
                        }

                        // Mostrar la imagen con ajuste de contraste en pictureBox1
                        pictureBox1.Image = contrastFrame.ToBitmap();
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

        private void sobbelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplySobelFilter();

        }

        private void ApplySobelFilter()
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
                int currentFrameIndex = 0;

                // Crear un temporizador para manejar la actualización del frame
                System.Windows.Forms.Timer frameTimer = new System.Windows.Forms.Timer();
                frameTimer.Interval = (int)(1000 / FPS);
                frameTimer.Tick += (sender, e) =>
                {
                    // Leer el siguiente frame
                    capture.SetCaptureProperty(CapProp.PosFrames, currentFrameIndex);
                    capture.Read(m);

                    if (!m.IsEmpty)
                    {
                        Image<Bgr, byte> currentFrame = m.ToImage<Bgr, byte>();

                        // Convertir el frame a escala de grises
                        Bitmap grayBitmap = GrayscaleImage(currentFrame.ToBitmap());
                        Bitmap bitmap = new Bitmap(grayBitmap);

                        int width = bitmap.Width;
                        int height = bitmap.Height;

                        // Matrices de Sobel
                        int[,] sobelHorizontal = new int[,]
                        {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                        };

                        int[,] sobelVertical = new int[,]
                        {
                    { 1, 2, 1 },
                    { 0, 0, 0 },
                    { -1, -2, -1 }
                        };

                        // Aplicar Sobel horizontal
                        Bitmap sobelHorizontalBitmap = ApplyConvolution(bitmap, sobelHorizontal);
                        // Aplicar Sobel vertical
                        Bitmap sobelVerticalBitmap = ApplyConvolution(bitmap, sobelVertical);

                        // Combinar los resultados de Sobel horizontal y vertical
                        Bitmap resultBitmap = CombineSobelImages(sobelHorizontalBitmap, sobelVerticalBitmap);

                        // Mostrar la imagen con filtro Sobel en pictureBox1
                        pictureBox1.Image = resultBitmap;
                        pictureBox1.Refresh();

                        // Incrementar el índice del frame
                        currentFrameIndex++;
                    }

                    // Verificar si se han procesado todos los frames
                    if (currentFrameIndex >= frameCount)
                    {
                        frameTimer.Stop();

                        // Reiniciar la reproducción del video si estaba en curso
                        if (timer != null && !timer.Enabled)
                        {
                            timer.Start();
                        }
                    }
                };

                // Iniciar el temporizador para procesar los frames
                frameTimer.Start();
            }
            else
            {
                MessageBox.Show("No se ha cargado ningún video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap GrayscaleImage(Bitmap original)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    Color newColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    newBitmap.SetPixel(x, y, newColor);
                }
            }

            return newBitmap;
        }

        private Bitmap ApplyConvolution(Bitmap original, int[,] kernel)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            int kernelSize = kernel.GetLength(0) / 2;

            for (int y = kernelSize; y < original.Height - kernelSize; y++)
            {
                for (int x = kernelSize; x < original.Width - kernelSize; x++)
                {
                    int grayValueX = 0;
                    int grayValueY = 0;

                    for (int i = -kernelSize; i <= kernelSize; i++)
                    {
                        for (int j = -kernelSize; j <= kernelSize; j++)
                        {
                            Color pixel = original.GetPixel(x + j, y + i);
                            int value = pixel.R;
                            grayValueX += kernel[j + kernelSize, i + kernelSize] * value;
                            grayValueY += kernel[i + kernelSize, j + kernelSize] * value;
                        }
                    }

                    int grayValue = (int)Math.Sqrt(grayValueX * grayValueX + grayValueY * grayValueY);
                    grayValue = Math.Min(Math.Max(grayValue, 0), 255);
                    Color newColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    newBitmap.SetPixel(x, y, newColor);
                }
            }

            return newBitmap;
        }

        private Bitmap CombineSobelImages(Bitmap horizontal, Bitmap vertical)
        {
            Bitmap resultBitmap = new Bitmap(horizontal.Width, horizontal.Height);

            for (int y = 0; y < horizontal.Height; y++)
            {
                for (int x = 0; x < horizontal.Width; x++)
                {
                    Color colorHorizontal = horizontal.GetPixel(x, y);
                    Color colorVertical = vertical.GetPixel(x, y);
                    int grayValue = (int)Math.Sqrt(colorHorizontal.R * colorHorizontal.R + colorVertical.R * colorVertical.R);
                    grayValue = Math.Min(Math.Max(grayValue, 0), 255);
                    Color newColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    resultBitmap.SetPixel(x, y, newColor);
                }
            }

            return resultBitmap;
        }

        private void ruidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyNoiseFilter();
        }

        private void ApplyNoiseFilter()
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

                Random random = new Random();
                int noiseIntensity = 50; // Intensidad del ruido (ajustable según tus necesidades)

                // Crear un VideoWriter para guardar el video con ruido
                string tempVideoPath = Path.Combine(Path.GetTempPath(), "video_con_ruido.mp4");
                VideoWriter writer = new VideoWriter(tempVideoPath, VideoWriter.Fourcc('X', '2', '6', '4'), FPS, new Size(capture.Width, capture.Height), true);

                for (int i = 0; i < frameCount; i++)
                {
                    capture.SetCaptureProperty(CapProp.PosFrames, i);

                    capture.Read(m);

                    if (!m.IsEmpty)
                    {
                        Image<Bgr, byte> currentFrame = m.ToImage<Bgr, byte>();
                        Bitmap bitmap = currentFrame.ToBitmap();

                        // Aplicar ruido a cada píxel de la imagen
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            for (int x = 0; x < bitmap.Width; x++)
                            {
                                Color originalColor = bitmap.GetPixel(x, y);

                                // Generar un valor aleatorio de ruido para cada canal de color
                                int r = originalColor.R + random.Next(-noiseIntensity, noiseIntensity + 1);
                                int g = originalColor.G + random.Next(-noiseIntensity, noiseIntensity + 1);
                                int b = originalColor.B + random.Next(-noiseIntensity, noiseIntensity + 1);

                                // Asegurarse de que los valores estén en el rango válido (0-255)
                                r = Math.Max(0, Math.Min(255, r));
                                g = Math.Max(0, Math.Min(255, g));
                                b = Math.Max(0, Math.Min(255, b));

                                Color noisyColor = Color.FromArgb(originalColor.A, r, g, b);
                                bitmap.SetPixel(x, y, noisyColor);
                            }
                        }

                        // Mostrar la imagen con ruido en pictureBox1
                        pictureBox1.Image = bitmap;
                        pictureBox1.Refresh();

                        // Escribir el frame con ruido al archivo de video
                        writer.Write(currentFrame.Mat);

                        // Pausa para simular la velocidad de reproducción del video
                        System.Threading.Thread.Sleep((int)(1000 / FPS));
                    }
                }

                // Liberar recursos del writer
                writer.Dispose();

                // Reiniciar la reproducción del video si estaba en curso
                if (timer != null && !timer.Enabled)
                {
                    timer.Start();
                }

                // Mostrar mensaje de éxito
                MessageBox.Show("Filtro de ruido aplicado correctamente al video.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se ha cargado ningún video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pixelacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyPixelationFilter();
        }


        private void ApplyPixelationFilter()
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

                        // Convertir el frame a Bitmap
                        Bitmap bitmap = currentFrame.ToBitmap();

                        // Aplicar el filtro de pixelación
                        bitmap = ApplyPixelation(bitmap);

                        // Mostrar la imagen pixelada en pictureBox1
                        pictureBox1.Image = bitmap;
                        pictureBox1.Refresh();

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
                MessageBox.Show("No se ha cargado ningún video o imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap ApplyPixelation(Bitmap original)
        {
            Bitmap bitmap = new Bitmap(original);

            // Tamaño de los bloques para la pixelación (ajustable según tus necesidades)
            int blockSize = 10;

            // Dimensiones de la imagen
            int width = bitmap.Width;
            int height = bitmap.Height;

            // Pixelar la imagen
            for (int y = 0; y < height; y += blockSize)
            {
                for (int x = 0; x < width; x += blockSize)
                {
                    int avgR = 0, avgG = 0, avgB = 0;

                    // Calcular el promedio de color para el bloque
                    for (int i = 0; i < blockSize; i++)
                    {
                        for (int j = 0; j < blockSize; j++)
                        {
                            int pixelX = x + i;
                            int pixelY = y + j;

                            if (pixelX < width && pixelY < height)
                            {
                                Color pixel = bitmap.GetPixel(pixelX, pixelY);
                                avgR += pixel.R;
                                avgG += pixel.G;
                                avgB += pixel.B;
                            }
                        }
                    }

                    // Promedio de colores del bloque
                    avgR /= blockSize * blockSize;
                    avgG /= blockSize * blockSize;
                    avgB /= blockSize * blockSize;

                    // Rellenar el bloque con el color promedio
                    for (int i = 0; i < blockSize; i++)
                    {
                        for (int j = 0; j < blockSize; j++)
                        {
                            int pixelX = x + i;
                            int pixelY = y + j;

                            if (pixelX < width && pixelY < height)
                            {
                                Color newColor = Color.FromArgb(bitmap.GetPixel(pixelX, pixelY).A, avgR, avgG, avgB);
                                bitmap.SetPixel(pixelX, pixelY, newColor);
                            }
                        }
                    }
                }
            }

            return bitmap;
        }

        private void saturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplySaturationFilter();
        }

        private void ApplySaturationFilter()
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

                        // Convertir el frame a Bitmap
                        Bitmap bitmap = currentFrame.ToBitmap();

                        // Aplicar el filtro de saturación
                        bitmap = ApplySaturation(bitmap);

                        // Mostrar la imagen con filtro de saturación en pictureBox1
                        pictureBox1.Image = bitmap;
                        pictureBox1.Refresh();

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
                MessageBox.Show("No se ha cargado ningún video o imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap ApplySaturation(Bitmap original)
        {
            Bitmap bitmap = new Bitmap(original);

            // Factor de saturación (ajustable según tus necesidades)
            float saturationFactor = 1.5f;

            // Ajustar la saturación de cada píxel
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color originalColor = bitmap.GetPixel(x, y);

                    // Convertir a HSL (Hue, Saturation, Lightness)
                    float hue, saturation, lightness;
                    ColorToHSL(originalColor, out hue, out saturation, out lightness);

                    // Ajustar la saturación
                    saturation *= saturationFactor;
                    saturation = Math.Max(0, Math.Min(1, saturation)); // Asegurar que esté en el rango [0, 1]

                    // Convertir de nuevo a RGB
                    Color newColor = HSLToColor(hue, saturation, lightness);
                    bitmap.SetPixel(x, y, newColor);
                }
            }

            return bitmap;
        }

        private void ColorToHSL(Color color, out float hue, out float saturation, out float lightness)
        {
            float r = (float)color.R / 255f;
            float g = (float)color.G / 255f;
            float b = (float)color.B / 255f;

            float min = Math.Min(Math.Min(r, g), b);
            float max = Math.Max(Math.Max(r, g), b);
            float delta = max - min;

            // Luminosidad
            lightness = (max + min) / 2f;

            // Saturación
            if (delta == 0)
            {
                saturation = 0;
            }
            else
            {
                saturation = lightness <= 0.5f ? delta / (max + min) : delta / (2 - max - min);
            }

            // Hue
            if (delta == 0)
            {
                hue = 0;
            }
            else
            {
                float deltaR = (((max - r) / 6f) + (delta / 2f)) / delta;
                float deltaG = (((max - g) / 6f) + (delta / 2f)) / delta;
                float deltaB = (((max - b) / 6f) + (delta / 2f)) / delta;

                if (r == max)
                {
                    hue = deltaB - deltaG;
                }
                else if (g == max)
                {
                    hue = (1 / 3f) + deltaR - deltaB;
                }
                else // b == max
                {
                    hue = (2 / 3f) + deltaG - deltaR;
                }

                if (hue < 0)
                {
                    hue += 1;
                }
                if (hue > 1)
                {
                    hue -= 1;
                }
            }
        }

        private Color HSLToColor(float hue, float saturation, float lightness)
        {
            byte r, g, b;
            if (saturation == 0)
            {
                r = g = b = (byte)(lightness * 255);
            }
            else
            {
                float q = lightness < 0.5f ? lightness * (1 + saturation) : lightness + saturation - lightness * saturation;
                float p = 2 * lightness - q;

                r = (byte)(HueToRGB(p, q, hue + 1 / 3f) * 255);
                g = (byte)(HueToRGB(p, q, hue) * 255);
                b = (byte)(HueToRGB(p, q, hue - 1 / 3f) * 255);
            }

            return Color.FromArgb(r, g, b);
        }

        private float HueToRGB(float p, float q, float t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1 / 6f) return p + (q - p) * 6 * t;
            if (t < 1 / 2f) return q;
            if (t < 2 / 3f) return p + (q - p) * (2 / 3f - t) * 6;
            return p;
        }



        private void UpdateHistogram(Bitmap frame)
        {
            int[] redHistogram = new int[256];
            int[] greenHistogram = new int[256];
            int[] blueHistogram = new int[256];

            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    Color pixel = frame.GetPixel(x, y);
                    redHistogram[pixel.R]++;
                    greenHistogram[pixel.G]++;
                    blueHistogram[pixel.B]++;
                }
            }

            // Limpiar el chart antes de actualizarlo
            chart1.Series.Clear();

            // Crear series para cada canal de color
            Series seriesRed = new Series("Rojo");
            Series seriesGreen = new Series("Verde");
            Series seriesBlue = new Series("Azul");

            // Añadir los datos al chart
            for (int i = 0; i < 256; i++)
            {
                seriesRed.Points.AddXY(i, redHistogram[i]);
                seriesGreen.Points.AddXY(i, greenHistogram[i]);
                seriesBlue.Points.AddXY(i, blueHistogram[i]);
            }

            // Añadir las series al chart
            chart1.Series.Add(seriesRed);
            chart1.Series.Add(seriesGreen);
            chart1.Series.Add(seriesBlue);

            // Configurar colores y estilos de las series
            seriesRed.Color = Color.Red;
            seriesGreen.Color = Color.Green;
            seriesBlue.Color = Color.Blue;

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 255;
            chart1.ChartAreas[0].AxisY.Minimum = 0;

            // Actualizar el gráfico
            chart1.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
