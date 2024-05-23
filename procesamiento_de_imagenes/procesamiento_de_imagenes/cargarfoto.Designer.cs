namespace procesamiento_de_imagenes
{
    partial class cargarfoto
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnFoto = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_guardar.FlatAppearance.BorderSize = 0;
            this.btn_guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(498, 534);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(106, 30);
            this.btn_guardar.TabIndex = 25;
            this.btn_guardar.Text = "Guardar foto";
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Foto";
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
            this.BtnFoto.Location = new System.Drawing.Point(39, 534);
            this.BtnFoto.Name = "BtnFoto";
            this.BtnFoto.Size = new System.Drawing.Size(125, 30);
            this.BtnFoto.TabIndex = 20;
            this.BtnFoto.Text = "Cargar Foto";
            this.BtnFoto.UseVisualStyleBackColor = false;
            this.BtnFoto.Click += new System.EventHandler(this.BtnFoto_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(39, 52);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(565, 476);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip1.TabIndex = 32;
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
            this.invertirToolStripMenuItem.Click += new System.EventHandler(this.invertirToolStripMenuItem_Click);
            // 
            // aberracionToolStripMenuItem
            // 
            this.aberracionToolStripMenuItem.Name = "aberracionToolStripMenuItem";
            this.aberracionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aberracionToolStripMenuItem.Text = "Aberracion";
            this.aberracionToolStripMenuItem.Click += new System.EventHandler(this.aberracionToolStripMenuItem_Click);
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
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(635, 52);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(383, 476);
            this.chart1.TabIndex = 34;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(632, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "Histograma";
            // 
            // cargarfoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1064, 576);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnFoto);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "cargarfoto";
            this.Text = "cargarfoto";
            this.Load += new System.EventHandler(this.cargarfoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnFoto;
        private System.Windows.Forms.PictureBox pictureBox2;
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
        private System.Windows.Forms.Label label1;
    }
}