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
using BDMuestras.Reportes;

namespace BDMuestras
{
    public partial class Imprimir : Form
    {
        cCiclo ciclo = new cCiclo();//Se utiliza para la comunicacion con la BD
        public static string fecha; //Guarda la fecha seleccionada
        public static int noCiclo;
        public static string horno;
        List<String> muestras = null;
      // List<string> Muestras;
        bool todos = false;
        string[] vFecha;

        public Imprimir()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento cargar ventana
        /// </summary>
        private void Imprimir_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Evento de seleccionar fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            vFecha = dateTimePicker.Value.ToString().Split();
            fecha = vFecha[0];
            labelFecha.Text = fecha;
            comboBoxCiclos.Items.Clear();
            checkedListBoxMuestras.Items.Clear();
            List<string> ciclos = ciclo.obtenerPorHornoyFecha(Program.horno, fecha);
            if (ciclos.Count == 0 || ciclos == null)
            {
                MessageBox.Show("No existen cicos en la fecha seleccionada");
                comboBoxCiclos.Enabled = false;
                return;
            }
            else
            {
                comboBoxCiclos.Enabled = true;
                foreach (var item in ciclos)
                {
                    comboBoxCiclos.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// Evento de clic en el boton cancelar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Evento de seleccionar ciclo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCiclos_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxTodos.Checked = false;
            MostrarCiclos();
        }
        /// <summary>
        /// Evento que muestra los ciclos en la lista
        /// </summary>
        private void MostrarCiclos()
        {
            checkedListBoxMuestras.Items.Clear();
            cMuestra muestra = new cMuestra();
            try
            {
                string[] vCiclo = comboBoxCiclos.SelectedItem.ToString().Split();
                muestras = muestra.obtenerMuestrasdeCiclo(vCiclo[0], Convert.ToInt32(vCiclo[1]));
                foreach (var item in muestras)
                {
                    checkedListBoxMuestras.Items.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No selecciono ciclo ");
                return;
            }
        }
        /// <summary>
        /// Seleccionar todas o ninguna muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxTodos_CheckedChanged(object sender, EventArgs e)
        {

            if (todos)
            {
                for (int muestra = 0; muestra < checkedListBoxMuestras.Items.Count; muestra++)
                {
                    checkedListBoxMuestras.SetItemChecked(muestra, false);
                }
                todos = false;
            }
            else
            {
                for (int muestra = 0; muestra < checkedListBoxMuestras.Items.Count; muestra++)
                {
                    checkedListBoxMuestras.SetItemChecked(muestra, true);
                }
                todos = true;
            }
        }
        /// <summary>
        /// Boton editar ciclo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string[] infoCiclo = comboBoxCiclos.Text.ToString().Split();
                fecha = labelFecha.Text;
                noCiclo = Convert.ToInt32(infoCiclo[1]);
                horno = infoCiclo[0];

                Program.fechaAuxiliar = fecha;
                Program.NcicloAuxiliar = noCiclo;
                Program.PkCicloAuxiliar = horno;

                Program.sesion = 2;
                Program.VentanaInicio.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("No selecciono Ciclo.");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> muestrasList = new List<string>();
            foreach (string item in checkedListBoxMuestras.CheckedItems)
            {
                muestrasList.Add(item);
            }
            string[] infoCiclo = comboBoxCiclos.SelectedItem.ToString().Split('|');
            EntidadReporteMuestra entidad = new EntidadReporteMuestra();
            entidad.Fecha = labelFecha.Text;
            entidad.NombreCiclo = infoCiclo[0];
            entidad.Muestras = muestrasList;
            ReporteMuestras visorReporte = new ReporteMuestras(entidad);
            visorReporte.Show();
            muestrasList = null;
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBoxMuestras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
