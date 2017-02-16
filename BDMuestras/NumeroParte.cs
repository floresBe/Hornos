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
            configurar(conf);

        }

        private void configurar(int conf)
        {
            switch (conf)
            {
                case 1:  //Guardar numero de parte en ciclo
                    labelTitulo.Text = "Ingresar No. de Parte.";
                    comboBox1.Visible = false;
                    button1.Text = "Agregar";
                    button2.Text = "Más tarde";
                    timer1.Start();
                    break;
                case 2: //Editar numero de parte de ciclo
                    configuracionII();
                    break;
                case 3: //Imprimir numero de parte de cico
                    configuracionII();
                    break;
                default:
                    break;
            }
        }
        private void configuracionII()
        {
            cParteCiclo cicloParte = new cParteCiclo();
            List<string> partes;
            labelTitulo.Text = "Seleccionar No. de Parte.";
            comboBox1.Visible = true;
            button1.Text = "Seleccionar";
            button2.Text = "Cancelar";
            partes = cicloParte.obtenerNumerosPartePorCiclo(horno, ciclo);
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
                this.Close();
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
                }else
                {
                    numeroParte = textBox1.Text;
                    if (MessageBox.Show("Seguro que desea agregar el número de parte: " + numeroParte +" a la base de datos?","Agregar número de parte",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if(parteCiclo.insertar(ciclo,horno,numeroParte) > 0)
                        {
                            MessageBox.Show("Número de parte agregada con exito.");
                            if (MessageBox.Show("Desea agregar otro número de parte al ciclo?","Agregar otro número",MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                this.Refresh();
                            }else
                            {
                                this.Close();
                            }
                        }
                    }else
                    {
                        textBox1.Focus();
                    }
                }                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
            if(segundos == 90)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
