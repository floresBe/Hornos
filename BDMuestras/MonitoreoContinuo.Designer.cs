namespace BDMuestras
{
    partial class MonitoreoContinuo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitoreoContinuo));
            this.labelHorno = new System.Windows.Forms.Label();
            this.labelTituloGrafica = new System.Windows.Forms.Label();
            this.labelTituloLista = new System.Windows.Forms.Label();
            this.labelMaqTitulo = new System.Windows.Forms.Label();
            this.labelFechaHora = new System.Windows.Forms.Label();
            this.labelCiclo = new System.Windows.Forms.Label();
            this.listBoxMuestrasTemp = new System.Windows.Forms.ListBox();
            this.chartMuestras = new System.Windows.Forms.DataVisualization.Charting.Chart();
            serialPortMuestras = new System.IO.Ports.SerialPort(this.components);
            this.listBoxMuestrasPress = new System.Windows.Forms.ListBox();
            this.TemporizadorHora = new System.Windows.Forms.Timer(this.components);
            this.timerMuestreo = new System.Windows.Forms.Timer(this.components);
            this.labelReporte = new System.Windows.Forms.Label();
            this.labelConfiguración = new System.Windows.Forms.Label();
            listBoxAmbiente = new System.Windows.Forms.ListBox();
            serialPortAmbiente = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.IconoAtencion = new System.Windows.Forms.PictureBox();
            this.pictureDetenido = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonImprimirInforme = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMaquina = new System.Windows.Forms.Label();
            this.pictureCorriendo = new System.Windows.Forms.PictureBox();
            this.labelPromedio = new System.Windows.Forms.Label();
            this.labelPro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartMuestras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconoAtencion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDetenido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCorriendo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHorno
            // 
            this.labelHorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHorno.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelHorno.Location = new System.Drawing.Point(15, 533);
            this.labelHorno.Name = "labelHorno";
            this.labelHorno.Size = new System.Drawing.Size(235, 28);
            this.labelHorno.TabIndex = 25;
            this.labelHorno.Text = "Estado del Horno:";
            this.labelHorno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTituloGrafica
            // 
            this.labelTituloGrafica.AutoSize = true;
            this.labelTituloGrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloGrafica.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTituloGrafica.Location = new System.Drawing.Point(454, 76);
            this.labelTituloGrafica.Name = "labelTituloGrafica";
            this.labelTituloGrafica.Size = new System.Drawing.Size(464, 31);
            this.labelTituloGrafica.TabIndex = 24;
            this.labelTituloGrafica.Text = "Representación Gráfica de Muestras:";
            // 
            // labelTituloLista
            // 
            this.labelTituloLista.AutoSize = true;
            this.labelTituloLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloLista.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTituloLista.Location = new System.Drawing.Point(14, 76);
            this.labelTituloLista.Name = "labelTituloLista";
            this.labelTituloLista.Size = new System.Drawing.Size(266, 31);
            this.labelTituloLista.TabIndex = 23;
            this.labelTituloLista.Text = "Listado de Muestras:";
            // 
            // labelMaqTitulo
            // 
            this.labelMaqTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaqTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelMaqTitulo.Location = new System.Drawing.Point(14, 8);
            this.labelMaqTitulo.Name = "labelMaqTitulo";
            this.labelMaqTitulo.Size = new System.Drawing.Size(125, 35);
            this.labelMaqTitulo.TabIndex = 22;
            this.labelMaqTitulo.Text = "Máquina: ";
            // 
            // labelFechaHora
            // 
            this.labelFechaHora.AutoSize = true;
            this.labelFechaHora.BackColor = System.Drawing.Color.White;
            this.labelFechaHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaHora.ForeColor = System.Drawing.Color.Red;
            this.labelFechaHora.Location = new System.Drawing.Point(1059, 23);
            this.labelFechaHora.Name = "labelFechaHora";
            this.labelFechaHora.Size = new System.Drawing.Size(276, 31);
            this.labelFechaHora.TabIndex = 21;
            this.labelFechaHora.Text = "00/00/00 00:00:00 AA";
            // 
            // labelCiclo
            // 
            this.labelCiclo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCiclo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCiclo.Location = new System.Drawing.Point(14, 43);
            this.labelCiclo.Name = "labelCiclo";
            this.labelCiclo.Size = new System.Drawing.Size(273, 47);
            this.labelCiclo.TabIndex = 17;
            this.labelCiclo.Text = "Ciclo: ";
            // 
            // listBoxMuestrasTemp
            // 
            this.listBoxMuestrasTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxMuestrasTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMuestrasTemp.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.listBoxMuestrasTemp.FormattingEnabled = true;
            this.listBoxMuestrasTemp.ItemHeight = 29;
            this.listBoxMuestrasTemp.Items.AddRange(new object[] {
            "Nombre       Hora        Temperatura"});
            this.listBoxMuestrasTemp.Location = new System.Drawing.Point(21, 120);
            this.listBoxMuestrasTemp.Name = "listBoxMuestrasTemp";
            this.listBoxMuestrasTemp.Size = new System.Drawing.Size(405, 176);
            this.listBoxMuestrasTemp.TabIndex = 16;
            // 
            // chartMuestras
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMuestras.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMuestras.Legends.Add(legend1);
            this.chartMuestras.Location = new System.Drawing.Point(461, 120);
            this.chartMuestras.Name = "chartMuestras";
            this.chartMuestras.Size = new System.Drawing.Size(875, 441);
            this.chartMuestras.TabIndex = 30;
            this.chartMuestras.Text = "chartMuestras";
            // 
            // serialPortMuestras
            // 
            serialPortMuestras.PortName = "COM3";
            // 
            // listBoxMuestrasPress
            // 
            this.listBoxMuestrasPress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxMuestrasPress.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMuestrasPress.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.listBoxMuestrasPress.FormattingEnabled = true;
            this.listBoxMuestrasPress.ItemHeight = 29;
            this.listBoxMuestrasPress.Items.AddRange(new object[] {
            "Nombre                   Hora         Presión"});
            this.listBoxMuestrasPress.Location = new System.Drawing.Point(21, 335);
            this.listBoxMuestrasPress.Name = "listBoxMuestrasPress";
            this.listBoxMuestrasPress.Size = new System.Drawing.Size(405, 176);
            this.listBoxMuestrasPress.TabIndex = 31;
            // 
            // TemporizadorHora
            // 
            this.TemporizadorHora.Interval = 1000;
            this.TemporizadorHora.Tick += new System.EventHandler(this.TemporizadorHora_Tick);
            // 
            // timerMuestreo
            // 
            this.timerMuestreo.Interval = 1000;
            this.timerMuestreo.Tick += new System.EventHandler(this.timerMuestreo_Tick);
            // 
            // labelReporte
            // 
            this.labelReporte.AutoSize = true;
            this.labelReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReporte.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelReporte.Location = new System.Drawing.Point(17, 676);
            this.labelReporte.Name = "labelReporte";
            this.labelReporte.Size = new System.Drawing.Size(64, 16);
            this.labelReporte.TabIndex = 35;
            this.labelReporte.Text = "Reportes";
            // 
            // labelConfiguración
            // 
            this.labelConfiguración.AutoSize = true;
            this.labelConfiguración.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfiguración.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelConfiguración.Location = new System.Drawing.Point(351, 676);
            this.labelConfiguración.Name = "labelConfiguración";
            this.labelConfiguración.Size = new System.Drawing.Size(90, 16);
            this.labelConfiguración.TabIndex = 36;
            this.labelConfiguración.Text = "Configuración";
            // 
            // listBoxAmbiente
            // 
            listBoxAmbiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listBoxAmbiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listBoxAmbiente.ForeColor = System.Drawing.SystemColors.ControlDark;
            listBoxAmbiente.FormattingEnabled = true;
            listBoxAmbiente.ItemHeight = 29;
            listBoxAmbiente.Location = new System.Drawing.Point(460, 605);
            listBoxAmbiente.Name = "listBoxAmbiente";
            listBoxAmbiente.Size = new System.Drawing.Size(875, 89);
            listBoxAmbiente.TabIndex = 38;
            // 
            // serialPortAmbiente
            // 
            serialPortAmbiente.PortName = "COM6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(454, 571);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 31);
            this.label1.TabIndex = 39;
            this.label1.Text = "Temperatura y Humedad Ambiente";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hornos.Properties.Resources._2000px_Logo_honeywell_svg;
            this.pictureBox1.Location = new System.Drawing.Point(460, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(409, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // IconoAtencion
            // 
            this.IconoAtencion.Image = ((System.Drawing.Image)(resources.GetObject("IconoAtencion.Image")));
            this.IconoAtencion.Location = new System.Drawing.Point(204, 43);
            this.IconoAtencion.Name = "IconoAtencion";
            this.IconoAtencion.Size = new System.Drawing.Size(36, 28);
            this.IconoAtencion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconoAtencion.TabIndex = 37;
            this.IconoAtencion.TabStop = false;
            this.IconoAtencion.Click += new System.EventHandler(this.IconoAtencion_Click_1);
            // 
            // pictureDetenido
            // 
            this.pictureDetenido.Image = global::Hornos.Properties.Resources.Detenido;
            this.pictureDetenido.Location = new System.Drawing.Point(275, 531);
            this.pictureDetenido.Name = "pictureDetenido";
            this.pictureDetenido.Size = new System.Drawing.Size(153, 33);
            this.pictureDetenido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureDetenido.TabIndex = 34;
            this.pictureDetenido.TabStop = false;
            this.pictureDetenido.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(368, 618);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 55);
            this.button1.TabIndex = 32;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonImprimirInforme
            // 
            this.buttonImprimirInforme.BackColor = System.Drawing.Color.Red;
            this.buttonImprimirInforme.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonImprimirInforme.BackgroundImage")));
            this.buttonImprimirInforme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonImprimirInforme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonImprimirInforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimirInforme.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonImprimirInforme.Location = new System.Drawing.Point(21, 618);
            this.buttonImprimirInforme.Name = "buttonImprimirInforme";
            this.buttonImprimirInforme.Size = new System.Drawing.Size(57, 55);
            this.buttonImprimirInforme.TabIndex = 20;
            this.buttonImprimirInforme.UseVisualStyleBackColor = false;
            this.buttonImprimirInforme.Click += new System.EventHandler(this.buttonImprimirInforme_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 31);
            this.label2.TabIndex = 41;
            this.label2.Text = "Nombre       Hora        Temperatura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 31);
            this.label3.TabIndex = 42;
            this.label3.Text = "Nombre             Hora            Vacio";
            // 
            // labelMaquina
            // 
            this.labelMaquina.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaquina.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelMaquina.Location = new System.Drawing.Point(145, 8);
            this.labelMaquina.Name = "labelMaquina";
            this.labelMaquina.Size = new System.Drawing.Size(202, 35);
            this.labelMaquina.TabIndex = 43;
            this.labelMaquina.Text = "I1806";
            // 
            // pictureCorriendo
            // 
            this.pictureCorriendo.Image = global::Hornos.Properties.Resources.Corriendo;
            this.pictureCorriendo.Location = new System.Drawing.Point(275, 531);
            this.pictureCorriendo.Name = "pictureCorriendo";
            this.pictureCorriendo.Size = new System.Drawing.Size(153, 33);
            this.pictureCorriendo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCorriendo.TabIndex = 44;
            this.pictureCorriendo.TabStop = false;
            this.pictureCorriendo.Visible = false;
            // 
            // labelPromedio
            // 
            this.labelPromedio.AutoSize = true;
            this.labelPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPromedio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPromedio.Location = new System.Drawing.Point(1235, 496);
            this.labelPromedio.Name = "labelPromedio";
            this.labelPromedio.Size = new System.Drawing.Size(74, 31);
            this.labelPromedio.TabIndex = 45;
            this.labelPromedio.Text = "0000";
            // 
            // labelPro
            // 
            this.labelPro.BackColor = System.Drawing.Color.White;
            this.labelPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelPro.Location = new System.Drawing.Point(1226, 457);
            this.labelPro.Name = "labelPro";
            this.labelPro.Size = new System.Drawing.Size(92, 29);
            this.labelPro.TabIndex = 46;
            this.labelPro.Text = "Promedio";
            // 
            // MonitoreoContinuo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1356, 726);
            this.Controls.Add(this.labelPro);
            this.Controls.Add(this.labelPromedio);
            this.Controls.Add(this.pictureCorriendo);
            this.Controls.Add(this.labelMaquina);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(listBoxAmbiente);
            this.Controls.Add(this.IconoAtencion);
            this.Controls.Add(this.labelConfiguración);
            this.Controls.Add(this.labelReporte);
            this.Controls.Add(this.pictureDetenido);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxMuestrasPress);
            this.Controls.Add(this.labelHorno);
            this.Controls.Add(this.labelTituloGrafica);
            this.Controls.Add(this.labelTituloLista);
            this.Controls.Add(this.labelMaqTitulo);
            this.Controls.Add(this.labelFechaHora);
            this.Controls.Add(this.buttonImprimirInforme);
            this.Controls.Add(this.labelCiclo);
            this.Controls.Add(this.listBoxMuestrasTemp);
            this.Controls.Add(this.chartMuestras);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "MonitoreoContinuo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toma de Muestras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitoreoContinuo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MonitoreoContinuo_FormClosed);
            this.Load += new System.EventHandler(this.MonitoreoContinuo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartMuestras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconoAtencion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDetenido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCorriendo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelHorno;
        private System.Windows.Forms.Label labelTituloGrafica;
        private System.Windows.Forms.Label labelTituloLista;
        private System.Windows.Forms.Label labelMaqTitulo;
        private System.Windows.Forms.Label labelFechaHora;
        private System.Windows.Forms.Button buttonImprimirInforme;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer TemporizadorHora;
        private System.Windows.Forms.Timer timerMuestreo;
        public System.Windows.Forms.Label labelCiclo;
        public System.Windows.Forms.ListBox listBoxMuestrasTemp;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartMuestras;
        public System.Windows.Forms.ListBox listBoxMuestrasPress;
        public System.Windows.Forms.PictureBox pictureDetenido;
        private System.Windows.Forms.Label labelReporte;
        private System.Windows.Forms.Label labelConfiguración;
        private System.Windows.Forms.PictureBox IconoAtencion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMaquina;
        public System.Windows.Forms.PictureBox pictureCorriendo;
        private System.Windows.Forms.Label labelPromedio;
        private System.Windows.Forms.Label labelPro;
        private static System.IO.Ports.SerialPort serialPortMuestras;
        private static System.IO.Ports.SerialPort serialPortAmbiente;
        public static System.Windows.Forms.ListBox listBoxAmbiente;
    }
}