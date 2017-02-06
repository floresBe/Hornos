using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio;

namespace BDMuestras
{
    public partial class CapturadeDatos : Form
    {
        string fecha;
        int noCiclo;
        string horno;
        string parte;
        int rebraze;
        int entrantes;
        int malas;

        cParteCiclo parteCiclo = new cParteCiclo();
        cCiclo ciclo = new cCiclo();
        private DialogResult respuesta;

        public CapturadeDatos()
        {
            InitializeComponent();
        }

        private void CapturadeDatos_Load(object sender, EventArgs e)
        {
            if (Program.sesion == 1)
            {
                fecha = Program.fechaAuxiliar;
                noCiclo = Program.NcicloAuxiliar;
                horno = Program.PkCicloAuxiliar;
            }
            else if (Program.sesion == 2)
            {
                fecha = Program.fechaAuxiliar;
                noCiclo = Program.NcicloAuxiliar;
                horno = Program.PkCicloAuxiliar;
                string informacionCiclo = parteCiclo.ObtenerTodoslosDatos(horno, noCiclo);
                if (informacionCiclo != null)
                {
                    string[] infoCiclo = informacionCiclo.Split();
                    textBoxParte.Text = infoCiclo[0];
                    textBoxEntrantes.Text = infoCiclo[1];
                    textBoxMalas.Text = infoCiclo[3];
                    textBoxRebraze.Text = infoCiclo[2];
                }
            }

            FechaLabel.Text = fecha;
            CicloLabel.Text = "Ciclo: " + horno + noCiclo;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxParte.Text != string.Empty)
                    parte = textBoxParte.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Dato no valido: " + textBoxParte.Text);
                textBoxEntrantes.Text = string.Empty;
                return;
            }
            try
            {
                entrantes = Convert.ToInt32(textBoxEntrantes.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Dato no valido: " + textBoxEntrantes.Text);
                textBoxEntrantes.Text = string.Empty;
                return;
            }
            try
            {
                malas = Convert.ToInt32(textBoxMalas.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Dato no valido: " + textBoxMalas.Text);
                textBoxMalas.Text = string.Empty;
                return;
            }
            try
            {
                rebraze = Convert.ToInt32(textBoxRebraze.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Dato no valido: " + textBoxRebraze.Text);
                textBoxRebraze.Text = string.Empty;
                return;
            }

            respuesta = MessageBox.Show("Seguro que desea actualizar el ciclo?", "Actualizar Ciclo", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                parteCiclo.ActualizarCiclo(horno, noCiclo, parte, entrantes, malas, rebraze);

                respuesta = MessageBox.Show("Desea Agregar mas Piezas al Ciclo?", "Agregar Pieza", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    textBoxEntrantes.Text = string.Empty;
                    textBoxParte.Text = string.Empty;
                    textBoxMalas.Text = string.Empty;
                    textBoxRebraze.Text = string.Empty;
                    textBoxParte.Focus();
                }
                else
                {
                    this.Close();
                }
            }
            else if (Program.sesion != 2)
            {
                this.Close();
                Program.VentanaInformesIncompletos = new InformesIncompletos();
                Program.VentanaInformesIncompletos.Show();
            }
            else
            {
                this.Close();
            }

        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Program.sesion != 2)
            {
                Program.VentanaInformesIncompletos = new InformesIncompletos();
                Program.VentanaInformesIncompletos.Show();
            }
        }
    }
}
