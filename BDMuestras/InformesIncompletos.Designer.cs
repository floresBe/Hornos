namespace BDMuestras
{
    partial class InformesIncompletos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformesIncompletos));
            this.buttonEditarCiclo = new System.Windows.Forms.Button();
            this.listBoxCiclosdelDia = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEditar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelFecha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonEditarCiclo
            // 
            this.buttonEditarCiclo.BackColor = System.Drawing.Color.DarkGray;
            this.buttonEditarCiclo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEditarCiclo.BackgroundImage")));
            this.buttonEditarCiclo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEditarCiclo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEditarCiclo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonEditarCiclo.Location = new System.Drawing.Point(294, 69);
            this.buttonEditarCiclo.Name = "buttonEditarCiclo";
            this.buttonEditarCiclo.Size = new System.Drawing.Size(58, 50);
            this.buttonEditarCiclo.TabIndex = 10;
            this.buttonEditarCiclo.UseVisualStyleBackColor = false;
            this.buttonEditarCiclo.Click += new System.EventHandler(this.buttonEditarCiclo_Click);
            // 
            // listBoxCiclosdelDia
            // 
            this.listBoxCiclosdelDia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxCiclosdelDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxCiclosdelDia.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listBoxCiclosdelDia.FormattingEnabled = true;
            this.listBoxCiclosdelDia.ItemHeight = 25;
            this.listBoxCiclosdelDia.Items.AddRange(new object[] {
            "0|0"});
            this.listBoxCiclosdelDia.Location = new System.Drawing.Point(109, 100);
            this.listBoxCiclosdelDia.Name = "listBoxCiclosdelDia";
            this.listBoxCiclosdelDia.Size = new System.Drawing.Size(120, 100);
            this.listBoxCiclosdelDia.TabIndex = 8;
            this.listBoxCiclosdelDia.SelectedIndexChanged += new System.EventHandler(this.listBoxCiclosdelDia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "Seleccionar Ciclo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEditar
            // 
            this.labelEditar.AutoSize = true;
            this.labelEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditar.ForeColor = System.Drawing.Color.White;
            this.labelEditar.Location = new System.Drawing.Point(285, 122);
            this.labelEditar.Name = "labelEditar";
            this.labelEditar.Size = new System.Drawing.Size(76, 16);
            this.labelEditar.TabIndex = 12;
            this.labelEditar.Text = "Editar Ciclo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(292, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Cancelar";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.Red;
            this.buttonCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.BackgroundImage")));
            this.buttonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCancelar.Location = new System.Drawing.Point(294, 150);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(58, 50);
            this.buttonCancelar.TabIndex = 39;
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 25);
            this.label4.TabIndex = 41;
            this.label4.Text = "Fecha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 25);
            this.label5.TabIndex = 42;
            this.label5.Text = "Ciclo:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(230, 69);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(18, 20);
            this.dateTimePicker.TabIndex = 43;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.ForeColor = System.Drawing.Color.White;
            this.labelFecha.Location = new System.Drawing.Point(104, 68);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(120, 25);
            this.labelFecha.TabIndex = 44;
            this.labelFecha.Text = "00/00/0000";
            this.labelFecha.Click += new System.EventHandler(this.labelFecha_Click);
            // 
            // InformesIncompletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(364, 244);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.labelEditar);
            this.Controls.Add(this.buttonEditarCiclo);
            this.Controls.Add(this.listBoxCiclosdelDia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = "InformesIncompletos";
            this.Text = "Actualización de Datos";
            this.Load += new System.EventHandler(this.InformesIncompletos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonEditarCiclo;
        private System.Windows.Forms.ListBox listBoxCiclosdelDia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEditar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label labelFecha;
    }
}