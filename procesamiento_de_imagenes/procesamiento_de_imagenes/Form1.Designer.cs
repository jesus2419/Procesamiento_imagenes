namespace procesamiento_de_imagenes
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.BtnRestaurar = new System.Windows.Forms.PictureBox();
            this.BtnMax = new System.Windows.Forms.PictureBox();
            this.BtnMin = new System.Windows.Forms.PictureBox();
            this.BtnCerrar = new System.Windows.Forms.PictureBox();
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.SubMenuArchivos = new System.Windows.Forms.Panel();
            this.BtnCargarVideo = new System.Windows.Forms.Button();
            this.BtnCargarFoto = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.BtnCargar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BtnFoto = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelContenido = new System.Windows.Forms.Panel();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).BeginInit();
            this.MenuVertical.SuspendLayout();
            this.SubMenuArchivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BarraTitulo.Controls.Add(this.BtnRestaurar);
            this.BarraTitulo.Controls.Add(this.BtnMax);
            this.BarraTitulo.Controls.Add(this.BtnMin);
            this.BarraTitulo.Controls.Add(this.BtnCerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1300, 35);
            this.BarraTitulo.TabIndex = 0;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // BtnRestaurar
            // 
            this.BtnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRestaurar.Image = global::procesamiento_de_imagenes.Properties.Resources.restaurar;
            this.BtnRestaurar.Location = new System.Drawing.Point(1232, 7);
            this.BtnRestaurar.Name = "BtnRestaurar";
            this.BtnRestaurar.Size = new System.Drawing.Size(25, 25);
            this.BtnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnRestaurar.TabIndex = 3;
            this.BtnRestaurar.TabStop = false;
            this.BtnRestaurar.Visible = false;
            this.BtnRestaurar.Click += new System.EventHandler(this.BtnRestaurar_Click);
            // 
            // BtnMax
            // 
            this.BtnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMax.Image = global::procesamiento_de_imagenes.Properties.Resources.icons8_maximize_window_50;
            this.BtnMax.Location = new System.Drawing.Point(1232, 7);
            this.BtnMax.Name = "BtnMax";
            this.BtnMax.Size = new System.Drawing.Size(25, 25);
            this.BtnMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnMax.TabIndex = 2;
            this.BtnMax.TabStop = false;
            this.BtnMax.Click += new System.EventHandler(this.BtnMax_Click);
            // 
            // BtnMin
            // 
            this.BtnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMin.Image = global::procesamiento_de_imagenes.Properties.Resources.icons8_minimize_window_30;
            this.BtnMin.Location = new System.Drawing.Point(1201, 7);
            this.BtnMin.Name = "BtnMin";
            this.BtnMin.Size = new System.Drawing.Size(25, 25);
            this.BtnMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnMin.TabIndex = 1;
            this.BtnMin.TabStop = false;
            this.BtnMin.Click += new System.EventHandler(this.BtnMin_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.Image = global::procesamiento_de_imagenes.Properties.Resources.icons8_close_window_50;
            this.BtnCerrar.Location = new System.Drawing.Point(1263, 7);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(25, 25);
            this.BtnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnCerrar.TabIndex = 0;
            this.BtnCerrar.TabStop = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.MenuVertical.Controls.Add(this.SubMenuArchivos);
            this.MenuVertical.Controls.Add(this.pictureBox4);
            this.MenuVertical.Controls.Add(this.BtnCargar);
            this.MenuVertical.Controls.Add(this.pictureBox2);
            this.MenuVertical.Controls.Add(this.BtnFoto);
            this.MenuVertical.Controls.Add(this.pictureBox1);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 35);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(220, 615);
            this.MenuVertical.TabIndex = 1;
            // 
            // SubMenuArchivos
            // 
            this.SubMenuArchivos.Controls.Add(this.BtnCargarVideo);
            this.SubMenuArchivos.Controls.Add(this.BtnCargarFoto);
            this.SubMenuArchivos.Location = new System.Drawing.Point(33, 312);
            this.SubMenuArchivos.Name = "SubMenuArchivos";
            this.SubMenuArchivos.Size = new System.Drawing.Size(181, 100);
            this.SubMenuArchivos.TabIndex = 7;
            this.SubMenuArchivos.Visible = false;
            // 
            // BtnCargarVideo
            // 
            this.BtnCargarVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.BtnCargarVideo.FlatAppearance.BorderSize = 0;
            this.BtnCargarVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnCargarVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargarVideo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarVideo.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnCargarVideo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCargarVideo.Location = new System.Drawing.Point(0, 37);
            this.BtnCargarVideo.Name = "BtnCargarVideo";
            this.BtnCargarVideo.Size = new System.Drawing.Size(184, 31);
            this.BtnCargarVideo.TabIndex = 9;
            this.BtnCargarVideo.Text = "Cargar Video";
            this.BtnCargarVideo.UseVisualStyleBackColor = false;
            this.BtnCargarVideo.Click += new System.EventHandler(this.BtnCargarVideo_Click);
            // 
            // BtnCargarFoto
            // 
            this.BtnCargarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.BtnCargarFoto.FlatAppearance.BorderSize = 0;
            this.BtnCargarFoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnCargarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargarFoto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarFoto.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnCargarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCargarFoto.Location = new System.Drawing.Point(0, 0);
            this.BtnCargarFoto.Name = "BtnCargarFoto";
            this.BtnCargarFoto.Size = new System.Drawing.Size(184, 31);
            this.BtnCargarFoto.TabIndex = 8;
            this.BtnCargarFoto.Text = "Cargar Imagen";
            this.BtnCargarFoto.UseVisualStyleBackColor = false;
            this.BtnCargarFoto.Click += new System.EventHandler(this.BtnCargarFoto_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::procesamiento_de_imagenes.Properties.Resources.frame_gallery_image_images_photo_picture_pictures_icon_123209;
            this.pictureBox4.Location = new System.Drawing.Point(0, 275);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // BtnCargar
            // 
            this.BtnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.BtnCargar.FlatAppearance.BorderSize = 0;
            this.BtnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargar.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCargar.Location = new System.Drawing.Point(36, 275);
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.Size = new System.Drawing.Size(184, 31);
            this.BtnCargar.TabIndex = 5;
            this.BtnCargar.Text = "Cargar";
            this.BtnCargar.UseVisualStyleBackColor = false;
            this.BtnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::procesamiento_de_imagenes.Properties.Resources.camera_icon_icons_com_59928;
            this.pictureBox2.Location = new System.Drawing.Point(0, 238);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // BtnFoto
            // 
            this.BtnFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.BtnFoto.FlatAppearance.BorderSize = 0;
            this.BtnFoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BtnFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFoto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFoto.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFoto.Location = new System.Drawing.Point(36, 238);
            this.BtnFoto.Name = "BtnFoto";
            this.BtnFoto.Size = new System.Drawing.Size(184, 31);
            this.BtnFoto.TabIndex = 1;
            this.BtnFoto.Text = "Cámara";
            this.BtnFoto.UseVisualStyleBackColor = false;
            this.BtnFoto.Click += new System.EventHandler(this.BtnFoto_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::procesamiento_de_imagenes.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PanelContenido
            // 
            this.PanelContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.PanelContenido.Cursor = System.Windows.Forms.Cursors.Default;
            this.PanelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenido.Location = new System.Drawing.Point(220, 35);
            this.PanelContenido.Name = "PanelContenido";
            this.PanelContenido.Size = new System.Drawing.Size(1080, 615);
            this.PanelContenido.TabIndex = 2;
            this.PanelContenido.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelContenido_Paint);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.PanelContenido);
            this.Controls.Add(this.MenuVertical);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).EndInit();
            this.MenuVertical.ResumeLayout(false);
            this.SubMenuArchivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Panel PanelContenido;
        private System.Windows.Forms.PictureBox BtnCerrar;
        private System.Windows.Forms.PictureBox BtnMin;
        private System.Windows.Forms.PictureBox BtnMax;
        private System.Windows.Forms.PictureBox BtnRestaurar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnFoto;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button BtnCargar;
        private System.Windows.Forms.Panel SubMenuArchivos;
        private System.Windows.Forms.Button BtnCargarVideo;
        private System.Windows.Forms.Button BtnCargarFoto;
    }
}

