using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace procesamiento_de_imagenes
{
    public partial class cargarfoto : Form
    {
        public cargarfoto()
        {
            InitializeComponent();
        }
        private Bitmap originalBitmap; // Para almacenar la imagen original
        private void BtnFoto_Click(object sender, EventArgs e)
        {

            // Crear un nuevo OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagenes|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Title = "Seleccionar una imagen";

            // Mostrar el OpenFileDialog y verificar si se seleccionó un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Cargar la imagen seleccionada en el PictureBox
                originalBitmap = new Bitmap(openFileDialog.FileName);
                pictureBox2.Image = new Bitmap(openFileDialog.FileName);
                UpdateHistogram();
            }
        }

        private void UpdateHistogram()
        {
            if (originalBitmap != null)
            {
                // Calcular histograma para la imagen actual
                int[] redHistogram = new int[256];
                int[] greenHistogram = new int[256];
                int[] blueHistogram = new int[256];

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        Color pixel = originalBitmap.GetPixel(x, y);
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
        }
        private void btn_guardar_Click(object sender, EventArgs e)
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

        private void invertirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                Bitmap bitmap = new Bitmap(pictureBox2.Image);

                // Invertir los colores de cada píxel
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color originalColor = bitmap.GetPixel(x, y);
                        Color invertedColor = Color.FromArgb(originalColor.A,
                                                             255 - originalColor.R,
                                                             255 - originalColor.G,
                                                             255 - originalColor.B);
                        bitmap.SetPixel(x, y, invertedColor);
                    }
                }

                // Asignar la imagen invertida al PictureBox
                pictureBox2.Image = bitmap;
                UpdateHistogram();
            }
            else
            {
                MessageBox.Show("No hay imagen cargada para invertir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aberracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                Bitmap originalBitmap = new Bitmap(pictureBox2.Image);
                Bitmap aberrationBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                int shiftAmount = 10; // Cantidad de desplazamiento para los canales de color

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        Color originalColor = originalBitmap.GetPixel(x, y);

                        int redX = x + shiftAmount < originalBitmap.Width ? x + shiftAmount : x;
                        int greenY = y + shiftAmount < originalBitmap.Height ? y + shiftAmount : y;
                        int blueX = x - shiftAmount >= 0 ? x - shiftAmount : x;

                        Color redColor = originalBitmap.GetPixel(redX, y);
                        Color greenColor = originalBitmap.GetPixel(x, greenY);
                        Color blueColor = originalBitmap.GetPixel(blueX, y);

                        Color aberrationColor = Color.FromArgb(originalColor.A, redColor.R, greenColor.G, blueColor.B);
                        aberrationBitmap.SetPixel(x, y, aberrationColor);
                    }
                }

                // Asignar la imagen con aberración al PictureBox
                pictureBox2.Image = aberrationBitmap;
                UpdateHistogram();
            }
            else
            {
                MessageBox.Show("No hay imagen cargada para aplicar la aberración de color.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void colorizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap != null)
            {
                Bitmap bitmap = new Bitmap(originalBitmap);

                // Convertir a escala de grises y aplicar color amarillo
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color originalColor = bitmap.GetPixel(x, y);

                        // Convertir a escala de grises
                        int gray = (int)(originalColor.R * 0.299 + originalColor.G * 0.587 + originalColor.B * 0.114);

                        // Aplicar el color amarillo
                        int red = (int)(gray * 1.0);     // Amarillo: R = G = 255, B = 0
                        int green = (int)(gray * 1.0);
                        int blue = 0;

                        // Asegurarse de que los valores estén en el rango válido (0-255)
                        red = Math.Max(0, Math.Min(255, red));
                        green = Math.Max(0, Math.Min(255, green));
                        blue = Math.Max(0, Math.Min(255, blue));

                        Color colorizedColor = Color.FromArgb(originalColor.A, red, green, blue);
                        bitmap.SetPixel(x, y, colorizedColor);
                    }
                }

                // Asignar la imagen colorizada al PictureBox
                pictureBox2.Image = bitmap;
                UpdateHistogram();
            }
            else
            {
                MessageBox.Show("No hay imagen cargada para colorizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cargarfoto_Load(object sender, EventArgs e)
        {
           
        }

       

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Solicitar al usuario que ingrese el valor de gamma
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
            if (originalBitmap != null)
            {
                Bitmap bitmap = new Bitmap(originalBitmap);

                // Aplicar filtro gamma a cada píxel
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color originalColor = bitmap.GetPixel(x, y);

                        int red = (int)(255 * Math.Pow(originalColor.R / 255.0, gammaValue));
                        int green = (int)(255 * Math.Pow(originalColor.G / 255.0, gammaValue));
                        int blue = (int)(255 * Math.Pow(originalColor.B / 255.0, gammaValue));

                        // Asegurarse de que los valores estén en el rango válido (0-255)
                        red = Math.Max(0, Math.Min(255, red));
                        green = Math.Max(0, Math.Min(255, green));
                        blue = Math.Max(0, Math.Min(255, blue));

                        Color gammaColor = Color.FromArgb(originalColor.A, red, green, blue);
                        bitmap.SetPixel(x, y, gammaColor);
                    }
                }

                // Asignar la imagen con filtro gamma al PictureBox
                pictureBox2.Image = bitmap;
                UpdateHistogram();
            }
            else
            {
                MessageBox.Show("No hay imagen cargada para aplicar el filtro gamma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (originalBitmap != null)
            {
                Bitmap bitmap = new Bitmap(originalBitmap);

                // Aplicar ajuste de brillo a cada píxel
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color originalColor = bitmap.GetPixel(x, y);

                        int red = (int)(originalColor.R + brightnessValue);
                        int green = (int)(originalColor.G + brightnessValue);
                        int blue = (int)(originalColor.B + brightnessValue);

                        // Asegurarse de que los valores estén en el rango válido (0-255)
                        red = Math.Max(0, Math.Min(255, red));
                        green = Math.Max(0, Math.Min(255, green));
                        blue = Math.Max(0, Math.Min(255, blue));

                        Color adjustedColor = Color.FromArgb(originalColor.A, red, green, blue);
                        bitmap.SetPixel(x, y, adjustedColor);
                    }
                }

                // Asignar la imagen con ajuste de brillo al PictureBox
                pictureBox2.Image = bitmap;
                UpdateHistogram();
            }
            else
            {
                MessageBox.Show("No hay imagen cargada para ajustar el brillo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (originalBitmap != null)
            {
                Bitmap bitmap = new Bitmap(originalBitmap);

                // Aplicar ajuste de contraste a cada píxel
                double contrastLevel = Math.Pow((100.0 + contrastValue) / 100.0, 2);

                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color originalColor = bitmap.GetPixel(x, y);

                        int red = (int)(((originalColor.R / 255.0 - 0.5) * contrastLevel + 0.5) * 255);
                        int green = (int)(((originalColor.G / 255.0 - 0.5) * contrastLevel + 0.5) * 255);
                        int blue = (int)(((originalColor.B / 255.0 - 0.5) * contrastLevel + 0.5) * 255);

                        // Asegurarse de que los valores estén en el rango válido (0-255)
                        red = Math.Max(0, Math.Min(255, red));
                        green = Math.Max(0, Math.Min(255, green));
                        blue = Math.Max(0, Math.Min(255, blue));

                        Color adjustedColor = Color.FromArgb(originalColor.A, red, green, blue);
                        bitmap.SetPixel(x, y, adjustedColor);
                    }
                }

                // Asignar la imagen con ajuste de contraste al PictureBox
                pictureBox2.Image = bitmap;
                UpdateHistogram();
            }
            else
            {
                MessageBox.Show("No hay imagen cargada para ajustar el contraste.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sobbelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplySobelFilter();
        }
        private void ApplySobelFilter()
        {
            if (originalBitmap != null)
            {
                Bitmap grayImage = GrayscaleImage(originalBitmap);
                Bitmap bitmap = new Bitmap(grayImage);

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

                // Mostrar la imagen con filtro Sobel en pictureBox2
                pictureBox2.Image = resultBitmap;
                UpdateHistogram();
            }
            else
            {
                MessageBox.Show("No hay imagen cargada para aplicar el filtro de Sobel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (originalBitmap != null)
            {
                Bitmap bitmap = new Bitmap(originalBitmap);

                Random random = new Random();

                // Intensidad del ruido (ajustable según tus necesidades)
                int noiseIntensity = 50;

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

                // Mostrar la imagen con ruido en pictureBox2
                pictureBox2.Image = bitmap;
                UpdateHistogram();
            }
            else
            {
                MessageBox.Show("No hay imagen cargada para aplicar el filtro de ruido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pixelacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyPixelationFilter();
        }
        private void ApplyPixelationFilter()
        {
            if (originalBitmap != null)
            {
                Bitmap bitmap = new Bitmap(originalBitmap);

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

                // Mostrar la imagen pixelada en pictureBox2
                pictureBox2.Image = bitmap;
                UpdateHistogram();
            }
            else
            {
                MessageBox.Show("No hay imagen cargada para aplicar el filtro de pixelación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplySaturationFilter();
        }
        private void ApplySaturationFilter()
        {
            if (originalBitmap != null)
            {
                Bitmap bitmap = new Bitmap(originalBitmap);

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

                // Mostrar la imagen con filtro de saturación en pictureBox2
                pictureBox2.Image = bitmap;
                UpdateHistogram();
            }
            else
            {
                MessageBox.Show("No hay imagen cargada para aplicar el filtro de saturación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


    }
}
