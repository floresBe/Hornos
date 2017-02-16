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
        int ciclo;

        public NumeroParte(int conf,string hor, int cic)
        {
            InitializeComponent();
            horno = hor;
            ciclo = cic;
            configuracion = conf;
            configurar(conf);

        }

        private void NumeroParte_Load(object sender, EventArgs e)
        {

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
            }else
            {
                MessageBox.Show("El ciclo no contiene números de parte guardados.");
                this.Close();
            }
        }
    }
}
