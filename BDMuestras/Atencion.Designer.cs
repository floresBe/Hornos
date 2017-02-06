namespace BDMuestras
{
    partial class Atencion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Atencion));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonRecordar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAhora = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(216, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 53);
            this.label2.TabIndex = 9;
            this.label2.Text = "Existen datos incompletos en la base de datos. ¿Desea capturarlos ahora?   ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // buttonRecordar
            // 
            this.buttonRecordar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRecordar.Location = new System.Drawing.Point(344, 139);
            this.buttonRecordar.Name = "buttonRecordar";
            this.buttonRecordar.Size = new System.Drawing.Size(255, 34);
            this.buttonRecordar.TabIndex = 7;
            this.buttonRecordar.Text = "Recordarmelo más tarde";
            this.buttonRecordar.UseVisualStyleBackColor = true;
            this.buttonRecordar.Click += new System.EventHandler(this.buttonRecordar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Atención.";
            // 
            // buttonAhora
            // 
            this.buttonAhora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAhora.Location = new System.Drawing.Point(220, 139);
            this.buttonAhora.Name = "buttonAhora";
            this.buttonAhora.Size = new System.Drawing.Size(118, 34);
            this.buttonAhora.TabIndex = 5;
            this.buttonAhora.Text = "Ahora";
            this.buttonAhora.UseVisualStyleBackColor = true;
            this.buttonAhora.Click += new System.EventHandler(this.buttonAhora_Click);
            // 
            // Atencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 191);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonRecordar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAhora);
            this.Name = "Atencion";
            this.Text = "Alerta";
            this.Load += new System.EventHandler(this.Atencion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonRecordar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAhora;
    }
}