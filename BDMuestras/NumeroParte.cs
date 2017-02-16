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
        public NumeroParte(int conf)
        {
            InitializeComponent();
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
                    break;
                case 2: //Editar numero de parte de ciclo
                    break;
                case 3: //Imprimir numero de parte de cico
                    break;
                default:
                    break;
            }
        }


    }
}
