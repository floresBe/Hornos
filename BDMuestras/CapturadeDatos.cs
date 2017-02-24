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
using Hornos;

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
        cParteCiclo parteCiclo = null;
        private DialogResult respuesta;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="horno"></param>
        /// <param name="noCiclo"></param>
        public CapturadeDatos(string fecha, string horno, int noCiclo, string noParte)
        {
            InitializeComponent();
            this.fecha = fecha;
            this.horno = horno;
            this.noCiclo = noCiclo;
            parte = noParte;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CapturadeDatos_Load(object sender, EventArgs e)
        {

            FechaLabel.Text = fecha;
            CicloLabel.Text = "Ciclo: " + horno + noCiclo;
            textBoxParte.Text = parte;
            textBoxParte.Enabled = false;
           
                mostrarDatos();
                      
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxParte.Text != string.Empty)
                    parte = textBoxParte.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dato no valido: " + textBoxParte.Text);
                textBoxParte.Text = string.Empty;
                textBoxParte.Focus();
                return;
            }
            try
            {
                entrantes = Convert.ToInt32(textBoxEntrantes.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dato no valido: " + textBoxEntrantes.Text);
                textBoxEntrantes.Text = string.Empty;
                textBoxEntrantes.Focus();
                return;
            }
            try
            {
                malas = Convert.ToInt32(textBoxMalas.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dato no valido: " + textBoxMalas.Text);
                textBoxMalas.Text = string.Empty;
                textBoxMalas.Focus();
                return;
            }
            try
            {
                rebraze = Convert.ToInt32(textBoxRebraze.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dato no valido: " + textBoxRebraze.Text);
                textBoxRebraze.Text = string.Empty;
                textBoxRebraze.Focus();
                return;
            }
            respuesta = MessageBox.Show("Seguro que desea actualizar el ciclo?", "Actualizar Ciclo", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                parteCiclo = new cParteCiclo();
                parteCiclo.actualizar(horno, noCiclo, parte, entrantes, malas, rebraze);
                parteCiclo = null;
                respuesta = MessageBox.Show("Desea Agregar más números de parte al Ciclo?", "Agregar Pieza", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    textBoxParte.Enabled = true;
                    textBoxParte.Text = string.Empty;
                    textBoxEntrantes.Text = string.Empty;
                    textBoxParte.Text = string.Empty;
                    textBoxMalas.Text = string.Empty;
                    textBoxRebraze.Text = string.Empty;
                    textBoxParte.Focus();
                }
                else
                {
                    this.Close();
                    NumeroParte parte = new NumeroParte(2,horno,noCiclo);
                    parte.Show();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mostrarDatos()
        {
            parteCiclo = new cParteCiclo();
            string informacionCiclo = parteCiclo.obtenerDatos(horno, noCiclo, parte);
            if (informacionCiclo != null)
            {
                string[] infoCiclo = informacionCiclo.Split();
                textBoxEntrantes.Text = infoCiclo[0];
                textBoxMalas.Text = infoCiclo[1];
                textBoxRebraze.Text = infoCiclo[2];
            }
            parteCiclo = null;
        }
    }
}
