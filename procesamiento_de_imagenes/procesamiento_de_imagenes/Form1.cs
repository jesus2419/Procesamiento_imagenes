using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace procesamiento_de_imagenes
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PanelContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMax.Visible = false;
            BtnRestaurar.Visible = true;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnMax.Visible = true;
            BtnRestaurar.Visible = false;

        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            SubMenuArchivos.Visible = true;
        }

        private void BtnCargarFoto_Click(object sender, EventArgs e)
        {
            SubMenuArchivos.Visible = false;
            AbrirFormHija(new cargarfoto());
        }

        private void BtnCargarVideo_Click(object sender, EventArgs e)
        {
            SubMenuArchivos.Visible = false;
            AbrirFormHija(new cargarvideo());

        }


        /*
        private void AbrirFormHija(object formhija)
        {
            if (this.PanelContenido.Controls.Count > 0)
                this.PanelContenido.Controls.RemoveAt(0);
            
            Form fh = formhija as Form;
            fh.TopLevel = true;
            fh.Dock = DockStyle.Fill;
            this.PanelContenido.Controls.Add(fh);
            this.PanelContenido.Tag = fh;
            fh.Show();
        }
        */
        private void AbrirFormHija(Form formhija)
        {
            // Si ya hay un formulario hijo en PanelContenido, lo elimina
            if (this.PanelContenido.Controls.Count > 0)
                this.PanelContenido.Controls.RemoveAt(0);

            // Ajusta las propiedades del formulario hijo
            formhija.TopLevel = false;
            formhija.FormBorderStyle = FormBorderStyle.None;
            formhija.Dock = DockStyle.Fill;

            // Agrega el formulario hijo al PanelContenido
            this.PanelContenido.Controls.Add(formhija);
            this.PanelContenido.Tag = formhija;

            // Muestra el formulario hijo
            formhija.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnFoto_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new foto());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new video());
        }
    }
}
