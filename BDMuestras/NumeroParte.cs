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
        int congifuracion;

        public NumeroParte(int conf)
        {
            InitializeComponent();
            configurar(conf);
            congifuracion = conf;           
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
                    labelTitulo.Text = "Seleccionar No. de Parte.";
                    comboBox1.Visible = true;
                    button1.Text = "Seleccionar";
                    button2.Text = "Cancelar";
                    break;
                case 3: //Imprimir numero de parte de cico
                    labelTitulo.Text = "Seleccionar No. de Parte.";
                    comboBox1.Visible = true;
                    button1.Text = "Seleccionar";
                    button2.Text = "Cancelar";
                    break;
                default:
                    break;
            }
        }


    }
}
