using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDMuestras
{
    public partial class Atencion : Form
    {
        public Atencion()
        {
            InitializeComponent();
        }
        private void Atencion_Load(object sender, EventArgs e)
        {

        }
        private void buttonAhora_Click(object sender, EventArgs e)
        {
            Program.VentanaInformesIncompletos = new InformesIncompletos();
            Program.VentanaInformesIncompletos.Show();
            this.Close();
        }

        private void buttonRecordar_Click(object sender, EventArgs e)
        {
            Program.ciclosVacios = false;
            this.Close();
        }


    }
}
