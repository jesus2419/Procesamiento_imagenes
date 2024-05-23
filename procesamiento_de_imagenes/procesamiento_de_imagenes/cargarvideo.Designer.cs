namespace procesamiento_de_imagenes
{
    partial class cargarvideo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.btn_reproducir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Btnvideo = new System.Windows.Forms.Button();
            this.btn_parar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filtrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aberracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brilloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobbelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saturacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.Btn_guardar.FlatAppearance.BorderSize = 0;
            this.Btn_guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.Btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_guardar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_guardar.ForeColor = System.Drawing.SystemColors.Window;
            this.Btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_guardar.Location = new System.Drawing.Point(514, 466);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(167, 30);
            this.Btn_guardar.TabIndex = 38;
            this.Btn_guardar.Text = "Guardar video";
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // btn_reproducir
            // 
            this.btn_reproducir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_reproducir.FlatAppearance.BorderSize = 0;
            this.btn_reproducir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_reproducir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reproducir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reproducir.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_reproducir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_reproducir.Location = new System.Drawing.Point(232, 466);
            this.btn_reproducir.Name = "btn_reproducir";
            this.btn_reproducir.Size = new System.Drawing.Size(106, 30);
            this.btn_reproducir.TabIndex = 37;
            this.btn_reproducir.Text = "Reproducir";
            this.btn_reproducir.UseVisualStyleBackColor = false;
            this.btn_reproducir.Click += new System.EventHandler(this.btn_reproducir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Video";
            // 
            // Btnvideo
            // 
            this.Btnvideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.Btnvideo.FlatAppearance.BorderSize = 0;
            this.Btnvideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.Btnvideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnvideo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnvideo.ForeColor = System.Drawing.SystemColors.Window;
            this.Btnvideo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btnvideo.Location = new System.Drawing.Point(41, 466);
            this.Btnvideo.Name = "Btnvideo";
            this.Btnvideo.Size = new System.Drawing.Size(125, 30);
            this.Btnvideo.TabIndex = 33;
            this.Btnvideo.Text = "Cargar video";
            this.Btnvideo.UseVisualStyleBackColor = false;
            this.Btnvideo.Click += new System.EventHandler(this.Btnvideo_Click);
            // 
            // btn_parar
            // 
            this.btn_parar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_parar.FlatAppearance.BorderSize = 0;
            this.btn_parar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_parar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_parar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_parar.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_parar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_parar.Location = new System.Drawing.Point(344, 466);
            this.btn_parar.Name = "btn_parar";
            this.btn_parar.Size = new System.Drawing.Size(106, 30);
            this.btn_parar.TabIndex = 50;
            this.btn_parar.Text = "Parar";
            this.btn_parar.UseVisualStyleBackColor = false;
            this.btn_parar.Click += new System.EventHandler(this.btn_parar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(41, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 408);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1048, 24);
            this.menuStrip1.TabIndex = 52;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filtrosToolStripMenuItem
            // 
            this.filtrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invertirToolStripMenuItem,
            this.aberracionToolStripMenuItem,
            this.colorizarToolStripMenuItem,
            this.gammaToolStripMenuItem,
            this.brilloToolStripMenuItem,
            this.contrasteToolStripMenuItem,
            this.sobbelToolStripMenuItem,
            this.ruidoToolStripMenuItem,
            this.pixelacionToolStripMenuItem,
            this.saturacionToolStripMenuItem});
            this.filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            this.filtrosToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.filtrosToolStripMenuItem.Text = "Filtros";
            // 
            // invertirToolStripMenuItem
            // 
            this.invertirToolStripMenuItem.Name = "invertirToolStripMenuItem";
            this.invertirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.invertirToolStripMenuItem.Text = "Invertir";
            this.invertirToolStripMenuItem.Click += new System.EventHandler(this.invertirToolStripMenuItem_Click_1);
            // 
            // aberracionToolStripMenuItem
            // 
            this.aberracionToolStripMenuItem.Name = "aberracionToolStripMenuItem";
            this.aberracionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aberracionToolStripMenuItem.Text = "Aberracion";
            this.aberracionToolStripMenuItem.Click += new System.EventHandler(this.aberracionToolStripMenuItem_Click_1);
            // 
            // colorizarToolStripMenuItem
            // 
            this.colorizarToolStripMenuItem.Name = "colorizarToolStripMenuItem";
            this.colorizarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorizarToolStripMenuItem.Text = "Colorizar";
            this.colorizarToolStripMenuItem.Click += new System.EventHandler(this.colorizarToolStripMenuItem_Click);
            // 
            // gammaToolStripMenuItem
            // 
            this.gammaToolStripMenuItem.Name = "gammaToolStripMenuItem";
            this.gammaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gammaToolStripMenuItem.Text = "Gamma";
            this.gammaToolStripMenuItem.Click += new System.EventHandler(this.gammaToolStripMenuItem_Click);
            // 
            // brilloToolStripMenuItem
            // 
            this.brilloToolStripMenuItem.Name = "brilloToolStripMenuItem";
            this.brilloToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.brilloToolStripMenuItem.Text = "Brillo";
            this.brilloToolStripMenuItem.Click += new System.EventHandler(this.brilloToolStripMenuItem_Click);
            // 
            // contrasteToolStripMenuItem
            // 
            this.contrasteToolStripMenuItem.Name = "contrasteToolStripMenuItem";
            this.contrasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.contrasteToolStripMenuItem.Text = "Contraste";
            this.contrasteToolStripMenuItem.Click += new System.EventHandler(this.contrasteToolStripMenuItem_Click);
            // 
            // sobbelToolStripMenuItem
            // 
            this.sobbelToolStripMenuItem.Name = "sobbelToolStripMenuItem";
            this.sobbelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sobbelToolStripMenuItem.Text = "Sobbel";
            this.sobbelToolStripMenuItem.Click += new System.EventHandler(this.sobbelToolStripMenuItem_Click);
            // 
            // ruidoToolStripMenuItem
            // 
            this.ruidoToolStripMenuItem.Name = "ruidoToolStripMenuItem";
            this.ruidoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ruidoToolStripMenuItem.Text = "Ruido";
            this.ruidoToolStripMenuItem.Click += new System.EventHandler(this.ruidoToolStripMenuItem_Click);
            // 
            // pixelacionToolStripMenuItem
            // 
            this.pixelacionToolStripMenuItem.Name = "pixelacionToolStripMenuItem";
            this.pixelacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pixelacionToolStripMenuItem.Text = "Pixelacion";
            this.pixelacionToolStripMenuItem.Click += new System.EventHandler(this.pixelacionToolStripMenuItem_Click);
            // 
            // saturacionToolStripMenuItem
            // 
            this.saturacionToolStripMenuItem.Name = "saturacionToolStripMenuItem";
            this.saturacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saturacionToolStripMenuItem.Text = "Saturacion";
            this.saturacionToolStripMenuItem.Click += new System.EventHandler(this.saturacionToolStripMenuItem_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(748, 52);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 53;
            this.chart1.Text = "chart1";
            // 
            // cargarvideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1048, 537);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_parar);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.btn_reproducir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btnvideo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cargarvideo";
            this.Text = "cargarvideo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cargarvideo_FormClosing);
            this.Load += new System.EventHandler(this.cargarvideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button btn_reproducir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btnvideo;
        private System.Windows.Forms.Button btn_parar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filtrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aberracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gammaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brilloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobbelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ruidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saturacionToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}