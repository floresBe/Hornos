using BDMuestras;
using Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hornos
{
    public partial class NumeroParte : Form
    {
        int configuracion;
        string horno = string.Empty;
        string numeroParte;
        int ciclo;
        int segundos = 0;
        cParteCiclo parteCiclo = null;
        public NumeroParte(int conf, string hor, int cic)
        {
            InitializeComponent();
            horno = hor;
            ciclo = cic;
            configuracion = conf;
            configurar();

        }
        private void configurar()
        {
            if (configuracion == 1)
            {
                labelTitulo.Text = "Ingresar No. de Parte.";
                comboBox1.Visible = false;
                button1.Text = "Agregar";
                button2.Text = "Más tarde";
                timer1.Start();
            }
            else {
                configuracionII();

            }
                        
        }
        private void configuracionII()
        {
            cParteCiclo cicloParte = new cParteCiclo();
            List<string> partes = new List<string>();
            labelTitulo.Text = "Seleccionar No. de Parte.";
            comboBox1.Visible = true;
            button1.Text = "Seleccionar";
            button2.Text = "Cancelar";
            if (configuracion == 2)
            {//se cumple cuando se van a guardar datos de un ciclo
                partes = cicloParte.obtenerNumerosParteVaciosPorCiclo(horno, ciclo);
            }
            else if (configuracion == 3 || configuracion == 4)
            {// se cumple cuando se quieren editar datos de un ciclo
                // o cuando se quiere imprimir un reporte 
                partes = cicloParte.obtenerNumerosPartePorCiclo(horno, ciclo);
            }


            if (partes.Count > 0)
            {
                foreach (string noParte in partes)
                {
                    comboBox1.Items.Add(noParte);
                }
            }
            else
            {
                MessageBox.Show("El ciclo no contiene números de parte guardados.");
                configuracion = 1;
                configurar();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            parteCiclo = new cParteCiclo();
            if (configuracion == 1)
            {
                if (textBox1.Text == string.Empty || textBox1.Text == null)
                {
                    MessageBox.Show("Ingrese número de parte.");
                    textBox1.Focus();
                    return;
                }
                else
                {
                    numeroParte = textBox1.Text;
                    if (MessageBox.Show("Seguro que desea agregar el número de parte: " + numeroParte + " a la base de datos?", "Agregar número de parte", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (parteCiclo.insertar(ciclo, horno, numeroParte) > 0)
                        {
                            MessageBox.Show("Número de parte agregada con exito.");
                            if (MessageBox.Show("Desea agregar otro número de parte al ciclo?", "Agregar otro número", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                segundos = 0;
                                textBox1.Text = string.Empty;
                                textBox1.Focus();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        textBox1.Focus();
                    }
                }
            }
            else
            {
                if (comboBox1.SelectedItem != null)
                {
                    numeroParte = comboBox1.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Seleccione número de parte.");
                    return;
                }
                if (configuracion == 2 || configuracion == 3) //Proigram.sesion = 2
                {
                    CapturadeDatos capturarDatos =
                        new CapturadeDatos(Program.fechaAuxiliar, horno, ciclo, numeroParte);
                    capturarDatos.Show();
                    capturarDatos = null;
                    this.Close();
                }
                if (configuracion == 4)
                {
                    //Imprimir numero de parte
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (segundos == 60)
            {
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (configuracion == 2)
            {
                InformesIncompletos ventana = new InformesIncompletos();
                ventana.Show();
            }
            this.Close();
        }
    }
}
