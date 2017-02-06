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
    public partial class ConfigurarMonitoreo : Form
    {
        List<string> sensores = new List<string>();
        cSensor sensor = new cSensor();
        bool todos = false;

        public ConfigurarMonitoreo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeleccionSensor_Load(object sender, EventArgs e)
        {//Se llena lista con los nombres
            sensores = sensor.ObtenerTodos();
            foreach (var item in sensores)
            {
                if (item != "TempAmbiente" && item != "HumAmbiente")
                    ListBoxSensores.Items.Add(item);
            }
            sensores = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGuardarCambios_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (todos)
            {
                for (int sensor = 0; sensor < ListBoxSensores.Items.Count; sensor++)
                {
                    ListBoxSensores.SetItemChecked(sensor, false);
                }
                todos = false;
            }
            else
            {
                for (int sensor = 0; sensor < ListBoxSensores.Items.Count; sensor++)
                {
                    ListBoxSensores.SetItemChecked(sensor, true);
                }
                todos = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelar_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            int items = 0;
            foreach (string snsr in ListBoxSensores.Items)
            {
                items++;
                sensor.CambiarEstado(items, 0);
            }
            foreach (var item in ListBoxSensores.CheckedItems)
            {
                string nombre = item.ToString();
                int pk = sensor.ObtenerPK(nombre);
                sensor.CambiarEstado(pk, 1);
            }
            if (radioButton1.Checked == true)
            {
                Program.tiempoMuestreo = 1;
            }
            else if (radioButton2.Checked == true)
            {
                Program.tiempoMuestreo = 3;
            }
            else
            {
                Program.tiempoMuestreo = 5;
            }
            Program.mismociclo = true;
            Program.sesion = 0;
            Program.VentanaInicio.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.sesion = 0;
            Program.VentanaInicio.Show();
            this.Close();
        }
    }
}

